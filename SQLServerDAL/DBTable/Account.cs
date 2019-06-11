using System;
using System.Collections.Generic;
using System.Text;
using ShareOS.SQLServerDAL.DS;

namespace ShareOS.SQLServerDAL.DBTable
{
    public class Account
    {
        public string Text = "Account";
        public Column Id = new Column("Id");
        public Column UserName = new Column("UserName");
        public Column Password = new Column("Password");
        public Column UserType = new Column("UserType");
        public Column TrueName = new Column("TrueName");
    }
}
