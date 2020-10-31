namespace Domain.Entities
{
    public class Category
    {
        public string Id { get; set; }

        public string CategoryName { get; set; }

        public void Update (Category category)
        {
            CategoryName = category.CategoryName ?? CategoryName;
        }
    }
}
