/*
* ==============================================================================
*
* FileName: KuaiShouService.cs
* Created: 2026/6/3 17:09:32
* Author: yangqingde
* Description: 
*
* ==============================================================================
*/
using DDX.KuaiShouOpen.ApiRequest;
using DDX.KuaiShouOpen.Config;
using DDX.KuaiShouOpen.Requests;
using DDX.KuaiShouOpen.Responses;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DDX.KuaiShouOpen.Services
{
    public class KuaiShouService : IKuaiShouService
    {
        private readonly ILogger<KuaiShouService> _logger;
        private readonly IKuaiShouApiRequest _apiRequest;
        private readonly KuaiShouOption _option;
        private readonly IHttpClientFactory _httpClientFactory;

        public KuaiShouService(IKuaiShouApiRequest apiRequest, KuaiShouOption option, IHttpClientFactory httpClientFactory, ILogger<KuaiShouService> logger)
        {
            _apiRequest = apiRequest;
            _option = option;
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        #region 券码

        /// <summary>
        /// 验签准备
        /// https://open.kwailocallife.com/docs/api?apiName=goodlife.v1.fulfilment.certificate.prepare&version=1
        /// </summary>
        public async Task<CertificatePrepareData> CertificatePrepare(CertificatePrepareReq request)
        {
            if (!string.IsNullOrWhiteSpace(request.EncryptedShortCode) && (request.EncryptedShortCode.StartsWith("http://") || request.EncryptedShortCode.StartsWith("https://")))
            {
                var shortCode = request.EncryptedShortCode.Substring(request.EncryptedShortCode.LastIndexOf("/"));
                request.EncryptedShortCode = shortCode;
            }

            var token = await GetAccessToken();
            var endpoint = "goodlife/v1/fulfilment/certificate/prepare";
            var result = await _apiRequest.GetAsync<CertificatePrepareRes>(endpoint, request.ToQueryParameters(), token);
            CheckResponse(result);
            return result.Data;
        }

        /// <summary>
        /// 验签
        /// https://open.kwailocallife.com/docs/api?apiName=goodlife.v1.fulfilment.certificate.verify&version=1
        /// </summary>
        public async Task<CertificateVerifyData> CertificateVerify(CertificateVerifyReq request)
        {
            var token = await GetAccessToken();
            var endpoint = "goodlife/v1/fulfilment/certificate/verify";
            var result = await _apiRequest.PostAsync<CertificateVerifyReq, CertificateVerifyRes>(endpoint, request, token);
            CheckResponse(result);
            return result.Data;
        }

        /// <summary>
        /// 验签
        /// https://open.kwailocallife.com/docs/api?apiName=goodlife.v1.fulfilment.certificate.verify&version=1
        /// </summary>
        public async Task<CertificateCancelData> CertificateCancel(CertificateCancelReq request)
        {
            var token = await GetAccessToken();
            var endpoint = "goodlife/v1/fulfilment/certificate/verify";
            var result = await _apiRequest.PostAsync<CertificateCancelReq, CertificateCancelRes>(endpoint, request, token);
            CheckResponse(result);
            return result.Data;
        }

        #endregion

        #region 商品

        /// <summary>
        /// 商品列表 — 查询商品信息
        /// </summary>
        public async Task<ItemListBatchQueryData> ItemQuery(ItemListBatchQueryReq request)
        {
            var token = await GetAccessToken();
            var endpoint = "goodlife/v1/item/itemlist/batch/query";
            var result = await _apiRequest.PostAsync<ItemListBatchQueryReq, ItemListBatchQueryRes>(endpoint, request, token);
            CheckResponse(result);
            return result.Data;
        }

        /// <summary>
        /// 所有商品列表
        /// </summary>
        public async Task<List<ItemListBatchQueryItemInfo>> AllItemQuery()
        {
            var request = new ItemListBatchQueryReq()
            {
                Cursor = 0,
                Size = 100,
            };
            var token = await GetAccessToken();
            var endpoint = "goodlife/v1/item/itemlist/batch/query";
            var list = new List<ItemListBatchQueryItemInfo>();
            while (true)
            {
                var result = await _apiRequest.PostAsync<ItemListBatchQueryReq, ItemListBatchQueryRes>(endpoint, request, token);

                CheckResponse(result);

                if (result.Data.ItemList == null || result.Data.ItemList.Count <= 0)
                    return list;

                list.AddRange(result.Data.ItemList);

                if (!result.Data.HasMore)
                    return list;

                request.Cursor = result.Data.NextCursor;
            }
        }

        #endregion

        #region 门店

        /// <summary>
        /// 门店列表 — 查询门店信息
        /// </summary>
        public async Task<ShopPoiQueryData> ShopQuery(ShopPoiQueryReq request)
        {
            var token = await GetAccessToken();
            var endpoint = "goodlife/v1/shop/poi/query/";
            var result = await _apiRequest.GetAsync<ShopPoiQueryRes>(endpoint, request.ToQueryParameters(), token);
            CheckResponse(result);
            return result.Data;
        }

        /// <summary>
        /// 所有门店列表
        /// </summary>
        public async Task<List<ShopPoiQueryPois>> AllShopQuery()
        {
            var request = new ShopPoiQueryReq()
            {
                AccountId = _option.AccountId,
                Page = 1,
                Size = 100,
            };
            var token = await GetAccessToken();
            var endpoint = "goodlife/v1/shop/poi/query/";
            var list = new List<ShopPoiQueryPois>();
            while (true)
            {
                var result = await _apiRequest.GetAsync<ShopPoiQueryRes>(endpoint, request.ToQueryParameters(), token);

                CheckResponse(result);

                if (result.Data.Pois == null || result.Data.Pois.Count <= 0)
                    return list;

                list.AddRange(result.Data.Pois);

                if (result.Data.Total <= list.Count)
                    return list;

                request.Page++;
            }
        }

        #endregion

        #region AccessToken

        /// <summary>
        /// 获取AccessToken
        /// </summary>
        public async Task<KuaiShouAccessToken> AccessToken(string code)
        {
            var result = await GetAccessToken(code);
            var KuaiShouAccessToken = new KuaiShouAccessToken()
            {
                AppId = _option.AppId,
                AppSecret = _option.AppSecret,
                AccessToken = result.AccessToken,
                RefreshToken = result.RefreshToken,
                ExpiresIn = result.ExpiresIn,
                ExpiresTime = DateTime.Now.AddSeconds(result.ExpiresIn - 60) //过期时间提前60秒
            };

            //保存缓存
            var tokenKey = string.Format(_option.TokenKey, _option.AppId);
            // 缓存 Token（提前120秒过期，避免边界问题）
            var expiresIn = Math.Max(result.ExpiresIn - 120, 1);
            _option.CacheSet?.Invoke(tokenKey, KuaiShouAccessToken, expiresIn);

            return KuaiShouAccessToken;
        }

        /// <summary>
        /// 获取AccessToken
        /// </summary>
        public async Task<OAuth2AccessTokenRes> GetAccessToken(string code)
        {
            var request = new OAuth2AccessTokenReq
            {
                AppId = _option.AppId,
                AppSecret = _option.AppSecret,
                Code = code
            };
            var endpoint = "oauth2/access_token";
            var result = await _apiRequest.GetAsync<OAuth2AccessTokenRes>(endpoint, request.ToQueryParameters(), null, "KuaiShouOAuth");
            CheckResponse(result);
            return result;
        }

        /// <summary>
        /// 刷新AccessToken
        /// </summary>
        public async Task<KuaiShouAccessToken> RefreshToken(string refresh_token)
        {
            var result = await GetRefreshToken(refresh_token);

            var KuaiShouAccessToken = new KuaiShouAccessToken()
            {
                AppId = _option.AppId,
                AppSecret = _option.AppSecret,
                AccessToken = result.AccessToken,
                RefreshToken = result.RefreshToken,
                ExpiresIn = result.ExpiresIn,
                ExpiresTime = DateTime.Now.AddSeconds(result.ExpiresIn - 60) //过期时间提前60秒
            };

            //保存缓存
            var tokenKey = string.Format(_option.TokenKey, _option.AppId);
            // 缓存 Token（提前120秒过期，避免边界问题）
            var expiresIn = Math.Max(result.ExpiresIn - 120, 1);
            _option.CacheSet?.Invoke(tokenKey, KuaiShouAccessToken, expiresIn);

            return KuaiShouAccessToken;
        }

        /// <summary>
        /// 刷新AccessToken
        /// </summary>
        public async Task<OAuth2RefreshTokenRes> GetRefreshToken(string refresh_token)
        {
            var request = new OAuth2RefreshTokenReq
            {
                AppId = _option.AppId,
                AppSecret = _option.AppSecret,
                RefreshToken = refresh_token
            };
            var endpoint = "oauth2/refresh_token";
            var result = await _apiRequest.GetAsync<OAuth2RefreshTokenRes>(endpoint, request.ToQueryParameters(), null, "KuaiShouOAuth");
            CheckResponse(result);
            return result;
        }

        /// <summary>
        /// 获取 access_token（优先从缓存读取）
        /// </summary>
        public async Task<string> GetAccessToken()
        {
            var tokenKey = string.Format(_option.TokenKey, _option.AppId);
            // 尝试从缓存获取 Token
            var cachedToken = _option.CacheGet?.Invoke(tokenKey);

            if (cachedToken == null)
                throw new KuaiShouException("快手access_token为空，请先授权");

            if (_option.AutoRefreshToken && cachedToken.ExpiresTime < DateTime.Now.AddMinutes(10))
                cachedToken = await RefreshToken(cachedToken.RefreshToken);

            return cachedToken.AccessToken;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 检查响应结果，失败时抛出异常
        /// </summary>
        private void CheckResponse(OAuth2AccessTokenRes response)
        {
            if (response == null)
            {
                throw new KuaiShouException("获取快手access_token返回数据为空");
            }

            if (!response.IsSuccess)
                throw new KuaiShouException($"获取快手access_token错误: {response.Result},原因：{response.ErrorMsg}");
        }
        /// <summary>
        /// 检查响应结果，失败时抛出异常
        /// </summary>
        private void CheckResponse(OAuth2RefreshTokenRes response)
        {
            if (response == null)
            {
                throw new KuaiShouException("获取快手access_token返回数据为空");
            }

            if (!response.IsSuccess)
                throw new KuaiShouException($"获取快手access_token错误: {response.Result},原因：{response.ErrorMsg}");
        }
        /// <summary>
        /// 检查响应结果，失败时抛出异常
        /// </summary>
        private void CheckResponse<T>(KuaiShouBaseRes<T> response) where T : KuaiShouBaseData
        {
            if (response == null)
            {
                throw new KuaiShouException("快手 API 返回数据为空");
            }

            // 检查 extra 层错误
            if (response.Extra != null && response.Extra.ErrorCode != 0)
            {
                _logger.LogError($"快手 API 错误 [extra]: error_code={response.Extra.ErrorCode}, " +
                                 $"description={response.Extra.Description}, " +
                                 $"sub_error_code={response.Extra.SubErrorCode}, " +
                                 $"sub_description={response.Extra.SubDescription}, " +
                                 $"logid={response.Extra.Logid}");
                throw new KuaiShouException(
                    $"快手API错误：{response.Extra.ErrorCode}, " +
                    $"原因：{response.Extra.Description}");
            }

            // 检查 data 层错误
            if (response.Data != null && !response.Data.Success)
            {
                _logger.LogError($"快手 API 错误 [data]: error_code={response.Data.ErrorCode}, " +
                                 $"description={response.Data.Description}");
                throw new KuaiShouException(
                    $"快手API错误: {response.Data.ErrorCode}, " +
                    $"原因：{response.Data.Description}");
            }
        }

        #endregion
    }
}
