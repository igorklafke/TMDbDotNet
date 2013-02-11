namespace TMDbSampleApp
{
    partial class FormSearch
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
            this.textSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.moviesGrid = new System.Windows.Forms.DataGridView();
            this.gbDetails = new System.Windows.Forms.GroupBox();
            this.btnFavorite = new System.Windows.Forms.Button();
            this.btnCast = new System.Windows.Forms.Button();
            this.lbOverview = new System.Windows.Forms.Label();
            this.lbReleaseDate = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.picturePoster = new System.Windows.Forms.PictureBox();
            this.btnWatchList = new System.Windows.Forms.Button();
            this.btnRate = new System.Windows.Forms.Button();
            this.numberRate = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.moviesGrid)).BeginInit();
            this.gbDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturePoster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberRate)).BeginInit();
            this.SuspendLayout();
            // 
            // textSearch
            // 
            this.textSearch.Location = new System.Drawing.Point(96, 6);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(339, 20);
            this.textSearch.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search Movies";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(441, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // moviesGrid
            // 
            this.moviesGrid.AllowUserToAddRows = false;
            this.moviesGrid.AllowUserToDeleteRows = false;
            this.moviesGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.moviesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.moviesGrid.Location = new System.Drawing.Point(12, 33);
            this.moviesGrid.MultiSelect = false;
            this.moviesGrid.Name = "moviesGrid";
            this.moviesGrid.ReadOnly = true;
            this.moviesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.moviesGrid.ShowEditingIcon = false;
            this.moviesGrid.Size = new System.Drawing.Size(504, 218);
            this.moviesGrid.TabIndex = 3;
            this.moviesGrid.Click += new System.EventHandler(this.moviesGrid_Click);
            // 
            // gbDetails
            // 
            this.gbDetails.Controls.Add(this.numberRate);
            this.gbDetails.Controls.Add(this.btnRate);
            this.gbDetails.Controls.Add(this.btnWatchList);
            this.gbDetails.Controls.Add(this.btnFavorite);
            this.gbDetails.Controls.Add(this.btnCast);
            this.gbDetails.Controls.Add(this.lbOverview);
            this.gbDetails.Controls.Add(this.lbReleaseDate);
            this.gbDetails.Controls.Add(this.lbTitle);
            this.gbDetails.Controls.Add(this.picturePoster);
            this.gbDetails.Location = new System.Drawing.Point(12, 257);
            this.gbDetails.Name = "gbDetails";
            this.gbDetails.Size = new System.Drawing.Size(504, 169);
            this.gbDetails.TabIndex = 4;
            this.gbDetails.TabStop = false;
            this.gbDetails.Text = "Movie Details";
            this.gbDetails.Visible = false;
            // 
            // btnFavorite
            // 
            this.btnFavorite.Enabled = false;
            this.btnFavorite.Location = new System.Drawing.Point(201, 134);
            this.btnFavorite.Name = "btnFavorite";
            this.btnFavorite.Size = new System.Drawing.Size(75, 23);
            this.btnFavorite.TabIndex = 5;
            this.btnFavorite.Text = "Favorite";
            this.btnFavorite.UseVisualStyleBackColor = true;
            this.btnFavorite.Click += new System.EventHandler(this.btnFavorite_Click);
            // 
            // btnCast
            // 
            this.btnCast.Enabled = false;
            this.btnCast.Location = new System.Drawing.Point(108, 134);
            this.btnCast.Name = "btnCast";
            this.btnCast.Size = new System.Drawing.Size(87, 23);
            this.btnCast.TabIndex = 4;
            this.btnCast.Text = "Cast and Crew";
            this.btnCast.UseVisualStyleBackColor = true;
            this.btnCast.Click += new System.EventHandler(this.btnCast_Click);
            // 
            // lbOverview
            // 
            this.lbOverview.AutoEllipsis = true;
            this.lbOverview.Location = new System.Drawing.Point(105, 59);
            this.lbOverview.Name = "lbOverview";
            this.lbOverview.Size = new System.Drawing.Size(393, 72);
            this.lbOverview.TabIndex = 3;
            this.lbOverview.Text = "_overview";
            // 
            // lbReleaseDate
            // 
            this.lbReleaseDate.AutoSize = true;
            this.lbReleaseDate.Location = new System.Drawing.Point(105, 38);
            this.lbReleaseDate.Name = "lbReleaseDate";
            this.lbReleaseDate.Size = new System.Drawing.Size(74, 13);
            this.lbReleaseDate.TabIndex = 2;
            this.lbReleaseDate.Text = "_release_date";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(105, 20);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(44, 18);
            this.lbTitle.TabIndex = 1;
            this.lbTitle.Text = "_title";
            // 
            // picturePoster
            // 
            this.picturePoster.Location = new System.Drawing.Point(7, 20);
            this.picturePoster.Name = "picturePoster";
            this.picturePoster.Size = new System.Drawing.Size(92, 138);
            this.picturePoster.TabIndex = 0;
            this.picturePoster.TabStop = false;
            // 
            // btnWatchList
            // 
            this.btnWatchList.Enabled = false;
            this.btnWatchList.Location = new System.Drawing.Point(282, 134);
            this.btnWatchList.Name = "btnWatchList";
            this.btnWatchList.Size = new System.Drawing.Size(75, 23);
            this.btnWatchList.TabIndex = 6;
            this.btnWatchList.Text = "Watchlist";
            this.btnWatchList.UseVisualStyleBackColor = true;
            this.btnWatchList.Click += new System.EventHandler(this.btnWatchList_Click);
            // 
            // btnRate
            // 
            this.btnRate.Enabled = false;
            this.btnRate.Location = new System.Drawing.Point(423, 134);
            this.btnRate.Name = "btnRate";
            this.btnRate.Size = new System.Drawing.Size(75, 23);
            this.btnRate.TabIndex = 7;
            this.btnRate.Text = "Rate";
            this.btnRate.UseVisualStyleBackColor = true;
            this.btnRate.Click += new System.EventHandler(this.btnRate_Click);
            // 
            // numberRate
            // 
            this.numberRate.Location = new System.Drawing.Point(365, 135);
            this.numberRate.Name = "numberRate";
            this.numberRate.Size = new System.Drawing.Size(52, 20);
            this.numberRate.TabIndex = 8;
            // 
            // FormSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 434);
            this.Controls.Add(this.gbDetails);
            this.Controls.Add(this.moviesGrid);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textSearch);
            this.MaximizeBox = false;
            this.Name = "FormSearch";
            this.Text = "TMDbDotNet Sample App";
            ((System.ComponentModel.ISupportInitialize)(this.moviesGrid)).EndInit();
            this.gbDetails.ResumeLayout(false);
            this.gbDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturePoster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView moviesGrid;
        private System.Windows.Forms.GroupBox gbDetails;
        private System.Windows.Forms.PictureBox picturePoster;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbOverview;
        private System.Windows.Forms.Label lbReleaseDate;
        private System.Windows.Forms.Button btnCast;
        private System.Windows.Forms.Button btnFavorite;
        private System.Windows.Forms.Button btnWatchList;
        private System.Windows.Forms.Button btnRate;
        private System.Windows.Forms.NumericUpDown numberRate;
    }
}

