/*
* ==============================================================================
*
* FileName: GoodlifeV1ItemListBatchQueryRes.cs
* Created: 2026/6/4 10:57:57
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
    /// 商家批量查询商品列表
    /// https://open.kwailocallife.com/docs/api?apiName=goodlife.v1.item.itemlist.batch.query&version=1&cid=%E5%95%86%E5%93%81API_21245&cnName=%E6%89%B9%E9%87%8F%E6%9F%A5%E8%AF%A2%E5%95%86%E5%93%81%E5%88%97%E8%A1%A8
    /// </summary>
    public class ItemListBatchQueryRes : KuaiShouBaseRes<ItemListBatchQueryData>
    {
    }

    public class ItemListBatchQueryData: KuaiShouBaseData
    {
        /// <summary>
        /// 商品类目列表（对应图中的具体商品信息列表）
        /// </summary>
        [JsonPropertyName("item_list")]
        public List<ItemListBatchQueryItemInfo> ItemList { get; set; }

        /// <summary>
        /// 若有下一页，通过此cursor查询下一页
        /// </summary>
        [JsonPropertyName("next_cursor")]
        public long NextCursor { get; set; }

        /// <summary>
        /// 是否有下一页
        /// </summary>
        [JsonPropertyName("has_more")]
        public bool HasMore { get; set; }
    }

    public class ItemListBatchQueryItemInfo
    {
        /// <summary>
        /// 类目明细
        /// </summary>
        [JsonPropertyName("category_detail")]
        public ItemListBatchQueryCategoryDetail CategoryDetail { get; set; }

        /// <summary>
        /// 商品id
        /// </summary>
        [JsonPropertyName("product_id")]
        public long ProductId { get; set; }

        /// <summary>
        /// 商品类型 1-团购 11-代金券 21-次卡 31-日历票 41-兑换券
        /// </summary>
        [JsonPropertyName("product_type")]
        public int ProductType { get; set; }

        /// <summary>
        /// 外部商品id
        /// </summary>
        [JsonPropertyName("out_product_id")]
        public string OutProductId { get; set; }

        /// <summary>
        /// 商品在店铺状态 1-已上架 2-已下架 3-已售罄 5-删除
        /// </summary>
        [JsonPropertyName("status")]
        public int Status { get; set; }

        /// <summary>
        /// 商品审核状态 1-审核中 2-审核通过 4-审核驳回
        /// </summary>
        [JsonPropertyName("check_status")]
        public int CheckStatus { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [JsonPropertyName("product_name")]
        public string ProductName { get; set; }

        /// <summary>
        /// 售卖开始时间 (Unix时间戳)
        /// </summary>
        [JsonPropertyName("sold_start_time")]
        public long SoldStartTime { get; set; }

        /// <summary>
        /// 售卖结束时间 (Unix时间戳)
        /// </summary>
        [JsonPropertyName("sold_end_time")]
        public long SoldEndTime { get; set; }

        /// <summary>
        /// sku信息，最多返回10个
        /// </summary>
        [JsonPropertyName("sku")]
        public List<ItemListBatchQuerySkuInfo> SkuList { get; set; }

        /// <summary>
        /// sku的总个数
        /// </summary>
        [JsonPropertyName("sku_count")]
        public int SkuCount { get; set; }

        /// <summary>
        /// 商品属性KV
        /// </summary>
        [JsonPropertyName("attr_key_value_map")]
        public Dictionary<string, string> AttrKeyValueMap { get; set; }
    }

    public class ItemListBatchQueryCategoryDetail
    {
        /// <summary>
        /// 一级类目id
        /// </summary>
        [JsonPropertyName("first_cid")]
        public long FirstCid { get; set; }

        /// <summary>
        /// 二级类目id
        /// </summary>
        [JsonPropertyName("second_cid")]
        public long SecondCid { get; set; }

        /// <summary>
        /// 三级类目id
        /// </summary>
        [JsonPropertyName("third_cid")]
        public long ThirdCid { get; set; }

        /// <summary>
        /// 一级类目名称
        /// </summary>
        [JsonPropertyName("first_cname")]
        public string FirstCname { get; set; }

        /// <summary>
        /// 二级类目名称
        /// </summary>
        [JsonPropertyName("second_cname")]
        public string SecondCname { get; set; }

        /// <summary>
        /// 三级类目名称
        /// </summary>
        [JsonPropertyName("third_cname")]
        public string ThirdCname { get; set; }
    }

    public class ItemListBatchQuerySkuInfo
    {
        /// <summary>
        /// sku id
        /// </summary>
        [JsonPropertyName("sku_id")]
        public string SkuId { get; set; }

        /// <summary>
        /// 外部sku编码
        /// </summary>
        [JsonPropertyName("out_sku_id")]
        public string OutSkuId { get; set; }

        /// <summary>
        /// sku名
        /// </summary>
        [JsonPropertyName("sku_name")]
        public string SkuName { get; set; }

        /// <summary>
        /// 原价、市场价、划线价 (单位通常为分)
        /// </summary>
        [JsonPropertyName("origin_amount")]
        public long OriginAmount { get; set; }

        /// <summary>
        /// 团购价格 (单位通常为分)
        /// </summary>
        [JsonPropertyName("actual_amount")]
        public long ActualAmount { get; set; }

        /// <summary>
        /// 库存信息
        /// </summary>
        [JsonPropertyName("stock")]
        public ItemListBatchQueryStockInfo Stock { get; set; }

        /// <summary>
        /// sku属性
        /// </summary>
        [JsonPropertyName("attr_key_value_map")]
        public Dictionary<string, string> AttrKeyValueMap { get; set; }
    }

    public class ItemListBatchQueryStockInfo
    {
        /// <summary>
        /// 总库存 stock_qty = avail_qty + sold_qty
        /// </summary>
        [JsonPropertyName("stock_qty")]
        public int StockQty { get; set; }

        /// <summary>
        /// 可用库存
        /// </summary>
        [JsonPropertyName("avail_qty")]
        public int AvailQty { get; set; }

        /// <summary>
        /// 售卖库存，退款回滚
        /// </summary>
        [JsonPropertyName("sold_qty")]
        public int SoldQty { get; set; }
    }
}
