using BlazorNorthwindUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorNorthwindUI.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Add(ProductViewModel productViewModel)
        {
            await _httpClient.PostAsJsonAsync("https://localhost:5001/api/products/add", productViewModel);
        }

        public async Task<ProductViewModel> GetProductById(int productId)
        {
            return await _httpClient.GetFromJsonAsync<ProductViewModel>("https://localhost:5001/api/products/getbyid?id="+ productId);
          
        }

        public async Task<ProductListViewModel[]> GetProducts()
        {
            return await _httpClient.GetFromJsonAsync<ProductListViewModel[]>("https://localhost:5001/api/products/getall");
           
        }

        public async Task Save(ProductViewModel productViewModel)
        {
            await _httpClient.PostAsJsonAsync("https://localhost:5001/api/products/update", productViewModel);
        }
    }

}
