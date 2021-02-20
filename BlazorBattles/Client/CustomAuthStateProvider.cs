using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorBattles.Client
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly HttpClient _http;


        public CustomAuthStateProvider(ILocalStorageService localStorageService, HttpClient http)
        {
            _localStorageService = localStorageService;
            _http = http;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            var state = new AuthenticationState(new ClaimsPrincipal());

            if (await _localStorageService.GetItemAsync<bool>("isAuthenticated"))
            {
                var identity = new ClaimsIdentity(
                new []
                {
                    new Claim(ClaimTypes.Name, "Georg")
                }, "Test auth type");
            var user = new ClaimsPrincipal(identity);
            state = new AuthenticationState(user);

            NotifyAuthenticationStateChanged(Task.FromResult(state));
            return state;
            }

            NotifyAuthenticationStateChanged(Task.FromResult(state));
            return state;
        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "==";
                    break;
                case 3: base64 += "=";
                    break;
            }

            return Convert.FromBase64String(base64);
        }

        public IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split(".")[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            var claims = keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));

            return claims;
        }
    }
}