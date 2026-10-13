/*
* ==============================================================================
*
* FileName: CertificatePrepareRes.cs
* Created: 2026/6/4 11:26:45
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
    /// 验签准备
    /// https://open.kwailocallife.com/docs/api?apiName=goodlife.v1.fulfilment.certificate.prepare&version=1
    /// </summary>
    public class CertificatePrepareRes : KuaiShouBaseRes<CertificatePrepareData>
    {
    }

    public class CertificatePrepareData : KuaiShouBaseData
    {
        /// <summary>
        /// 一次验券的标识，在验券接口传入
        /// </summary>
        [JsonPropertyName("verify_token")]
        public string VerifyToken { get; set; }

        /// <summary>
        /// 快手订单id
        /// </summary>
        [JsonPropertyName("order_id")]
        public string OrderId { get; set; }

        /// <summary>
        /// 可用团购券列表
        /// </summary>
        [JsonPropertyName("certificates")]
        public List<CertificatePrepareCertificateInfo> Certificates { get; set; }
    }

    public class CertificatePrepareCertificateInfo
    {
        /// <summary>
        /// 加密密码
        /// </summary>
        [JsonPropertyName("encrypted_code")]
        public string EncryptedCode { get; set; }

        /// <summary>
        /// 券码有效期，截至时间，时间戳，单位秒
        /// </summary>
        [JsonPropertyName("expire_time")]
        public long ExpireTime { get; set; }

        /// <summary>
        /// 金额信息
        /// </summary>
        [JsonPropertyName("amount")]
        public CertificatePrepareAmountInfo Amount { get; set; }

        /// <summary>
        /// 团购信息
        /// </summary>
        [JsonPropertyName("sku")]
        public CertificatePrepareSkuInfo Sku { get; set; }

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

    public class CertificatePrepareAmountInfo
    {
        /// <summary>
        /// 商品团购价，单位分
        /// </summary>
        [JsonPropertyName("original_amount")]
        public int OriginalAmount { get; set; }

        /// <summary>
        /// 用户实付金额，单位分
        /// </summary>
        [JsonPropertyName("pay_amount")]
        public int PayAmount { get; set; }

        /// <summary>
        /// 商家营销金额，单位分
        /// </summary>
        [JsonPropertyName("merchant_ticket_amount")]
        public int MerchantTicketAmount { get; set; }

        /// <summary>
        /// 支付优惠金额，单位分
        /// </summary>
        [JsonPropertyName("payment_discount_amount")]
        public int PaymentDiscountAmount { get; set; }

        /// <summary>
        /// 券实付金额（=用户实付金额+支付优惠金额），单位分
        /// </summary>
        [JsonPropertyName("coupon_pay_amount")]
        public int CouponPayAmount { get; set; }

        /// <summary>
        /// 平台营销金额，单位分
        /// </summary>
        [JsonPropertyName("platform_ticket_amount")]
        public int PlatformTicketAmount { get; set; }

        /// <summary>
        /// 商品原价/市场价，单位分
        /// </summary>
        [JsonPropertyName("market_price")]
        public int MarketPrice { get; set; }
    }

    public class CertificatePrepareSkuInfo
    {
        /// <summary>
        /// 团购SKU ID
        /// </summary>
        [JsonPropertyName("sku_id")]
        public string SkuId { get; set; }

        /// <summary>
        /// 团购名称
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// 团购类型（1 团餐；2 代金券；21 次卡）
        /// </summary>
        [JsonPropertyName("groupon_type")]
        public int GrouponType { get; set; }

        /// <summary>
        /// 团购市场价，单位分
        /// </summary>
        [JsonPropertyName("market_price")]
        public long MarketPrice { get; set; }

        /// <summary>
        /// 团购售卖开始时间，时间戳，单位秒
        /// </summary>
        [JsonPropertyName("sold_start_time")]
        public long SoldStartTime { get; set; }

        /// <summary>
        /// 商家系统（第三方）团购id
        /// </summary>
        [JsonPropertyName("third_sku_id")]
        public string ThirdSkuId { get; set; }

        /// <summary>
        /// 商家团购账号id
        /// </summary>
        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }

        /// <summary>
        /// 次卡商品总次数，非次卡商品次数为1
        /// </summary>
        [JsonPropertyName("times_count")]
        public int TimesCount { get; set; }
    }
}
