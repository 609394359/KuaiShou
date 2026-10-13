/*
* ==============================================================================
*
* FileName: CertificateVerifyRes.cs
* Created: 2026/6/4 11:44:31
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
    /// 验签
    /// https://open.kwailocallife.com/docs/api?apiName=goodlife.v1.fulfilment.certificate.verify&version=1
    /// </summary>
    public class CertificateVerifyRes : KuaiShouBaseRes<CertificateVerifyData>
    {
    }

    public class CertificateVerifyData : KuaiShouBaseData
    {
        /// <summary>
        /// 验券结果列表
        /// </summary>
        [JsonPropertyName("verify_results")]
        public List<CertificateVerifyResultItem> VerifyResults { get; set; }
    }

    public class CertificateVerifyResultItem
    {
        /// <summary>
        /// 验券结果码，0表示成功，非0表示失败
        /// </summary>
        [JsonPropertyName("result")]
        public long Result { get; set; }

        /// <summary>
        /// 验券结果说明
        /// </summary>
        [JsonPropertyName("msg")]
        public string Msg { get; set; }

        /// <summary>
        /// 代表验券传入的 code 或 encrypted_code
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// 代表券码一次核销的标识（撤销时需要）
        /// </summary>
        [JsonPropertyName("verify_id")]
        public string VerifyId { get; set; }

        /// <summary>
        /// 代表一张券码的标识（撤销时需要）
        /// </summary>
        [JsonPropertyName("certificate_id")]
        public string CertificateId { get; set; }

        /// <summary>
        /// 原始券码
        /// </summary>
        [JsonPropertyName("origin_code")]
        public string OriginCode { get; set; }

        /// <summary>
        /// 代表商家总店 id（查询验券历史时需要）
        /// </summary>
        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }

        /// <summary>
        /// 验券结果通知：true 异常，false 非异常
        /// </summary>
        [JsonPropertyName("is_abnormal")]
        public bool IsAbnormal { get; set; }

        /// <summary>
        /// 核销金额信息，仅核销成功有值，全部为券维度拆分金额
        /// </summary>
        [JsonPropertyName("verify_amount_info")]
        public CertificateVerifyAmountInfo VerifyAmountInfo { get; set; }

        /// <summary>
        /// 次卡类型 0：非次卡 1：普通次卡 2：阶梯次卡
        /// </summary>
        [JsonPropertyName("times_card_type")]
        public int TimesCardType { get; set; }

        /// <summary>
        /// 阶梯次卡次序
        /// </summary>
        [JsonPropertyName("voucher_seq")]
        public int VoucherSeq { get; set; }
    }

    public class CertificateVerifyAmountInfo
    {
        /// <summary>
        /// 券原始金额/团购价，单位分
        /// </summary>
        [JsonPropertyName("original_amount")]
        public long OriginalAmount { get; set; }

        /// <summary>
        /// 用户支付金额，单位分
        /// </summary>
        [JsonPropertyName("pay_amount")]
        public long PayAmount { get; set; }

        /// <summary>
        /// 商家营销金额，单位分
        /// </summary>
        [JsonPropertyName("merchant_ticket_amount")]
        public long MerchantTicketAmount { get; set; }

        /// <summary>
        /// 市场价/划线价，单位分
        /// </summary>
        [JsonPropertyName("market_amount")]
        public long MarketAmount { get; set; }

        /// <summary>
        /// 平台营销金额，单位分
        /// </summary>
        [JsonPropertyName("platform_ticket_amount")]
        public long PlatformTicketAmount { get; set; }
    }
}
