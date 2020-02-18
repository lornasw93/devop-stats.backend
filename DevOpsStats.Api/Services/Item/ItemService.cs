﻿using System.Net.Http;
using System.Threading.Tasks;
using DevOpsStats.Api.Extensions;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Models.Build;
using Newtonsoft.Json;

namespace DevOpsStats.Api.Services.Item
{
    public class ItemService : IItemService
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string HttpClientName = "devOpsHttpClient";

        public ItemService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        private async Task<string> GetResponseWithApiVersion(string resourceUrl)
        {
            var client = _clientFactory.CreateClient(HttpClientName);
            var response = client.GetAsyncWithApiVersion(resourceUrl);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        private async Task<string> GetResponse(string resourceUrl)
        {
            var client = _clientFactory.CreateClient(HttpClientName);
            var response = client.GetAsync(resourceUrl).Result;

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<ListCount> Count(string resourceUrl)
        {
            var response = await GetResponse(resourceUrl);
            return JsonConvert.DeserializeObject<ListCount>(response);

        }

        public async Task<ListObject> List(string resourceUrl)
        {
            var response = await GetResponseWithApiVersion(resourceUrl);
            return JsonConvert.DeserializeObject<ListObject>(response);
        }
    }
}