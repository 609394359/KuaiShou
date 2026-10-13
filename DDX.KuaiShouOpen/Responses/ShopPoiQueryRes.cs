/*
* ==============================================================================
*
* FileName: GoodlifeV1ShopPoiQueryRes.cs
* Created: 2026/6/3 16:41:15
* Author: yangqingde
* Description: 
*
* ==============================================================================
*/
using DDX.KuaiShouOpen.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DDX.KuaiShouOpen.Responses
{
    /// <summary>
    /// 商家查询门店信息
    /// https://open.kwailocallife.com/docs/api?apiName=goodlife.v1.shop.poi.query&version=1&cid=%E9%97%A8%E5%BA%97API_35057&cnName=%E9%97%A8%E5%BA%97%E4%BF%A1%E6%81%AF%E6%9F%A5%E8%AF%A2%E6%8E%A5%E5%8F%A3
    /// </summary>
    public class ShopPoiQueryRes : KuaiShouBaseRes<ShopPoiQueryData>
    {
    }



    public class ShopPoiQueryData : KuaiShouBaseData
    {
        /// <summary>
        /// 门店账户总条数
        /// </summary>
        [JsonPropertyName("total")]
        public long Total { get; set; }

        /// <summary>
        /// 门店列表
        /// </summary>
        [JsonPropertyName("pois")]
        public List<ShopPoiQueryPois> Pois { get; set; }
    }

    public class ShopPoiQueryPois
    {
        /// <summary>
        /// 门店poi详细信息
        /// </summary>
        [JsonPropertyName("poi")]
        public ShopPoiQueryPoi Poi { get; set; }
    }

    public class ShopPoiQueryPoi
    {
        /// <summary>
        /// 三方id
        /// </summary>
        [JsonPropertyName("third_id")]
        public string ThirdId { get; set; }

        /// <summary>
        /// 快手门店 POI ID
        /// </summary>
        [JsonPropertyName("poi_id")]
        public string PoiId { get; set; }

        /// <summary>
        /// 门店 POI 名称
        /// </summary>
        [JsonPropertyName("poi_name")]
        public string PoiName { get; set; }

        /// <summary>
        /// 门店地址
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; }

        /// <summary>
        /// 门店 POI 纬度
        /// </summary>
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        /// <summary>
        /// 门店 POI 经度
        /// </summary>
        [JsonPropertyName("longtitude")]
        public double Longtitude { get; set; }

        /// <summary>
        /// 关联类型：1 认领 2 关联
        /// </summary>
        [JsonPropertyName("rel_type")]
        public int? RelType { get; set; }

        /// <summary>
        /// 门店ID备注
        /// </summary>
        [JsonPropertyName("poi_id_remark")]
        public string PoiIdRemark { get; set; }
    }
}
