namespace DoAnDotNet
{
    partial class FormThemToaNha
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_TenToaNha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_PhuongXa = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_QuanHuyen = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_ThanhPho = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_XacNhan = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_QuayLai = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên tòa nhà:";
            // 
            // txt_TenToaNha
            // 
            this.txt_TenToaNha.Location = new System.Drawing.Point(107, 54);
            this.txt_TenToaNha.Name = "txt_TenToaNha";
            this.txt_TenToaNha.Size = new System.Drawing.Size(247, 20);
            this.txt_TenToaNha.TabIndex = 1;
            this.txt_TenToaNha.TextChanged += new System.EventHandler(this.txt_TenToaNha_TextChanged);
            this.txt_TenToaNha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_TenToaNha_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Thêm tòa nhà";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_PhuongXa);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_QuanHuyen);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_ThanhPho);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(36, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 129);
            this.groupBox1.TabIndex = 3;
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
            // btn_XacNhan
            // 
            this.btn_XacNhan.Location = new System.Drawing.Point(97, 234);
            this.btn_XacNhan.Name = "btn_XacNhan";
            this.btn_XacNhan.Size = new System.Drawing.Size(75, 23);
            this.btn_XacNhan.TabIndex = 4;
            this.btn_XacNhan.Text = "Xác nhận";
            this.btn_XacNhan.UseVisualStyleBackColor = true;
            this.btn_XacNhan.Click += new System.EventHandler(this.btn_XacNhan_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Location = new System.Drawing.Point(183, 234);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(75, 23);
            this.btn_Xoa.TabIndex = 5;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_QuayLai
            // 
            this.btn_QuayLai.Location = new System.Drawing.Point(269, 233);
            this.btn_QuayLai.Name = "btn_QuayLai";
            this.btn_QuayLai.Size = new System.Drawing.Size(75, 23);
            this.btn_QuayLai.TabIndex = 6;
            this.btn_QuayLai.Text = "Quay lại";
            this.btn_QuayLai.UseVisualStyleBackColor = true;
            this.btn_QuayLai.Click += new System.EventHandler(this.btn_QuayLai_Click);
            // 
            // FormThemToaNha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 266);
            this.Controls.Add(this.btn_QuayLai);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.btn_XacNhan);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_TenToaNha);
            this.Controls.Add(this.label1);
            this.Name = "FormThemToaNha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormThemToaNha";
            this.Load += new System.EventHandler(this.FormThemToaNha_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_TenToaNha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_PhuongXa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_QuanHuyen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_ThanhPho;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_XacNhan;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_QuayLai;
    }
}