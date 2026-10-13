/*
* ==============================================================================
*
* FileName: KuaiShouException.cs
* Created: 2026/6/3 15:56:28
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

namespace DDX.KuaiShouOpen
{
    /// <summary>
    /// 快手SDK异常类
    /// </summary>
    /// <param name="message"></param>
    public class KuaiShouException(string message) : Exception(message);
}
