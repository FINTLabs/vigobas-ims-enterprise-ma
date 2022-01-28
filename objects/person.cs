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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class person
{


    //Create CSEntries
    internal CSEntryChange GetCSEntryChange()
    {
        // Add all to CSEntry
        CSEntryChange csentry = CSEntryChange.Create();
        csentry.ObjectModificationType = ObjectModificationType.Add;
        csentry.ObjectType = "person";

        csentry.AttributeChanges.Add(AttributeChange.CreateAttributeAdd("ID", sourcedid[0].id));
        //DisplayName (Fullname)
        if (name?.fn != null)
            csentry.AttributeChanges.Add(AttributeChange.CreateAttributeAdd("name_fn", name.fn));

        //GivenName
        if (name?.n?.given != null)
            csentry.AttributeChanges.Add(AttributeChange.CreateAttributeAdd("name_given", name.n.given));
        //FamilyName
        if (name?.n?.family != null)
            csentry.AttributeChanges.Add(AttributeChange.CreateAttributeAdd("name_family", name.n.family));

        //ID (SocialSecurityNumber)
        if (sourcedid[0].id != null)
            csentry.AttributeChanges.Add(AttributeChange.CreateAttributeAdd("sourceID_ID_#0", sourcedid[0].id));

        //Birthday
        if (demographics?.bday != null)
            csentry.AttributeChanges.Add(AttributeChange.CreateAttributeAdd("bday", demographics.bday));
        //Gender
        if (demographics?.gender != null)
            csentry.AttributeChanges.Add(AttributeChange.CreateAttributeAdd("gender", demographics.gender));

        if (email != null)
            csentry.AttributeChanges.Add(AttributeChange.CreateAttributeAdd("email", email));

        if (institutionrole != null)
            foreach (var role in institutionrole)
            {
                if (role.primaryrole == institutionrolePrimaryrole.Yes)
                {
                    csentry.AttributeChanges.Add(AttributeChange.CreateAttributeAdd("institutionrole", role.institutionroletype.ToString()));
                }
            }

        //TODO: Needs check if array exists
        if (tel != null)
        {
            if (tel.Length != 0)
            {
                foreach (tel phoneNumber in tel)
                {
                    switch (phoneNumber.teltype)
                    {
                        case telTeltype.Item1:
                            csentry.AttributeChanges.Add(AttributeChange.CreateAttributeAdd("tel_work", phoneNumber.Value));
                            break;
                        case telTeltype.Item2:
                            //Not Implemented
                            break;
                        case telTeltype.Item3:
                            //Not Implemented
                            break;
                        case telTeltype.Item4:
                            //Not Implemented
                            break;
                        case telTeltype.Voice:
                            //Not Implemented
                            break;
                        case telTeltype.Fax:
                            //Not Implemented
                            break;
                        case telTeltype.Mobile:
                            csentry.AttributeChanges.Add(AttributeChange.CreateAttributeAdd("tel_mobile", phoneNumber.Value));
                            break;
                        case telTeltype.Pager:
                            //Not Implemented
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        //Address
        if (adr != null)
        {
            if (adr.street.Length != 0)
                csentry.AttributeChanges.Add(AttributeChange.CreateAttributeAdd("adr_street", adr.street[0]));
            if (adr?.pcode != null)
                csentry.AttributeChanges.Add(AttributeChange.CreateAttributeAdd("adr_pcode", adr.pcode));
            if (adr?.locality != null)
                csentry.AttributeChanges.Add(AttributeChange.CreateAttributeAdd("adr_locality", adr.locality));

            //Photo (External Referanse)
            if (photo?.extref != null)
                csentry.AttributeChanges.Add(AttributeChange.CreateAttributeAdd("photo_extref", photo.extref));
        }

        if (userid != null && userid.Length != 0)
        {
            if (userid[0].Value != null)
                csentry.AttributeChanges.Add(AttributeChange.CreateAttributeAdd("userid", userid[0].Value));
        }

        //Comment
        if (comments != null)
        {
            if (comments.Value != null)
                csentry.AttributeChanges.Add(AttributeChange.CreateAttributeAdd("comment", comments.Value));
        }

        // Return
        return csentry;        
    }

    //Exports CSEntry ti IMS_Enterprise object type.
    internal person ExportCSEntry(CSEntryChange csentryChange)
    {        
        List<string> availibleAttributes = new List<string>();

        foreach (var attribute in csentryChange.AttributeChanges)
        {
            availibleAttributes.Add(attribute.Name);
        }
        
        //Rectype '1=Add', '2=Update' and '3=Delete'
        switch (csentryChange.ObjectModificationType)
        {
            case ObjectModificationType.Unconfigured:
                break;
            case ObjectModificationType.None:
                break;
            case ObjectModificationType.Add:
                recstatusSpecified = true;
                recstatus = personRecstatus.Item1;
                break;
            case ObjectModificationType.Replace:
                this.recstatusSpecified = true;
                recstatus = personRecstatus.Item2;
                break;
            case ObjectModificationType.Update:
                recstatusSpecified = true;
                recstatus = personRecstatus.Item2;
                break;
            case ObjectModificationType.Delete:
                recstatusSpecified = true;
                recstatus = personRecstatus.Item3;
                break;
            default:
                recstatusSpecified = false;
                break;
        }

        name = new name();

        //Skriver personnummer til SourceID
        if (availibleAttributes.Contains("sourceID_ID_#0"))
        {
            sourcedid = new sourcedid[]
            {
                new sourcedid
                {
                sourcedidtype = sourcedidSourcedidtype.New,
                source = "VigoBAS",
                id = csentryChange.AttributeChanges["sourceID_ID_#0"].ValueChanges[0].Value.ToString()
                }
            };
        }
        
        //Skriver Displayname til name.fn
        name = new name();        

        if (availibleAttributes.Contains("name_fn"))
            name.fn = csentryChange.AttributeChanges["name_fn"].ValueChanges[0].Value.ToString();

        //Skriver Fornavn og Etternavn til name.n.given og name.n.family 
        if (availibleAttributes.Any(c => c == "name_given" || c == "name_family"))
        {
            name.n = new n();
            if (availibleAttributes.Contains("name_given"))
                name.n.given = csentryChange.AttributeChanges["name_given"].ValueChanges[0].Value.ToString();
            if (availibleAttributes.Contains("name_family"))
                name.n.family = csentryChange.AttributeChanges["name_family"].ValueChanges[0].Value.ToString();
        }

        if (availibleAttributes.Any(c => c == "bday" || c == "gender"))
        {
            demographics = new demographics();

            if (availibleAttributes.Contains("bday"))
                demographics.bday = csentryChange.AttributeChanges["bday"].ValueChanges[0].Value.ToString();

            if (availibleAttributes.Contains("gender"))
                demographics.gender = csentryChange.AttributeChanges["gender"].ValueChanges[0].Value.ToString();
        }

        if (availibleAttributes.Contains("email"))
            email = csentryChange.AttributeChanges["email"].ValueChanges[0].Value.ToString();

        if (availibleAttributes.Any(c => c == "tel_work" || c == "tel_mobile"))
        {
            List<tel> phonenumbers = new List<tel>();

            if (availibleAttributes.Contains("tel_work"))
                phonenumbers.Add(new tel { Value = csentryChange.AttributeChanges["tel_work"].ValueChanges[0].Value.ToString(), teltype = telTeltype.Item1 });

            if (availibleAttributes.Contains("tel_mobile"))
                phonenumbers.Add(new tel { Value = csentryChange.AttributeChanges["tel_mobile"].ValueChanges[0].Value.ToString(), teltype = telTeltype.Mobile });

            tel = phonenumbers.ToArray();
        }

        if (availibleAttributes.Any(c => c == "adr_street" || c == "adr_pcode" || c == "adr_locality"))
        {
            adr = new adr();

            if (availibleAttributes.Contains("adr_street"))
                adr.street = new string[] { csentryChange.AttributeChanges["adr_street"].ValueChanges[0].Value.ToString() };

            if (availibleAttributes.Contains("adr_pcode"))
                adr.pcode = csentryChange.AttributeChanges["adr_pcode"].ValueChanges[0].Value.ToString();

            if (availibleAttributes.Contains("adr_locality"))
                adr.locality = csentryChange.AttributeChanges["adr_locality"].ValueChanges[0].Value.ToString();
        }

        if (availibleAttributes.Contains("photo_extref"))
        {
            photo = new photo();
            photo.extref = csentryChange.AttributeChanges["photo_extref"].ValueChanges[0].Value.ToString();
            photo.imgtype = "jpeg//png";
        }

        if (availibleAttributes.Contains("userid"))
            userid = new userid[] { new userid { Value = csentryChange.AttributeChanges["userid"].ValueChanges[0].Value.ToString(), authenticationtype = "ldap" } };

        if (availibleAttributes.Contains("comment"))
        {
            comments = new comments();
            comments.Value = csentryChange.AttributeChanges["comment"].ValueChanges[0].Value.ToString();
            comments.lang = "nb-NO";
        }

        if (availibleAttributes.Contains("institutionrole"))
        {
            switch (csentryChange.AttributeChanges["institutionrole"].ValueChanges[0].Value.ToString())
            {
                case "Faculty":
                    institutionrole = new institutionrole[] { new institutionrole { institutionroletype = institutionroleInstitutionroletype.Faculty, primaryrole = institutionrolePrimaryrole.Yes } };
                    break;
                case "Student":
                    institutionrole = new institutionrole[] { new institutionrole { institutionroletype = institutionroleInstitutionroletype.Student, primaryrole = institutionrolePrimaryrole.Yes } };
                    break;
                case "Staff":
                    institutionrole = new institutionrole[] { new institutionrole { institutionroletype = institutionroleInstitutionroletype.Staff, primaryrole = institutionrolePrimaryrole.Yes } };
                    break;
                default:
                    break;
            }
             //csentryChange.AttributeChanges["comment"].ValueChanges[0].Value.ToString()
        }
            return this;
    }
}
