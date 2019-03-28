using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framwork.UIBase
{
    /// <summary>
    /// Page基础接口
    /// 作者：马乃金
    /// 时间：2019.01.24
    /// </summary>
    interface IPage
    {
        void Dispose();
        void AddListener();
        void RemoveListener();
    }
}
