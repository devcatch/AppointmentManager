using System.Threading;
using System.Threading.Tasks;

namespace AppointmentManager.Services.Rest
{
    public interface IRestService
    {
        Task<object> GetAsync(IRestRequest request, CancellationToken cancellationToken);
    }
}