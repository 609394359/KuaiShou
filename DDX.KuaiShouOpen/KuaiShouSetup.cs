/*
* ==============================================================================
*
* FileName: KuaiShouSetup.cs
* Created: 2026/6/3 17:31:47
* Author: yangqingde
* Description: 
*
* ==============================================================================
*/
using DDX.KuaiShouOpen.ApiRequest;
using DDX.KuaiShouOpen.Config;
using DDX.KuaiShouOpen.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDX.KuaiShouOpen
{
    /// <summary>
    /// 快手服务注册
    /// </summary>
    public static class KuaiShouSetup
    {
        /// <summary>
        /// 添加快手开放平台服务
        /// </summary>
        /// <param name="service"></param>
        /// <param name="option">配置项</param>
        public static void AddDouyin(this IServiceCollection service, KuaiShouOption option)
        {
            service.AddHttpClient("KuaiShouApi", httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://lbs-open.kwailocallife.com/");
            });
            service.AddHttpClient("KuaiShouOAuth", httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://lbs-open.kuaishou.com/");
            });
            service.AddSingleton(option);

            service.AddScoped<IKuaiShouApiRequest, KuaiShouApiRequest>();
            service.AddScoped<IKuaiShouService, KuaiShouService>();
        }
    }
}
