namespace Resturant.Card
{
    partial class frmShowOrderItem
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
            this.dgvOrderItm = new System.Windows.Forms.DataGridView();
            this.lbHeader = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTotal = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnComplate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItm)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrderItm
            // 
            this.dgvOrderItm.AllowUserToAddRows = false;
            this.dgvOrderItm.AllowUserToDeleteRows = false;
            this.dgvOrderItm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderItm.Location = new System.Drawing.Point(63, 111);
            this.dgvOrderItm.Name = "dgvOrderItm";
            this.dgvOrderItm.ReadOnly = true;
            this.dgvOrderItm.RowHeadersWidth = 51;
            this.dgvOrderItm.RowTemplate.Height = 24;
            this.dgvOrderItm.Size = new System.Drawing.Size(399, 453);
            this.dgvOrderItm.TabIndex = 0;
            // 
            // lbHeader
            // 
            this.lbHeader.AutoSize = true;
            this.lbHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeader.Location = new System.Drawing.Point(127, 29);
            this.lbHeader.Name = "lbHeader";
            this.lbHeader.Size = new System.Drawing.Size(279, 54);
            this.lbHeader.TabIndex = 15;
            this.lbHeader.Text = "قائمة المشتريات";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 577);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "الاجمالي :";
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Location = new System.Drawing.Point(133, 577);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(35, 16);
            this.lbTotal.TabIndex = 17;
            this.lbTotal.Text = "؟؟؟؟";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.btnClose.Location = new System.Drawing.Point(324, 625);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(138, 60);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "اغلاق";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnComplate
            // 
            this.btnComplate.BackColor = System.Drawing.Color.White;
            this.btnComplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.btnComplate.Location = new System.Drawing.Point(165, 625);
            this.btnComplate.Name = "btnComplate";
            this.btnComplate.Size = new System.Drawing.Size(138, 60);
            this.btnComplate.TabIndex = 24;
            this.btnComplate.Text = "اكمال العملية";
            this.btnComplate.UseVisualStyleBackColor = false;
            this.btnComplate.Visible = false;
            this.btnComplate.Click += new System.EventHandler(this.btnComplate_Click);
            // 
            // frmShowOrderItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 697);
            this.Controls.Add(this.btnComplate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbHeader);
            this.Controls.Add(this.dgvOrderItm);
            this.Name = "frmShowOrderItem";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "frmOrderItem";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrderItm;
        private System.Windows.Forms.Label lbHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnComplate;
    }
}