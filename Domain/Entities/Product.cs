using System;

namespace Domain.Entities
{
    public class Product
    {
        public string Id { get; set; }

        public string ProductName { get; set; }

        public string Price { get; set; }

        public string FeaturedProduct { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public byte[] Imagen { get; set; }

        public string GenerateGuid()
        {
            return Guid.NewGuid().ToString();
        }

        public void Update(Product product)
        {
            ProductName = product.ProductName ?? ProductName;
            Price = product.Price ?? Price;
            FeaturedProduct = product.FeaturedProduct ?? FeaturedProduct;
            Category = product.Category ?? Category;
            Description = product.Description ?? Description;
            Imagen = product.Imagen.Length != 0 ? product.Imagen : Imagen;
        }
    }
}
