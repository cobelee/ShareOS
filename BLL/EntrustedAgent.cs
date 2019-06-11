using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using ShareOS.IDAL;
using ShareOS.Model;

namespace ShareOS.BLL
{
    public class EntrustedAgent
    {
        private IEntrustedAgent dal = ShareOS.DALFactory.DataAccess.CreateEntrustedAgent();

        public bool Insert(ShareOS.Model.EntrustedAgent entrustedAgent)
        {
            return dal.Insert(entrustedAgent);
        }

        /// <summary>
        /// 新增委托代理人（股东代表）.
        /// </summary>
        /// <param name="agentShn">委托代理人（股东代表）的股东号.</param>
        /// <returns></returns>
        public bool Create(int agentShn)
        {
            return dal.Create(agentShn);
        }

        public IList<ShareOS.Model.EntrustedAgent> Select()
        {
            return dal.Select();
        }

        public bool Delete(int shareholderNumber)
        {
            return dal.Delete(shareholderNumber);
        }

        public void ActFor(int shareholderId, ShareOS.Model.EntrustedAgent entrustedAgent)
        {
            dal.ActFor(shareholderId, entrustedAgent);
        }

        /// <summary>
        /// 是否存在委托代理人。
        /// </summary>
        /// <param name="shareholderNumber">委托代理人的股东号。</param>
        /// <returns></returns>
        public bool Exist(int shareholderNumber)
        {
            return dal.Exist(shareholderNumber);
        }

        /// <summary>
        /// 为股权代理人分配助理。
        /// </summary>
        /// <param name="agentShareholderNumber">股权代理人股东号。</param>
        /// <param name="assistantJobNumber">助理工号。</param>
        public void AssignAssistant(int agentShareholderNumber, string assistantJobNumber)
        {
            dal.SetAssistant(agentShareholderNumber, assistantJobNumber);
        }

        /// <summary>
        /// 获取股东代理人的助理。
        /// </summary>
        /// <param name="agentShareholderNumber">股权代理人股东号.</param>
        /// <returns></returns>
        public DataTable SelectAssistant(int agentShareholderNumber)
        {
            return dal.SelectAssistant(agentShareholderNumber);
        }

        /// <summary>
        /// 删除股权代理人的助理。
        /// </summary>
        /// <param name="agentShareholderNumber">股权代理人股东号。</param>
        /// <param name="assistantJobNumber">助理工号。</param>
        public bool DeleteAssistant(int agentShareholderNumber, string assistantJobNumber)
        {
            return dal.DeleteAssistant(agentShareholderNumber, assistantJobNumber);
        }

        /// <summary>
        /// 获取某指定助理所对应的代理人。
        /// </summary>
        /// <param name="assistantJobNumber">助理工号。</param>
        /// <returns></returns>
        public int GetAgentShareholderNumber(string assistantJobNumber)
        {
            return dal.GetAgentShareholderNumber(assistantJobNumber);
        }

        /// <summary>
        /// 判断是否是代理人的助理身份。
        /// </summary>
        /// <param name="assistantJobNumber">助理工号。</param>
        /// <returns></returns>
        public bool IsAssistant(string assistantJobNumber)
        {
            int agent = dal.GetAgentShareholderNumber(assistantJobNumber);
            return agent > 0 ? true : false;
        }
    }
}
