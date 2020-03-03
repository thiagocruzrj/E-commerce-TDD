﻿using ShopDemo.Core.DomainObjects;
using System.Collections.Generic;

namespace ShopDemo.Catalog.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; private set; }
        public int Code { get; private set; }

        // EF Relation
        public ICollection<Product> Products { get; set; }
    }
}