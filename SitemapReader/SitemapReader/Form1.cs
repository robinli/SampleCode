using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Net;

namespace SitemapReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filepath = this.txtFile.Text;
            GoogleSiteMap sitemap = GoogleSiteMapHelper.DeserializeFromXml<GoogleSiteMap>(filepath);
            MessageBox.Show("DeserializeFromXml is ok");

            foreach (SiteUrl urlinfo in sitemap.Urls)
            {
                Spider‎WebPage(urlinfo.Location);
            }
        }

        private void butBrowser_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtFile.Text = this.openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EAPortal_SystemLeadEntities db = new EAPortal_SystemLeadEntities();
            db.Article_AddContent("index.html", "<P>hello world</P>");
            MessageBox.Show("row added");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //讀取網頁資料
            string url = "http://www.ccafps.khc.edu.tw/releaseRedirect.do?unitID=183&pageID=3072";
            Spider‎WebPage(url);
        
        }

        private void Spider‎WebPage(string url)
        {
            WebRequest myWebRequest = WebRequest.Create(url);
            myWebRequest.Timeout = 10000;

            WebResponse myWebResponse = myWebRequest.GetResponse();
            using (Stream myStream = myWebResponse.GetResponseStream())
            {
                using (StreamReader myStreamReader = new StreamReader(myStream))
                {
                    string htmlText = myStreamReader.ReadToEnd();

                    InsertDB(url, ParseHtml(htmlText));
                }
            }
        }

        private string ParseHtml(string htmlText)
        {
            string findKey="<body  leftmargin=0 topmargin=0 >";
            int start = htmlText.LastIndexOf(findKey)+findKey.Length;
            int end = htmlText.LastIndexOf("</body>");
            return htmlText.Substring(start, end - start);
        }

        EAPortal_SystemLeadEntities db = new EAPortal_SystemLeadEntities();
        private void InsertDB(string UrlAddress, string htmlText)
        {
            db.Article_AddContent(UrlAddress, htmlText);
        }
    }
}
