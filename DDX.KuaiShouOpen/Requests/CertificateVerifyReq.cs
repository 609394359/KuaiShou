/*
* ==============================================================================
*
* FileName: CertificateVerifyReq.cs
* Created: 2026/6/4 11:37:12
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
    /// 验签
    /// https://open.kwailocallife.com/docs/api?apiName=goodlife.v1.fulfilment.certificate.verify&version=1
    /// </summary>
    public class CertificateVerifyReq
    {
        /// <summary>
        /// 一次验券的标识（用于短时间内的幂等）（必填）
        /// <para>平台券的 verify_token 由验券准备接口返回；三方券的 verify_token 由开发者自主生成，多次验券 verify_token 的值要有变化。</para>
        /// </summary>
        [JsonPropertyName("verify_token")]
        public string VerifyToken { get; set; }

        /// <summary>
        /// 核销的快手门店id（必填）
        /// </summary>
        [JsonPropertyName("poi_id")]
        public string PoiId { get; set; }

        /// <summary>
        /// 验券准备接口返回的加密快手券码（可选）
        /// </summary>
        [JsonPropertyName("encrypted_codes")]
        public List<string> EncryptedCodes { get; set; }

        /// <summary>
        /// 三方原始券码值列表（可选）
        /// <para>(encrypted_codes / codes / code_with_time_list 必须三选一)</para>
        /// </summary>
        [JsonPropertyName("codes")]
        public List<string> Codes { get; set; }

        /// <summary>
        /// 快手订单号（必填）
        /// </summary>
        [JsonPropertyName("order_id")]
        public string OrderId { get; set; }

        /// <summary>
        /// 带有核销时间的三方码列表（可选）
        /// <para>如果 code_with_time_list 和 codes 同时传，本字段优先级更高</para>
        /// </summary>
        [JsonPropertyName("code_with_time_list")]
        public List<CodeWithTimeItem> CodeWithTimeList { get; set; }

        /// <summary>
        /// 外部订单ID（可选）
        /// </summary>
        [JsonPropertyName("out_order_id")]
        public string OutOrderId { get; set; }

        /// <summary>
        /// 快手侧的券唯一id。如果是单一码场景，只能使用此字段核销，不能用code（可选）
        /// </summary>
        [JsonPropertyName("certificate_ids")]
        public List<string> CertificateIds { get; set; }

        /// <summary>
        /// 一单一码场景，发券回调时若不记录快手券唯一id即certificate_id，核销时则使用此参数（可选）
        /// </summary>
        [JsonPropertyName("code_with_biz_info")]
        public CodeWithBizInfo CodeWithBizInfo { get; set; }
    }

    public class CodeWithTimeItem
    {
        /// <summary>
        /// 三方码（可选）
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// 核销时间戳（秒）（可选）
        /// </summary>
        [JsonPropertyName("verify_time")]
        public long? VerifyTime { get; set; }

        /// <summary>
        /// 验签（可选）
        /// </summary>
        [JsonPropertyName("verify_sign_list")]
        public List<string> VerifySignList { get; set; }
    }

    public class CodeWithBizInfo
    {
        /// <summary>
        /// 核销凭证code，每次核销都传发券时唯一相同的code（必填）
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// 核销流水，长期幂等标识。订单维度唯一，不支持跨订单使用（必填）
        /// </summary>
        [JsonPropertyName("verify_biz_id")]
        public string VerifyBizId { get; set; }

        /// <summary>
        /// 本次核销数量（必填）
        /// </summary>
        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}
