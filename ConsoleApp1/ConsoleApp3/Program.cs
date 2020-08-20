using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductFactoy pFactory = new ProductFactoy();

            string productCodeToProcess = "CRED_TYPE_A";
            int productEventId = 2020;

            pFactory.ProcessProduct(productCodeToProcess, productEventId);
        }
    }
}
