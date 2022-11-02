using Newtonsoft.Json;
using System.Net;
using System;
using WebApiClient.Models;
using System.Net.Http.Headers;
using System.Net.Http;

namespace WebApiClient.Services
{
    public class ProductService
    {
        HttpClient client;
        string serviceUrl;
        LoginService loginService = new LoginService();

        public ProductService()
        {
            //conf["ProductServiceUrl"]
            client = new HttpClient();
            serviceUrl = @"https://localhost:7119/api/products";
            client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Bearer", loginService.GetToken());
        }

        public IEnumerable<Product> GetProducts()
        {
            var resp = client.GetAsync(serviceUrl).Result;
            var content = resp.Content.ReadAsStringAsync().Result;
            var prods = JsonConvert.DeserializeObject<List<Product>>(content);
            return prods;
        }

        public Product GetProduct(int id)
        {
            var resp = client.GetAsync(serviceUrl + $"/{id}").Result;
            var result = resp.Content.ReadAsStringAsync().Result;
            var prod = JsonConvert.DeserializeObject<Product>(result);
            return prod;
        }
        public HttpStatusCode AddProduct(Product prod)
        {
            var content = new StringContent(JsonConvert.SerializeObject(prod),
                System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(
                serviceUrl, content).Result;
            return response.StatusCode;
        }

        public void EditProduct(int id, Product prod)
        {
            var content = new StringContent(JsonConvert.SerializeObject(prod),
                System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(
                serviceUrl + $"/{id}", content).Result;
        }

        public void DeleteProduct(int id)
        {
            HttpResponseMessage response = client.DeleteAsync(
                serviceUrl + $"/{id}").Result;
        }



    }
}
