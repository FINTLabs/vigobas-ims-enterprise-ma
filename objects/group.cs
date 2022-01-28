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
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vigo.Bas.ManagementAgent.Log;

public partial class group
{
    public List<object> member_learner;
    public List<object> member_instructor;

    internal Microsoft.MetadirectoryServices.CSEntryChange GetCSEntryChange()
    {
        // Add all to CSEntry
        CSEntryChange csentry = CSEntryChange.Create();
        csentry.ObjectModificationType = ObjectModificationType.Add;
        csentry.ObjectType = "group";

        csentry.AttributeChanges.Add(AttributeChange.CreateAttributeAdd("ID", sourcedid[0].id));

        //ID (SocialSecurityNumber)
        if (sourcedid[0].id != null)
            csentry.AttributeChanges.Add(AttributeChange.CreateAttributeAdd("sourceID_ID_#0", sourcedid[0].id));

        //Description (Full)
        if (description?.full != null)
            csentry.AttributeChanges.Add(AttributeChange.CreateAttributeAdd("description_Full", description.full));

        //Description (Short)
        if (description?.@short != null)
            csentry.AttributeChanges.Add(AttributeChange.CreateAttributeAdd("description_Short", description.@short));

        //Description (Long)
        if (description?.@long != null)
            csentry.AttributeChanges.Add(AttributeChange.CreateAttributeAdd("description_Long", description.@long));

        //Grouptype 
        if (grouptype.Length > 0)
            csentry.AttributeChanges.Add(AttributeChange.CreateAttributeAdd("grouptype", grouptype[0].typevalue[0].level));

        //Grouptypename
        if (grouptype?.Length > 0 & grouptype[0]?.typevalue[0]?.Value != null)
            csentry.AttributeChanges.Add(AttributeChange.CreateAttributeAdd("grouptypename", grouptype[0].typevalue[0].Value));

        //Grouptype 
        if (datasource != null)
            csentry.AttributeChanges.Add(AttributeChange.CreateAttributeAdd("datasource", datasource));
               
        if (relationship != null && relationship.Length > 0)
            //ToDO: forbedre logikk for å skille på grupper ,enheter og org.
            foreach (relationship relationship in relationship)
            {
                switch (relationship.label)

                {
                    case "Skole/Avdeling":
                        csentry.AttributeChanges.Add(AttributeChange.CreateAttributeAdd("orgUnitRef", relationship.sourcedid.id));
                        break;
                    case "Fylke/Kommune":
                        csentry.AttributeChanges.Add(AttributeChange.CreateAttributeAdd("orgRef", relationship.sourcedid.id));
                        break;
                    case "Root":
                        csentry.AttributeChanges.Add(AttributeChange.CreateAttributeAdd("orgRef", relationship.sourcedid.id));
                        break;
                    default:
                        csentry.AttributeChanges.Add(AttributeChange.CreateAttributeAdd("orgUnitRef", relationship.sourcedid.id));
                        break;
                }
            }
            
        if (member_learner != null)
            csentry.AttributeChanges.Add(AttributeChange.CreateAttributeAdd("member_student", member_learner));

        if (member_instructor != null)
            csentry.AttributeChanges.Add(AttributeChange.CreateAttributeAdd("member_instructor", member_instructor));

        return csentry;        
    }

