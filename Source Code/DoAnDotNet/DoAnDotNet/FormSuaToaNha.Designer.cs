namespace DoAnDotNet
{
    partial class FormSuaToaNha
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
            this.btn_QuayLai = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_XacNhan = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_PhuongXa = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_QuanHuyen = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_ThanhPho = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_TenToaNha = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_MaToaNha = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_QuayLai
            // 
            this.btn_QuayLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QuayLai.Location = new System.Drawing.Point(271, 236);
            this.btn_QuayLai.Name = "btn_QuayLai";
            this.btn_QuayLai.Size = new System.Drawing.Size(83, 26);
            this.btn_QuayLai.TabIndex = 13;
            this.btn_QuayLai.Text = "Quay lại";
            this.btn_QuayLai.UseVisualStyleBackColor = true;
            this.btn_QuayLai.Click += new System.EventHandler(this.btn_QuayLai_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Xoa.Location = new System.Drawing.Point(181, 236);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(83, 26);
            this.btn_Xoa.TabIndex = 12;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_XacNhan
            // 
            this.btn_XacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XacNhan.Location = new System.Drawing.Point(91, 236);
            this.btn_XacNhan.Name = "btn_XacNhan";
            this.btn_XacNhan.Size = new System.Drawing.Size(83, 26);
            this.btn_XacNhan.TabIndex = 11;
            this.btn_XacNhan.Text = "Xác nhận";
            this.btn_XacNhan.UseVisualStyleBackColor = true;
            this.btn_XacNhan.Click += new System.EventHandler(this.btn_XacNhan_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_PhuongXa);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_QuanHuyen);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_ThanhPho);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(38, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 129);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Địa chỉ:";
            // 
            // txt_PhuongXa
            // 
            this.txt_PhuongXa.Location = new System.Drawing.Point(118, 88);
            this.txt_PhuongXa.Name = "txt_PhuongXa";
            this.txt_PhuongXa.Size = new System.Drawing.Size(194, 20);
            this.txt_PhuongXa.TabIndex = 9;
            this.txt_PhuongXa.TextChanged += new System.EventHandler(this.txt_TenToaNha_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Phường/Xã/Thị trấn:";
            // 
            // txt_QuanHuyen
            // 
            this.txt_QuanHuyen.Location = new System.Drawing.Point(118, 62);
            this.txt_QuanHuyen.Name = "txt_QuanHuyen";
            this.txt_QuanHuyen.Size = new System.Drawing.Size(194, 20);
            this.txt_QuanHuyen.TabIndex = 7;
            this.txt_QuanHuyen.TextChanged += new System.EventHandler(this.txt_TenToaNha_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Quận/Huyện:";
            // 
            // txt_ThanhPho
            // 
            this.txt_ThanhPho.Location = new System.Drawing.Point(118, 36);
            this.txt_ThanhPho.Name = "txt_ThanhPho";
            this.txt_ThanhPho.Size = new System.Drawing.Size(194, 20);
            this.txt_ThanhPho.TabIndex = 5;
            this.txt_ThanhPho.TextChanged += new System.EventHandler(this.txt_TenToaNha_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Thành phố:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(138, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Sửa tòa nhà";
            // 
            // txt_TenToaNha
            // 
            this.txt_TenToaNha.Location = new System.Drawing.Point(109, 75);
            this.txt_TenToaNha.Name = "txt_TenToaNha";
            this.txt_TenToaNha.Size = new System.Drawing.Size(247, 20);
            this.txt_TenToaNha.TabIndex = 8;
            this.txt_TenToaNha.TextChanged += new System.EventHandler(this.txt_TenToaNha_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tên tòa nhà:";
            // 
            // txt_MaToaNha
            // 
            this.txt_MaToaNha.Location = new System.Drawing.Point(109, 48);
            this.txt_MaToaNha.Name = "txt_MaToaNha";
            this.txt_MaToaNha.Size = new System.Drawing.Size(247, 20);
            this.txt_MaToaNha.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Tòa nhà số:";
            // 
            // FormSuaToaNha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 274);
            this.Controls.Add(this.txt_MaToaNha);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_QuayLai);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.btn_XacNhan);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_TenToaNha);
            this.Controls.Add(this.label1);
            this.Name = "FormSuaToaNha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSuaToaNha";
            this.Load += new System.EventHandler(this.FormSuaToaNha_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_QuayLai;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_XacNhan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_PhuongXa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_QuanHuyen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_ThanhPho;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_TenToaNha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_MaToaNha;
        private System.Windows.Forms.Label label6;
    }
}