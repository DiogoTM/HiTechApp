namespace HiTechApp.GUI
{
    partial class OrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderForm));
            this.metroComboBoxOrdProd = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel42 = new MetroFramework.Controls.MetroLabel();
            this.metroLabelProdCost = new MetroFramework.Controls.MetroLabel();
            this.metroLabelProdName = new MetroFramework.Controls.MetroLabel();
            this.metroLabel37 = new MetroFramework.Controls.MetroLabel();
            this.metroDateTimeOrdShip = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel36 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBoxOrdID = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel43 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel41 = new MetroFramework.Controls.MetroLabel();
            this.metroComboBoxOrdCl = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel50 = new MetroFramework.Controls.MetroLabel();
            this.metroComboBoxOrdProdType = new MetroFramework.Controls.MetroComboBox();
            this.metroTextBoxOrdQt = new MetroFramework.Controls.MetroTextBox();
            this.metroDateTimeOrd = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel20 = new MetroFramework.Controls.MetroLabel();
            this.metroComboBoxOrdType = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroTileOrdList = new MetroFramework.Controls.MetroTile();
            this.metroTileOrdRem = new MetroFramework.Controls.MetroTile();
            this.metroTileOrdAdd = new MetroFramework.Controls.MetroTile();
            this.metroTileOrdSav = new MetroFramework.Controls.MetroTile();
            this.metroTileOrdExit = new MetroFramework.Controls.MetroTile();
            this.pictureBoxOrdCl = new System.Windows.Forms.PictureBox();
            this.metroLabelProdTitle = new MetroFramework.Controls.MetroLabel();
            this.metroLabelProdCosts = new MetroFramework.Controls.MetroLabel();
            this.metroLabelClCredit = new MetroFramework.Controls.MetroLabel();
            this.metroLabelClName = new MetroFramework.Controls.MetroLabel();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.metroListViewOrder = new MetroFramework.Controls.MetroListView();
            this.metroLabelTotalCost = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrdCl)).BeginInit();
            this.SuspendLayout();
            // 
            // metroComboBoxOrdProd
            // 
            this.metroComboBoxOrdProd.FormattingEnabled = true;
            this.metroComboBoxOrdProd.ItemHeight = 23;
            this.metroComboBoxOrdProd.Location = new System.Drawing.Point(145, 148);
            this.metroComboBoxOrdProd.Name = "metroComboBoxOrdProd";
            this.metroComboBoxOrdProd.PromptText = "Product Selection";
            this.metroComboBoxOrdProd.Size = new System.Drawing.Size(153, 29);
            this.metroComboBoxOrdProd.TabIndex = 174;
            this.metroComboBoxOrdProd.Tag = "Product Selection";
            this.metroComboBoxOrdProd.UseSelectable = true;
            this.metroComboBoxOrdProd.SelectedIndexChanged += new System.EventHandler(this.metroComboBoxOrdProd_SelectedIndexChanged);
            // 
            // metroLabel42
            // 
            this.metroLabel42.AutoSize = true;
            this.metroLabel42.Location = new System.Drawing.Point(142, 126);
            this.metroLabel42.Name = "metroLabel42";
            this.metroLabel42.Size = new System.Drawing.Size(111, 19);
            this.metroLabel42.TabIndex = 173;
            this.metroLabel42.Text = "Product Selection";
            // 
            // metroLabelProdCost
            // 
            this.metroLabelProdCost.AutoSize = true;
            this.metroLabelProdCost.Location = new System.Drawing.Point(304, 148);
            this.metroLabelProdCost.Name = "metroLabelProdCost";
            this.metroLabelProdCost.Size = new System.Drawing.Size(0, 0);
            this.metroLabelProdCost.TabIndex = 172;
            // 
            // metroLabelProdName
            // 
            this.metroLabelProdName.AutoSize = true;
            this.metroLabelProdName.Location = new System.Drawing.Point(304, 129);
            this.metroLabelProdName.Name = "metroLabelProdName";
            this.metroLabelProdName.Size = new System.Drawing.Size(0, 0);
            this.metroLabelProdName.TabIndex = 171;
            // 
            // metroLabel37
            // 
            this.metroLabel37.AutoSize = true;
            this.metroLabel37.Location = new System.Drawing.Point(491, 71);
            this.metroLabel37.Name = "metroLabel37";
            this.metroLabel37.Size = new System.Drawing.Size(91, 19);
            this.metroLabel37.TabIndex = 170;
            this.metroLabel37.Text = "Shipping Date";
            // 
            // metroDateTimeOrdShip
            // 
            this.metroDateTimeOrdShip.Location = new System.Drawing.Point(491, 93);
            this.metroDateTimeOrdShip.MinimumSize = new System.Drawing.Size(0, 29);
            this.metroDateTimeOrdShip.Name = "metroDateTimeOrdShip";
            this.metroDateTimeOrdShip.Size = new System.Drawing.Size(200, 29);
            this.metroDateTimeOrdShip.TabIndex = 169;
            // 
            // metroLabel36
            // 
            this.metroLabel36.AutoSize = true;
            this.metroLabel36.Location = new System.Drawing.Point(285, 71);
            this.metroLabel36.Name = "metroLabel36";
            this.metroLabel36.Size = new System.Drawing.Size(76, 19);
            this.metroLabel36.TabIndex = 168;
            this.metroLabel36.Text = "Order Date";
            // 
            // metroTextBoxOrdID
            // 
            // 
            // 
            // 
            this.metroTextBoxOrdID.CustomButton.Image = null;
            this.metroTextBoxOrdID.CustomButton.Location = new System.Drawing.Point(48, 1);
            this.metroTextBoxOrdID.CustomButton.Name = "";
            this.metroTextBoxOrdID.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBoxOrdID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxOrdID.CustomButton.TabIndex = 1;
            this.metroTextBoxOrdID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxOrdID.CustomButton.UseSelectable = true;
            this.metroTextBoxOrdID.CustomButton.Visible = false;
            this.metroTextBoxOrdID.Enabled = false;
            this.metroTextBoxOrdID.Lines = new string[0];
            this.metroTextBoxOrdID.Location = new System.Drawing.Point(18, 99);
            this.metroTextBoxOrdID.MaxLength = 32767;
            this.metroTextBoxOrdID.Name = "metroTextBoxOrdID";
            this.metroTextBoxOrdID.PasswordChar = '\0';
            this.metroTextBoxOrdID.PromptText = "Order ID";
            this.metroTextBoxOrdID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxOrdID.SelectedText = "";
            this.metroTextBoxOrdID.SelectionLength = 0;
            this.metroTextBoxOrdID.SelectionStart = 0;
            this.metroTextBoxOrdID.ShortcutsEnabled = true;
            this.metroTextBoxOrdID.Size = new System.Drawing.Size(70, 23);
            this.metroTextBoxOrdID.TabIndex = 167;
            this.metroTextBoxOrdID.Tag = "Order ID";
            this.metroTextBoxOrdID.UseSelectable = true;
            this.metroTextBoxOrdID.WaterMark = "Order ID";
            this.metroTextBoxOrdID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxOrdID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel43
            // 
            this.metroLabel43.AutoSize = true;
            this.metroLabel43.Location = new System.Drawing.Point(15, 71);
            this.metroLabel43.Name = "metroLabel43";
            this.metroLabel43.Size = new System.Drawing.Size(61, 19);
            this.metroLabel43.TabIndex = 166;
            this.metroLabel43.Text = "Order ID";
            // 
            // metroLabel41
            // 
            this.metroLabel41.AutoSize = true;
            this.metroLabel41.Location = new System.Drawing.Point(221, 71);
            this.metroLabel41.Name = "metroLabel41";
            this.metroLabel41.Size = new System.Drawing.Size(58, 19);
            this.metroLabel41.TabIndex = 165;
            this.metroLabel41.Tag = "Quantity";
            this.metroLabel41.Text = "Quantity";
            // 
            // metroComboBoxOrdCl
            // 
            this.metroComboBoxOrdCl.FormattingEnabled = true;
            this.metroComboBoxOrdCl.ItemHeight = 23;
            this.metroComboBoxOrdCl.Location = new System.Drawing.Point(94, 93);
            this.metroComboBoxOrdCl.Name = "metroComboBoxOrdCl";
            this.metroComboBoxOrdCl.PromptText = "Client";
            this.metroComboBoxOrdCl.Size = new System.Drawing.Size(121, 29);
            this.metroComboBoxOrdCl.TabIndex = 164;
            this.metroComboBoxOrdCl.Tag = "Client";
            this.metroComboBoxOrdCl.UseSelectable = true;
            this.metroComboBoxOrdCl.DropDown += new System.EventHandler(this.metroComboBoxOrdCl_DropDown);
            this.metroComboBoxOrdCl.SelectedIndexChanged += new System.EventHandler(this.metroComboBoxOrdCl_SelectedIndexChanged);
            // 
            // metroLabel50
            // 
            this.metroLabel50.AutoSize = true;
            this.metroLabel50.Location = new System.Drawing.Point(91, 71);
            this.metroLabel50.Name = "metroLabel50";
            this.metroLabel50.Size = new System.Drawing.Size(42, 19);
            this.metroLabel50.TabIndex = 163;
            this.metroLabel50.Text = "Client";
            // 
            // metroComboBoxOrdProdType
            // 
            this.metroComboBoxOrdProdType.FormattingEnabled = true;
            this.metroComboBoxOrdProdType.ItemHeight = 23;
            this.metroComboBoxOrdProdType.Items.AddRange(new object[] {
            "Book",
            "Software"});
            this.metroComboBoxOrdProdType.Location = new System.Drawing.Point(18, 148);
            this.metroComboBoxOrdProdType.Name = "metroComboBoxOrdProdType";
            this.metroComboBoxOrdProdType.PromptText = "Product Type";
            this.metroComboBoxOrdProdType.Size = new System.Drawing.Size(121, 29);
            this.metroComboBoxOrdProdType.TabIndex = 162;
            this.metroComboBoxOrdProdType.Tag = "Product Type";
            this.metroComboBoxOrdProdType.UseSelectable = true;
            this.metroComboBoxOrdProdType.SelectedIndexChanged += new System.EventHandler(this.metroComboBoxOrdProdType_SelectedIndexChanged);
            // 
            // metroTextBoxOrdQt
            // 
            // 
            // 
            // 
            this.metroTextBoxOrdQt.CustomButton.Image = null;
            this.metroTextBoxOrdQt.CustomButton.Location = new System.Drawing.Point(36, 1);
            this.metroTextBoxOrdQt.CustomButton.Name = "";
            this.metroTextBoxOrdQt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBoxOrdQt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxOrdQt.CustomButton.TabIndex = 1;
            this.metroTextBoxOrdQt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxOrdQt.CustomButton.UseSelectable = true;
            this.metroTextBoxOrdQt.CustomButton.Visible = false;
            this.metroTextBoxOrdQt.Lines = new string[0];
            this.metroTextBoxOrdQt.Location = new System.Drawing.Point(221, 99);
            this.metroTextBoxOrdQt.MaxLength = 32767;
            this.metroTextBoxOrdQt.Name = "metroTextBoxOrdQt";
            this.metroTextBoxOrdQt.PasswordChar = '\0';
            this.metroTextBoxOrdQt.PromptText = "Quantity";
            this.metroTextBoxOrdQt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxOrdQt.SelectedText = "";
            this.metroTextBoxOrdQt.SelectionLength = 0;
            this.metroTextBoxOrdQt.SelectionStart = 0;
            this.metroTextBoxOrdQt.ShortcutsEnabled = true;
            this.metroTextBoxOrdQt.Size = new System.Drawing.Size(58, 23);
            this.metroTextBoxOrdQt.TabIndex = 161;
            this.metroTextBoxOrdQt.Tag = "Quantity";
            this.metroTextBoxOrdQt.UseSelectable = true;
            this.metroTextBoxOrdQt.WaterMark = "Quantity";
            this.metroTextBoxOrdQt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxOrdQt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroDateTimeOrd
            // 
            this.metroDateTimeOrd.Location = new System.Drawing.Point(285, 93);
            this.metroDateTimeOrd.MinimumSize = new System.Drawing.Size(0, 29);
            this.metroDateTimeOrd.Name = "metroDateTimeOrd";
            this.metroDateTimeOrd.Size = new System.Drawing.Size(200, 29);
            this.metroDateTimeOrd.TabIndex = 160;
            // 
            // metroLabel20
            // 
            this.metroLabel20.AutoSize = true;
            this.metroLabel20.Location = new System.Drawing.Point(15, 126);
            this.metroLabel20.Name = "metroLabel20";
            this.metroLabel20.Size = new System.Drawing.Size(86, 19);
            this.metroLabel20.TabIndex = 159;
            this.metroLabel20.Text = "Product Type";
            // 
            // metroComboBoxOrdType
            // 
            this.metroComboBoxOrdType.FormattingEnabled = true;
            this.metroComboBoxOrdType.ItemHeight = 23;
            this.metroComboBoxOrdType.Items.AddRange(new object[] {
            "Fax",
            "Phone",
            "E-mail"});
            this.metroComboBoxOrdType.Location = new System.Drawing.Point(697, 93);
            this.metroComboBoxOrdType.Name = "metroComboBoxOrdType";
            this.metroComboBoxOrdType.PromptText = "Order Type";
            this.metroComboBoxOrdType.Size = new System.Drawing.Size(153, 29);
            this.metroComboBoxOrdType.TabIndex = 180;
            this.metroComboBoxOrdType.Tag = "Order Type";
            this.metroComboBoxOrdType.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(697, 71);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(76, 19);
            this.metroLabel1.TabIndex = 179;
            this.metroLabel1.Text = "Order Type";
            // 
            // metroTileOrdList
            // 
            this.metroTileOrdList.ActiveControl = null;
            this.metroTileOrdList.BackColor = System.Drawing.Color.White;
            this.metroTileOrdList.ForeColor = System.Drawing.SystemColors.Highlight;
            this.metroTileOrdList.Location = new System.Drawing.Point(919, 321);
            this.metroTileOrdList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.metroTileOrdList.Name = "metroTileOrdList";
            this.metroTileOrdList.Size = new System.Drawing.Size(125, 40);
            this.metroTileOrdList.TabIndex = 187;
            this.metroTileOrdList.Text = "&List Items";
            this.metroTileOrdList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroTileOrdList.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTileOrdList.TileImage")));
            this.metroTileOrdList.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroTileOrdList.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.metroTileOrdList.UseCustomBackColor = true;
            this.metroTileOrdList.UseCustomForeColor = true;
            this.metroTileOrdList.UseSelectable = true;
            this.metroTileOrdList.UseTileImage = true;
            this.metroTileOrdList.Click += new System.EventHandler(this.metroTileOrdList_Click);
            // 
            // metroTileOrdRem
            // 
            this.metroTileOrdRem.ActiveControl = null;
            this.metroTileOrdRem.BackColor = System.Drawing.Color.White;
            this.metroTileOrdRem.ForeColor = System.Drawing.SystemColors.Highlight;
            this.metroTileOrdRem.Location = new System.Drawing.Point(919, 229);
            this.metroTileOrdRem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.metroTileOrdRem.Name = "metroTileOrdRem";
            this.metroTileOrdRem.Size = new System.Drawing.Size(125, 40);
            this.metroTileOrdRem.TabIndex = 186;
            this.metroTileOrdRem.Text = "&Remove Item";
            this.metroTileOrdRem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroTileOrdRem.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTileOrdRem.TileImage")));
            this.metroTileOrdRem.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroTileOrdRem.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.metroTileOrdRem.UseCustomBackColor = true;
            this.metroTileOrdRem.UseCustomForeColor = true;
            this.metroTileOrdRem.UseSelectable = true;
            this.metroTileOrdRem.UseTileImage = true;
            this.metroTileOrdRem.Click += new System.EventHandler(this.metroTileOrdRem_Click);
            // 
            // metroTileOrdAdd
            // 
            this.metroTileOrdAdd.ActiveControl = null;
            this.metroTileOrdAdd.BackColor = System.Drawing.Color.White;
            this.metroTileOrdAdd.ForeColor = System.Drawing.SystemColors.Highlight;
            this.metroTileOrdAdd.Location = new System.Drawing.Point(919, 183);
            this.metroTileOrdAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.metroTileOrdAdd.Name = "metroTileOrdAdd";
            this.metroTileOrdAdd.Size = new System.Drawing.Size(125, 40);
            this.metroTileOrdAdd.TabIndex = 185;
            this.metroTileOrdAdd.Text = "&Add Item";
            this.metroTileOrdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroTileOrdAdd.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTileOrdAdd.TileImage")));
            this.metroTileOrdAdd.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroTileOrdAdd.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.metroTileOrdAdd.UseCustomBackColor = true;
            this.metroTileOrdAdd.UseCustomForeColor = true;
            this.metroTileOrdAdd.UseSelectable = true;
            this.metroTileOrdAdd.UseTileImage = true;
            this.metroTileOrdAdd.Click += new System.EventHandler(this.metroTileOrdAdd_Click);
            // 
            // metroTileOrdSav
            // 
            this.metroTileOrdSav.ActiveControl = null;
            this.metroTileOrdSav.BackColor = System.Drawing.Color.White;
            this.metroTileOrdSav.ForeColor = System.Drawing.SystemColors.Highlight;
            this.metroTileOrdSav.Location = new System.Drawing.Point(919, 275);
            this.metroTileOrdSav.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.metroTileOrdSav.Name = "metroTileOrdSav";
            this.metroTileOrdSav.Size = new System.Drawing.Size(125, 40);
            this.metroTileOrdSav.TabIndex = 184;
            this.metroTileOrdSav.Text = "&Save Order";
            this.metroTileOrdSav.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroTileOrdSav.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTileOrdSav.TileImage")));
            this.metroTileOrdSav.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroTileOrdSav.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.metroTileOrdSav.UseCustomBackColor = true;
            this.metroTileOrdSav.UseCustomForeColor = true;
            this.metroTileOrdSav.UseSelectable = true;
            this.metroTileOrdSav.UseTileImage = true;
            this.metroTileOrdSav.Click += new System.EventHandler(this.metroTileOrdSav_Click);
            // 
            // metroTileOrdExit
            // 
            this.metroTileOrdExit.ActiveControl = null;
            this.metroTileOrdExit.BackColor = System.Drawing.Color.White;
            this.metroTileOrdExit.ForeColor = System.Drawing.SystemColors.Highlight;
            this.metroTileOrdExit.Location = new System.Drawing.Point(919, 365);
            this.metroTileOrdExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.metroTileOrdExit.Name = "metroTileOrdExit";
            this.metroTileOrdExit.Size = new System.Drawing.Size(125, 40);
            this.metroTileOrdExit.TabIndex = 188;
            this.metroTileOrdExit.Text = "&Exit";
            this.metroTileOrdExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroTileOrdExit.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTileOrdExit.TileImage")));
            this.metroTileOrdExit.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroTileOrdExit.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.metroTileOrdExit.UseCustomBackColor = true;
            this.metroTileOrdExit.UseCustomForeColor = true;
            this.metroTileOrdExit.UseSelectable = true;
            this.metroTileOrdExit.UseTileImage = true;
            this.metroTileOrdExit.Click += new System.EventHandler(this.metroTileOrdExit_Click);
            // 
            // pictureBoxOrdCl
            // 
            this.pictureBoxOrdCl.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxOrdCl.Image")));
            this.pictureBoxOrdCl.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxOrdCl.InitialImage")));
            this.pictureBoxOrdCl.Location = new System.Drawing.Point(919, 23);
            this.pictureBoxOrdCl.Name = "pictureBoxOrdCl";
            this.pictureBoxOrdCl.Size = new System.Drawing.Size(112, 109);
            this.pictureBoxOrdCl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxOrdCl.TabIndex = 189;
            this.pictureBoxOrdCl.TabStop = false;
            this.pictureBoxOrdCl.Tag = "No image Yet";
            // 
            // metroLabelProdTitle
            // 
            this.metroLabelProdTitle.AutoSize = true;
            this.metroLabelProdTitle.Location = new System.Drawing.Point(327, 135);
            this.metroLabelProdTitle.Name = "metroLabelProdTitle";
            this.metroLabelProdTitle.Size = new System.Drawing.Size(136, 19);
            this.metroLabelProdTitle.TabIndex = 190;
            this.metroLabelProdTitle.Text = "Product Selected Title";
            // 
            // metroLabelProdCosts
            // 
            this.metroLabelProdCosts.AutoSize = true;
            this.metroLabelProdCosts.Location = new System.Drawing.Point(327, 154);
            this.metroLabelProdCosts.Name = "metroLabelProdCosts";
            this.metroLabelProdCosts.Size = new System.Drawing.Size(234, 19);
            this.metroLabelProdCosts.TabIndex = 191;
            this.metroLabelProdCosts.Text = "Product Selected  Unit Cost & Total Cost";
            // 
            // metroLabelClCredit
            // 
            this.metroLabelClCredit.AutoSize = true;
            this.metroLabelClCredit.Location = new System.Drawing.Point(895, 154);
            this.metroLabelClCredit.Name = "metroLabelClCredit";
            this.metroLabelClCredit.Size = new System.Drawing.Size(89, 19);
            this.metroLabelClCredit.TabIndex = 193;
            this.metroLabelClCredit.Text = "Client\'s Credit";
            this.metroLabelClCredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroLabelClName
            // 
            this.metroLabelClName.AutoSize = true;
            this.metroLabelClName.Location = new System.Drawing.Point(933, 135);
            this.metroLabelClName.Name = "metroLabelClName";
            this.metroLabelClName.Size = new System.Drawing.Size(95, 19);
            this.metroLabelClName.TabIndex = 192;
            this.metroLabelClName.Text = "Client Selected";
            this.metroLabelClName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Ord ItemID";
            this.columnHeader1.Width = 109;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Item ID";
            this.columnHeader9.Width = 79;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Item Type";
            this.columnHeader2.Width = 86;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Title";
            this.columnHeader3.Width = 188;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Author";
            this.columnHeader4.Width = 123;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Quantity";
            this.columnHeader5.Width = 113;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Unit Cost";
            this.columnHeader6.Width = 90;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Subtotal Cost";
            this.columnHeader7.Width = 107;
            // 
            // metroListViewOrder
            // 
            this.metroListViewOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader9,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.metroListViewOrder.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.metroListViewOrder.FullRowSelect = true;
            this.metroListViewOrder.GridLines = true;
            this.metroListViewOrder.Location = new System.Drawing.Point(18, 183);
            this.metroListViewOrder.Name = "metroListViewOrder";
            this.metroListViewOrder.OwnerDraw = true;
            this.metroListViewOrder.Size = new System.Drawing.Size(901, 287);
            this.metroListViewOrder.TabIndex = 177;
            this.metroListViewOrder.UseCompatibleStateImageBehavior = false;
            this.metroListViewOrder.UseSelectable = true;
            this.metroListViewOrder.View = System.Windows.Forms.View.Details;
            // 
            // metroLabelTotalCost
            // 
            this.metroLabelTotalCost.AutoSize = true;
            this.metroLabelTotalCost.Location = new System.Drawing.Point(697, 154);
            this.metroLabelTotalCost.Name = "metroLabelTotalCost";
            this.metroLabelTotalCost.Size = new System.Drawing.Size(12, 19);
            this.metroLabelTotalCost.TabIndex = 194;
            this.metroLabelTotalCost.Text = ".";
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 478);
            this.Controls.Add(this.metroLabelTotalCost);
            this.Controls.Add(this.metroLabelClCredit);
            this.Controls.Add(this.metroLabelClName);
            this.Controls.Add(this.metroLabelProdCosts);
            this.Controls.Add(this.metroLabelProdTitle);
            this.Controls.Add(this.pictureBoxOrdCl);
            this.Controls.Add(this.metroTileOrdExit);
            this.Controls.Add(this.metroTileOrdList);
            this.Controls.Add(this.metroTileOrdRem);
            this.Controls.Add(this.metroTileOrdAdd);
            this.Controls.Add(this.metroTileOrdSav);
            this.Controls.Add(this.metroComboBoxOrdType);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroListViewOrder);
            this.Controls.Add(this.metroComboBoxOrdProd);
            this.Controls.Add(this.metroLabel42);
            this.Controls.Add(this.metroLabel37);
            this.Controls.Add(this.metroDateTimeOrdShip);
            this.Controls.Add(this.metroLabel36);
            this.Controls.Add(this.metroTextBoxOrdID);
            this.Controls.Add(this.metroLabel43);
            this.Controls.Add(this.metroLabel41);
            this.Controls.Add(this.metroComboBoxOrdCl);
            this.Controls.Add(this.metroLabel50);
            this.Controls.Add(this.metroComboBoxOrdProdType);
            this.Controls.Add(this.metroTextBoxOrdQt);
            this.Controls.Add(this.metroDateTimeOrd);
            this.Controls.Add(this.metroLabel20);
            this.Name = "OrderForm";
            this.Text = "Order Control System";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrdCl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox metroComboBoxOrdProd;
        private MetroFramework.Controls.MetroLabel metroLabel42;
        private MetroFramework.Controls.MetroLabel metroLabelProdCost;
        private MetroFramework.Controls.MetroLabel metroLabelProdName;
        private MetroFramework.Controls.MetroLabel metroLabel37;
        private MetroFramework.Controls.MetroDateTime metroDateTimeOrdShip;
        private MetroFramework.Controls.MetroLabel metroLabel36;
        private MetroFramework.Controls.MetroTextBox metroTextBoxOrdID;
        private MetroFramework.Controls.MetroLabel metroLabel43;
        private MetroFramework.Controls.MetroLabel metroLabel41;
        private MetroFramework.Controls.MetroComboBox metroComboBoxOrdCl;
        private MetroFramework.Controls.MetroLabel metroLabel50;
        private MetroFramework.Controls.MetroComboBox metroComboBoxOrdProdType;
        private MetroFramework.Controls.MetroTextBox metroTextBoxOrdQt;
        private MetroFramework.Controls.MetroDateTime metroDateTimeOrd;
        private MetroFramework.Controls.MetroLabel metroLabel20;
        private MetroFramework.Controls.MetroComboBox metroComboBoxOrdType;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTile metroTileOrdList;
        private MetroFramework.Controls.MetroTile metroTileOrdRem;
        private MetroFramework.Controls.MetroTile metroTileOrdAdd;
        private MetroFramework.Controls.MetroTile metroTileOrdSav;
        private MetroFramework.Controls.MetroTile metroTileOrdExit;
        private System.Windows.Forms.PictureBox pictureBoxOrdCl;
        private MetroFramework.Controls.MetroLabel metroLabelProdTitle;
        private MetroFramework.Controls.MetroLabel metroLabelProdCosts;
        private MetroFramework.Controls.MetroLabel metroLabelClCredit;
        private MetroFramework.Controls.MetroLabel metroLabelClName;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private MetroFramework.Controls.MetroListView metroListViewOrder;
        private MetroFramework.Controls.MetroLabel metroLabelTotalCost;
    }
}