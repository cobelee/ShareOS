using System;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.SQLServerDAL.DBTable
{
    public class BonusRecord
    {
        public string Text = "BonusRecord";
        public Column IssueNumber = new Column("IssueNumber");
        public Column ShareholderNumber = new Column("ShareholderNumber");
        public Column CashBonus = new Column("CashBonus");
    }
}