    //Exports CSEntry ti IMS_Enterprise object type.
    internal groupholder ExportCSEntry(CSEntryChange csentryChange)
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
                recstatus = groupRecstatus.Item1;
                break;
            case ObjectModificationType.Replace:
                recstatusSpecified = true;
                recstatus = groupRecstatus.Item2;
                break;
            case ObjectModificationType.Update:
                recstatusSpecified = true;
                recstatus = groupRecstatus.Item2;
                break;
            case ObjectModificationType.Delete:
                recstatusSpecified = true;
                recstatus = groupRecstatus.Item3;
                break;
            default:
                recstatusSpecified = false;
                break;
        }

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

        //Description Fields
        if (availibleAttributes.Any(c => c == "description_Full" || c == "description_Long" || c == "description_Short"))
        {
            description = new description();

            if (availibleAttributes.Contains("description_Full"))
                description.full = csentryChange.AttributeChanges["description_Full"].ValueChanges[0].Value.ToString();
            if (availibleAttributes.Contains("description_Long"))
                description.@long = csentryChange.AttributeChanges["description_Long"].ValueChanges[0].Value.ToString();
            if (availibleAttributes.Contains("description_Short"))
                description.@short = csentryChange.AttributeChanges["description_Short"].ValueChanges[0].Value.ToString();
        }
        //Grouptype
        if (availibleAttributes.Contains("grouptype"))
        { 
            //TODO : fix Schema and "Value" ,values 
            string typevaluename;

            //Add the name of the grouptype if it's availible.
            if (availibleAttributes.Contains("grouptypename"))
                {
                typevaluename = csentryChange.AttributeChanges["grouptypename"].ValueChanges[0].Value.ToString();

                grouptype = new grouptype[] { new grouptype { scheme = "", typevalue = new typevalue[] { new typevalue { level = csentryChange.AttributeChanges["grouptype"].ValueChanges[0].Value.ToString(), Value = typevaluename } } } };
            }
            else
            {
                grouptype = new grouptype[] { new grouptype { scheme = "", typevalue = new typevalue[] { new typevalue { level = csentryChange.AttributeChanges["grouptype"].ValueChanges[0].Value.ToString() } } } };
            }
        }

        // grouptype = new grouptype[] { new grouptype { scheme = "", typevalue = new typevalue[] { new typevalue { level = csentryChange.AttributeChanges["grouptype"].ValueChanges[0].Value.ToString(), Value = typevaluename } } } };
    
        //Datasource
        if (availibleAttributes.Contains("datasource"))
            datasource = csentryChange.AttributeChanges["datasource"].ValueChanges[0].Value.ToString();


        if (availibleAttributes.Contains("orgUnitRef"))
            relationship = new relationship[] { new relationship { sourcedid = new sourcedid { id = csentryChange.AttributeChanges["orgUnitRef"].ValueChanges[0].Value.ToString(), source = "VigoBAS" }, relation = relationshipRelation.Item2, label = "Skole/Avdeling" } };

        //Only if OrgUnitRef is not present ,check if it should add OrgRef
        else if (availibleAttributes.Contains("orgRef") && csentryChange.AttributeChanges["grouptype"].ValueChanges[0].Value.ToString() != "0")
        {            
                relationship = new relationship[] { new relationship { sourcedid = new sourcedid { id = csentryChange.AttributeChanges["orgRef"].ValueChanges[0].Value.ToString(), source = "VigoBAS" }, relation = relationshipRelation.Item2, label = "Fylke/Kommune" } };
        }

        //If grouptype = 0 it's the root object and refrences itself. --IT's Learning uses self referance to know it's reached the top of the hirarcy
        else if (availibleAttributes.Contains("grouptype") && csentryChange.AttributeChanges["grouptype"].ValueChanges[0].Value.ToString() == "0")
        {
            relationship = new relationship[] { new relationship { sourcedid = new sourcedid { id = csentryChange.AttributeChanges["sourceID_ID_#0"].ValueChanges[0].Value.ToString(), source = "VigoBAS" }, relation = relationshipRelation.Item2, label = "Root" } };
        }

        membership ims_membership = new membership();
        if (availibleAttributes.Any(c => c == "member_instructor" || c == "member_student"))

        {
            //membership ims_membership = new membership();
            ims_membership.sourcedid =
                            new sourcedid
                            {
                                sourcedidtype = sourcedidSourcedidtype.New,
                                source = "VigoBAS",
                                id = csentryChange.AttributeChanges["sourceID_ID_#0"].ValueChanges[0].Value.ToString()
                            };

            List<member> members__temp = new List<member>();

            if (availibleAttributes.Contains("member_instructor"))
            {
                foreach (var member in csentryChange.AttributeChanges["member_instructor"].ValueChanges)
                {
                    member member_temp = new member();
                    member_temp.sourcedid = new sourcedid
                    {
                        sourcedidtype = sourcedidSourcedidtype.New,
                        source = "VigoBAS",
                        id = member.Value.ToString()
                    };
                    member_temp.role = new role[] { new role { roletype = roleRoletype.Item02 } };
                    members__temp.Add(member_temp);
                }
            }

            if (availibleAttributes.Contains("member_student"))
            {
                foreach (var member in csentryChange.AttributeChanges["member_student"].ValueChanges)
                {
                    member member_temp = new member();
                    member_temp.sourcedid = new sourcedid
                    {
                        sourcedidtype = sourcedidSourcedidtype.New,
                        source = "VigoBAS",
                        id = member.Value.ToString()
                    };
                    if (availibleAttributes.Contains("grouptypename"))
                    {
                        var grouptypename = csentryChange.AttributeChanges["grouptypename"].ValueChanges[0].Value.ToString();

                        List<string> aggregatesGroupTypes = new List<string> { "ELEVER", "ADMINISTRATIVTANSATTE", "LÆRERE" };

                        if (!aggregatesGroupTypes.Contains(grouptypename))
                        {
                            member_temp.role = new role[] { new role { roletype = roleRoletype.RealItem01 } };
                        }
                        members__temp.Add(member_temp);
                    }
                }
            }

            ims_membership.member = members__temp.ToArray();
        }

        return new groupholder() { Group = this, Membership = ims_membership };
    }

}

//New Object to hold both group and memberships objects.
class groupholder
{
    public group Group { get; set; }
    public membership Membership { get; set; }
}