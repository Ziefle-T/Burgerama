using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Server.Models
{
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "Driver", Namespace = "http://schemas.datacontract.org/2004/07/Server.Models")]
    public partial class Driver : object, System.Runtime.Serialization.IExtensibleDataObject
    {

        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        private int IdField;

        private int EmployeeNumberField;

        private string FirstNameField;

        private string LastNameField;

        private Area[] AreasField;

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
        public int EmployeeNumber
        {
            get
            {
                return this.EmployeeNumberField;
            }
            set
            {
                this.EmployeeNumberField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public Area[] Areas
        {
            get
            {
                return this.AreasField;
            }
            set
            {
                this.AreasField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName
        {
            get
            {
                return this.FirstNameField;
            }
            set
            {
                this.FirstNameField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName
        {
            get
            {
                return this.LastNameField;
            }
            set
            {
                this.LastNameField = value;
            }
        }

        public override bool Equals(object obj)
        {
            var driver = obj as Driver;
            if (driver != null)
            {
                return driver.IdField == IdField;
            }

            return false;
        }
    }
}
