/*
* ==============================================================================
*
* FileName: KuaiShouOption.cs
* Created: 2026/6/3 15:53:03
* Author: yangqingde
* Description: 
*
* ==============================================================================
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDX.KuaiShouOpen.Config
{
    /// <summary>
    /// 快手平台配置
    /// </summary>
    public class KuaiShouOption
    {
        /// <summary>
        /// 开发者appKey
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// 开发者的appSecret
        /// </summary>
        public string AppSecret { get; set; }

        /// <summary>
        /// AccountId
        /// </summary>
        public long? AccountId { get; set; }

        /// <summary>
        /// Token 缓存 Key
        /// </summary>
        public string TokenKey => "KuaiShouOpenCache:Client:AccessToken:{0}";

        /// <summary>
        /// 读取缓存
        /// </summary>
        public Func<string, KuaiShouAccessToken> CacheGet { get; set; } = null!;

        /// <summary>
        /// 设置缓存（key, value, 过期秒数）
        /// </summary>
        public Action<string, KuaiShouAccessToken, int> CacheSet { get; set; } = null!;

        public bool AutoRefreshToken { get; set; } = true;
        public Action<string> HttpResponse { get; set; } = null!;
        public Action<string> HttpRequest { get; set; } = null!;
    }
}
