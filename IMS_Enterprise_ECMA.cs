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

using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Collections.Specialized;
using Microsoft.MetadirectoryServices;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Net;
using System.Xml.Serialization;
using System.Linq;
using Vigo.Bas.ManagementAgent.Log;
using FimSync_Ezma.xml;

namespace FimSync_Ezma
{
    public class EzmaExtension :
    IMAExtensible2CallExport,
    IMAExtensible2CallImport,
    //IMAExtensible2FileImport,
    //IMAExtensible2FileExport,
    //IMAExtensible2GetHierarchy,
    IMAExtensible2GetSchema,
    IMAExtensible2GetCapabilities,
    IMAExtensible2GetParameters
    //IMAExtensible2GetPartitions



    #region Page Size
    {

        //
        // Constructor
        //
        public EzmaExtension()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private int importMaxPageSize = 50;
        private int importDefaultPageSize = 40;
        private int exportMaxPageSize = 20;
        private int exportDefaultPageSize = 15;

        List<string> allreadyimported = new List<string>();

        List<ImportListItem> ImportedObjectsList;
        int GetImportEntriesIndex, GetImportEntriesPageSize;

        //public string myEmpID;

        public int ImportMaxPageSize
        {
            get { return importMaxPageSize; }
            set { importMaxPageSize = value; }
        }

        public int ImportDefaultPageSize
        {
            get { return importDefaultPageSize; }
            set { importDefaultPageSize = value; }
        }

        public int ExportDefaultPageSize
        {
            get { return exportDefaultPageSize; }
            set { exportDefaultPageSize = value; }
        }

        public int ExportMaxPageSize
        {
            get { return exportMaxPageSize; }
            set { exportMaxPageSize = value; }
        }
        #endregion

        public MACapabilities Capabilities
        {
            get
            {
                MACapabilities capabilities = new MACapabilities();
                
                //Thomas L: Har trøbbel med å få debugger til å koble til rett slik at breakpoints treffes. Starte debugger fra koden funker.
                //System.Diagnostics.Debugger.Launch();

                capabilities.ConcurrentOperation = true;
                capabilities.ObjectRename = false;
                capabilities.DeleteAddAsReplace = false;
                capabilities.DeltaImport = false;
                capabilities.DistinguishedNameStyle = MADistinguishedNameStyle.None;
                capabilities.ExportType = MAExportType.ObjectReplace;
                capabilities.FullExport = true;
                capabilities.NoReferenceValuesInFirstExport = true;
                capabilities.Normalizations = MANormalizations.None;
                capabilities.ObjectConfirmation = MAObjectConfirmation.Normal;

                return capabilities;
            }
        }

        public IList<ConfigParameterDefinition> GetConfigParameters(KeyedCollection<string, ConfigParameter> configParameters, ConfigParameterPage page)
        {
            List<ConfigParameterDefinition> configParametersDefinitions = new List<ConfigParameterDefinition>();

            switch (page)
            {
                case ConfigParameterPage.Connectivity:
                    configParametersDefinitions.Add(ConfigParameterDefinition.CreateDropDownParameter("Type", new string[] { "Fronter", "ITs Learning", "Generisk" }, false, "Generisk"));
                    configParametersDefinitions.Add(ConfigParameterDefinition.CreateStringParameter("Import URL", "", ""));
                    configParametersDefinitions.Add(ConfigParameterDefinition.CreateDividerParameter());
                    configParametersDefinitions.Add(ConfigParameterDefinition.CreateStringParameter("Export URL","", ""));
                    // Username and Password
                    configParametersDefinitions.Add(ConfigParameterDefinition.CreateStringParameter("Username", ""));
                    configParametersDefinitions.Add(ConfigParameterDefinition.CreateEncryptedStringParameter("Password", ""));
                    configParametersDefinitions.Add(ConfigParameterDefinition.CreateStringParameter("Xml File Name", "", "IMS-EnterpriseData.xml"));
                    configParametersDefinitions.Add(ConfigParameterDefinition.CreateStringParameter("Domain", ""));
                    break;

                case ConfigParameterPage.Capabilities:
                case ConfigParameterPage.Global:
                case ConfigParameterPage.Schema:
                    break;
            }

            return configParametersDefinitions;
        }

        public ParameterValidationResult ValidateConfigParameters(KeyedCollection<string, ConfigParameter> configParameters, ConfigParameterPage page)
        {
            //System.Diagnostics.Debugger.Launch();
            ParameterValidationResult validateResults = new ParameterValidationResult();

            switch (page)
            {
                case ConfigParameterPage.Connectivity:
                    //try
                    //{
                    //    sendhandler testConnection = new sendhandler();
                    //    Stream IMS_XML = testConnection.RESTGetGenericRequest(configParameters["WebService GET URL"].Value, testConnection.GetNetworkCredential(configParameters), "GET", null, 10);

                    //    XmlSerializer serializer = new XmlSerializer(typeof(enterprise));
                    //    enterprise xmlResponse = (enterprise)serializer.Deserialize(IMS_XML);
                    //}
                    //catch (Exception error)
                    //{
                    //    validateResults.Code = ParameterValidationResultCode.Failure;
                    //    validateResults.ErrorMessage = error.Message;
                    //    return validateResults;
                    //}

                    break;
                case ConfigParameterPage.Global:
                    break;
                case ConfigParameterPage.RunStep:
                    break;
                case ConfigParameterPage.Partition:
                    break;
                case ConfigParameterPage.Capabilities:
                    break;
                case ConfigParameterPage.Schema:
                    break;
                default:
                    break;
            }

            return validateResults;
        }

        public Schema GetSchema(KeyedCollection<string, ConfigParameter> configParameters)
        {
            // Create CS Schema type person
            SchemaType person = SchemaType.Create("person", true);

            // Anchor
            person.Attributes.Add(SchemaAttribute.CreateAnchorAttribute("ID", AttributeType.String));

            // Attributes
            person.Attributes.Add(SchemaAttribute.CreateSingleValuedAttribute("name_fn", AttributeType.String, AttributeOperation.ImportExport));
            person.Attributes.Add(SchemaAttribute.CreateSingleValuedAttribute("name_family", AttributeType.String, AttributeOperation.ImportExport));
            person.Attributes.Add(SchemaAttribute.CreateSingleValuedAttribute("name_given", AttributeType.String, AttributeOperation.ImportExport));
            person.Attributes.Add(SchemaAttribute.CreateSingleValuedAttribute("sourceID_ID_#0", AttributeType.String, AttributeOperation.ImportExport));
            person.Attributes.Add(SchemaAttribute.CreateSingleValuedAttribute("gender", AttributeType.String, AttributeOperation.ImportExport));
            person.Attributes.Add(SchemaAttribute.CreateSingleValuedAttribute("bday", AttributeType.String, AttributeOperation.ImportExport));
            person.Attributes.Add(SchemaAttribute.CreateSingleValuedAttribute("email", AttributeType.String, AttributeOperation.ImportExport));
            person.Attributes.Add(SchemaAttribute.CreateSingleValuedAttribute("tel_mobile", AttributeType.String, AttributeOperation.ImportExport));
            person.Attributes.Add(SchemaAttribute.CreateSingleValuedAttribute("tel_work", AttributeType.String, AttributeOperation.ImportExport));
            person.Attributes.Add(SchemaAttribute.CreateSingleValuedAttribute("adr_street", AttributeType.String, AttributeOperation.ImportExport));
            person.Attributes.Add(SchemaAttribute.CreateSingleValuedAttribute("adr_pcode", AttributeType.String, AttributeOperation.ImportExport));
            person.Attributes.Add(SchemaAttribute.CreateSingleValuedAttribute("adr_locality", AttributeType.String, AttributeOperation.ImportExport));
            person.Attributes.Add(SchemaAttribute.CreateSingleValuedAttribute("photo_extref", AttributeType.String, AttributeOperation.ImportExport));
            person.Attributes.Add(SchemaAttribute.CreateSingleValuedAttribute("systemrole", AttributeType.String, AttributeOperation.ImportExport));
            person.Attributes.Add(SchemaAttribute.CreateSingleValuedAttribute("institutionrole", AttributeType.String, AttributeOperation.ImportExport));
            person.Attributes.Add(SchemaAttribute.CreateSingleValuedAttribute("userid", AttributeType.String, AttributeOperation.ImportExport));
            person.Attributes.Add(SchemaAttribute.CreateSingleValuedAttribute("comment", AttributeType.String, AttributeOperation.ImportExport));

            // Create CS type Group
            SchemaType gruppe = SchemaType.Create("group", true);

            //Define Anchor
            gruppe.Attributes.Add(SchemaAttribute.CreateAnchorAttribute("ID", AttributeType.String));

            // Attributes
            gruppe.Attributes.Add(SchemaAttribute.CreateSingleValuedAttribute("sourceID_ID_#0", AttributeType.String, AttributeOperation.ImportExport));
            gruppe.Attributes.Add(SchemaAttribute.CreateSingleValuedAttribute("description_Short", AttributeType.String, AttributeOperation.ImportExport));
            gruppe.Attributes.Add(SchemaAttribute.CreateSingleValuedAttribute("description_Long", AttributeType.String, AttributeOperation.ImportExport));
            gruppe.Attributes.Add(SchemaAttribute.CreateSingleValuedAttribute("description_Full", AttributeType.String, AttributeOperation.ImportExport));
            gruppe.Attributes.Add(SchemaAttribute.CreateSingleValuedAttribute("grouptype", AttributeType.String, AttributeOperation.ImportExport));
            gruppe.Attributes.Add(SchemaAttribute.CreateSingleValuedAttribute("grouptypename", AttributeType.String, AttributeOperation.ImportExport));
            gruppe.Attributes.Add(SchemaAttribute.CreateSingleValuedAttribute("datasource", AttributeType.String, AttributeOperation.ImportExport));
            gruppe.Attributes.Add(SchemaAttribute.CreateMultiValuedAttribute("member_instructor", AttributeType.Reference, AttributeOperation.ImportExport));
            gruppe.Attributes.Add(SchemaAttribute.CreateMultiValuedAttribute("member_student", AttributeType.Reference, AttributeOperation.ImportExport));
            gruppe.Attributes.Add(SchemaAttribute.CreateSingleValuedAttribute("relationship", AttributeType.String, AttributeOperation.ImportExport));
            gruppe.Attributes.Add(SchemaAttribute.CreateSingleValuedAttribute("orgUnitRef", AttributeType.Reference, AttributeOperation.ImportExport));
            gruppe.Attributes.Add(SchemaAttribute.CreateSingleValuedAttribute("orgRef", AttributeType.Reference, AttributeOperation.ImportExport));

            //gruppe.Attributes.Add(SchemaAttribute.CreateSingleValuedAttribute("Navn", AttributeType.String, AttributeOperation.ImportOnly));

            // Return schema
            Schema schema = Schema.Create();
            schema.Types.Add(person);
            schema.Types.Add(gruppe);

            return schema;
        }



        public OpenImportConnectionResults OpenImportConnection(KeyedCollection<string, ConfigParameter> configParameters, Schema types, OpenImportConnectionRunStep importRunStep)
        {
            sendhandler getXML = new sendhandler();
            string transfertype = configParameters["Type"].Value;
            Stream IMS_XML;



            switch (transfertype.ToLower())
            {
                case "its learning":
                    var xmlFolder = MAUtils.MAFolder;
                    IMS_XML = getXML.readItsLearningXMLFromFile(xmlFolder);
                    break;
                case "fronter":
                    //pushXML.RESTFronterRequest(exportConfigParameters["WebService POST URL"].Value, "POST", xmlStream, 10);
                    IMS_XML = getXML.RESTGetGenericRequest(configParameters["Import URL"].Value, getXML.GetNetworkCredential(configParameters), "GET", null, 10);
                    break;
                default:
                    //pushXML.RESTGetGenericRequest(exportConfigParameters["WebService POST URL"].Value, pushXML.GetNetworkCredential(exportConfigParameters), "POST", xmlStream, 10);
                    IMS_XML = getXML.RESTGetGenericRequest(configParameters["Import URL"].Value, getXML.GetNetworkCredential(configParameters), "GET", null, 10);
                    break;
            }

            
            XmlSerializer serializer = new XmlSerializer(typeof(enterprise));
            enterprise xmlResponse = (enterprise)serializer.Deserialize(IMS_XML);


            // Instantiate ImportedObjectsList
            ImportedObjectsList = new List<ImportListItem>();

            foreach (person person in xmlResponse.person)
            {
                Logger.Log.Debug(person.name.fn);
                if (!allreadyimported.Any(s => person.sourcedid.Any(p => p.id == s)))

                {
                    ImportedObjectsList.Add(new ImportListItem() { ims_person = person });
                    allreadyimported.Add(person.sourcedid[0].id);
                }
            }

            var membershipsList = new Dictionary<string, membership>();

            foreach (membership membership in xmlResponse.membership)
            {
                Logger.Log.Debug(membership.sourcedid.id + " " + membership.member);
                var membershipID = membership.sourcedid.id;
                if (!membershipsList.ContainsKey(membershipID))
                {
                    membershipsList.Add(membershipID, membership);
                }
            }

            foreach (group group in xmlResponse.group)
            {
                
                if (!allreadyimported.Any(s => group.sourcedid.Any(p => p.id == s)))
                {
                    string groupId = group.sourcedid[0].id;
                    if (membershipsList.ContainsKey(groupId))
                    {
                        membership membership = membershipsList[groupId];

                        foreach (var member in membership.member)
                        {
                            var memberId = member.sourcedid.id;
                            foreach (var role in member.role)
                            {
                                if (role.roletype.ToString() == "Item01" || role.roletype.ToString() == "Learner")
                                {
                                    if (!group.member_learner.Contains(memberId))
                                    {
                                        group.member_learner.Add(memberId);
                                    }
                                }
                                else if (role.roletype.ToString() == "Item02" || role.roletype.ToString() == "Instructor")
                                {
                                    if (!group.member_instructor.Contains(memberId))
                                    {
                                        group.member_instructor.Add(memberId);
                                    }
                                }

                            }
                        }
                    }
                    ImportedObjectsList.Add(new ImportListItem() { ims_group = group });
                    allreadyimported.Add(groupId);
                }
        }

            GetImportEntriesIndex = 0;
            GetImportEntriesPageSize = importRunStep.PageSize;

            return new OpenImportConnectionResults();
        }

        public GetImportEntriesResults GetImportEntries(GetImportEntriesRunStep importRunStep)
        {
            List<CSEntryChange> csentries = new List<CSEntryChange>();
            GetImportEntriesResults importReturnInfo = new GetImportEntriesResults();

            // If no result, return empty success
            if (ImportedObjectsList == null || ImportedObjectsList.Count == 0)
            {
                importReturnInfo.CSEntries = csentries;
                return importReturnInfo;
            }

            // Parse a full page or to the end
            for (int currentPage = 0;
                GetImportEntriesIndex < ImportedObjectsList.Count && currentPage < GetImportEntriesPageSize;
                GetImportEntriesIndex++, currentPage++)
            {
                if (ImportedObjectsList[GetImportEntriesIndex].ims_person != null)
                {
                    csentries.Add(ImportedObjectsList[GetImportEntriesIndex].ims_person.GetCSEntryChange());            
                }

                if (ImportedObjectsList[GetImportEntriesIndex].ims_group != null)
                {
                    csentries.Add(ImportedObjectsList[GetImportEntriesIndex].ims_group.GetCSEntryChange());
                }
            }

            // Store and return
            importReturnInfo.CSEntries = csentries;
            importReturnInfo.MoreToImport = GetImportEntriesIndex < ImportedObjectsList.Count;
            return importReturnInfo;
        }

        public CloseImportConnectionResults CloseImportConnection(CloseImportConnectionRunStep importRunStep)
        {
            return new CloseImportConnectionResults();
        }

        //To make parameters availible under PutExportEntiresResult
        KeyedCollection<string, ConfigParameter> exportConfigParameters;
        enterprise enterprise_root;
        List<person> imsPersonList;
        List<group> imsGroupList;
        List<membership> imsMembershipList;

        public void OpenExportConnection(KeyedCollection<string, ConfigParameter> configParameters, Schema types, OpenExportConnectionRunStep exportRunStep)
        {
            Logger.Log.Info("Starting Export");

            exportConfigParameters = configParameters;

            enterprise_root = new enterprise();
            imsPersonList = new List<person>();
            imsGroupList = new List<group>();
            imsMembershipList = new List<membership>();



            string[] targets = new string[] { "VigoBAS ,utlasting av IMS Enterprise 1.1 Data" };

            List<string> allreadyimported = new List<string>();

            //write XML Header            
            enterprise_root.properties = new properties();
            enterprise_root.properties.comments = new comments { lang = "nb-NO", Value = "VigoBAS IMS Enterprise Utrekk" };
            enterprise_root.properties.lang = "nb-NO";
            enterprise_root.properties.target = targets;
        }

        public PutExportEntriesResults PutExportEntries(IList<CSEntryChange> csentries)
        {
            foreach (CSEntryChange csentryChange in csentries)
            {
                Logger.Log.Debug(string.Format("Prepping object {0} for export.", csentryChange.DN.ToString()));
                //myEmpID = csentries[i].DN.ToString();

                if (csentryChange.ObjectType == "person")
                {
                    person ims_Person = new person();
                    ims_Person.ExportCSEntry(csentryChange);
                    Logger.Log.Debug(string.Format("Successfully created XML object for user: {0}.", ims_Person.name.fn));
                    imsPersonList.Add(ims_Person);
                }
                if (csentryChange.ObjectType == "group")
                {
                    groupholder ims_Group = new groupholder();
                    ims_Group.Group = new group();
                    ims_Group.Membership = new membership();

                    ims_Group = ims_Group.Group.ExportCSEntry(csentryChange);
                    Logger.Log.Debug(string.Format("Successfully created XML object for group: {0}.", ims_Group.Group.description.@long));
                    imsGroupList.Add(ims_Group.Group);

                    //Legger kun til i listen hvis den har medlemmer.
                    if (ims_Group.Membership.member != null)
                    {
                        imsMembershipList.Add(ims_Group.Membership);
                    }


                }

            }
            Logger.Log.Info($"Eksporterer {imsPersonList.Count} personer");
            Logger.Log.Info($"Eksporterer {imsGroupList.Count} grupper");
            Logger.Log.Info($"Eksporterer {imsMembershipList.Count} medlemskap");

            PutExportEntriesResults exportEntriesResults = new PutExportEntriesResults();
            


            return exportEntriesResults;

        }

        public void CloseExportConnection(CloseExportConnectionRunStep exportRunStep)
        {
            Logger.Log.Debug(string.Format("Adding {0} Persons to XML", imsPersonList.Count));
            enterprise_root.person = imsPersonList.ToArray();

            Logger.Log.Debug(string.Format("Adding {0} Groups to XML", imsGroupList.Count));
            enterprise_root.group = imsGroupList.ToArray();

            Logger.Log.Debug(string.Format("Adding {0} Memerships to XML", imsMembershipList.Count));
            enterprise_root.membership = imsMembershipList.ToArray();

            string transfertype = exportConfigParameters["Type"].Value;

            sendhandler pushXML = new sendhandler();

            string xmlToITL = string.Empty;

            MemoryStream stream = new MemoryStream();

            var sb = new StringBuilder();
            var stringWriter = new StringWriterUtf8(sb);
            string xml = string.Empty;

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.CloseOutput = true;
            settings.Encoding = new UTF8Encoding(false);
            using (XmlWriter writer = XmlWriter.Create(stringWriter, settings))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(enterprise));
                serializer.Serialize(writer, enterprise_root);

                writer.Flush();
            }

            xml = sb.ToString();

            var xmlFolder = MAUtils.MAFolder;
            pushXML.writeItsLearningXMLToFile(xmlFolder, xml);

            xmlToITL = xml.Replace("xmlns=\"http://tempuri.org/ims_epv1p1\"", "");

            byte[] byteArray = Encoding.UTF8.GetBytes(xmlToITL);
            MemoryStream resultStream = new MemoryStream(byteArray);

            Logger.Log.Info("WS Type: " + transfertype);


            switch (transfertype.ToLower())
            {
                case "its learning":                    
                    pushXML.sftpItsLearningUpload(exportConfigParameters["Export URL"].Value, exportConfigParameters["Xml File Name"].Value, 22, exportConfigParameters["Username"].Value, sendhandler.ConvertToUnsecureString(exportConfigParameters["Password"].SecureValue), resultStream);

                    break;
                case "fronter":
                    pushXML.RESTFronterRequest(exportConfigParameters["Export URL"].Value, "POST", resultStream, 10);
                    break;
                default:
                    pushXML.RESTGetGenericRequest(exportConfigParameters["Export URL"].Value, pushXML.GetNetworkCredential(exportConfigParameters), "POST", resultStream, 10);
                    break;
            }
        }
    };
}
