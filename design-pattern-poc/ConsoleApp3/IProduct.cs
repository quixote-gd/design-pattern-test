using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public interface IProduct
    {
        public string GetProductCode();
        public void ProcessProduct(int eventId);
    }
}
