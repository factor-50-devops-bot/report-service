﻿using HelpMyStreet.Contracts.ReportService.Response;
using Newtonsoft.Json;
using ReportingService.Core.Configuration;
using ReportingService.Core.Interfaces.Services;
using ReportingService.Core.Utils;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ReportingService.UserService
{
    public class ConnectUserService : IConnectUserService
    {
        private readonly IHttpClientWrapper _httpClientWrapper;

        public ConnectUserService(IHttpClientWrapper httpClientWrapper)
        {
            _httpClientWrapper = httpClientWrapper;
        }

        public async Task<GetReportResponse> GetReport()
        {
            GetReportResponse result;
            string path = $"/api/GetReport";
            string absolutePath = $"{path}";

            using (HttpResponseMessage response = await _httpClientWrapper.GetAsync(HttpClientConfigName.UserService, absolutePath, CancellationToken.None).ConfigureAwait(false))
            {
                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<GetReportResponse>(content);
            }

            return result;
        }
    }
}
