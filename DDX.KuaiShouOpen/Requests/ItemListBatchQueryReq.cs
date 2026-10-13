/*
* ==============================================================================
*
* FileName: GoodlifeV1ItemListBatchQueryReq.cs
* Created: 2026/6/4 10:52:07
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
    /// 商家批量查询商品列表
    /// https://open.kwailocallife.com/docs/api?apiName=goodlife.v1.item.itemlist.batch.query&version=1&cid=%E5%95%86%E5%93%81API_21245&cnName=%E6%89%B9%E9%87%8F%E6%9F%A5%E8%AF%A2%E5%95%86%E5%93%81%E5%88%97%E8%A1%A8
    /// </summary>
    public class ItemListBatchQueryReq
    {
        /// <summary>
        /// 商品 id 列表（可选）
        /// <para>若传参中有商品id, 则默认使用商品id进行查询。</para>
        /// <para>若要使用创建时间进行查询, 则商品id传参必须不传, 且 endTime 需大于 startTime, 且 endTime 和 startTime 都有数值值。</para>
        /// </summary>
        [JsonPropertyName("product_id")]
        public List<long> ProductId { get; set; }

        /// <summary>
        /// 商品创建开始时间，unix时间戳（可选）
        /// </summary>
        [JsonPropertyName("start_time")]
        public long? StartTime { get; set; }

        /// <summary>
        /// 商品创建结束时间，unix时间戳（可选）
        /// </summary>
        [JsonPropertyName("end_time")]
        public long? EndTime { get; set; }

        /// <summary>
        /// 查询游标（必填）
        /// <para>第一页查询传0，翻页查使用上一次查询返回的 cursor</para>
        /// </summary>
        [JsonPropertyName("cursor")]
        public long Cursor { get; set; }

        /// <summary>
        /// 每页数量（必填），取值范围 1-100
        /// </summary>
        [JsonPropertyName("size")]
        public long Size { get; set; }

        /// <summary>
        /// 外部商品 id 列表（可选）
        /// </summary>
        [JsonPropertyName("out_id")]
        public List<string> OutId { get; set; }

    }
}
