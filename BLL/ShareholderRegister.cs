using System;
using System.Data;
using System.Collections.Generic;
using ShareOS.IDAL;

namespace ShareOS.BLL
{
    public class ShareholderRegister
    {
        private IShareholderRegister dal = ShareOS.DALFactory.DataAccess.CreateShareholderRegister();

        public bool Create(ShareOS.Model.Shareholder shareholder)
        {
            return dal.InsertShareholder(shareholder);
        }

        public ShareOS.BLL.Shareholder GetShareholder(int shareholderNumber)
        {
            ShareOS.BLL.Shareholder bsh = new Shareholder();
            ShareOS.Model.Shareholder mSh = dal.SelectShareholder(shareholderNumber);
            mSh.CopyTo(bsh as ShareOS.Model.Shareholder);
            return bsh;
        }

        /// <summary>
        /// ��ȡ�����ɶ���Ϣ��
        /// </summary>
        /// <param name="jobNumber">���š�</param>
        /// <returns></returns>
        public ShareOS.Model.Shareholder GetShareholder(string jobNumber)
        {
            return dal.SelectShareholder(jobNumber);
        }

        public IList<ShareOS.Model.Shareholder> GetShareholderList()
        {
            return dal.SelectShareholder();
        }

        /// <summary>
        /// ��ȡ���йɶ��б�.
        /// </summary>
        /// <returns>���عɶ��б�Table</returns>
        public DataTable SelectShareholderTable()
        {
            return dal.SelectShareholderTable();
        }

        /// <summary>
        /// ��ȡ����û�й�Ȩ���ˡ�
        /// </summary>
        /// <returns></returns>
        public DataTable SelectShareholdersHaveNoShare()
        {
            return dal.SelectShareholdersHaveNoShare();
        }

        public IList<ShareOS.Model.Shareholder> Select(ShareOS.Model.EntrustedAgent entrustedAgent)
        {
            return dal.SelectShareholder(entrustedAgent);
        }

        public bool Update(ShareOS.Model.Shareholder shareholder)
        {
            return dal.UpdateShareholder(shareholder);
        }

        /// <summary>
        /// ���¹ɶ���������ͼƬ��
        /// </summary>
        /// <param name="shareholderNumber">�ɶ��š�</param>
        /// <returns></returns>
        public bool UpdateBarCode(int shareholderNumber, byte[] barCode)
        {
            return dal.UpdateBarCode(shareholderNumber, barCode);
        }

        public bool Delete(int shareholderId)
        {
            return dal.DeleteShareholder(shareholderId);
        }

        /// <summary>
        /// �Ƿ���ڹɶ���
        /// </summary>
        /// <param name="shareholderNumber">�ɶ��š�</param>
        /// <returns></returns>
        public bool ExistShareholder(int shareholderNumber)
        {
            return dal.ExistShareholder(shareholderNumber);
        }

        /// <summary>
        /// �Ƿ���ڹɶ���
        /// </summary>
        /// <param name="shareholderNumber">���š�</param>
        /// <returns></returns>
        public bool ExistShareholder(string jobNumber)
        {
            return dal.ExistShareholder(jobNumber);
        }

        /// <summary>
        /// ������ת��Ϊ���ݱ���
        /// </summary>
        /// <param name="shareholders">���νṹ�ɶ��б���</param>
        /// <returns></returns>
        public DataTable ConvertToDataTable(IList<Model.Shareholder> shareholders)
        {
            DataTable dtShareholders = new DataTable("Shareholder");
            dtShareholders.Columns.Add("���");
            dtShareholders.Columns.Add("�ɶ���");
            dtShareholders.Columns.Add("����");
            dtShareholders.Columns.Add("����");
            dtShareholders.Columns.Add("�Ա�");
            dtShareholders.Columns.Add("����֤��");
            dtShareholders.Columns.Add("��Ա���");
            dtShareholders.Columns.Add("�ɶ�״̬");
            dtShareholders.Columns.Add("ί�д�����");

            foreach (Model.Shareholder sh in shareholders)
            {
                DataRow row = dtShareholders.NewRow();
                row["���"] = sh.ShareholderId;
                row["�ɶ���"] = sh.ShareholderNumber;
                row["����"] = sh.JobNumber;
                row["����"] = sh.ShareholderName;
                row["�Ա�"] = sh.Sex ? "��" : "Ů";
                row["����֤��"] = sh.IdentityCard;
                row["��Ա���"] = sh.PersonType;
                row["�ɶ�״̬"] = sh.Status.ToString();

                Model.Shareholder wtShareholder = dal.SelectShareholder(sh.EntrustedAgent);
                row["ί�д�����"] = wtShareholder.ShareholderName;

                dtShareholders.Rows.Add(row);
            }

            return dtShareholders;
        }
    }
}