using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using ShareOS.Model;

namespace ShareOS.IDAL
{
    public interface IShareholderRegister
    {
        /// <summary>
        /// �����ɶ�.
        /// </summary>
        /// <param name="shareholder">�ɶ�.</param>
        /// <returns></returns>
        bool InsertShareholder(ShareOS.Model.Shareholder shareholder);

        /// <summary>
        /// ��ȡ���¹���
        /// </summary>
        /// <param name="shareholderNumber">�ɶ���.</param>
        /// <returns></returns>
        ShareOS.Model.Shareholder SelectShareholder(int shareholderNumber);

        /// <summary>
        /// ��ȡlbShareholderName
        /// </summary>
        /// <param name="jobNumber">���š�</param>
        /// <returns></returns>
        ShareOS.Model.Shareholder SelectShareholder(string jobNumber);

        /// <summary>
        /// ��ȡ���йɶ��б�.
        /// </summary>
        /// <returns></returns>
        IList<ShareOS.Model.Shareholder> SelectShareholder();

        /// <summary>
        /// ��ȡ���йɶ��б�.
        /// </summary>
        /// <returns>���عɶ��б�Table</returns>
        DataTable SelectShareholderTable();

        /// <summary>
        /// ��ȡ����û�й�Ȩ���ˡ�
        /// </summary>
        /// <returns></returns>
        DataTable SelectShareholdersHaveNoShare();

        /// <summary>
        /// ��ȡĳί�д��������¹��������йɶ��б���
        /// </summary>
        /// <param name="entrustedAgent">ί�д����ˡ�</param>
        /// <returns></returns>
        IList<ShareOS.Model.Shareholder> SelectShareholder(EntrustedAgent entrustedAgent);

        /// <summary>
        /// ���¹ɶ���Ϣ��
        /// </summary>
        /// <param name="shareholder">�ɶ�</param>
        /// <returns></returns>
        bool UpdateShareholder(ShareOS.Model.Shareholder shareholder);

        /// <summary>
        /// ���¹ɶ���������ͼƬ��
        /// </summary>
        /// <param name="shareholderNumber">�ɶ��š�</param>
        /// <returns></returns>
        bool UpdateBarCode(int shareholderNumber, byte[] barCode);

        /// <summary>
        /// ɾ���ɶ���
        /// </summary>
        /// <param name="shareholderId">�ɶ����š����ǹɶ��ţ�</param>
        /// <returns></returns>
        bool DeleteShareholder(int shareholderId);

        /// <summary>
        /// �Ƿ���ڹɶ���
        /// </summary>
        /// <param name="shareholderNumber">�ɶ��š�</param>
        /// <returns></returns>
        bool ExistShareholder(int shareholderNumber);

        /// <summary>
        /// �Ƿ���ڹɶ���
        /// </summary>
        /// <param name="shareholderNumber">���š�</param>
        /// <returns></returns>
        bool ExistShareholder(string jobNumber);
    }
}