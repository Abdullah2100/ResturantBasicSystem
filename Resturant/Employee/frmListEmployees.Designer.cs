namespace Resturant.Employee
{
    partial class frmListEmployees
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvEmployee = new System.Windows.Forms.DataGridView();
            this.cmsEmployee = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.اضافةموظفToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.تعديلالموظفToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.حذفالموظفToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.اظهاربياناتالموظفToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.تغيركلمةالسرToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.تفعيلالموظفToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ايقافتفعيلالموظفToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.cbbFilter = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lbCounter = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbState = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).BeginInit();
            this.cmsEmployee.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(541, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 59);
            this.label1.TabIndex = 0;
            this.label1.Text = "قائمة الموظفين";
            // 
            // dgvEmployee
            // 
            this.dgvEmployee.AllowUserToAddRows = false;
            this.dgvEmployee.AllowUserToDeleteRows = false;
            this.dgvEmployee.BackgroundColor = System.Drawing.Color.White;
            this.dgvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployee.ContextMenuStrip = this.cmsEmployee;
            this.dgvEmployee.Location = new System.Drawing.Point(108, 315);
            this.dgvEmployee.Name = "dgvEmployee";
            this.dgvEmployee.ReadOnly = true;
            this.dgvEmployee.RowHeadersWidth = 51;
            this.dgvEmployee.RowTemplate.Height = 24;
            this.dgvEmployee.Size = new System.Drawing.Size(1206, 301);
            this.dgvEmployee.TabIndex = 1;
            // 
            // cmsEmployee
            // 
            this.cmsEmployee.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsEmployee.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.اضافةموظفToolStripMenuItem,
            this.تعديلالموظفToolStripMenuItem,
            this.حذفالموظفToolStripMenuItem,
            this.اظهاربياناتالموظفToolStripMenuItem,
            this.تغيركلمةالسرToolStripMenuItem,
            this.تفعيلالموظفToolStripMenuItem,
            this.ايقافتفعيلالموظفToolStripMenuItem});
            this.cmsEmployee.Name = "cmsEmployee";
            this.cmsEmployee.Size = new System.Drawing.Size(214, 200);
            this.cmsEmployee.Opening += new System.ComponentModel.CancelEventHandler(this.cmsEmployee_Opening);
            // 
            // اضافةموظفToolStripMenuItem
            // 
            this.اضافةموظفToolStripMenuItem.Name = "اضافةموظفToolStripMenuItem";
            this.اضافةموظفToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.اضافةموظفToolStripMenuItem.Text = "اضافة موظف";
            this.اضافةموظفToolStripMenuItem.Click += new System.EventHandler(this.اضافةموظفToolStripMenuItem_Click);
            // 
            // تعديلالموظفToolStripMenuItem
            // 
            this.تعديلالموظفToolStripMenuItem.Name = "تعديلالموظفToolStripMenuItem";
            this.تعديلالموظفToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.تعديلالموظفToolStripMenuItem.Text = "تعديل الموظف";
            this.تعديلالموظفToolStripMenuItem.Click += new System.EventHandler(this.تعديلالموظفToolStripMenuItem_Click);
            // 
            // حذفالموظفToolStripMenuItem
            // 
            this.حذفالموظفToolStripMenuItem.Name = "حذفالموظفToolStripMenuItem";
            this.حذفالموظفToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.حذفالموظفToolStripMenuItem.Text = "حذف الموظف";
            this.حذفالموظفToolStripMenuItem.Click += new System.EventHandler(this.حذفالموظفToolStripMenuItem_Click);
            // 
            // اظهاربياناتالموظفToolStripMenuItem
            // 
            this.اظهاربياناتالموظفToolStripMenuItem.Name = "اظهاربياناتالموظفToolStripMenuItem";
            this.اظهاربياناتالموظفToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.اظهاربياناتالموظفToolStripMenuItem.Text = "اظهار بيانات الموظف";
            this.اظهاربياناتالموظفToolStripMenuItem.Click += new System.EventHandler(this.اظهاربياناتالموظفToolStripMenuItem_Click);
            // 
            // تغيركلمةالسرToolStripMenuItem
            // 
            this.تغيركلمةالسرToolStripMenuItem.Name = "تغيركلمةالسرToolStripMenuItem";
            this.تغيركلمةالسرToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.تغيركلمةالسرToolStripMenuItem.Text = "تغير كلمة السر ";
            this.تغيركلمةالسرToolStripMenuItem.Click += new System.EventHandler(this.تغيركلمةالسرToolStripMenuItem_Click);
            // 
            // تفعيلالموظفToolStripMenuItem
            // 
            this.تفعيلالموظفToolStripMenuItem.Name = "تفعيلالموظفToolStripMenuItem";
            this.تفعيلالموظفToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.تفعيلالموظفToolStripMenuItem.Text = "تفعيل الموظف";
            this.تفعيلالموظفToolStripMenuItem.Click += new System.EventHandler(this.تفعيلالموظفToolStripMenuItem_Click);
            // 
            // ايقافتفعيلالموظفToolStripMenuItem
            // 
            this.ايقافتفعيلالموظفToolStripMenuItem.Name = "ايقافتفعيلالموظفToolStripMenuItem";
            this.ايقافتفعيلالموظفToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.ايقافتفعيلالموظفToolStripMenuItem.Text = "ايقاف تفعيل الموظف";
            this.ايقافتفعيلالموظفToolStripMenuItem.Click += new System.EventHandler(this.ايقافتفعيلالموظفToolStripMenuItem_Click);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Location = new System.Drawing.Point(851, 268);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(174, 22);
            this.txtFilterValue.TabIndex = 9;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // cbbFilter
            // 
            this.cbbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFilter.FormattingEnabled = true;
            this.cbbFilter.Items.AddRange(new object[] {
            "لاشئ",
            "رقم الموظف",
            "رقم الشخص",
            "اسم المستخدم",
            "تاريخ الانشاء",
            "الاسم الكامل",
            "رقم الهاتف",
            "هل هو فعال"});
            this.cbbFilter.Location = new System.Drawing.Point(1039, 267);
            this.cbbFilter.Name = "cbbFilter";
            this.cbbFilter.Size = new System.Drawing.Size(165, 24);
            this.cbbFilter.TabIndex = 8;
            this.cbbFilter.SelectedIndexChanged += new System.EventHandler(this.cbbFilter_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.label5.Location = new System.Drawing.Point(1210, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 26);
            this.label5.TabIndex = 11;
            this.label5.Text = " : فلترة عبر ";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.button1.Location = new System.Drawing.Point(108, 622);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 53);
            this.button1.TabIndex = 15;
            this.button1.Text = "اغلاق";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbCounter
            // 
            this.lbCounter.AutoSize = true;
            this.lbCounter.Location = new System.Drawing.Point(1203, 643);
            this.lbCounter.Name = "lbCounter";
            this.lbCounter.Size = new System.Drawing.Size(14, 16);
            this.lbCounter.TabIndex = 14;
            this.lbCounter.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1246, 643);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "المجموع";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1299, 643);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "#";
            // 
            // cbbState
            // 
            this.cbbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbState.FormattingEnabled = true;
            this.cbbState.Items.AddRange(new object[] {
            "نعم",
            "لا",
            "الكل"});
            this.cbbState.Location = new System.Drawing.Point(925, 266);
            this.cbbState.Name = "cbbState";
            this.cbbState.Size = new System.Drawing.Size(100, 24);
            this.cbbState.TabIndex = 16;
            this.cbbState.Visible = false;
            this.cbbState.SelectedIndexChanged += new System.EventHandler(this.cbbState_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Image = global::Resturant.Properties.Resources.add;
            this.button2.Location = new System.Drawing.Point(108, 254);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 51);
            this.button2.TabIndex = 10;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmListEmployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1375, 693);
            this.Controls.Add(this.cbbState);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbCounter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.cbbFilter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dgvEmployee);
            this.Controls.Add(this.label1);
            this.Name = "frmListEmployees";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmListEmployees";
            this.Load += new System.EventHandler(this.frmListEmployees_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).EndInit();
            this.cmsEmployee.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvEmployee;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.ComboBox cbbFilter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbCounter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip cmsEmployee;
        private System.Windows.Forms.ToolStripMenuItem اضافةموظفToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem تعديلالموظفToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem حذفالموظفToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem اظهاربياناتالموظفToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbbState;
        private System.Windows.Forms.ToolStripMenuItem تغيركلمةالسرToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem تفعيلالموظفToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ايقافتفعيلالموظفToolStripMenuItem;
    }
}