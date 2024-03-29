namespace Resturant
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.employeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.peopleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.المعلوماتالشخصيةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.تغيركلمةالمرورToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.الفواتيرToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpcItem = new System.Windows.Forms.TabPage();
            this.dgvItem = new System.Windows.Forms.DataGridView();
            this.cmsItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.تعديلبياناتالطبقToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.حذفالطبقToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.اضافةللسلةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tpcCategory = new System.Windows.Forms.TabPage();
            this.dgvCategory = new System.Windows.Forms.DataGridView();
            this.cmsCategory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.حذفالصنفToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.cmsCart = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.حذفالعنصرمنالسلةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.شراءToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.افراغالسلةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.تسجيلالخروجToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpcItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
            this.cmsItems.SuspendLayout();
            this.tpcCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategory)).BeginInit();
            this.cmsCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.cmsCart.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employeeToolStripMenuItem,
            this.peopleToolStripMenuItem,
            this.currentUserToolStripMenuItem,
            this.الفواتيرToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1173, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // employeeToolStripMenuItem
            // 
            this.employeeToolStripMenuItem.Name = "employeeToolStripMenuItem";
            this.employeeToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.employeeToolStripMenuItem.Text = "الموظفين";
            this.employeeToolStripMenuItem.Click += new System.EventHandler(this.employeeToolStripMenuItem_Click);
            // 
            // peopleToolStripMenuItem
            // 
            this.peopleToolStripMenuItem.Name = "peopleToolStripMenuItem";
            this.peopleToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.peopleToolStripMenuItem.Text = "الاشخاص";
            this.peopleToolStripMenuItem.Click += new System.EventHandler(this.peopleToolStripMenuItem_Click);
            // 
            // currentUserToolStripMenuItem
            // 
            this.currentUserToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.المعلوماتالشخصيةToolStripMenuItem,
            this.تغيركلمةالمرورToolStripMenuItem,
            this.تسجيلالخروجToolStripMenuItem});
            this.currentUserToolStripMenuItem.Name = "currentUserToolStripMenuItem";
            this.currentUserToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.currentUserToolStripMenuItem.Text = "المستخدم الحالي";
            this.currentUserToolStripMenuItem.Click += new System.EventHandler(this.currentUserToolStripMenuItem_Click);
            // 
            // المعلوماتالشخصيةToolStripMenuItem
            // 
            this.المعلوماتالشخصيةToolStripMenuItem.Name = "المعلوماتالشخصيةToolStripMenuItem";
            this.المعلوماتالشخصيةToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.المعلوماتالشخصيةToolStripMenuItem.Text = "المعلومات الشخصية";
            this.المعلوماتالشخصيةToolStripMenuItem.Click += new System.EventHandler(this.المعلوماتالشخصيةToolStripMenuItem_Click);
            // 
            // تغيركلمةالمرورToolStripMenuItem
            // 
            this.تغيركلمةالمرورToolStripMenuItem.Name = "تغيركلمةالمرورToolStripMenuItem";
            this.تغيركلمةالمرورToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.تغيركلمةالمرورToolStripMenuItem.Text = "تغير كلمة المرور";
            this.تغيركلمةالمرورToolStripMenuItem.Click += new System.EventHandler(this.تغيركلمةالمرورToolStripMenuItem_Click);
            // 
            // الفواتيرToolStripMenuItem
            // 
            this.الفواتيرToolStripMenuItem.Name = "الفواتيرToolStripMenuItem";
            this.الفواتيرToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.الفواتيرToolStripMenuItem.Text = "قائمة المشتريات";
            this.الفواتيرToolStripMenuItem.Click += new System.EventHandler(this.الفواتيرToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpcItem);
            this.tabControl1.Controls.Add(this.tpcCategory);
            this.tabControl1.Location = new System.Drawing.Point(512, 104);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(661, 643);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tpcItem
            // 
            this.tpcItem.Controls.Add(this.dgvItem);
            this.tpcItem.Location = new System.Drawing.Point(4, 25);
            this.tpcItem.Name = "tpcItem";
            this.tpcItem.Padding = new System.Windows.Forms.Padding(3);
            this.tpcItem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tpcItem.Size = new System.Drawing.Size(653, 614);
            this.tpcItem.TabIndex = 0;
            this.tpcItem.Text = "الاطباق";
            this.tpcItem.UseVisualStyleBackColor = true;
            // 
            // dgvItem
            // 
            this.dgvItem.AllowUserToAddRows = false;
            this.dgvItem.AllowUserToDeleteRows = false;
            this.dgvItem.BackgroundColor = System.Drawing.Color.White;
            this.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItem.ContextMenuStrip = this.cmsItems;
            this.dgvItem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvItem.Location = new System.Drawing.Point(3, 34);
            this.dgvItem.Name = "dgvItem";
            this.dgvItem.ReadOnly = true;
            this.dgvItem.RowHeadersWidth = 51;
            this.dgvItem.RowTemplate.Height = 24;
            this.dgvItem.Size = new System.Drawing.Size(647, 577);
            this.dgvItem.TabIndex = 0;
            // 
            // cmsItems
            // 
            this.cmsItems.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dToolStripMenuItem,
            this.تعديلبياناتالطبقToolStripMenuItem,
            this.حذفالطبقToolStripMenuItem,
            this.اضافةللسلةToolStripMenuItem});
            this.cmsItems.Name = "cmsItems";
            this.cmsItems.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmsItems.Size = new System.Drawing.Size(199, 100);
            this.cmsItems.Opening += new System.ComponentModel.CancelEventHandler(this.cmsItems_Opening);
            // 
            // dToolStripMenuItem
            // 
            this.dToolStripMenuItem.Name = "dToolStripMenuItem";
            this.dToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.dToolStripMenuItem.Text = "اضافة طبق جديد";
            this.dToolStripMenuItem.Click += new System.EventHandler(this.dToolStripMenuItem_Click);
            // 
            // تعديلبياناتالطبقToolStripMenuItem
            // 
            this.تعديلبياناتالطبقToolStripMenuItem.Name = "تعديلبياناتالطبقToolStripMenuItem";
            this.تعديلبياناتالطبقToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.تعديلبياناتالطبقToolStripMenuItem.Text = "تعديل بيانات الطبق";
            this.تعديلبياناتالطبقToolStripMenuItem.Click += new System.EventHandler(this.تعديلبياناتالطبقToolStripMenuItem_Click);
            // 
            // حذفالطبقToolStripMenuItem
            // 
            this.حذفالطبقToolStripMenuItem.Name = "حذفالطبقToolStripMenuItem";
            this.حذفالطبقToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.حذفالطبقToolStripMenuItem.Text = "حذف الطبق";
            // 
            // اضافةللسلةToolStripMenuItem
            // 
            this.اضافةللسلةToolStripMenuItem.Name = "اضافةللسلةToolStripMenuItem";
            this.اضافةللسلةToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.اضافةللسلةToolStripMenuItem.Text = "اضافة للسلة";
            this.اضافةللسلةToolStripMenuItem.Click += new System.EventHandler(this.اضافةللسلةToolStripMenuItem_Click);
            // 
            // tpcCategory
            // 
            this.tpcCategory.Controls.Add(this.dgvCategory);
            this.tpcCategory.Location = new System.Drawing.Point(4, 25);
            this.tpcCategory.Name = "tpcCategory";
            this.tpcCategory.Padding = new System.Windows.Forms.Padding(3);
            this.tpcCategory.Size = new System.Drawing.Size(653, 614);
            this.tpcCategory.TabIndex = 1;
            this.tpcCategory.Text = "الاصناف";
            this.tpcCategory.UseVisualStyleBackColor = true;
            // 
            // dgvCategory
            // 
            this.dgvCategory.AllowUserToAddRows = false;
            this.dgvCategory.AllowUserToDeleteRows = false;
            this.dgvCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategory.ContextMenuStrip = this.cmsCategory;
            this.dgvCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCategory.Location = new System.Drawing.Point(3, 3);
            this.dgvCategory.Name = "dgvCategory";
            this.dgvCategory.ReadOnly = true;
            this.dgvCategory.RowHeadersWidth = 51;
            this.dgvCategory.RowTemplate.Height = 24;
            this.dgvCategory.Size = new System.Drawing.Size(647, 608);
            this.dgvCategory.TabIndex = 0;
            // 
            // cmsCategory
            // 
            this.cmsCategory.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsCategory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dToolStripMenuItem1,
            this.dToolStripMenuItem2,
            this.حذفالصنفToolStripMenuItem});
            this.cmsCategory.Name = "cmsCategory";
            this.cmsCategory.Size = new System.Drawing.Size(208, 76);
            this.cmsCategory.Opening += new System.ComponentModel.CancelEventHandler(this.cmsCategory_Opening);
            // 
            // dToolStripMenuItem1
            // 
            this.dToolStripMenuItem1.Name = "dToolStripMenuItem1";
            this.dToolStripMenuItem1.Size = new System.Drawing.Size(207, 24);
            this.dToolStripMenuItem1.Text = "اضافة صنف جديد";
            this.dToolStripMenuItem1.Click += new System.EventHandler(this.dToolStripMenuItem1_Click);
            // 
            // dToolStripMenuItem2
            // 
            this.dToolStripMenuItem2.Name = "dToolStripMenuItem2";
            this.dToolStripMenuItem2.Size = new System.Drawing.Size(207, 24);
            this.dToolStripMenuItem2.Text = "تعديل الصنف الحالي";
            this.dToolStripMenuItem2.Click += new System.EventHandler(this.dToolStripMenuItem2_Click);
            // 
            // حذفالصنفToolStripMenuItem
            // 
            this.حذفالصنفToolStripMenuItem.Name = "حذفالصنفToolStripMenuItem";
            this.حذفالصنفToolStripMenuItem.Size = new System.Drawing.Size(207, 24);
            this.حذفالصنفToolStripMenuItem.Text = "حذف الصنف";
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.BackgroundColor = System.Drawing.Color.White;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.ContextMenuStrip = this.cmsCart;
            this.dgvCart.Location = new System.Drawing.Point(3, 71);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.RowHeadersWidth = 51;
            this.dgvCart.RowTemplate.Height = 24;
            this.dgvCart.Size = new System.Drawing.Size(494, 669);
            this.dgvCart.TabIndex = 4;
            // 
            // cmsCart
            // 
            this.cmsCart.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsCart.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.حذفالعنصرمنالسلةToolStripMenuItem,
            this.شراءToolStripMenuItem,
            this.افراغالسلةToolStripMenuItem});
            this.cmsCart.Name = "cmsCart";
            this.cmsCart.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmsCart.Size = new System.Drawing.Size(220, 76);
            this.cmsCart.Opening += new System.ComponentModel.CancelEventHandler(this.cmsCart_Opening);
            // 
            // حذفالعنصرمنالسلةToolStripMenuItem
            // 
            this.حذفالعنصرمنالسلةToolStripMenuItem.Name = "حذفالعنصرمنالسلةToolStripMenuItem";
            this.حذفالعنصرمنالسلةToolStripMenuItem.Size = new System.Drawing.Size(219, 24);
            this.حذفالعنصرمنالسلةToolStripMenuItem.Text = "حذف العنصر من السلة";
            this.حذفالعنصرمنالسلةToolStripMenuItem.Click += new System.EventHandler(this.حذفالعنصرمنالسلةToolStripMenuItem_Click);
            // 
            // شراءToolStripMenuItem
            // 
            this.شراءToolStripMenuItem.Name = "شراءToolStripMenuItem";
            this.شراءToolStripMenuItem.Size = new System.Drawing.Size(219, 24);
            this.شراءToolStripMenuItem.Text = "شراء";
            this.شراءToolStripMenuItem.Click += new System.EventHandler(this.شراءToolStripMenuItem_Click);
            // 
            // افراغالسلةToolStripMenuItem
            // 
            this.افراغالسلةToolStripMenuItem.Name = "افراغالسلةToolStripMenuItem";
            this.افراغالسلةToolStripMenuItem.Size = new System.Drawing.Size(219, 24);
            this.افراغالسلةToolStripMenuItem.Text = "افراغ السلة";
            this.افراغالسلةToolStripMenuItem.Click += new System.EventHandler(this.افراغالسلةToolStripMenuItem_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(718, 61);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(301, 22);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // تسجيلالخروجToolStripMenuItem
            // 
            this.تسجيلالخروجToolStripMenuItem.Name = "تسجيلالخروجToolStripMenuItem";
            this.تسجيلالخروجToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.تسجيلالخروجToolStripMenuItem.Text = "تسجيل الخروج";
            this.تسجيلالخروجToolStripMenuItem.Click += new System.EventHandler(this.تسجيلالخروجToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1173, 759);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvCart);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpcItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            this.cmsItems.ResumeLayout(false);
            this.tpcCategory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategory)).EndInit();
            this.cmsCategory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.cmsCart.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem employeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem peopleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentUserToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpcItem;
        private System.Windows.Forms.TabPage tpcCategory;
        private System.Windows.Forms.ToolStripMenuItem المعلوماتالشخصيةToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem تغيركلمةالمرورToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvItem;
        private System.Windows.Forms.DataGridView dgvCategory;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.ContextMenuStrip cmsCart;
        private System.Windows.Forms.ToolStripMenuItem حذفالعنصرمنالسلةToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem شراءToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsItems;
        private System.Windows.Forms.ToolStripMenuItem dToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem تعديلبياناتالطبقToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem حذفالطبقToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsCategory;
        private System.Windows.Forms.ToolStripMenuItem dToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem حذفالصنفToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem اضافةللسلةToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem افراغالسلةToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem الفواتيرToolStripMenuItem;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ToolStripMenuItem تسجيلالخروجToolStripMenuItem;
    }
}