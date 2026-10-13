/*
* ==============================================================================
*
* FileName: BaseRes.cs
* Created: 2026/6/3 16:42:43
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
    public class KuaiShouBaseRes<T> where T : KuaiShouBaseData
    {
        /// <summary>
        /// 网关信息
        /// </summary>
        [JsonPropertyName("extra")]
        public KuaiShouExtra Extra { get; set; }

        [JsonPropertyName("data")]
        public T Data { get; set; }
    }

    /// <summary>
    /// 抖音 API data 层公共字段
    /// </summary>
    public class KuaiShouBaseData
    {
        /// <summary>
        /// 错误码（0 表示成功）
        /// </summary>
        [JsonPropertyName("error_code")]
        public int ErrorCode { get; set; }

        /// <summary>
        /// 错误描述
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success => ErrorCode == 0;
    }

    public class KuaiShouExtra
    {
        /// <summary>
        /// 网关主返回码 0-成功,否则失败
        /// </summary>
        [JsonPropertyName("error_code")]
        public long ErrorCode { get; set; }

        /// <summary>
        /// 网关主返回信息
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// 业务错误返回码
        /// </summary>
        [JsonPropertyName("sub_error_code")]
        public long SubErrorCode { get; set; }

        /// <summary>
        /// 业务返回信息
        /// </summary>
        [JsonPropertyName("sub_description")]
        public string SubDescription { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        [JsonPropertyName("now")]
        public long Now { get; set; }

        /// <summary>
        /// 日志id
        /// </summary>
        [JsonPropertyName("logid")]
        public string Logid { get; set; }
    }
}
