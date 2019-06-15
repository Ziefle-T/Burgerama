using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Server.Models
{
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "OrderLines", Namespace = "http://schemas.datacontract.org/2004/07/Server.Models")]
    public partial class OrderLines : object, System.Runtime.Serialization.IExtensibleDataObject
    {

        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        private int IdField;

        private int AmountField;

        private Article ArticleField;

        private Order OrderField;

        private int PositionField;

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
        public int Amount
        {
            get
            {
                return this.AmountField;
            }
            set
            {
                this.AmountField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public Article Article
        {
            get
            {
                return this.ArticleField;
            }
            set
            {
                this.ArticleField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public Order Order
        {
            get
            {
                return this.OrderField;
            }
            set
            {
                this.OrderField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Position
        {
            get
            {
                return this.PositionField;
            }
            set
            {
                this.PositionField = value;
            }
        }

        public override bool Equals(object obj)
        {
            var orderLines = obj as OrderLines;
            if (orderLines != null)
            {
                return orderLines.IdField == IdField;
            }

            return false;
        }
    }
}
