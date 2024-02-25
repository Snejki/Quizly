namespace Quizly.Modules.Questions.Domain.Entities
{
    public class Category
    {
        public CategoryId Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ImagePath { get; private set; }
        public bool IsActive { get; private set; }


        public static Category Creaate(CategoryId id, string name, string description, string imagePath)
        {
            return new Category(id, name, description, imagePath);
        }

        public Category(CategoryId categoryId, string name, string descrption, string imagePath)
        {
            Id = categoryId;
            Name = name;
            Description = descrption;
            ImagePath = imagePath;
            IsActive = true;
        }
    }
}
