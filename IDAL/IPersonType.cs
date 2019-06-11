using System;
using System.Collections.Generic;
using System.Text;
using ShareOS.Model;

namespace ShareOS.IDAL
{
    public interface IPersonType
    {
        /// <summary>
        /// 获取所有的人员类型.
        /// </summary>
        /// <returns></returns>
        IList<ShareOS.Model.PersonType> GetPersonTypes();

        void InsertPersonType( string personTypeName);

        void UpdatePersonType(string oldText, string newText);

        void DeletePersonType(string personTypeName);
    }
}
