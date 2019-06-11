using System;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.SQLServerDAL.DS.DBTable
{
    public class PersonType
    {
        public string Text = "PersonType";
        public Column PersonTypeName = new Column("PersonTypeName");
    }
}
