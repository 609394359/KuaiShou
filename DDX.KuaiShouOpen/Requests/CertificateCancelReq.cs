/*
* ==============================================================================
*
* FileName: CertificateCancelReq.cs
* Created: 2026/6/4 11:50:18
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
    /// 撤销核销
    /// https://open.kwailocallife.com/docs/api?apiName=goodlife.v1.fulfilment.certificate.cancel&version=1
    /// </summary>
    public class CertificateCancelReq
    {
        /// <summary>
        /// 代表券码一次核销的唯一标识（验券时返回）（必填）
        /// </summary>
        [JsonPropertyName("verify_id")]
        public string VerifyId { get; set; }

        /// <summary>
        /// 代表一张券码的标识（验券时返回）（必填）
        /// </summary>
        [JsonPropertyName("certificate_id")]
        public string CertificateId { get; set; }

        /// <summary>
        /// 更新券码（可选）
        /// <para>如有撤销核销后变更券码的需求场景，则使用此参数</para>
        /// </summary>
        [JsonPropertyName("new_code")]
        public string NewCode { get; set; }

        /// <summary>
        /// 订单号（可选）
        /// <para>用 code_with_biz_cancel_info 撤销核销时，必传</para>
        /// </summary>
        [JsonPropertyName("order_id")]
        public long? OrderId { get; set; }

        /// <summary>
        /// 核销时若使用 code_with_biz_info 核销，撤销核销用此参数（可选）
        /// </summary>
        [JsonPropertyName("code_with_biz_cancel_info")]
        public CodeWithBizCancelInfo CodeWithBizCancelInfo { get; set; }
    }
    public class CodeWithBizCancelInfo
    {
        /// <summary>
        /// 核销流水，核销时使用的核销流水幂等键（必填）
        /// </summary>
        [JsonPropertyName("verify_biz_id")]
        public string VerifyBizId { get; set; }

        /// <summary>
        /// 撤销核销流水（必填）
        /// </summary>
        [JsonPropertyName("cancel_verify_biz_id")]
        public string CancelVerifyBizId { get; set; }

        /// <summary>
        /// 本次撤销核销数量（必填）
        /// <para>必须小于等于一次核销流水下的核销数量</para>
        /// </summary>
        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}
