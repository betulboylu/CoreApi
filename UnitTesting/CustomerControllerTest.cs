using CoreApi.Controllers;
using Data;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTesting
{
    public class CustomerControllerTest : IClassFixture<WebApplicationFactory<CoreApi.Startup>>
    {
        readonly HttpClient _client;

        public CustomerControllerTest(WebApplicationFactory<CoreApi.Startup> fixture)
        {
            _client = fixture.CreateClient();
        }

        [Fact]
        public async Task GetCustomer_ShouldReturnCorrectCustomer()
        {
            var testCustomers = GetTestCustomers();

            var response = await _client.GetAsync("/api/customer/2");
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
            var customer = JsonConvert.DeserializeObject<Customer>(await response.Content.ReadAsStringAsync());
            customer.ShouldNotBeNull();
            customer.Name.ShouldBeEquivalentTo(testCustomers[1].Name);
        }

        [Fact]
        public async Task AddTestCustomer_ShouldReturnAddedCustomer()
        {
            Customer customer = new Customer
            {
                Name = "Erkan",
                Phone = "05557775555",
                Email = "e@e.com"
            };
            string postData = JsonConvert.SerializeObject(customer);
          
            HttpContent content = new StringContent(postData, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/customer", content);

            response.StatusCode.ShouldBe(HttpStatusCode.OK);
            var customerNew = JsonConvert.DeserializeObject<Customer>(await response.Content.ReadAsStringAsync());
            customerNew.Name.ShouldBe("Erkan");
        }

        [Fact]
        public async Task DeleteCustomer_ShouldUpdateCustomer()
        {
            var response = await _client.DeleteAsync("api/delete/3");
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task UpdateTestCustomer_ShouldReturnUpdatedCustomer()
        {
            var patchDoc = new JsonPatchDocument<Customer>();
            patchDoc.Replace(e => e.Name, "Mert");

            var serializedDoc = JsonConvert.SerializeObject(patchDoc);
            var requestContent = new StringContent(serializedDoc, Encoding.UTF8, "application/json");
            var response = await _client.PatchAsync("api/customer/2012", requestContent);
            response.StatusCode.ShouldBe(HttpStatusCode.OK);

            var newCustomer = JsonConvert.DeserializeObject<Customer>(await response.Content.ReadAsStringAsync());
            newCustomer.Name.ShouldBe("Mert");
        }

        private List<Customer> GetTestCustomers()
        {
            var testCustomers = new List<Customer>();
            testCustomers.Add(new Customer { Id = 1, Name = "Betul", Phone = "5555555555", Email= "Barry" });
            testCustomers.Add(new Customer { Id = 2, Name = "İlknur", Phone = "6666666666",
                Email = "test@test.com"});
            testCustomers.Add(new Customer { Id = 3, Name = "Barış", Phone = "7777777777",
                Email = "test@test.com"});
            testCustomers.Add(new Customer { Id = 4, Name = "İrfan", Phone = "8888885858",
                Email = "test@test.com"});

            return testCustomers;
        }

        [Fact]
        public async Task Get_All_Customers()
        {
            var response = await _client.GetAsync("/api/customer");
            response.StatusCode.ShouldBe(HttpStatusCode.OK);

            var customers = JsonConvert.DeserializeObject<Customer[]>(await response.Content.ReadAsStringAsync());
            customers.Length.ShouldBe(23);
        }
    }
}
