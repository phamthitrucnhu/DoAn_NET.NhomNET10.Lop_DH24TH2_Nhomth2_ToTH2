namespace DANGNHAP
{
    partial class menu
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
            this.btnTV = new System.Windows.Forms.Button();
            this.btnKHO = new System.Windows.Forms.Button();
            this.btnHD = new System.Windows.Forms.Button();
            this.btnNV = new System.Windows.Forms.Button();
            this.btnKH = new System.Windows.Forms.Button();
            this.btnT = new System.Windows.Forms.Button();
            this.lbMenu = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTV
            // 
            this.btnTV.BackColor = System.Drawing.SystemColors.Info;
            this.btnTV.Font = new System.Drawing.Font("Arial", 10.2F);
            this.btnTV.Location = new System.Drawing.Point(280, 89);
            this.btnTV.Name = "btnTV";
            this.btnTV.Size = new System.Drawing.Size(209, 37);
            this.btnTV.TabIndex = 0;
            this.btnTV.Text = "Quản Lý Sản Phẩm TiVi";
            this.btnTV.UseVisualStyleBackColor = false;
            this.btnTV.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnKHO
            // 
            this.btnKHO.BackColor = System.Drawing.SystemColors.Info;
            this.btnKHO.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKHO.Location = new System.Drawing.Point(280, 148);
            this.btnKHO.Name = "btnKHO";
            this.btnKHO.Size = new System.Drawing.Size(209, 37);
            this.btnKHO.TabIndex = 1;
            this.btnKHO.Text = "Quản Lý Kho Hàng";
            this.btnKHO.UseVisualStyleBackColor = false;
            this.btnKHO.Click += new System.EventHandler(this.btnKHO_Click);
            // 
            // btnHD
            // 
            this.btnHD.BackColor = System.Drawing.SystemColors.Info;
            this.btnHD.Font = new System.Drawing.Font("Arial", 10.2F);
            this.btnHD.Location = new System.Drawing.Point(280, 210);
            this.btnHD.Name = "btnHD";
            this.btnHD.Size = new System.Drawing.Size(209, 37);
            this.btnHD.TabIndex = 2;
            this.btnHD.Text = "Quản Lý Hóa Đơn";
            this.btnHD.UseVisualStyleBackColor = false;
            this.btnHD.Click += new System.EventHandler(this.btnHD_Click);
            // 
            // btnNV
            // 
            this.btnNV.BackColor = System.Drawing.SystemColors.Info;
            this.btnNV.Font = new System.Drawing.Font("Arial", 10.2F);
            this.btnNV.Location = new System.Drawing.Point(280, 325);
            this.btnNV.Name = "btnNV";
            this.btnNV.Size = new System.Drawing.Size(209, 37);
            this.btnNV.TabIndex = 3;
            this.btnNV.Text = "Quản Lý Nhân Viên";
            this.btnNV.UseVisualStyleBackColor = false;
            this.btnNV.Click += new System.EventHandler(this.btnNV_Click);
            // 
            // btnKH
            // 
            this.btnKH.BackColor = System.Drawing.SystemColors.Info;
            this.btnKH.Font = new System.Drawing.Font("Arial", 10.2F);
            this.btnKH.Location = new System.Drawing.Point(280, 268);
            this.btnKH.Name = "btnKH";
            this.btnKH.Size = new System.Drawing.Size(209, 37);
            this.btnKH.TabIndex = 4;
            this.btnKH.Text = "Quản Lý Khách Hàng";
            this.btnKH.UseVisualStyleBackColor = false;
            this.btnKH.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnT
            // 
            this.btnT.BackColor = System.Drawing.Color.MistyRose;
            this.btnT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnT.Location = new System.Drawing.Point(326, 389);
            this.btnT.Name = "btnT";
            this.btnT.Size = new System.Drawing.Size(106, 35);
            this.btnT.TabIndex = 5;
            this.btnT.Text = "Thoát";
            this.btnT.UseVisualStyleBackColor = false;
            this.btnT.Click += new System.EventHandler(this.button6_Click);
            // 
            // lbMenu
            // 
            this.lbMenu.AutoSize = true;
            this.lbMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMenu.Location = new System.Drawing.Point(214, 28);
            this.lbMenu.Name = "lbMenu";
            this.lbMenu.Size = new System.Drawing.Size(369, 32);
            this.lbMenu.TabIndex = 6;
            this.lbMenu.Text = "QUẢN LÝ CỬA HÀNG TIVI";
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbMenu);
            this.Controls.Add(this.btnT);
            this.Controls.Add(this.btnKH);
            this.Controls.Add(this.btnNV);
            this.Controls.Add(this.btnHD);
            this.Controls.Add(this.btnKHO);
            this.Controls.Add(this.btnTV);
            this.Name = "menu";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTV;
        private System.Windows.Forms.Button btnKHO;
        private System.Windows.Forms.Button btnHD;
        private System.Windows.Forms.Button btnNV;
        private System.Windows.Forms.Button btnKH;
        private System.Windows.Forms.Button btnT;
        private System.Windows.Forms.Label lbMenu;
    }
}