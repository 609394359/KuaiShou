/*
* ==============================================================================
*
* FileName: IKuaiShouService.cs
* Created: 2026/6/3 17:09:18
* Author: yangqingde
* Description: 
*
* ==============================================================================
*/
using DDX.KuaiShouOpen.Requests;
using DDX.KuaiShouOpen.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDX.KuaiShouOpen.Services
{
    public interface IKuaiShouService
    {


        #region 券码

        /// <summary>
        /// 验签准备
        /// https://open.kwailocallife.com/docs/api?apiName=goodlife.v1.fulfilment.certificate.prepare&version=1
        /// </summary>
        Task<CertificatePrepareData> CertificatePrepare(CertificatePrepareReq request);

        /// <summary>
        /// 验签
        /// https://open.kwailocallife.com/docs/api?apiName=goodlife.v1.fulfilment.certificate.verify&version=1
        /// </summary>
        Task<CertificateVerifyData> CertificateVerify(CertificateVerifyReq request);

        /// <summary>
        /// 验签
        /// https://open.kwailocallife.com/docs/api?apiName=goodlife.v1.fulfilment.certificate.verify&version=1
        /// </summary>
        Task<CertificateCancelData> CertificateCancel(CertificateCancelReq request);

        #endregion

        #region 商品

        /// <summary>
        /// 商品列表 — 查询商品信息
        /// </summary>
        Task<ItemListBatchQueryData> ItemQuery(ItemListBatchQueryReq request);

        /// <summary>
        /// 所有商品列表
        /// </summary>
        Task<List<ItemListBatchQueryItemInfo>> AllItemQuery();

        #endregion

        #region 门店

        /// <summary>
        /// 门店列表 — 查询门店信息
        /// </summary>
        Task<ShopPoiQueryData> ShopQuery(ShopPoiQueryReq request);

        /// <summary>
        /// 所有门店列表
        /// </summary>
        Task<List<ShopPoiQueryPois>> AllShopQuery();

        #endregion

        #region AccessToken

        /// <summary>
        /// 获取AccessToken
        /// </summary>
        Task<KuaiShouAccessToken> AccessToken(string code);

        /// <summary>
        /// 获取AccessToken
        /// </summary>
        Task<OAuth2AccessTokenRes> GetAccessToken(string code);

        /// <summary>
        /// 刷新AccessToken
        /// </summary>
        Task<KuaiShouAccessToken> RefreshToken(string refresh_token);

        /// <summary>
        /// 刷新AccessToken
        /// </summary>
        Task<OAuth2RefreshTokenRes> GetRefreshToken(string refresh_token);

        /// <summary>
        /// 获取 access_token（优先从缓存读取）
        /// </summary>
        Task<string> GetAccessToken();

        #endregion
    }
}
