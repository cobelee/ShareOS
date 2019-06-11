using System;
using System.Collections.Generic;
using System.Text;
using ShareOS.IDAL;
using ShareOS.Model;

namespace ShareOS.BLL
{
    public class Account
    {
        private IAccount dalAccount = ShareOS.DALFactory.DataAccess.CreateAccount();

        public IList<ShareOS.Model.Account> GetAccountAll()
        {
            return dalAccount.GetAccount();
        }

        public Model.Account GetAccountByUserName(string UserName)
        {
            return dalAccount.GetAccountByUserName(UserName);
        }

        public void AddAccount(string UserName, string Password, string UserType, string TrueName)
        {
            dalAccount.InsertAccount(UserName, Password, UserType, TrueName);
        }

        public void UpdateAccount(int Id, string UserName, string Password, string UserType, string TrueName)
        {
            dalAccount.UpdateAccount(Id, UserName, Password, UserType, TrueName);
        }

        public void DeleteAccount(int Id)
        {
            dalAccount.DeleteAccount(Id);
        }
    }
}
