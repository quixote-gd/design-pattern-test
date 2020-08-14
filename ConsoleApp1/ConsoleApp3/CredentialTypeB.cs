using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public class CredentialTypeB : Product
    {
        public int CredentialId { get; set; }

        private string CredentialType { get; set; }

        public CredentialTypeB()
        {
            this.CredentialType = "CRED_TYPE_B";
        }

        public override int CreateProductForEvent(int eventId)
        {
            throw new NotImplementedException();
        }

        public override Product ProcessProduct(int eventId)
        {
            throw new NotImplementedException();
        }

        public override void RemoveProductFromEvent(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
