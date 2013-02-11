namespace TMDbSampleApp
{
    partial class FormAuthentication
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnAuthorize = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(288, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "Click the button below to open themoviedb.org and authorize the app.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(246, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "More information about the authentication process:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(13, 164);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(265, 13);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://help.themoviedb.org/kb/api/user-authentication";
            // 
            // btnAuthorize
            // 
            this.btnAuthorize.Location = new System.Drawing.Point(16, 48);
            this.btnAuthorize.Name = "btnAuthorize";
            this.btnAuthorize.Size = new System.Drawing.Size(75, 23);
            this.btnAuthorize.TabIndex = 3;
            this.btnAuthorize.Text = "Authorize";
            this.btnAuthorize.UseVisualStyleBackColor = true;
            this.btnAuthorize.Click += new System.EventHandler(this.btnAuthorize_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(13, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(282, 33);
            this.label4.TabIndex = 4;
            this.label4.Text = "After authorizing the app to use your data, click the button bellow to start a ne" +
    "w user session.";
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(16, 114);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 5;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // FormAuthentication
            // 
            this.ClientSize = new System.Drawing.Size(300, 199);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAuthorize);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.Name = "FormAuthentication";
            this.Text = "Authorization";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnAuthorize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDone;
    }
}