using System;
using System.Collections.Generic;
using System.Text;
using ShareOS.IDAL;

namespace ShareOS.BLL
{
    public class Shareholder : ShareOS.Model.Shareholder
    {
        private IShareholder dal = ShareOS.DALFactory.DataAccess.CreateShareholder();

        /// <summary>
        /// 设置股东的状态
        /// <para>股东状态有：股东,非股东,退出人员</para>
        /// </summary>
        /// <param name="shareholderId">股东号</param>
        /// <param name="status">股东状态有：股东,非股东,退出人员</param>
        public void SetStatus(ShareOS.Model.ShareholderStatus status)
        {
            dal.SetStatus(this.ShareholderId, status);
        }
    }
}
