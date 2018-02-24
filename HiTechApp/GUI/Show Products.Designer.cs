namespace HiTechApp.GUI
{
    partial class Show_Products
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Show_Products));
            this.pictureBoxProd = new System.Windows.Forms.PictureBox();
            this.metroListViewProd = new MetroFramework.Controls.MetroListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader26 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProd)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxProd
            // 
            this.pictureBoxProd.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxProd.Image")));
            this.pictureBoxProd.Location = new System.Drawing.Point(820, 82);
            this.pictureBoxProd.Name = "pictureBoxProd";
            this.pictureBoxProd.Size = new System.Drawing.Size(295, 393);
            this.pictureBoxProd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProd.TabIndex = 99;
            this.pictureBoxProd.TabStop = false;
            this.pictureBoxProd.Tag = "No picture yet";
            // 
            // metroListViewProd
            // 
            this.metroListViewProd.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader26});
            this.metroListViewProd.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.metroListViewProd.FullRowSelect = true;
            this.metroListViewProd.GridLines = true;
            this.metroListViewProd.Location = new System.Drawing.Point(23, 82);
            this.metroListViewProd.Name = "metroListViewProd";
            this.metroListViewProd.OwnerDraw = true;
            this.metroListViewProd.Size = new System.Drawing.Size(791, 393);
            this.metroListViewProd.TabIndex = 98;
            this.metroListViewProd.UseCompatibleStateImageBehavior = false;
            this.metroListViewProd.UseSelectable = true;
            this.metroListViewProd.View = System.Windows.Forms.View.Details;
            this.metroListViewProd.MouseClick += new System.Windows.Forms.MouseEventHandler(this.metroListViewProd_MouseClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ProductID";
            this.columnHeader2.Width = 97;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Title";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Date";
            this.columnHeader7.Width = 98;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Category";
            this.columnHeader8.Width = 84;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Publisher";
            this.columnHeader9.Width = 114;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Author";
            this.columnHeader15.Width = 80;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Unit Price";
            this.columnHeader16.Width = 99;
            // 
            // columnHeader26
            // 
            this.columnHeader26.Text = "QOH";
            this.columnHeader26.Width = 64;
            // 
            // Show_Products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 498);
            this.Controls.Add(this.pictureBoxProd);
            this.Controls.Add(this.metroListViewProd);
            this.Name = "Show_Products";
            this.Text = "Product List";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxProd;
        private MetroFramework.Controls.MetroListView metroListViewProd;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader26;
    }
}