using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace PasswordValidatorTests.Integration
{
    public class PasswordValidatorTest : IClassFixture<WebApplicationFactory<PasswordValidator.Startup>>
    {
        readonly HttpClient _client;

        public PasswordValidatorTest(WebApplicationFactory<PasswordValidator.Startup> fixture)
        {
            _client = fixture.CreateClient();
        }

        [Fact]
        public async Task Get_IsValid_WithValidPassword_ReturnsTrue()
        {
            var validPassword = "AbTp9!fok";
            var response = await _client.GetAsync($"api/password/{validPassword}/is-valid");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);           

            var isValid = JsonConvert.DeserializeObject<bool>(await response.Content.ReadAsStringAsync());
            Assert.True(isValid);
        }

        [Fact]
        public async Task Get_IsValid_WithInvalidRequest_ReturnsFalse()
        {
            var response = await _client.GetAsync("api/password/ /is-valid");
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Theory]
        [InlineData("aa")]
        [InlineData("ab")]
        [InlineData("AAAbbbCc")]
        [InlineData("AbTp9!foo")]
        [InlineData("AbTp9!foA")]
        [InlineData("AbTp9 fok")]
        public async Task Get_IsValid_WithInvalidPassword_ReturnsFalse(string invalidPassword)
        {
            var response = await _client.GetAsync($"api/password/{invalidPassword}/is-valid");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var isValid = JsonConvert.DeserializeObject<bool>(await response.Content.ReadAsStringAsync());
            Assert.False(isValid);
        }
    }
}
