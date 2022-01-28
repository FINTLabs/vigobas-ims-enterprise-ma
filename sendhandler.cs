// VIGOBAS Identity Management System 
//  Copyright (C) 2021  Vigo IKS 
//  
//  Documentation - visit https://vigobas.vigoiks.no/ 
//  
//  This program is free software: you can redistribute it and/or modify 
//  it under the terms of the GNU Affero General Public License as 
//  published by the Free Software Foundation, either version 3 of the 
//  License, or (at your option) any later version. 
//  
//  This program is distributed in the hope that it will be useful, 
//  but WITHOUT ANY WARRANTY, without even the implied warranty of 
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the 
//  GNU Affero General Public License for more details. 
//  
//  You should have received a copy of the GNU Affero General Public License 
//  along with this program.  If not, see https://www.gnu.org/licenses/.

using Microsoft.MetadirectoryServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Vigo.Bas.ManagementAgent.Log;
using Renci.SshNet;
using System.Security;
using System.Runtime.InteropServices;

namespace FimSync_Ezma
{
    class sendhandler
    {
        public NetworkCredential GetNetworkCredential(KeyedCollection<string, ConfigParameter> configParameters)
        {
            //Collect username and password, domain and return to connect to WS
            string username = null;
            if (configParameters["Domain"].Value != null && configParameters["Domain"].Value != "")
            {
                username = configParameters["Domain"].Value + "\\" + configParameters["Username"].Value;
            }
            else
            {
                username = configParameters["Username"].Value;
            }
            return new NetworkCredential(username, configParameters["Password"].SecureValue);
        }

