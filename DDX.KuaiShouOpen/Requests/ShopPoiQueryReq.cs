/*
* ==============================================================================
*
* FileName: GoodlifeV1ShopPoiQueryReq.cs
* Created: 2026/6/3 16:32:36
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
    /// 商家查询门店信息
    /// https://open.kwailocallife.com/docs/api?apiName=goodlife.v1.shop.poi.query&version=1&cid=%E9%97%A8%E5%BA%97API_35057&cnName=%E9%97%A8%E5%BA%97%E4%BF%A1%E6%81%AF%E6%9F%A5%E8%AF%A2%E6%8E%A5%E5%8F%A3
    /// </summary>
    public class ShopPoiQueryReq
    {
        /// <summary>
        /// 三方ID（可选）
        /// </summary>
        [JsonPropertyName("third_id")]
        public long? ThirdId { get; set; }

        /// <summary>
        /// 本地生活账户ID（可选）
        /// </summary>
        [JsonPropertyName("account_id")]
        public long? AccountId { get; set; }

        /// <summary>
        /// 页大小，最大100个（必填）
        /// </summary>
        [JsonPropertyName("size")]
        public int Size { get; set; } = 10;

        /// <summary>
        /// 页码，从1开始（必填）
        /// </summary>
        [JsonPropertyName("page")]
        public int Page { get; set; } = 1;

        /// <summary>
        /// 快手门店POI_ID（可选）
        /// </summary>
        [JsonPropertyName("poi_id")]
        public long? PoiId { get; set; }

        /// <summary>
        /// 转换为查询参数字典
        /// </summary>
        public Dictionary<string, string> ToQueryParameters()
        {
            var dict = new Dictionary<string, string>();
            if (ThirdId.HasValue) dict["third_id"] = ThirdId.ToString();
            if (AccountId.HasValue) dict["account_id"] = AccountId.ToString();
            dict["size"] = Size.ToString();
            dict["page"] = Page.ToString();
            if (PoiId.HasValue) dict["poi_id"] = PoiId.ToString();
            return dict;
        }
    }
}
