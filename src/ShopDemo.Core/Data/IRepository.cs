using ShopDemo.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopDemo.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get;  }
    }
}
