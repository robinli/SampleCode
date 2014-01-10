namespace GrepLoadDoc
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.txtDept = new System.Windows.Forms.TextBox();
            this.butDownload = new System.Windows.Forms.Button();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(27, 46);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(486, 22);
            this.txtUrl.TabIndex = 0;
            this.txtUrl.Text = "http://www.ccafps.khc.edu.tw/releaseRedirect.do?unitID=183&pageID=3357";
            // 
            // txtDept
            // 
            this.txtDept.Location = new System.Drawing.Point(27, 91);
            this.txtDept.Name = "txtDept";
            this.txtDept.Size = new System.Drawing.Size(97, 22);
            this.txtDept.TabIndex = 1;
            this.txtDept.Text = "教務處";
            // 
            // butDownload
            // 
            this.butDownload.Location = new System.Drawing.Point(27, 176);
            this.butDownload.Name = "butDownload";
            this.butDownload.Size = new System.Drawing.Size(97, 30);
            this.butDownload.TabIndex = 2;
            this.butDownload.Text = "Download";
            this.butDownload.UseVisualStyleBackColor = true;
            this.butDownload.Click += new System.EventHandler(this.butDownload_Click);
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(27, 135);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.ReadOnly = true;
            this.txtFolder.Size = new System.Drawing.Size(486, 22);
            this.txtFolder.TabIndex = 3;
            this.txtFolder.Text = "R:\\New folder";
            this.txtFolder.Click += new System.EventHandler(this.txtFolder_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(27, 236);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(31, 12);
            this.lblMessage.TabIndex = 4;
            this.lblMessage.Text = "ready";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 333);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.butDownload);
            this.Controls.Add(this.txtDept);
            this.Controls.Add(this.txtUrl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.TextBox txtDept;
        private System.Windows.Forms.Button butDownload;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblMessage;
    }
}

