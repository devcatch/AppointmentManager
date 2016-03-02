using System.Threading;
using System.Threading.Tasks;

namespace AppointmentManager.Services.Rest
{
    public interface IRestService
    {
		Task<T> GetAsync<T>(string requestUrl, CancellationToken cancellationToken);
    }
}