using System.Threading;
using System.Threading.Tasks;

namespace AppointmentManager.Services.Rest
{
    public interface IRestService
    {
		/// <summary>
		/// Method for send async Gets request .
		/// </summary>
		/// <returns>Task with request.</returns>
		/// <param name="requestUrl">String of request.</param>
		/// <param name="cancellationToken">Cancellation token.</param>
		/// <typeparam name="T">The type return value.</typeparam>
		Task<T> GetAsync<T>(string requestUrl, CancellationToken cancellationToken);
    }
}