using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Web.Models;
using Web.Services.Interfaces;

namespace Web.Services
{
    public class UserService:IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserViewModel> GetUser()
        {
            return await _httpClient.GetFromJsonAsync<UserViewModel>("/api/user/getuser");
        }
    }
}
