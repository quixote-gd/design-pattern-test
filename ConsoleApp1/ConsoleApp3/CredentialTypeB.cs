﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public class CredentialTypeB : Product
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
