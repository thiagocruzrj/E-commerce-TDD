using MediatR;
using ShopDemo.Catalog.Data;
using ShopDemo.Core.DomainObjects;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDemo.Sales.Data
{
    public static class MediatorExtension
    {
        public static async Task PublishEvents(this IMediator mediator, SalesContext ctx)
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.Notifications != null && x.Entity.Notifications.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.Notifications)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.CleanEvents());

            var tasks = domainEvents
                .Select(async (domainEvent) => {
                    await mediator.Publish(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
