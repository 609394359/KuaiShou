/*
* ==============================================================================
*
* FileName: CertificateCancelRes.cs
* Created: 2026/6/4 11:51:35
* Author: yangqingde
* Description: 
*
* ==============================================================================
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDX.KuaiShouOpen.Responses
{
    /// <summary>
    /// 撤销核销
    /// https://open.kwailocallife.com/docs/api?apiName=goodlife.v1.fulfilment.certificate.cancel&version=1
    /// </summary>
    public class CertificateCancelRes : KuaiShouBaseRes<CertificateCancelData>
    {
    }

    public class CertificateCancelData : KuaiShouBaseData
    { 
    }
}
