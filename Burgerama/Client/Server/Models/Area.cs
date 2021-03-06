﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Server.Models
{
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "Area", Namespace = "http://schemas.datacontract.org/2004/07/Server.Models")]
    public partial class Area : object, System.Runtime.Serialization.IExtensibleDataObject
    {

        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        private int IdField;

        private string NameField;

        private int PlzField;

        private int VersionField;

        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Plz
        {
            get
            {
                return this.PlzField;
            }
            set
            {
                this.PlzField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Version
        {
            get { return this.VersionField; }
            set { this.VersionField = value; }
        }

        public Driver Driver { get; set; }

        public bool InDriverAreaList
        {
            set
            {
                if (value)
                {
                    var list = Driver.Areas.ToList();
                    list.Add(this);
                    Driver.Areas = list.ToArray();
                }
                else
                {
                    var list = Driver.Areas.ToList();
                    list.Remove(this);
                    Driver.Areas = list.ToArray();
                }
            }
            get { return Driver.Areas.Contains(this); }
        }

        public override bool Equals(object obj)
        {
            var area = obj as Area;
            if (area != null)
            {
                return area.IdField == IdField;
            }

            return false;
        }
        
    }
}
