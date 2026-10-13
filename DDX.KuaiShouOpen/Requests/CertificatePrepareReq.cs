/*
* ==============================================================================
*
* FileName: CertificatePrepareReq.cs
* Created: 2026/6/4 11:20:51
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
    /// 验签准备
    /// https://open.kwailocallife.com/docs/api?apiName=goodlife.v1.fulfilment.certificate.prepare&version=1
    /// </summary>
    public class CertificatePrepareReq
    {
        /// <summary>
        /// 原始的快手团购券码（可选）
        /// <para>手动输入券码核销时，使用此参数。code/encrypted_short_code必须二选一</para>
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// 加密数据（可选）
        /// <para>该参数即将废弃，请新对接投资者使用 encrypted_short_code</para>
        /// </summary>
        [JsonPropertyName("encrypted_data")]
        public string EncryptedData { get; set; }

        /// <summary>
        /// 扫描二维码后解析出的加密短码（可选）
        /// <para>例：https://ksurl.cn/T3KpHnB1，则取后缀T3KpHnB1。code/encrypted_short_code必须二选一</para>
        /// </summary>
        [JsonPropertyName("encrypted_short_code")]
        public string EncryptedShortCode { get; set; }


        /// <summary>
        /// 转换为查询参数字典
        /// </summary>
        public Dictionary<string, string> ToQueryParameters()
        {
            var dict = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(Code)) dict["code"] = Code;
            if (!string.IsNullOrEmpty(EncryptedData)) dict["encrypted_data"] = EncryptedData;
            if (!string.IsNullOrEmpty(EncryptedShortCode)) dict["encrypted_short_code"] = EncryptedShortCode;
            return dict;
        }
    }
}
