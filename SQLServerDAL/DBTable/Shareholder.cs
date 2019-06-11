using System;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.SQLServerDAL.DBTable
{
    public class Shareholder
    {
        public string Text = "Shareholder";
        public Column ShareholderId = new Column("ShareholderId");
        public Column ShareholderNumber = new Column("ShareholderNumber");
        public Column JobNumber = new Column("JobNumber");
        public Column ShareholderName = new Column("ShareholderName");
        public Column Sex = new Column("Sex");
        public Column IdentityCard = new Column("IdentityCard");
        public Column PersonType = new Column("PersonType");
        public Column Status = new Column("Status");
        public Column EntrustedAgent = new Column("EntrustedAgent");

    }
}
