using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Tiyi.ShareOS.SQLServerDAL
{
    /// <summary>
    /// 物料数据内容。
    /// </summary>
    public partial class ShareDataContext
    {
        //public ShareDataContext() :
        //    base(Tiyi.ShareOS.SQLServerDAL.Connection.GetConnectionString(), mappingSource)
        //{
        //    OnCreated();
        //}

        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.GetQichuSharesInIssueNumber", IsComposable = true)]
        public System.Nullable<decimal> GetQichuSharesInIssueNumber([global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ShareholderNumber", DbType = "Int")] System.Nullable<int> shareholderNumber, [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "IssueNumber", DbType = "Int")] System.Nullable<int> issueNumber)
        {
            return ((System.Nullable<decimal>)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), shareholderNumber, issueNumber).ReturnValue));
        }

        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.GetCurrentTotalSharesInIssueNumber", IsComposable = true)]
        public System.Nullable<decimal> GetCurrentTotalSharesInIssueNumber([global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ShareholderNumber", DbType = "Int")] System.Nullable<int> shareholderNumber, [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "IssueNumber", DbType = "Int")] System.Nullable<int> issueNumber)
        {
            return ((System.Nullable<decimal>)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), shareholderNumber, issueNumber).ReturnValue));
        }

        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.GetShareholderName", IsComposable = true)]
        public string GetShareholderName([global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ShareholderNumber", DbType = "Int")] System.Nullable<int> shareholderNumber)
        {
            return ((string)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), shareholderNumber).ReturnValue));
        }

    }

}
