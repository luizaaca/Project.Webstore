using Project.Webstore.Infrastructure.Repository.Interfaces;
using Project.Webstore.Model.Shipping;

namespace Project.Webstore.Model.Repositories
{
    public interface IDeliveryOptionRepository: IReadOnlyRepository<DeliveryOption, int>
    {
    }
}
