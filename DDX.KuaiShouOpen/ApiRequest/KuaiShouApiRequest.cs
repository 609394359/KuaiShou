/*
* ==============================================================================
*
* FileName: KuaiShouApiRequest.cs
* Created: 2026/6/3 15:52:09
* Author: yangqingde
* Description: 
*
* ==============================================================================
*/
using DDX.KuaiShouOpen.Config;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DDX.KuaiShouOpen.ApiRequest
{
    public class KuaiShouApiRequest : IKuaiShouApiRequest
    {
        private readonly ILogger<KuaiShouApiRequest> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly KuaiShouOption _option;

        /// <summary>
        /// JSON 序列化配置（snake_case 命名）
        /// </summary>
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            PropertyNameCaseInsensitive = true
        };

        public KuaiShouApiRequest(IHttpClientFactory httpClientFactory, ILogger<KuaiShouApiRequest> logger, KuaiShouOption option)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _option = option;
        }

        /// <summary>
        /// GET 请求
        /// </summary>
        public async Task<TResponse> GetAsync<TResponse>(string endpoint, Dictionary<string, string> parameters, string accessToken, string httpClientName = "KuaiShouApi")
        {
            // 拼接查询参数
            var query = string.Join("&", parameters
                .Where(p => !string.IsNullOrEmpty(p.Value))
                .Select(p => $"{Uri.EscapeDataString(p.Key)}={Uri.EscapeDataString(p.Value)}"));

            /// 记录参数
            _option.HttpRequest?.Invoke(query);

            var url = string.IsNullOrEmpty(query) ? endpoint : $"{endpoint}?{query}";

            var httpClient = _httpClientFactory.CreateClient(httpClientName);
            httpClient.DefaultRequestHeaders.Remove("access-token");
            httpClient.DefaultRequestHeaders.Add("access-token", accessToken);

            var response = await httpClient.GetAsync(url);
            return await HandleResponse<TResponse>(response);
        }

        /// <summary>
        /// POST 请求（JSON Body）
        /// </summary>
        public async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest data, string accessToken, string httpClientName = "KuaiShouApi")
        {
            var json = JsonSerializer.Serialize(data, JsonOptions);

            /// 记录参数
            _option.HttpRequest?.Invoke(json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var httpClient = _httpClientFactory.CreateClient(httpClientName);
            httpClient.DefaultRequestHeaders.Remove("access-token");
            httpClient.DefaultRequestHeaders.Add("access-token", accessToken);

            try
            {
                var response = await httpClient.PostAsync(endpoint, content);
                return await HandleResponse<TResponse>(response);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "快手 API POST 请求异常: {Endpoint}", endpoint);
                throw;
            }
        }

        /// <summary>
        /// 处理响应并反序列化
        /// </summary>
        private async Task<TResponse> HandleResponse<TResponse>(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();

            /// 记录响应
            _option.HttpResponse?.Invoke(content);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("快手 API 错误响应: {Content}", content);
                throw new HttpRequestException($"快手 API 请求失败，HTTP 状态码: {response.StatusCode}");
            }

            return JsonSerializer.Deserialize<TResponse>(content, JsonOptions);
        }
    }
}
