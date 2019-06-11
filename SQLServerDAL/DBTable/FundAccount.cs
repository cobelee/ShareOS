using System;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.SQLServerDAL.DBTable
{
    public class FundAccount
    {
        public string Text = "FundAccount";
        public Column FundAccountId = new Column("FundAccountId");
        public Column IssueNumber = new Column("IssueNumber");
        public Column ShareholderNumber = new Column("ShareholderNumber");
        public Column ChangeMoney = new Column("ChangeMoney");
        public Column ChangeReason = new Column("ChangeReason");
        public Column ChangeDate = new Column("ChangeDate");
    }
}
