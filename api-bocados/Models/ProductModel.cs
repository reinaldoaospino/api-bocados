namespace api_bocados.Models
{
    public class ProductModel
    {
        public string Id { get; set; }

        public string ProductName { get; set; }

        public string Price { get; set; }

        public string FeaturedProduct { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public byte[] Imagen { get; set; }
    }
}
