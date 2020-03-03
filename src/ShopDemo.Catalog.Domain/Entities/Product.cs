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
    }
}
