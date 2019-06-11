using System;
using System.Collections.Generic;
using System.Text;
using ShareOS.IDAL;
using ShareOS.Model;

namespace ShareOS.BLL
{
    public class PersonType
    {
        private IPersonType dal = ShareOS.DALFactory.DataAccess.CreatePersonType();

        public IList<ShareOS.Model.PersonType> GetPersonTypes()
        {
            return dal.GetPersonTypes();
        }

        public void InsertPersonType(string personTypeName)
        {
            dal.InsertPersonType(personTypeName);
        }

        public void UpdatePersonType(string oldText, string newText)
        {
            dal.UpdatePersonType(oldText, newText);
        }

        public void DeletePersonType(string personTypeName)
        {
            dal.DeletePersonType(personTypeName);
        }


    }
}
