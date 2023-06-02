using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace DiplomApp5F.Services
{
    public class CookieService
    {
        private IJSRuntime _jsRuntime;

        public CookieService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task WriteAsync(string name, string value, int days) =>
            await _jsRuntime.InvokeAsync<object>("WriteCookie.WriteCookie", name, value, days);

        public async Task<string> ReadAsync(string name) =>
            await _jsRuntime.InvokeAsync<string>("ReadCookie.ReadCookie", name);
    }
}