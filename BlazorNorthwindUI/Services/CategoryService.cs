using BlazorNorthwindUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorNorthwindUI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CategoryListViewModel[]> GetCategories()
        {
            return await _httpClient.GetFromJsonAsync<CategoryListViewModel[]>("https://localhost:5001/api/categories/getall");
            
        }
    }

}
