/*
* ==============================================================================
*
* FileName: OAuth2AccessTokenReq.cs
* Created: 2026/6/3 16:12:30
* Author: yangqingde
* Description: 
*
* ==============================================================================
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DDX.KuaiShouOpen.Requests
{
    /// <summary>
    /// 获取access_token
    /// https://open.kwailocallife.com/docs/dev?pageSign=32e10b789418cf8854f0410e521b101a1673422499895
    /// </summary>
    public class OAuth2AccessTokenReq
    {
        /// <summary>
        /// 开发者appKey
        /// </summary>
        [JsonPropertyName("app_id")]
        public string AppId { get; set; }

        /// <summary>
        /// 授权的类型 写死 "code"
        /// </summary>
        [JsonPropertyName("grant_type")]
        public string GrantType { get; set; } = "code";

        /// <summary>
        /// 临时授权票据
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// 开发者的appSecret
        /// </summary>
        [JsonPropertyName("app_secret")]
        public string AppSecret { get; set; }


        /// <summary>
        /// 转换为查询参数字典
        /// </summary>
        public Dictionary<string, string> ToQueryParameters()
        {
            var dict = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(AppId)) dict["app_id"] = AppId;
            if (!string.IsNullOrEmpty(GrantType)) dict["grant_type"] = GrantType;
            if (!string.IsNullOrEmpty(Code)) dict["code"] = Code;
            if (!string.IsNullOrEmpty(AppSecret)) dict["app_secret"] = AppSecret;
            return dict;
        }
    }
}
