using ShopDemo.Core.DomainObjects;
using System;

namespace ShopDemo.Catalog.Domain.Entities
{
    public class Product : Entity, IAggregateRoot
    {
        public Guid CategoryId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; }
        public decimal Value { get; private set; }
        public DateTime RegisterDate { get; private set; }
        public string Image { get; private set; }
        public int StockQuantity { get; private set; }
        public Dimensions Dimensions { get; private set; }
        public Category Category { get; private set; }

        protected Product() { }

        public Product(Guid categoryId, 
            string name, string description, 
            bool active, decimal value, 
            DateTime registerDate, string image, 
            int stockQuantity, Dimensions dimensions)
        {
            CategoryId = categoryId;
            Name = name;
            Description = description;
            Active = active;
            Value = value;
            RegisterDate = registerDate;
            Image = image;
            StockQuantity = stockQuantity;
            Dimensions = dimensions;
        }

        public void Ative() => Active = true;

        public void Deactive() => Active = false;

        public void UpdateCategory(Category category)
        {
            Category = category;
            CategoryId = category.Id;
        }

        public void UpdateDescription(string description)
        {
            Description = description;
        }

        public void RemoveStockItem(int quantity)
        {
            if (quantity < 0) quantity *= -1;
            if (!HasOnStock(quantity)) throw new DomainException("Insuficient stock");
            StockQuantity -= quantity;
        }

        public void ReplenishStock(int quantity)
        {
            StockQuantity += quantity;
        }

        public bool HasOnStock(int quantity)
        {
            return StockQuantity >= quantity;
        }
    }
}
