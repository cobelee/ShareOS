using System;
using System.Collections.Generic;
using System.Text;


namespace ShareOS.IDAL
{
    public interface IAccount
    {
        /// <summary>
        /// ��ȡ����ϵͳ�˻��б���
        /// </summary>
        /// <returns></returns>
        IList<ShareOS.Model.Account> GetAccount();

        ShareOS.Model.Account GetAccountByUserName(string UserName);

        void InsertAccount(string UserName, string Password, string UserType, string TrueName);

        void UpdateAccount(int Id, string UserName, string Password, string UserType, string TrueName);

        void DeleteAccount(int Id);
    }
}