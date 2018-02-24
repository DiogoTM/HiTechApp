namespace HiTechApp.GUI
{
    partial class ShowOrders
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
            this.metroListViewOrdList = new MetroFramework.Controls.MetroListView();
            this.columnHeader29 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader30 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader32 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader33 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader34 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader31 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader38 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // metroListViewOrdList
            // 
            this.metroListViewOrdList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader29,
            this.columnHeader30,
            this.columnHeader32,
            this.columnHeader33,
            this.columnHeader34,
            this.columnHeader31,
            this.columnHeader38});
            this.metroListViewOrdList.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.metroListViewOrdList.FullRowSelect = true;
            this.metroListViewOrdList.GridLines = true;
            this.metroListViewOrdList.Location = new System.Drawing.Point(23, 79);
            this.metroListViewOrdList.Name = "metroListViewOrdList";
            this.metroListViewOrdList.OwnerDraw = true;
            this.metroListViewOrdList.Size = new System.Drawing.Size(757, 370);
            this.metroListViewOrdList.TabIndex = 16;
            this.metroListViewOrdList.UseCompatibleStateImageBehavior = false;
            this.metroListViewOrdList.UseSelectable = true;
            this.metroListViewOrdList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader29
            // 
            this.columnHeader29.Text = "OrderID";
            this.columnHeader29.Width = 111;
            // 
            // columnHeader30
            // 
            this.columnHeader30.Text = "Client";
            this.columnHeader30.Width = 158;
            // 
            // columnHeader32
            // 
            this.columnHeader32.Text = "Order Date";
            this.columnHeader32.Width = 111;
            // 
            // columnHeader33
            // 
            this.columnHeader33.Text = "Shipping Date";
            this.columnHeader33.Width = 112;
            // 
            // columnHeader34
            // 
            this.columnHeader34.Text = "Total Cost";
            this.columnHeader34.Width = 85;
            // 
            // columnHeader31
            // 
            this.columnHeader31.Text = "Order Type";
            this.columnHeader31.Width = 95;
            // 
            // columnHeader38
            // 
            this.columnHeader38.Text = "Placed by";
            this.columnHeader38.Width = 79;
            // 
            // ShowOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 472);
            this.Controls.Add(this.metroListViewOrdList);
            this.Name = "ShowOrders";
            this.Text = "Orders List";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroListView metroListViewOrdList;
        private System.Windows.Forms.ColumnHeader columnHeader29;
        private System.Windows.Forms.ColumnHeader columnHeader30;
        private System.Windows.Forms.ColumnHeader columnHeader32;
        private System.Windows.Forms.ColumnHeader columnHeader33;
        private System.Windows.Forms.ColumnHeader columnHeader34;
        private System.Windows.Forms.ColumnHeader columnHeader31;
        private System.Windows.Forms.ColumnHeader columnHeader38;
    }
}