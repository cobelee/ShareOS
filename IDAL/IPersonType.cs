using System;
using System.Collections.Generic;
using System.Text;
using ShareOS.Model;

namespace ShareOS.IDAL
{
    public interface IPersonType
    {
        /// <summary>
        /// ��ȡ���е���Ա����.
        /// </summary>
        /// <returns></returns>
        IList<ShareOS.Model.PersonType> GetPersonTypes();

        void InsertPersonType( string personTypeName);

        void UpdatePersonType(string oldText, string newText);

        void DeletePersonType(string personTypeName);
    }
}