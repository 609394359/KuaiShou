/*
* ==============================================================================
*
* FileName: KuaiShouAccessToken.cs
* Created: 2026/6/3 15:57:34
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

namespace DDX.KuaiShouOpen
{
    /// <summary>
    /// 快手AccessToken
    /// </summary>
    public class KuaiShouAccessToken
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
        /// Token
        /// </summary>
        public string AccessToken { get; set; }
        /// <summary>
        /// refresh_token
        /// </summary>
        public string RefreshToken { get; set; }
        /// <summary>
        /// 超时时间（秒）
        /// </summary>
        public long ExpiresIn { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime? ExpiresTime { get; set; }
    }
}
