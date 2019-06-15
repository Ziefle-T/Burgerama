using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Server.Models
{
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "Order", Namespace = "http://schemas.datacontract.org/2004/07/Server.Models")]
    public partial class Order : object, System.Runtime.Serialization.IExtensibleDataObject
    {

        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        private Server.Models.Customer CustomerField;

        private string DescriptionField;

        private Server.Models.Driver DriverField;

        private int IdField;

        private System.DateTime OrderDateField;

        private Server.Models.OrderLines[] OrderLinesField;

        private string OrderNumberField;

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
        public Server.Models.Customer Customer
        {
            get
            {
                return this.CustomerField;
            }
            set
            {
                this.CustomerField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description
        {
            get
            {
                return this.DescriptionField;
            }
            set
            {
                this.DescriptionField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public Server.Models.Driver Driver
        {
            get
            {
                return this.DriverField;
            }
            set
            {
                this.DriverField = value;
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
        public System.DateTime OrderDate
        {
            get
            {
                return this.OrderDateField;
            }
            set
            {
                this.OrderDateField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public Server.Models.OrderLines[] OrderLines
        {
            get
            {
                return this.OrderLinesField;
            }
            set
            {
                this.OrderLinesField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OrderNumber
        {
            get
            {
                return this.OrderNumberField;
            }
            set
            {
                this.OrderNumberField = value;
            }
        }

        public override bool Equals(object obj)
        {
            var order = obj as Order;
            if (order != null)
            {
                return order.IdField == IdField;
            }

            return false;
        }
    }
}
