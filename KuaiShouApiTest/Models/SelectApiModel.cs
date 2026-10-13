/*
* ==============================================================================
*
* FileName: SelectApiModel.cs
* Created: 2026/6/5 17:58:56
* Author: yangqingde
* Description: 
*
* ==============================================================================
*/
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuaiShouApiTest.Models
{
    [AddINotifyPropertyChangedInterface]
    public class SelectApiModel
    {
        public SelectApiModel()
        {

        }
        public SelectApiModel(string displayName, string apiKey)
        {
            DisplayName = displayName;
            ApiKey = apiKey;
        }
        public string DisplayName { get; set; }

        public string ApiKey { get; set; }
    }
}
