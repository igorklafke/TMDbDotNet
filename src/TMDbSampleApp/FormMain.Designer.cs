namespace TMDbSampleApp
{
    partial class FormMain
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
            this.btnMovieSearch = new System.Windows.Forms.Button();
            this.btnAccount = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMovieSearch
            // 
            this.btnMovieSearch.Location = new System.Drawing.Point(71, 58);
            this.btnMovieSearch.Name = "btnMovieSearch";
            this.btnMovieSearch.Size = new System.Drawing.Size(146, 40);
            this.btnMovieSearch.TabIndex = 0;
            this.btnMovieSearch.Text = "Search Movies";
            this.btnMovieSearch.UseVisualStyleBackColor = true;
            this.btnMovieSearch.Click += new System.EventHandler(this.btnMovieSearch_Click);
            // 
            // btnAccount
            // 
            this.btnAccount.Location = new System.Drawing.Point(71, 12);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(146, 40);
            this.btnAccount.TabIndex = 1;
            this.btnAccount.Text = "User Account";
            this.btnAccount.UseVisualStyleBackColor = true;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnAccount);
            this.Controls.Add(this.btnMovieSearch);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "TMDbDotNet Sample App";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMovieSearch;
        private System.Windows.Forms.Button btnAccount;
    }
}