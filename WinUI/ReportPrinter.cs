using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Collections.Generic;
using Microsoft.Reporting.WinForms;
using System.Windows.Forms;

namespace WinUI
{
    public class ReportPrinter : IDisposable
    {
        private int m_currentPageIndex;
        private IList<Stream> m_streams;
        private LocalReport m_localReport;
        private PrintDocument m_printDocument;

        public PrintDocument PrintDocument
        {
            get { return m_printDocument; }
        }

        public LocalReport LocalReport
        {
            get { return m_localReport; }
            set { m_localReport = value; }
        }

        /// <summary>
        /// 微软 RDLC 本地报表模版。
        /// </summary>
        /// <param name="report"></param>
        public ReportPrinter(LocalReport report)
        {
            m_localReport = report;
            m_printDocument = new PrintDocument();
            m_printDocument.PrintPage += new PrintPageEventHandler(PrintPage);
            m_printDocument.BeginPrint += new PrintEventHandler(m_printDocument_BeginPrint);
        }

        

        
        private Stream CreateFileStream(string name, string fileNameExtension, Encoding encoding,
                                  string mimeType, bool willSeek)
        {
            Stream stream = new FileStream(name + "." + fileNameExtension, FileMode.Create);

            m_streams.Add(stream);
            return stream;
        }

        private Stream CreateMemoryStream(string name, string fileNameExtension, Encoding encoding,
                                  string mimeType, bool willSeek)
        {
            Stream stream = new System.IO.MemoryStream();

            m_streams.Add(stream);
            return stream;
        }

        /// <summary>
        /// 将微软报表导出为Excel, PDF, EMF 格式的文档。
        /// </summary>
        /// <param name="fileFormat">导出文件的格式，可输入为"Excel","PDF","Image"。</param>
        public void Export(string fileFormat)
        {
            if (m_localReport != null && string.IsNullOrEmpty(m_localReport.ReportPath))
                return;

            string deviceInfo =
              "<DeviceInfo>" +
              "  <OutputFormat>EMF</OutputFormat>" +
              "  <PageWidth>21cm</PageWidth>" +
              "  <PageHeight>29.7cm</PageHeight>" +
              "  <MarginTop>0cm</MarginTop>" +
              "  <MarginLeft>0cm</MarginLeft>" +
              "  <MarginRight>0cm</MarginRight>" +
              "  <MarginBottom>0cm</MarginBottom>" +
              "</DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();

            m_localReport.Render(fileFormat, deviceInfo, CreateFileStream, out warnings);

            foreach (Stream stream in m_streams)
            {
                stream.Position = 0;
                stream.Close();
            }
        }


        /// <summary>
        /// 生成报表，并存储在内存中以备再次调用。
        /// </summary>
        private void ExportToMemory()
        {
            if (m_localReport != null && string.IsNullOrEmpty(m_localReport.ReportPath))
                return;

            string deviceInfo =
              "<DeviceInfo>" +
              "  <OutputFormat>EMF</OutputFormat>" +
              "  <PageWidth>21cm</PageWidth>" +
              "  <PageHeight>29.7cm</PageHeight>" +
              "  <MarginTop>0cm</MarginTop>" +
              "  <MarginLeft>0cm</MarginLeft>" +
              "  <MarginRight>0cm</MarginRight>" +
              "  <MarginBottom>0cm</MarginBottom>" +
              "</DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();

            m_localReport.Render("Image", deviceInfo, CreateMemoryStream, out warnings);

            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }

        /// <summary>
        /// 打印文档中的每一页。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ev"></param>
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);
            ev.Graphics.DrawImage(pageImage, ev.PageBounds);

            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }


        private void m_printDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            PrintPrepare();
        }

        /// <summary>
        /// 在打印文档前的准备工作。
        /// 包括在内存中生成报表。
        /// </summary>
        private void PrintPrepare()
        {
            if (m_localReport == null)
                return;
            ExportToMemory();

            m_currentPageIndex = 0;

            if (m_streams == null || m_streams.Count == 0)
                return;

            if (!m_printDocument.PrinterSettings.IsValid)
            {
                string msg = String.Format("Can't find printer \"{0}\".", m_printDocument.PrinterSettings.PrinterName);
                MessageBox.Show(msg);
                return;
            }
        }

        /// <summary>
        /// 打印生成的报表。
        /// </summary>
        public void Print()
        {
            m_printDocument.Print();
        }


        public void Dispose()
        {
            if (m_streams != null)
            {
                //foreach (Stream stream in m_streams)
                //    stream.Close();
                m_streams = null;
            }
        }

    }
}

