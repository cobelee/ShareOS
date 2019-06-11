using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using ShareOS.IDAL;
using System.Reflection;

namespace ShareOS.DALFactory
{
    public sealed class DataAccess
    {
        private static readonly string SHARES_DAL_PATH = ConfigurationManager.AppSettings["SHARES_DAL_PATH"];

        private DataAccess() { }

        public static ShareOS.IDAL.IAccount CreateAccount()
        {
            string className = SHARES_DAL_PATH + ".Account";
            return (ShareOS.IDAL.IAccount)Assembly.Load(SHARES_DAL_PATH).CreateInstance(className);
        }

        public static ShareOS.IDAL.IShareholderRegister CreateShareholderRegister()
        {
            string className = SHARES_DAL_PATH + ".Shareholder";
            return (ShareOS.IDAL.IShareholderRegister)Assembly.Load(SHARES_DAL_PATH).CreateInstance(className);
        }

        public static ShareOS.IDAL.IShareholder CreateShareholder()
        {
            string className = SHARES_DAL_PATH + ".Shareholder";
            return (ShareOS.IDAL.IShareholder)Assembly.Load(SHARES_DAL_PATH).CreateInstance(className);
        }

        public static ShareOS.IDAL.IPersonType CreatePersonType()
        {
            string className = SHARES_DAL_PATH + ".PersonType";
            return (ShareOS.IDAL.IPersonType)Assembly.Load(SHARES_DAL_PATH).CreateInstance(className);
        }

        public static ShareOS.IDAL.IEntrustedAgent CreateEntrustedAgent()
        {
            string className = SHARES_DAL_PATH + ".EntrustedAgent";
            return (ShareOS.IDAL.IEntrustedAgent)Assembly.Load(SHARES_DAL_PATH).CreateInstance(className);
        }

        public static ShareOS.IDAL.IShareOwnership CreateShareOwnership()
        {
            string className = SHARES_DAL_PATH + ".ShareOwnership";
            return (ShareOS.IDAL.IShareOwnership)Assembly.Load(SHARES_DAL_PATH).CreateInstance(className);
        }

        public static ShareOS.IDAL.ISharesBonus CreateSharesBonus()
        {
            string className = SHARES_DAL_PATH + ".SharesBonus";
            return (ShareOS.IDAL.ISharesBonus)Assembly.Load(SHARES_DAL_PATH).CreateInstance(className);
        }

        public static ShareOS.IDAL.IFundAccount CreateFundAccount()
        {
            string className = SHARES_DAL_PATH + ".FundAccount";
            return (ShareOS.IDAL.IFundAccount)Assembly.Load(SHARES_DAL_PATH).CreateInstance(className);
        }
    }
}
