namespace Resturant.Card
{
    partial class frmCardList
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
            this.lbHeader = new System.Windows.Forms.Label();
            this.dgvCardList = new System.Windows.Forms.DataGridView();
            this.cmsCart = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.بياناتالطلبToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.اغاءالطلبToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.حذفالطلبToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbbState = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.cbbFilter = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbCounter = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbOrderPlace = new System.Windows.Forms.ComboBox();
            this.اكمالالطلبToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardList)).BeginInit();
            this.cmsCart.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbHeader
            // 
            this.lbHeader.AutoSize = true;
            this.lbHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeader.Location = new System.Drawing.Point(345, 51);
            this.lbHeader.Name = "lbHeader";
            this.lbHeader.Size = new System.Drawing.Size(279, 54);
            this.lbHeader.TabIndex = 14;
            this.lbHeader.Text = "قائمة المشتريات";
            // 
            // dgvCardList
            // 
            this.dgvCardList.AllowUserToAddRows = false;
            this.dgvCardList.AllowUserToDeleteRows = false;
            this.dgvCardList.BackgroundColor = System.Drawing.Color.White;
            this.dgvCardList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCardList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCardList.ContextMenuStrip = this.cmsCart;
            this.dgvCardList.Location = new System.Drawing.Point(32, 229);
            this.dgvCardList.Name = "dgvCardList";
            this.dgvCardList.ReadOnly = true;
            this.dgvCardList.RowHeadersWidth = 51;
            this.dgvCardList.RowTemplate.Height = 24;
            this.dgvCardList.Size = new System.Drawing.Size(939, 278);
            this.dgvCardList.TabIndex = 15;
            // 
            // cmsCart
            // 
            this.cmsCart.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsCart.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.بياناتالطلبToolStripMenuItem,
            this.اغاءالطلبToolStripMenuItem,
            this.حذفالطلبToolStripMenuItem,
            this.اكمالالطلبToolStripMenuItem});
            this.cmsCart.Name = "cmsCart";
            this.cmsCart.Size = new System.Drawing.Size(211, 128);
            this.cmsCart.Opening += new System.ComponentModel.CancelEventHandler(this.cmsCart_Opening);
            // 
            // بياناتالطلبToolStripMenuItem
            // 
            this.بياناتالطلبToolStripMenuItem.Name = "بياناتالطلبToolStripMenuItem";
            this.بياناتالطلبToolStripMenuItem.Size = new System.Drawing.Size(160, 24);
            this.بياناتالطلبToolStripMenuItem.Text = "بيانات الطلب";
            this.بياناتالطلبToolStripMenuItem.Click += new System.EventHandler(this.بياناتالطلبToolStripMenuItem_Click);
            // 
            // اغاءالطلبToolStripMenuItem
            // 
            this.اغاءالطلبToolStripMenuItem.Name = "اغاءالطلبToolStripMenuItem";
            this.اغاءالطلبToolStripMenuItem.Size = new System.Drawing.Size(160, 24);
            this.اغاءالطلبToolStripMenuItem.Text = "اغاء الطلب";
            this.اغاءالطلبToolStripMenuItem.Click += new System.EventHandler(this.اغاءالطلبToolStripMenuItem_Click);
            // 
            // حذفالطلبToolStripMenuItem
            // 
            this.حذفالطلبToolStripMenuItem.Name = "حذفالطلبToolStripMenuItem";
            this.حذفالطلبToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.حذفالطلبToolStripMenuItem.Text = "تعليق الطلب";
            this.حذفالطلبToolStripMenuItem.Click += new System.EventHandler(this.حذفالطلبToolStripMenuItem_Click);
            // 
            // cbbState
            // 
            this.cbbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbState.FormattingEnabled = true;
            this.cbbState.Items.AddRange(new object[] {
            "طلبية ناحجة",
            "طلبية معلقة",
            "طلبية ملغاة"});
            this.cbbState.Location = new System.Drawing.Point(582, 187);
            this.cbbState.Name = "cbbState";
            this.cbbState.Size = new System.Drawing.Size(100, 24);
            this.cbbState.TabIndex = 21;
            this.cbbState.Visible = false;
            this.cbbState.SelectedIndexChanged += new System.EventHandler(this.cbbState_SelectedIndexChanged);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Location = new System.Drawing.Point(508, 189);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(174, 22);
            this.txtFilterValue.TabIndex = 18;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            // 
            // cbbFilter
            // 
            this.cbbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFilter.FormattingEnabled = true;
            this.cbbFilter.Items.AddRange(new object[] {
            "لاشئ",
            "رقم الطلب",
            "حالة الطلب",
            "هل الطلب محلي"});
            this.cbbFilter.Location = new System.Drawing.Point(696, 188);
            this.cbbFilter.Name = "cbbFilter";
            this.cbbFilter.Size = new System.Drawing.Size(165, 24);
            this.cbbFilter.TabIndex = 17;
            this.cbbFilter.SelectedIndexChanged += new System.EventHandler(this.cbbFilter_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.label5.Location = new System.Drawing.Point(867, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 26);
            this.label5.TabIndex = 20;
            this.label5.Text = " : فلترة عبر ";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Image = global::Resturant.Properties.Resources.add;
            this.button2.Location = new System.Drawing.Point(36, 177);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 51);
            this.button2.TabIndex = 19;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.btnClose.Location = new System.Drawing.Point(32, 532);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(174, 60);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "اغلاق";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // lbCounter
            // 
            this.lbCounter.AutoSize = true;
            this.lbCounter.Location = new System.Drawing.Point(864, 546);
            this.lbCounter.Name = "lbCounter";
            this.lbCounter.Size = new System.Drawing.Size(14, 16);
            this.lbCounter.TabIndex = 25;
            this.lbCounter.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(907, 546);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 24;
            this.label3.Text = "المجموع";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(960, 546);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "#";
            // 
            // cbbOrderPlace
            // 
            this.cbbOrderPlace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbOrderPlace.FormattingEnabled = true;
            this.cbbOrderPlace.Items.AddRange(new object[] {
            "في المطعم ",
            "سفري",
            "الكل"});
            this.cbbOrderPlace.Location = new System.Drawing.Point(582, 187);
            this.cbbOrderPlace.Name = "cbbOrderPlace";
            this.cbbOrderPlace.Size = new System.Drawing.Size(100, 24);
            this.cbbOrderPlace.TabIndex = 26;
            this.cbbOrderPlace.Visible = false;
            this.cbbOrderPlace.SelectedIndexChanged += new System.EventHandler(this.cbbOrderPlace_SelectedIndexChanged);
            // 
            // اكمالالطلبToolStripMenuItem
            // 
            this.اكمالالطلبToolStripMenuItem.Name = "اكمالالطلبToolStripMenuItem";
            this.اكمالالطلبToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.اكمالالطلبToolStripMenuItem.Text = "اكمال الطلب";
            this.اكمالالطلبToolStripMenuItem.Click += new System.EventHandler(this.اكمالالطلبToolStripMenuItem_Click);
            // 
            // frmCardList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 618);
            this.Controls.Add(this.cbbOrderPlace);
            this.Controls.Add(this.lbCounter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cbbState);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.cbbFilter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dgvCardList);
            this.Controls.Add(this.lbHeader);
            this.Name = "frmCardList";
            this.Text = "frmCardList";
            this.Load += new System.EventHandler(this.frmCardList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardList)).EndInit();
            this.cmsCart.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbHeader;
        private System.Windows.Forms.DataGridView dgvCardList;
        private System.Windows.Forms.ComboBox cbbState;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.ComboBox cbbFilter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbCounter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbOrderPlace;
        private System.Windows.Forms.ContextMenuStrip cmsCart;
        private System.Windows.Forms.ToolStripMenuItem بياناتالطلبToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem اغاءالطلبToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem حذفالطلبToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem اكمالالطلبToolStripMenuItem;
    }
}