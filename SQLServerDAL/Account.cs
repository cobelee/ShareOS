using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using ShareOS.IDAL;
using ShareOS.SQLServerDAL.DS;
using Common.DBUtility;

namespace ShareOS.SQLServerDAL
{
    public class Account : IAccount
    {
        protected ShareOS.Model.Account Parse(SqlDataReader Reader)
        {
            DBTable.Account tableAccount = new ShareOS.SQLServerDAL.DBTable.Account();

            ShareOS.Model.Account mAccount = new ShareOS.Model.Account();
            mAccount.Id = Convert.ToInt32(Reader[tableAccount.Id.Text]);
            mAccount.UserName = Reader[tableAccount.UserName.Text].ToString().Trim();
            mAccount.Password = Reader[tableAccount.Password.Text].ToString().Trim();
            mAccount.UserType = Reader[tableAccount.UserType.Text].ToString().Trim();
            mAccount.TrueName = Reader[tableAccount.TrueName.Text].ToString().Trim();
            return mAccount;
        }

        #region IAccount 成员

        public IList<ShareOS.Model.Account> GetAccount()
        {
            //存储过程:Select_Account
            IList<ShareOS.Model.Account> mAccounts = new List<ShareOS.Model.Account>();
            DBProcedure.Select_Account cmdText = new ShareOS.SQLServerDAL.DBProcedure.Select_Account();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(ConnectionString.ConnectionStringShares, CommandType.StoredProcedure, cmdText.Text, null))
            {
                while (reader.Read())
                {
                    ShareOS.Model.Account mAccount = Parse(reader);
                    mAccounts.Add(mAccount);
                }
            }
            return mAccounts;
        }

        public ShareOS.Model.Account GetAccountByUserName(string UserName)
        {
            ShareOS.Model.Account account;
            DBProcedure.Select_Account_By_UserName prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Select_Account_By_UserName();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_UserName.ParameterName, UserName);
            using (SqlDataReader reader = prdHelper.ExecuteReader())
            {
                if (reader.Read())
                    account = Parse(reader);
                else
                    account = new ShareOS.Model.Account();
            }

            return account;
        }

        public void InsertAccount(string UserName, string Password, string UserType, string TrueName)
        {
            DBProcedure.Insert_Account prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Insert_Account();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_UserName.ParameterName, UserName);
            prdHelper.SetInputValue(prdCmdText.PARM_Password.ParameterName, Password);
            prdHelper.SetInputValue(prdCmdText.PARM_UserType.ParameterName, UserType);
            prdHelper.SetInputValue(prdCmdText.PARM_TrueName.ParameterName, TrueName);

            prdHelper.ExecuteNonQuery();
        }

        public void UpdateAccount(int Id, string UserName, string Password, string UserType, string TrueName)
        {
            DBProcedure.Update_Account prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Update_Account();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_Id.ParameterName, Id);
            prdHelper.SetInputValue(prdCmdText.PARM_UserName.ParameterName, UserName);
            prdHelper.SetInputValue(prdCmdText.PARM_Password.ParameterName, Password);
            prdHelper.SetInputValue(prdCmdText.PARM_UserType.ParameterName, UserType);
            prdHelper.SetInputValue(prdCmdText.PARM_TrueName.ParameterName, TrueName);

            prdHelper.ExecuteNonQuery();

        }

        public void DeleteAccount(int Id)
        {
            DBProcedure.Delete_Account prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Delete_Account();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_Id.ParameterName, Id);

            prdHelper.ExecuteNonQuery();

        }

        

        #endregion
    }
}
