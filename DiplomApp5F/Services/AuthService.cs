using System;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using DiplomApp5F.Models;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Linq;

namespace DiplomApp5F.Services
{
    public class AuthService
    {
        private HttpClient _http;
        private CookieService _cookieService;

        public AuthService(HttpClient http, CookieService cookieService)
        {
            _http = http;
            _cookieService = cookieService;
        }

        public async Task CreateUserAsync(User user)
        {
            await _http.PostAsJsonAsync<User>("https://localhost:44395/api/users", user);
        }

        public async Task<bool> LogInAsync(string login, string password)
        {
            string sessionId = GetSessionId();
            var user = await _http.GetFromJsonAsync<User>($"https://localhost:44395/api/users/{login}/{password}");
            IEnumerable<CurrentUser> currentUsers;
            currentUsers = await _http.GetFromJsonAsync<IEnumerable<CurrentUser>>($"https://localhost:44395/api/currentuser");

            if (user.Id == 0)
                return false;

            if (currentUsers.Count<CurrentUser>() == 0)
            {
                await _cookieService.WriteAsync("SessionId", sessionId, 1);
                var currentUser = new CurrentUser();
                currentUser.DeptId = user.Profile.DeptId;
                currentUser.ProfileId = user.Profile.Id;
                currentUser.RankId = user.Profile.RankId;
                currentUser.UserId = user.Id;
                currentUser.SessionId = sessionId;
                await _http.PutAsJsonAsync<CurrentUser>($"https://localhost:44395/api/currentuser", currentUser);
                user.AuthDate = DateTime.Now;
                await _http.PutAsJsonAsync<User>($"https://localhost:44395/api/users", user);
                return true;
            }
            //await _http.PostAsJsonAsync<CurrentUser>("https://localhost:44395/api/currentuser", currentUser);
            return false;
        }

        public async Task LogOutAsync()
        {
            var currentUser = await GetCurrentUserAsync();

            //Console.WriteLine($"currentUser.DeptId: {currentUser.DeptId}");
            //Console.WriteLine($"currentUser.ProfileId: {currentUser.ProfileId}");
            //Console.WriteLine($"currentUser.RankId: {currentUser.RankId}");
            //Console.WriteLine($"currentUser.DeptId: {currentUser.DeptId}");
            Console.WriteLine($"currentUser: {currentUser.Id}, {currentUser.SessionId}");

            if (currentUser.Id > 0)
                await _http.DeleteAsync($"https://localhost:44395/api/currentuser/{currentUser.Id}");
        }

        public async Task<CurrentUser> GetCurrentUserAsync()
        {
            Console.WriteLine("GetCurrentUserAsync");
            string sessionId = await _cookieService.ReadAsync("SessionId");
            Console.WriteLine(sessionId);
            //return await _http.GetFromJsonAsync<CurrentUser>($"https://localhost:44395/api/currentuser/session/{sessionId}");
            return await _http.GetFromJsonAsync<CurrentUser>($"https://localhost:44395/api/currentuser/session/{sessionId}");
        }

        private string GetSessionId()
        {
            var data = Encoding.UTF8.GetBytes(Guid.NewGuid().ToString());
            return Convert.ToBase64String(data);
        }
    }
}