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
    public class PersonType : IPersonType
    {
        protected ShareOS.Model.PersonType Parse(SqlDataReader Reader)
        {
            DBTable.PersonType table = new ShareOS.SQLServerDAL.DBTable.PersonType();

            ShareOS.Model.PersonType mPersonType = new ShareOS.Model.PersonType();
            mPersonType.PersonTypeName = Reader[table.PersonTypeName.Text].ToString().Trim();
            return mPersonType;
        }

        #region IPersonType ≥…‘±

        public IList<ShareOS.Model.PersonType> GetPersonTypes()
        {
            IList<ShareOS.Model.PersonType> mPersonTypes = new List<ShareOS.Model.PersonType>();
            DBProcedure.Select_PersonType cmdText = new ShareOS.SQLServerDAL.DBProcedure.Select_PersonType();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(ConnectionString.ConnectionStringShares, CommandType.StoredProcedure, cmdText.Text, null))
            {
                while (reader.Read())
                {
                    ShareOS.Model.PersonType personType = Parse(reader);
                    mPersonTypes.Add(personType);
                }
            }
            return mPersonTypes;
        }

        public void InsertPersonType(string personTypeName)
        {
            DBProcedure.Insert_PersonType prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Insert_PersonType();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_PersonTypeName.ParameterName, personTypeName);

            prdHelper.ExecuteNonQuery();
        }

        public void UpdatePersonType(string oldText, string newText)
        {
            DBProcedure.Update_PersonType prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Update_PersonType();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_OldPersonTypeName.ParameterName, oldText);
            prdHelper.SetInputValue(prdCmdText.PARM_NewPersonTypeName.ParameterName, newText);

            prdHelper.ExecuteNonQuery();
        }

        public void DeletePersonType(string personTypeName)
        {
            DBProcedure.Delete_PersonType prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Delete_PersonType();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_PersonTypeName.ParameterName, personTypeName);

            prdHelper.ExecuteNonQuery();
        }

        #endregion
    }
}
