using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Course.Shared.Utilities.Dtos;
using Microsoft.AspNetCore.Http;
using Web.Models.PhotoStocks;
using Web.Services.Interfaces;

namespace Web.Services
{
    public class PhotoStockService:IPhotoStockService
    {
        private readonly HttpClient _httpClient;

        public PhotoStockService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PhotoViewModel> UploadPhoto(IFormFile photo)
        {
            if (photo == null || photo.Length <= 0)
            {
                return null;
            }

            var randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(photo.FileName)}";

            using var memoryStream = new MemoryStream();
            await photo.CopyToAsync(memoryStream);

            var multiPartContent = new MultipartFormDataContent();
            multiPartContent.Add(new ByteArrayContent(memoryStream.ToArray()),"photo",randomFileName);

            var response = await _httpClient.PostAsync("photos", multiPartContent);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess =  await response.Content.ReadFromJsonAsync<Response<PhotoViewModel>>();
            return responseSuccess.Data;

        }

        public async Task<bool> DeletePhoto(string photoUrl)
        {
            var response = await _httpClient.DeleteAsync($"photos?photoUrl={photoUrl}");
            return response.IsSuccessStatusCode;
        }
    }
}
