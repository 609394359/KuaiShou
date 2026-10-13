using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDX.KuaiShouOpen.ApiRequest
{
    public interface IKuaiShouApiRequest
    {
        /// <summary>
        /// GET 请求
        /// </summary>
        /// <param name="endpoint">接口路径</param>
        /// <param name="parameters">查询参数</param>
        /// <param name="accessToken">访问令牌</param>
        /// <typeparam name="TResponse"></typeparam>
        /// <returns></returns>
        Task<TResponse> GetAsync<TResponse>(string endpoint, Dictionary<string, string> parameters, string accessToken, string httpClientName = "KuaiShouApi");

        /// <summary>
        /// POST 请求（JSON Body）
        /// </summary>
        /// <param name="endpoint">接口路径</param>
        /// <param name="data">请求体</param>
        /// <param name="accessToken">访问令牌</param>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <returns></returns>
        Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest data, string accessToken, string httpClientName = "KuaiShouApi");
    }
}
