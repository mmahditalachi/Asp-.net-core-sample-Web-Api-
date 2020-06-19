using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using SampleWebApi.Server;
using SampleWebApi.Shared;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Xunit;

namespace SampleWebApi.IntegrationTest
{
    public class EmployeeControllerTests
        : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient httpClient;
        private readonly CustomWebApplicationFactory<Startup> factory;

        public EmployeeControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
            httpClient = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Fact]
        public async void Test_Get_All_Employees()
        {
            var response = await httpClient.GetAsync("api/Employee/GetEmployees");

            response.EnsureSuccessStatusCode();

            //using FluentAssertions nuget package
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async void Test_Add_Employee()
        {

            var emp = new Employee()
            {
                FirstName = "Rana",
                LastName = "Goldmen",
                Email = "Rana@test.com",
                EmployeeId = 5
            };

            var employeepAsJson = JsonSerializer.Serialize(emp);

            var response = await httpClient.PostAsync("api/employee/AddEmployee",
                new StringContent(employeepAsJson, Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            //FluentAssertions nuget package
            response.StatusCode.Should().Be(HttpStatusCode.Created);

        }

        [Fact]
        public async void Test_Get_Employee()
        {

            var response = await httpClient.GetAsync($"api/employee/GetEmployee/{1}");

            response.EnsureSuccessStatusCode();

            //FluentAssertions nuget package
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }
    }
}
