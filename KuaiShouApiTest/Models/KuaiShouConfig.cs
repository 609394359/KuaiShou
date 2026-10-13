/*
* ==============================================================================
*
* FileName: KuaiShouConfig.cs
* Created: 2026/6/5 17:40:17
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

namespace KuaiShouApiTest.Models
{
    public class KuaiShouConfig
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
        /// Token
        /// </summary>
        public string AccessToken { get; set; }
        /// <summary>
        /// refresh_token
        /// </summary>
        public string RefreshToken { get; set; }
    }
}
