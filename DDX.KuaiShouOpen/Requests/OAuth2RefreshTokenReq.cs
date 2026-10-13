/*
* ==============================================================================
*
* FileName: OAuth2RefreshTokenReq.cs
* Created: 2026/6/3 16:14:55
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
    /// token 刷新请求
    /// https://open.kwailocallife.com/docs/dev?pageSign=32e10b789418cf8854f0410e521b101a1673422499895
    /// </summary>
    public class OAuth2RefreshTokenReq
    {
        /// <summary>
        /// 开发者appKey
        /// </summary>
        [JsonPropertyName("app_id")]
        public string AppId { get; set; }

        /// <summary>
        /// 授权的类型，必需是"refresh_token"
        /// </summary>
        [JsonPropertyName("grant_type")]
        public string GrantType { get; set; } = "refresh_token";

        /// <summary>
        /// refresh_token
        /// </summary>
        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

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
            if (!string.IsNullOrEmpty(RefreshToken)) dict["refresh_token"] = RefreshToken;
            if (!string.IsNullOrEmpty(AppSecret)) dict["app_secret"] = AppSecret;
            return dict;
        }
    }
}