        public static string ConvertToUnsecureString(SecureString securePassword)
        {
            if (securePassword == null)
                throw new ArgumentNullException("securePassword");

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = System.Runtime.InteropServices.Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

        public Stream RESTGetGenericRequest(string uri, NetworkCredential credentials, string method, MemoryStream body, int timeoutSec)
        {
            try
            {
                // Log request
                Logger.Log.Info("Request: " + uri);
                Logger.Log.Info("Request method: " + method);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = method;
                request.Timeout = timeoutSec * 1000;

                //Send POST body
                if (method.ToUpper() == "POST" && body != null)
                {
                    //Logger.Log.Info("Parsing body: " + body);
                    byte[] bytes = body.ToArray();
                    request.ContentLength = bytes.Length;
                    request.ContentType = "text/xml; encoding='utf-8'"; ;

                    Stream requestStream = request.GetRequestStream();

                    if (bytes.Length / 1024 == 0)
                    {
                        Logger.Log.Info("Posting " + bytes.Length + " bytes of data");
                    }
                    else if (bytes.Length / (1024 * 1024) == 0)
                    {
                        Logger.Log.Info("Posting " + bytes.Length / 1024f + " kB of data");
                    }

                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Close();
                }

                if (credentials != null)
                {
                    //Logger.Log.Info("Username: " + credentials.UserName);
                    //Logger.Log.Info("Domain: " + credentials.Domain);

                    request.Credentials = credentials;
                }
                // Even If certificates not is valid, it moves on
                System.Net.Security.RemoteCertificateValidationCallback BadCertificates = new System.Net.Security.RemoteCertificateValidationCallback(delegate { return true; });
                System.Net.ServicePointManager.ServerCertificateValidationCallback = BadCertificates;

                // Get WebResponse, create Stream and read the stream with a StreamReader

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Logger.Log.Info("HTTP Statuscode: " + response.StatusCode);
                Logger.Log.Info("HTTP StatusDescription: " + response.StatusDescription);

                Stream responseStream = response.GetResponseStream();

                return responseStream;
            }
            catch (Exception e)
            {

                Logger.Log.Error("Message: " + e.Message);
                Logger.Log.Error("StackTrace: " + e.StackTrace);
                throw new Exception("URL: " + uri + " Message: " + e.Message + " StackTrace: " + e.StackTrace);
            }
        }


        public Stream RESTFronterRequest(string uri, string method, MemoryStream body, int timeoutSec)
        {
            try
            {
                Logger.Log.Info("Request: " + uri);
                Logger.Log.Info("Request method: " + method);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = method;
                request.Timeout = timeoutSec * 1000;
                //Send POST body
                if (method.ToUpper() == "POST" && body != null)
                {
                    //Fronter needs the POST to Start with "POSTXML\n" and then the XML file. 
                    //Adding the Imput Memorystrem to the stream PostData string
                    string PostData = "POSTXML\n";
                    PostData += Encoding.UTF8.GetString(body.ToArray());

                    //Converting to ByteArray
                    byte[] postBytes = Encoding.UTF8.GetBytes(PostData);

                    //Header stuff
                    request.Headers.Add("Content-Encoding", Encoding.UTF8.WebName);
                    request.Headers.Add("Content-Transfer-Encoding", "binary");
                    request.ContentLength = postBytes.Length;
                    request.ContentType = "text/xml";
                    //request.ContentType = "text/xml; encoding='utf-8'";

                    Stream requestStream = request.GetRequestStream();

                    //Logging Post data size
                    if (PostData.Length / 1024 == 0)
                    {
                        Logger.Log.Info("Posting " + postBytes.Length + " bytes of data");
                    }
                    else if (postBytes.Length / (1024 * 1024) == 0)
                    {
                        Logger.Log.Info("Posting " + postBytes.Length / 1024f + " kB of data");
                    }
                    
                    //Posting data to WS
                    requestStream.Write(postBytes, 0, postBytes.Length);
                    requestStream.Close();
                }

                // Even If certificates not is valid, it moves on
                System.Net.Security.RemoteCertificateValidationCallback BadCertificates = new System.Net.Security.RemoteCertificateValidationCallback(delegate { return true; });
                System.Net.ServicePointManager.ServerCertificateValidationCallback = BadCertificates;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Logger.Log.Info("HTTP Statuscode: " + response.StatusCode);
                Logger.Log.Info("HTTP StatusDescription: " + response.StatusDescription);
                Stream responseStream = response.GetResponseStream();

                return responseStream;
            }

            catch (Exception e)
            {
                Logger.Log.Error("Message: " + e.Message);
                Logger.Log.Error("StackTrace: " + e.StackTrace);
                throw new Exception("URL: " + uri + " Message: " + e.Message + " StackTrace: " + e.StackTrace);
            }
        }

        public void sftpItsLearningUpload(string uri, string filename, int port, string username, string password, MemoryStream xmlstream)
        {
            //set pointer to start of file ,if not it writes 0 bytes.
            xmlstream.Position = 0;

            //Splits URL into it's invidudual components.
            var url = new Uri(uri);

            try
            {
                SftpClient sftpClient = new SftpClient($"{url.DnsSafeHost}", url.Port, username, password);
                sftpClient.Connect();

                sftpClient.BufferSize = 1024;                
                sftpClient.UploadFile(xmlstream, $"{url.AbsolutePath}/{filename}");

                sftpClient.Dispose();
            }
            catch (Exception e)
            {
                Logger.Log.Error("Message: " + e.Message);
                Logger.Log.Error("StackTrace: " + e.StackTrace);
                throw new Exception("URL: " + uri + " Message: " + e.Message + " StackTrace: " + e.StackTrace);                
            }

        }

        public void writeItsLearningXMLToFile (string filePath, string xml)
        {          
            string filename = "IMS-EnterpriseData.xml";

            string fullPath = filePath + "\\" + filename;

            var encoding = new UTF8Encoding(false);
            System.IO.File.WriteAllText(fullPath, xml, encoding);
        }

        public MemoryStream sftpItsLearningDownload(string uri,string username, string password)
        {
            //Splits URL into it's invidudual components.
            var url = new Uri(uri);

            //IT's Learning wants single file thats overwritten everytime. 
            //string filename = $"xmldata{DateTime.Now.ToString("yyyy-dd-MMM-HHmm")}.xml";
            string filename = "IMS-EnterpriseData.xml";
            var xmlstream = new MemoryStream();
            try
            {
                SftpClient sftpClient = new SftpClient($"{url.DnsSafeHost}", url.Port, username, password);
                sftpClient.Connect();

                sftpClient.BufferSize = 1024;
                sftpClient.DownloadFile($"{url.AbsolutePath}/{filename}",xmlstream);

                sftpClient.Dispose();

                xmlstream.Position = 0;
                return xmlstream;
            }
            catch (Exception e)
            {
                Logger.Log.Error("Message: " + e.Message);
                Logger.Log.Error("StackTrace: " + e.StackTrace);
                throw new Exception("URL: " + uri + " Message: " + e.Message + " StackTrace: " + e.StackTrace);
            }

            

        }
        public MemoryStream readItsLearningXMLFromFile(string filePath)
        {
            string fullPath = filePath + "\\IMS-EnterpriseData.xml";

            var xmlstream = new MemoryStream();
            try
            {
                using (FileStream fileStream = File.OpenRead(fullPath))
                {
                    xmlstream.SetLength(fileStream.Length);
                    fileStream.Read(xmlstream.GetBuffer(), 0, (int)fileStream.Length);
                }
                xmlstream.Position = 0;
                return xmlstream;
            }
            catch (Exception e)
            {
                Logger.Log.Error("Message: " + e.Message);
                Logger.Log.Error("StackTrace: " + e.StackTrace);
                throw new Exception("Unable to read from file: " + fullPath + "Message: " + e.Message + " StackTrace: " + e.StackTrace);
            }



        }


    }

}

