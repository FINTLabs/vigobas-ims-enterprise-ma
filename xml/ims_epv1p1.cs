﻿// VIGOBAS Identity Management System 
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
using System.Xml.Serialization;


[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/ims_epv1p1", IsNullable=true)]
public partial class enterprise {
    
    private comments commentsField;
    
    private properties propertiesField;
    
    private person[] personField;
    
    private group[] groupField;
    
    private membership[] membershipField;
    
    /// <remarks/>
    public comments comments {
        get {
            return this.commentsField;
        }
        set {
            this.commentsField = value;
        }
    }
    
    /// <remarks/>
    public properties properties {
        get {
            return this.propertiesField;
        }
        set {
            this.propertiesField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("person")]
    public person[] person {
        get {
            return this.personField;
        }
        set {
            this.personField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("group")]
    public group[] group {
        get {
            return this.groupField;
        }
        set {
            this.groupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("membership")]
    public membership[] membership {
        get {
            return this.membershipField;
        }
        set {
            this.membershipField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/ims_epv1p1", IsNullable=false)]
public partial class comments {
    
    private string langField;
    
    private string valueField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string lang {
        get {
            return this.langField;
        }
        set {
            this.langField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/ims_epv1p1", IsNullable=false)]
public partial class properties {
    
    private comments commentsField;
    
    private string datasourceField;
    
    private string[] targetField;
    
    private string typeField;
    
    private string datetimeField;
    
    private extension extensionField;
    
    private string langField;
    
    /// <remarks/>
    public comments comments {
        get {
            return this.commentsField;
        }
        set {
            this.commentsField = value;
        }
    }
    
    /// <remarks/>
    public string datasource {
        get {
            return this.datasourceField;
        }
        set {
            this.datasourceField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("target")]
    public string[] target {
        get {
            return this.targetField;
        }
        set {
            this.targetField = value;
        }
    }
    
    /// <remarks/>
    public string type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }
    
    /// <remarks/>
    public string datetime {
        get {
            return this.datetimeField;
        }
        set {
            this.datetimeField = value;
        }
    }
    
    /// <remarks/>
    public extension extension {
        get {
            return this.extensionField;
        }
        set {
            this.extensionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string lang {
        get {
            return this.langField;
        }
        set {
            this.langField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/ims_epv1p1", IsNullable=false)]
public partial class extension {
    
    private System.Xml.XmlNode[] anyField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    [System.Xml.Serialization.XmlAnyElementAttribute()]
    public System.Xml.XmlNode[] Any {
        get {
            return this.anyField;
        }
        set {
            this.anyField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/ims_epv1p1", IsNullable=false)]
public partial class person {
    
    private comments commentsField;
    
    private sourcedid[] sourcedidField;
    
    private userid[] useridField;
    
    private name nameField;
    
    private demographics demographicsField;
    
    private string emailField;
    
    private string urlField;
    
    private tel[] telField;
    
    private adr adrField;
    
    private photo photoField;
    
    private systemrole systemroleField;
    
    private institutionrole[] institutionroleField;
    
    private string datasourceField;
    
    private extension extensionField;
    
    private personRecstatus recstatusField;
    
    private bool recstatusFieldSpecified;


    
    /// <remarks/>
    public comments comments {
        get {
            return this.commentsField;
        }
        set {
            this.commentsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("sourcedid")]
    public sourcedid[] sourcedid {
        get {
            return this.sourcedidField;
        }
        set {
            this.sourcedidField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("userid")]
    public userid[] userid {
        get {
            return this.useridField;
        }
        set {
            this.useridField = value;
        }
    }
    
    /// <remarks/>
    public name name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    public demographics demographics {
        get {
            return this.demographicsField;
        }
        set {
            this.demographicsField = value;
        }
    }
    
    /// <remarks/>
    public string email {
        get {
            return this.emailField;
        }
        set {
            this.emailField = value;
        }
    }
    
    /// <remarks/>
    public string url {
        get {
            return this.urlField;
        }
        set {
            this.urlField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("tel")]
    public tel[] tel {
        get {
            return this.telField;
        }
        set {
            this.telField = value;
        }
    }
    
    /// <remarks/>
    public adr adr {
        get {
            return this.adrField;
        }
        set {
            this.adrField = value;
        }
    }
    
    /// <remarks/>
    public photo photo {
        get {
            return this.photoField;
        }
        set {
            this.photoField = value;
        }
    }
    
    /// <remarks/>
    public systemrole systemrole {
        get {
            return this.systemroleField;
        }
        set {
            this.systemroleField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("institutionrole")]
    public institutionrole[] institutionrole {
        get {
            return this.institutionroleField;
        }
        set {
            this.institutionroleField = value;
        }
    }
    
    /// <remarks/>
    public string datasource {
        get {
            return this.datasourceField;
        }
        set {
            this.datasourceField = value;
        }
    }
    
    /// <remarks/>
    public extension extension {
        get {
            return this.extensionField;
        }
        set {
            this.extensionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public personRecstatus recstatus {
        get {
            return this.recstatusField;
        }
        set {
            this.recstatusField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool recstatusSpecified {
        get {
            return this.recstatusFieldSpecified;
        }
        set {
            this.recstatusFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/ims_epv1p1", IsNullable=false)]
public partial class sourcedid {
    
    private string sourceField;
    
    private string idField;
    
    private sourcedidSourcedidtype sourcedidtypeField;
    
    private bool sourcedidtypeFieldSpecified;
    
    /// <remarks/>
    public string source {
        get {
            return this.sourceField;
        }
        set {
            this.sourceField = value;
        }
    }
    
    /// <remarks/>
    public string id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public sourcedidSourcedidtype sourcedidtype {
        get {
            return this.sourcedidtypeField;
        }
        set {
            this.sourcedidtypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool sourcedidtypeSpecified {
        get {
            return this.sourcedidtypeFieldSpecified;
        }
        set {
            this.sourcedidtypeFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
public enum sourcedidSourcedidtype {
    
    /// <remarks/>
    New,
    
    /// <remarks/>
    Old,
    
    /// <remarks/>
    Duplicate,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/ims_epv1p1", IsNullable=false)]
public partial class userid {
    
    private string useridtypeField;
    
    private string passwordField;
    
    private string pwencryptiontypeField;
    
    private string authenticationtypeField;
    
    private string valueField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string useridtype {
        get {
            return this.useridtypeField;
        }
        set {
            this.useridtypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string password {
        get {
            return this.passwordField;
        }
        set {
            this.passwordField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string pwencryptiontype {
        get {
            return this.pwencryptiontypeField;
        }
        set {
            this.pwencryptiontypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string authenticationtype {
        get {
            return this.authenticationtypeField;
        }
        set {
            this.authenticationtypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/ims_epv1p1", IsNullable=false)]
public partial class name {
    
    private string fnField;
    
    private string sortField;
    
    private string nicknameField;
    
    private n nField;
    
    /// <remarks/>
    public string fn {
        get {
            return this.fnField;
        }
        set {
            this.fnField = value;
        }
    }
    
    /// <remarks/>
    public string sort {
        get {
            return this.sortField;
        }
        set {
            this.sortField = value;
        }
    }
    
    /// <remarks/>
    public string nickname {
        get {
            return this.nicknameField;
        }
        set {
            this.nicknameField = value;
        }
    }
    
    /// <remarks/>
    public n n {
        get {
            return this.nField;
        }
        set {
            this.nField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/ims_epv1p1", IsNullable=false)]
public partial class n {
    
    private string familyField;
    
    private string givenField;
    
    private string[] otherField;
    
    private string prefixField;
    
    private string suffixField;
    
    private partname[] partnameField;
    
    /// <remarks/>
    public string family {
        get {
            return this.familyField;
        }
        set {
            this.familyField = value;
        }
    }
    
    /// <remarks/>
    public string given {
        get {
            return this.givenField;
        }
        set {
            this.givenField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("other")]
    public string[] other {
        get {
            return this.otherField;
        }
        set {
            this.otherField = value;
        }
    }
    
    /// <remarks/>
    public string prefix {
        get {
            return this.prefixField;
        }
        set {
            this.prefixField = value;
        }
    }
    
    /// <remarks/>
    public string suffix {
        get {
            return this.suffixField;
        }
        set {
            this.suffixField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("partname")]
    public partname[] partname {
        get {
            return this.partnameField;
        }
        set {
            this.partnameField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/ims_epv1p1", IsNullable=false)]
public partial class partname {
    
    private string langField;
    
    private string partnametypeField;
    
    private string valueField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string lang {
        get {
            return this.langField;
        }
        set {
            this.langField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string partnametype {
        get {
            return this.partnametypeField;
        }
        set {
            this.partnametypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/ims_epv1p1", IsNullable=false)]
public partial class demographics {
    
    private string genderField;
    
    private string bdayField;
    
    private string[] disabilityField;
    
    /// <remarks/>
    public string gender {
        get {
            return this.genderField;
        }
        set {
            this.genderField = value;
        }
    }
    
    /// <remarks/>
    public string bday {
        get {
            return this.bdayField;
        }
        set {
            this.bdayField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("disability")]
    public string[] disability {
        get {
            return this.disabilityField;
        }
        set {
            this.disabilityField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/ims_epv1p1", IsNullable=false)]
public partial class tel {
    
    private telTeltype teltypeField;
    
    private string valueField;
    
    public tel() {
        this.teltypeField = telTeltype.Item1;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(telTeltype.Item1)]
    public telTeltype teltype {
        get {
            return this.teltypeField;
        }
        set {
            this.teltypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
public enum telTeltype {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("1")]
    Item1,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("2")]
    Item2,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("3")]
    Item3,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("4")]
    Item4,
    
    /// <remarks/>
    Voice,
    
    /// <remarks/>
    Fax,
    
    /// <remarks/>
    Mobile,
    
    /// <remarks/>
    Pager,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/ims_epv1p1", IsNullable=false)]
public partial class adr {
    
    private string poboxField;
    
    private string extaddField;
    
    private string[] streetField;
    
    private string localityField;
    
    private string regionField;
    
    private string pcodeField;
    
    private string countryField;
    
    /// <remarks/>
    public string pobox {
        get {
            return this.poboxField;
        }
        set {
            this.poboxField = value;
        }
    }
    
    /// <remarks/>
    public string extadd {
        get {
            return this.extaddField;
        }
        set {
            this.extaddField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("street")]
    public string[] street {
        get {
            return this.streetField;
        }
        set {
            this.streetField = value;
        }
    }
    
    /// <remarks/>
    public string locality {
        get {
            return this.localityField;
        }
        set {
            this.localityField = value;
        }
    }
    
    /// <remarks/>
    public string region {
        get {
            return this.regionField;
        }
        set {
            this.regionField = value;
        }
    }
    
    /// <remarks/>
    public string pcode {
        get {
            return this.pcodeField;
        }
        set {
            this.pcodeField = value;
        }
    }
    
    /// <remarks/>
    public string country {
        get {
            return this.countryField;
        }
        set {
            this.countryField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/ims_epv1p1", IsNullable=false)]
public partial class photo {
    
    private string extrefField;
    
    private string imgtypeField;
    
    /// <remarks/>
    public string extref {
        get {
            return this.extrefField;
        }
        set {
            this.extrefField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string imgtype {
        get {
            return this.imgtypeField;
        }
        set {
            this.imgtypeField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/ims_epv1p1", IsNullable=false)]
public partial class systemrole {
    
    private systemroleSystemroletype systemroletypeField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public systemroleSystemroletype systemroletype {
        get {
            return this.systemroletypeField;
        }
        set {
            this.systemroletypeField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
public enum systemroleSystemroletype {
    
    /// <remarks/>
    SysAdmin,
    
    /// <remarks/>
    SysSupport,
    
    /// <remarks/>
    Creator,
    
    /// <remarks/>
    AccountAdmin,
    
    /// <remarks/>
    User,
    
    /// <remarks/>
    None,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/ims_epv1p1", IsNullable=false)]
public partial class institutionrole {
    
    private institutionrolePrimaryrole primaryroleField;
    
    private institutionroleInstitutionroletype institutionroletypeField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public institutionrolePrimaryrole primaryrole {
        get {
            return this.primaryroleField;
        }
        set {
            this.primaryroleField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public institutionroleInstitutionroletype institutionroletype {
        get {
            return this.institutionroletypeField;
        }
        set {
            this.institutionroletypeField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
public enum institutionrolePrimaryrole {
    
    /// <remarks/>
    Yes,
    
    /// <remarks/>
    No,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
public enum institutionroleInstitutionroletype {
    
    /// <remarks/>
    Student,
    
    /// <remarks/>
    Faculty,
    
    /// <remarks/>
    Staff,
    
    /// <remarks/>
    Alumni,
    
    /// <remarks/>
    ProspectiveStudent,
    
    /// <remarks/>
    Guest,
    
    /// <remarks/>
    Other,
    
    /// <remarks/>
    Administrator,
    
    /// <remarks/>
    Observer,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
public enum personRecstatus {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("1")]
    Item1,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("2")]
    Item2,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("3")]
    Item3,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/ims_epv1p1", IsNullable=false)]
public partial class group {
    
    private comments commentsField;
    
    private sourcedid[] sourcedidField;
    
    private grouptype[] grouptypeField;
    
    private description descriptionField;
    
    private org orgField;
    
    private timeframe timeframeField;
    
    private enrollcontrol enrollcontrolField;
    
    private string emailField;
    
    private string urlField;
    
    private relationship[] relationshipField;
    
    private string datasourceField;
    
    private extension extensionField;
    
    private groupRecstatus recstatusField;
    
    private bool recstatusFieldSpecified;
    
    /// <remarks/>
    public comments comments {
        get {
            return this.commentsField;
        }
        set {
            this.commentsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("sourcedid")]
    public sourcedid[] sourcedid {
        get {
            return this.sourcedidField;
        }
        set {
            this.sourcedidField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("grouptype")]
    public grouptype[] grouptype {
        get {
            return this.grouptypeField;
        }
        set {
            this.grouptypeField = value;
        }
    }
    
    /// <remarks/>
    public description description {
        get {
            return this.descriptionField;
        }
        set {
            this.descriptionField = value;
        }
    }
    
    /// <remarks/>
    public org org {
        get {
            return this.orgField;
        }
        set {
            this.orgField = value;
        }
    }
    
    /// <remarks/>
    public timeframe timeframe {
        get {
            return this.timeframeField;
        }
        set {
            this.timeframeField = value;
        }
    }
    
    /// <remarks/>
    public enrollcontrol enrollcontrol {
        get {
            return this.enrollcontrolField;
        }
        set {
            this.enrollcontrolField = value;
        }
    }
    
    /// <remarks/>
    public string email {
        get {
            return this.emailField;
        }
        set {
            this.emailField = value;
        }
    }
    
    /// <remarks/>
    public string url {
        get {
            return this.urlField;
        }
        set {
            this.urlField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("relationship")]
    public relationship[] relationship {
        get {
            return this.relationshipField;
        }
        set {
            this.relationshipField = value;
        }
    }
    
    /// <remarks/>
    public string datasource {
        get {
            return this.datasourceField;
        }
        set {
            this.datasourceField = value;
        }
    }
    
    /// <remarks/>
    public extension extension {
        get {
            return this.extensionField;
        }
        set {
            this.extensionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public groupRecstatus recstatus {
        get {
            return this.recstatusField;
        }
        set {
            this.recstatusField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool recstatusSpecified {
        get {
            return this.recstatusFieldSpecified;
        }
        set {
            this.recstatusFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/ims_epv1p1", IsNullable=false)]
public partial class grouptype {
    
    private string schemeField;
    
    private typevalue[] typevalueField;
    
    /// <remarks/>
    public string scheme {
        get {
            return this.schemeField;
        }
        set {
            this.schemeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("typevalue")]
    public typevalue[] typevalue {
        get {
            return this.typevalueField;
        }
        set {
            this.typevalueField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/ims_epv1p1", IsNullable=false)]
public partial class typevalue {
    
    private string levelField;
    
    private string valueField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string level {
        get {
            return this.levelField;
        }
        set {
            this.levelField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/ims_epv1p1", IsNullable=false)]
public partial class description {
    
    private string shortField;
    
    private string longField;
    
    private string fullField;
    
    /// <remarks/>
    public string @short {
        get {
            return this.shortField;
        }
        set {
            this.shortField = value;
        }
    }
    
    /// <remarks/>
    public string @long {
        get {
            return this.longField;
        }
        set {
            this.longField = value;
        }
    }
    
    /// <remarks/>
    public string full {
        get {
            return this.fullField;
        }
        set {
            this.fullField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/ims_epv1p1", IsNullable=false)]
public partial class org {
    
    private string orgnameField;
    
    private string[] orgunitField;
    
    private string typeField;
    
    private string idField;
    
    /// <remarks/>
    public string orgname {
        get {
            return this.orgnameField;
        }
        set {
            this.orgnameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("orgunit")]
    public string[] orgunit {
        get {
            return this.orgunitField;
        }
        set {
            this.orgunitField = value;
        }
    }
    
    /// <remarks/>
    public string type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }
    
    /// <remarks/>
    public string id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/ims_epv1p1", IsNullable=false)]
public partial class timeframe {
    
    private begin beginField;
    
    private end endField;
    
    private string adminperiodField;
    
    /// <remarks/>
    public begin begin {
        get {
            return this.beginField;
        }
        set {
            this.beginField = value;
        }
    }
    
    /// <remarks/>
    public end end {
        get {
            return this.endField;
        }
        set {
            this.endField = value;
        }
    }
    
    /// <remarks/>
    public string adminperiod {
        get {
            return this.adminperiodField;
        }
        set {
            this.adminperiodField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/ims_epv1p1", IsNullable=false)]
public partial class begin {
    
    private string restrictField;
    
    private string valueField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string restrict {
        get {
            return this.restrictField;
        }
        set {
            this.restrictField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/ims_epv1p1", IsNullable=false)]
public partial class end {
    
    private string restrictField;
    
    private string valueField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string restrict {
        get {
            return this.restrictField;
        }
        set {
            this.restrictField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/ims_epv1p1", IsNullable=false)]
public partial class enrollcontrol {
    
    private string enrollacceptField;
    
    private string enrollallowedField;
    
    /// <remarks/>
    public string enrollaccept {
        get {
            return this.enrollacceptField;
        }
        set {
            this.enrollacceptField = value;
        }
    }
    
    /// <remarks/>
    public string enrollallowed {
        get {
            return this.enrollallowedField;
        }
        set {
            this.enrollallowedField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/ims_epv1p1", IsNullable=false)]
public partial class relationship {
    
    private sourcedid sourcedidField;
    
    private string labelField;
    
    private relationshipRelation relationField;
    
    public relationship() {
        this.relationField = relationshipRelation.Item1;
    }
    
    /// <remarks/>
    public sourcedid sourcedid {
        get {
            return this.sourcedidField;
        }
        set {
            this.sourcedidField = value;
        }
    }
    
    /// <remarks/>
    public string label {
        get {
            return this.labelField;
        }
        set {
            this.labelField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(relationshipRelation.Item1)]
    public relationshipRelation relation {
        get {
            return this.relationField;
        }
        set {
            this.relationField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
public enum relationshipRelation {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("1")]
    Item1,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("2")]
    Item2,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("3")]
    Item3,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
public enum groupRecstatus {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("1")]
    Item1,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("2")]
    Item2,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("3")]
    Item3,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/ims_epv1p1", IsNullable=false)]
public partial class membership {
    
    private comments commentsField;
    
    private sourcedid sourcedidField;
    
    private member[] memberField;
    
    /// <remarks/>
    public comments comments {
        get {
            return this.commentsField;
        }
        set {
            this.commentsField = value;
        }
    }
    
    /// <remarks/>
    public sourcedid sourcedid {
        get {
            return this.sourcedidField;
        }
        set {
            this.sourcedidField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("member")]
    public member[] member {
        get {
            return this.memberField;
        }
        set {
            this.memberField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/ims_epv1p1", IsNullable=false)]
public partial class member {
    
    private comments commentsField;
    
    private sourcedid sourcedidField;
    
    private string idtypeField;
    
    private role[] roleField;
    
    /// <remarks/>
    public comments comments {
        get {
            return this.commentsField;
        }
        set {
            this.commentsField = value;
        }
    }
    
    /// <remarks/>
    public sourcedid sourcedid {
        get {
            return this.sourcedidField;
        }
        set {
            this.sourcedidField = value;
        }
    }
    
    /// <remarks/>
    public string idtype {
        get {
            return this.idtypeField;
        }
        set {
            this.idtypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("role")]
    public role[] role {
        get {
            return this.roleField;
        }
        set {
            this.roleField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/ims_epv1p1", IsNullable=false)]
public partial class role {
    
    private string subroleField;
    
    private string statusField;
    
    private userid useridField;
    
    private comments commentsField;
    
    private string datetimeField;
    
    private timeframe timeframeField;
    
    private interimresult[] interimresultField;
    
    private finalresult[] finalresultField;
    
    private string emailField;
    
    private string datasourceField;
    
    private extension extensionField;
    
    private roleRecstatus recstatusField;
    
    private bool recstatusFieldSpecified;
    
    private roleRoletype roletypeField;
    
    public role() {
        this.roletypeField = roleRoletype.Item01;
    }
    
    /// <remarks/>
    public string subrole {
        get {
            return this.subroleField;
        }
        set {
            this.subroleField = value;
        }
    }
    
    /// <remarks/>
    public string status {
        get {
            return this.statusField;
        }
        set {
            this.statusField = value;
        }
    }
    
    /// <remarks/>
    public userid userid {
        get {
            return this.useridField;
        }
        set {
            this.useridField = value;
        }
    }
    
    /// <remarks/>
    public comments comments {
        get {
            return this.commentsField;
        }
        set {
            this.commentsField = value;
        }
    }
    
    /// <remarks/>
    public string datetime {
        get {
            return this.datetimeField;
        }
        set {
            this.datetimeField = value;
        }
    }
    
    /// <remarks/>
    public timeframe timeframe {
        get {
            return this.timeframeField;
        }
        set {
            this.timeframeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("interimresult")]
    public interimresult[] interimresult {
        get {
            return this.interimresultField;
        }
        set {
            this.interimresultField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("finalresult")]
    public finalresult[] finalresult {
        get {
            return this.finalresultField;
        }
        set {
            this.finalresultField = value;
        }
    }
    
    /// <remarks/>
    public string email {
        get {
            return this.emailField;
        }
        set {
            this.emailField = value;
        }
    }
    
    /// <remarks/>
    public string datasource {
        get {
            return this.datasourceField;
        }
        set {
            this.datasourceField = value;
        }
    }
    
    /// <remarks/>
    public extension extension {
        get {
            return this.extensionField;
        }
        set {
            this.extensionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public roleRecstatus recstatus {
        get {
            return this.recstatusField;
        }
        set {
            this.recstatusField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool recstatusSpecified {
        get {
            return this.recstatusFieldSpecified;
        }
        set {
            this.recstatusFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(roleRoletype.Item01)]
    public roleRoletype roletype {
        get {
            return this.roletypeField;
        }
        set {
            this.roletypeField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/ims_epv1p1", IsNullable=false)]
public partial class interimresult {
    
    private string modeField;
    
    private values valuesField;
    
    private string resultField;
    
    private comments commentsField;
    
    private string resulttypeField;
    
    /// <remarks/>
    public string mode {
        get {
            return this.modeField;
        }
        set {
            this.modeField = value;
        }
    }
    
    /// <remarks/>
    public values values {
        get {
            return this.valuesField;
        }
        set {
            this.valuesField = value;
        }
    }
    
    /// <remarks/>
    public string result {
        get {
            return this.resultField;
        }
        set {
            this.resultField = value;
        }
    }
    
    /// <remarks/>
    public comments comments {
        get {
            return this.commentsField;
        }
        set {
            this.commentsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string resulttype {
        get {
            return this.resulttypeField;
        }
        set {
            this.resulttypeField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/ims_epv1p1", IsNullable=false)]
public partial class values {
    
    private string[] listField;
    
    private string minField;
    
    private string maxField;
    
    private valuesValuetype valuetypeField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("list")]
    public string[] list {
        get {
            return this.listField;
        }
        set {
            this.listField = value;
        }
    }
    
    /// <remarks/>
    public string min {
        get {
            return this.minField;
        }
        set {
            this.minField = value;
        }
    }
    
    /// <remarks/>
    public string max {
        get {
            return this.maxField;
        }
        set {
            this.maxField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public valuesValuetype valuetype {
        get {
            return this.valuetypeField;
        }
        set {
            this.valuetypeField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
public enum valuesValuetype {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("0")]
    Item0,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("1")]
    Item1,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/ims_epv1p1", IsNullable=false)]
public partial class finalresult {
    
    private string modeField;
    
    private values valuesField;
    
    private string resultField;
    
    private comments commentsField;
    
    /// <remarks/>
    public string mode {
        get {
            return this.modeField;
        }
        set {
            this.modeField = value;
        }
    }
    
    /// <remarks/>
    public values values {
        get {
            return this.valuesField;
        }
        set {
            this.valuesField = value;
        }
    }
    
    /// <remarks/>
    public string result {
        get {
            return this.resultField;
        }
        set {
            this.resultField = value;
        }
    }
    
    /// <remarks/>
    public comments comments {
        get {
            return this.commentsField;
        }
        set {
            this.commentsField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
public enum roleRecstatus {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("1")]
    Item1,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("2")]
    Item2,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("3")]
    Item3,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ims_epv1p1")]
public enum roleRoletype {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("01")]
    Item01,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("02")]
    Item02,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("03")]
    Item03,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("04")]
    Item04,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("05")]
    Item05,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("06")]
    Item06,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("07")]
    Item07,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("08")]
    Item08,

    //Thomas L : Seems to be a bug with Item01 ,it goes to "NULL" insted of "01"
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("01")]
    RealItem01,

    /// <remarks/>
    Learner,
    
    /// <remarks/>
    Instructor,
    
    /// <remarks/>
    ContentDeveloper,
    
    /// <remarks/>
    Member,
    
    /// <remarks/>
    Manager,
    
    /// <remarks/>
    Mentor,
    
    /// <remarks/>
    Administrator,
    
    /// <remarks/>
    TeachingAssistant,
}
