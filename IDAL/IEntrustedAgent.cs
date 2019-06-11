using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using ShareOS.Model;

namespace ShareOS.IDAL
{
    public interface IEntrustedAgent
    {
        /// <summary>
        /// 新增委托代理人（股东代表）.
        /// </summary>
        /// <param name="shareholder">委托代理人（股东代表）.</param>
        /// <returns></returns>
        bool Insert(ShareOS.Model.EntrustedAgent entrustedAgent);

        /// <summary>
        /// 新增委托代理人（股东代表）.
        /// </summary>
        /// <param name="agentShn">委托代理人（股东代表）的股东号.</param>
        /// <returns></returns>
        bool Create(int agentShn);

        /// <summary>
        /// 获取所有委托代理人（股东代表）列表.
        /// </summary>
        /// <returns></returns>
        IList<EntrustedAgent> Select();

        /// <summary>
        /// 删除委托代理人（股东代表）。
        /// </summary>
        /// <param name="shareholderNumber">股东号.</param>
        /// <returns></returns>
        bool Delete(int shareholderNumber);


        void ActFor(int shareholderId, ShareOS.Model.EntrustedAgent entrustedAgent);

        /// <summary>
        /// 是否存在委托代理人。
        /// </summary>
        /// <param name="shareholderNumber">委托代理人的股东号。</param>
        /// <returns></returns>
        bool Exist(int shareholderNumber);

        /// <summary>
        /// 为股权代理人分配助理。
        /// </summary>
        /// <param name="agentShareholderNumber">股权代理人股东号。</param>
        /// <param name="assistantJobNumber">助理工号。</param>
        void SetAssistant(int agentShareholderNumber, string assistantJobNumber);

        /// <summary>
        /// 获取股东代理人的助理。
        /// </summary>
        /// <param name="agentShareholderNumber">股权代理人股东号.</param>
        /// <returns></returns>
        DataTable SelectAssistant(int agentShareholderNumber);

        /// <summary>
        /// 获取某指定助理所对应的代理人。
        /// </summary>
        /// <param name="assistantJobNumber">助理工号。</param>
        /// <returns></returns>
        int GetAgentShareholderNumber(string assistantJobNumber);

        /// <summary>
        /// 删除股权代理人的助理。
        /// </summary>
        /// <param name="agentShareholderNumber">股权代理人股东号。</param>
        /// <param name="assistantJobNumber">助理工号。</param>
        bool DeleteAssistant(int agentShareholderNumber, string assistantJobNumber);
    }
}
