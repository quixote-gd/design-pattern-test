using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public class CredentialTypeB : Product, IProduct
    {
        public int id { get; set; }

        private string TypeCode { get; set; }


        public CredentialTypeB()
        {
            this.TypeCode = "CRED_TYPE_B";
        }

        public override int CreateProductForEvent(int eventId)
        {
            throw new NotImplementedException();
        }

        public override void RemoveProductFromEvent(int productId)
        {
            throw new NotImplementedException();
        }

        public string GetProductCode()
        {
            return this.TypeCode;
        }

        public override Product SaveProductState(Product p, int eventId)
        {
            throw new NotImplementedException();
        }

        public void ProcessProduct(int eventId)
        {
            Console.WriteLine("Run Business other rules");
            Console.WriteLine("Save the Product");
        }
    }
}
