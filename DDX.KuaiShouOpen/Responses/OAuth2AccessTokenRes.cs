/*
* ==============================================================================
*
* FileName: OAuth2AccessTokenRes.cs
* Created: 2026/6/3 16:19:16
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

namespace DDX.KuaiShouOpen.Responses
{
    /// <summary>
    /// token 响应
    /// https://open.kwailocallife.com/docs/dev?pageSign=32e10b789418cf8854f0410e521b101a1673422499895
    /// </summary>
    public class OAuth2AccessTokenRes
    {
        /// <summary>
        /// 返回结果类型，1为正确，其他为不正确
        /// </summary>
        [JsonPropertyName("result")]
        public int Result { get; set; }

        /// <summary>
        /// 错误详情，用于提示具体的错误原因
        /// </summary>
        [JsonPropertyName("error_msg")]
        public string ErrorMsg { get; set; }

        /// <summary>
        /// 临时访问令牌，作为调用授权API时的入参，过期时间为expires_in值，授权用户、app和权限组范围唯一决定一个access_token值
        /// </summary>
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// 长时访问令牌，默认为180天，授权用户、app和权限组范围唯一决定一个refresh_token值
        /// </summary>
        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// 用户对该开发者的唯一身份标识
        /// </summary>
        [JsonPropertyName("open_id")]
        public string OpenId { get; set; }

        /// <summary>
        /// access_token过期时间，单位秒，默认为172800，即48小时
        /// </summary>
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        /// <summary>
        /// 本次授权中，用户允许的授权权限范围，即access_token和refresh_token中包含的scopes
        /// </summary>
        [JsonPropertyName("scopes")]
        public List<string> Scopes { get; set; }

        public bool IsSuccess => Result == 1;
    }
}
