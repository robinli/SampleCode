using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace GrepLoadDoc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtFolder_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.txtFolder.Text = this.folderBrowserDialog1.SelectedPath;
        }

        private void butDownload_Click(object sender, EventArgs e)
        {
            GrepHtmlthenDownloadDoc(this.txtUrl.Text, this.txtFolder.Text, this.txtDept.Text);
            lblMessage.Text = String.Format("done at {0}", DateTime.Now);
        }

        private void GrepHtmlthenDownloadDoc(string url, string rootFolder, string newFolder)
        {
            string htmlText = Spider‎WebPage(url);




            List<string> list = ParseHtml(htmlText);


            string saveFolder = Path.Combine(rootFolder, newFolder);
            if (!Directory.Exists(saveFolder))
                Directory.CreateDirectory(saveFolder);

            foreach (string id in list)
            {
                //Download("http://www.ccafps.khc.edu.tw/fileManager.do?actionType=downloadF&file.id=197", saveFolder, newFolder);
                Download( "http://www.ccafps.khc.edu.tw/fileManager.do?actionType=downloadF&file.id="+id
                    , saveFolder
                    , newFolder);
            }

        }



        /// <summary>
        /// 讀取原始的HTML
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private string Spider‎WebPage(string url)
        {
            string htmlText = null;

            WebRequest myWebRequest = WebRequest.Create(url);
            myWebRequest.Timeout = 10000;

            WebResponse myWebResponse = myWebRequest.GetResponse();
            using (Stream myStream = myWebResponse.GetResponseStream())
            {
                using (StreamReader myStreamReader = new StreamReader(myStream))
                {
                    htmlText = myStreamReader.ReadToEnd();
                }
            }
            return htmlText;
        }


        private string GetOriginalFileName(string originalFileName)
        {
            string fileName = System.Web.HttpUtility.UrlDecode(originalFileName);
            string findKey="filename=";

            int idx = originalFileName.IndexOf(findKey)+findKey.Length;
            fileName = fileName.Substring(idx, fileName.Length - idx);

            return fileName;
        }


        private void Download(string url, string saveFolder, string prefix)
        {
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();

            string originalFileName = GetOriginalFileName(httpResponse.Headers["Content-Disposition"]);
            

            System.IO.Stream dataStream = httpResponse.GetResponseStream();
            byte[] buffer = new byte[8192];

            string newFileName = Path.Combine(saveFolder, string.Format("{0}-{1}", prefix, originalFileName));

            FileStream fs = new FileStream(newFileName,
                FileMode.Create, FileAccess.Write);
            int size = 0;
            do
            {
                size = dataStream.Read(buffer, 0, buffer.Length);
                if (size > 0)
                    fs.Write(buffer, 0, size);
            } while (size > 0);
            fs.Close();

            httpResponse.Close();

            Console.WriteLine("Done at " + DateTime.Now.ToString("HH:mm:ss.fff"));
        }


        private List<string> ParseHtml(string htmlText)
        {
            string[] tables = System.Text.RegularExpressions.Regex.Split(htmlText
                , "排版用表格"
            );

            List<string> returns = new List<string>();
            foreach (string table in tables)
            {
                string[] list = System.Text.RegularExpressions.Regex.Split(table
                , "actionType=downloadF&file.id="
                );

                foreach (string html in list)
                {
                    //"179\" class=\"a4\" title=\"校友申請各項證明申請表.doc(開啟新視窗)\">校友申請各項證明申請表.doc</a> 
                    string[] strs = html.Replace("\""," ").Split(new char[1] { ' ' });
                    int id;
                    if (Int32.TryParse(strs[0], out id))
                        returns.Add(strs[0]);
                }
            }
            
            return returns;
        }
    }
}
