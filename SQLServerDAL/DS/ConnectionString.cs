using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace ShareOS.SQLServerDAL.DS
{
    public class ConnectionString
    {
        public static readonly string ConnectionStringShares = ConfigurationManager.ConnectionStrings["Shares_SQL_ConnString"].ConnectionString;
    }
}
