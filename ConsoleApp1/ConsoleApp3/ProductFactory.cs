using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public class ProductFactoy
    {
        private Dictionary<string, IProduct> products = new Dictionary<string, IProduct>();

        public ProductFactoy()
        {
            foreach (var processor in typeof(IProduct).Assembly.GetTypes())
            {
                if (typeof(IProduct).IsAssignableFrom(processor) && !processor.IsInterface)
                {
                    var processorInstance = (IProduct)Activator.CreateInstance(processor);
                    products.Add(processorInstance.GetProductCode(), processorInstance);
                }
            }
        }

        public void ProcessProduct(string key, int eventId)
        {
            var processProduct = this.products?[key];
            processProduct.ProcessProduct(eventId);
        }
    }

}
