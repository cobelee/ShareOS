using System;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.IDAL
{
    public interface IShareholder
    {
        /// <summary>
        /// 设置股东的状态
        /// <para>股东状态有：股东,非股东,退出人员</para>
        /// </summary>
        /// <param name="shareholderId">股东Id.</param>
        /// <param name="status">股东状态有：股东,非股东,退出人员</param>
        void SetStatus(int shareholderId, ShareOS.Model.ShareholderStatus status);
    }
}
