namespace RealEstate
{
    partial class ShowPicture
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowPicture));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btn_AddPicture = new System.Windows.Forms.Button();
            this.btn_DeletePicture = new System.Windows.Forms.Button();
            this.btn_SavePicture = new System.Windows.Forms.Button();
            this.btn_ProfilePicture = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 59);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(456, 395);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(475, 57);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(196, 400);
            this.listBox1.TabIndex = 3;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            this.listBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listBox1_KeyPress);
            // 
            // btn_AddPicture
            // 
            this.btn_AddPicture.Location = new System.Drawing.Point(680, 23);
            this.btn_AddPicture.Name = "btn_AddPicture";
            this.btn_AddPicture.Size = new System.Drawing.Size(75, 39);
            this.btn_AddPicture.TabIndex = 4;
            this.btn_AddPicture.Text = "추가";
            this.btn_AddPicture.UseVisualStyleBackColor = true;
            this.btn_AddPicture.Click += new System.EventHandler(this.btn_AddPicture_Click);
            // 
            // btn_DeletePicture
            // 
            this.btn_DeletePicture.Location = new System.Drawing.Point(680, 81);
            this.btn_DeletePicture.Name = "btn_DeletePicture";
            this.btn_DeletePicture.Size = new System.Drawing.Size(75, 39);
            this.btn_DeletePicture.TabIndex = 4;
            this.btn_DeletePicture.Text = "제거";
            this.btn_DeletePicture.UseVisualStyleBackColor = true;
            this.btn_DeletePicture.Click += new System.EventHandler(this.btn_DeletePicture_Click);
            // 
            // btn_SavePicture
            // 
            this.btn_SavePicture.Location = new System.Drawing.Point(680, 137);
            this.btn_SavePicture.Name = "btn_SavePicture";
            this.btn_SavePicture.Size = new System.Drawing.Size(75, 39);
            this.btn_SavePicture.TabIndex = 5;
            this.btn_SavePicture.Text = "저장 /\r\n나가기";
            this.btn_SavePicture.UseVisualStyleBackColor = true;
            this.btn_SavePicture.Click += new System.EventHandler(this.btn_SavePicture_Click);
            // 
            // btn_ProfilePicture
            // 
            this.btn_ProfilePicture.Location = new System.Drawing.Point(680, 200);
            this.btn_ProfilePicture.Name = "btn_ProfilePicture";
            this.btn_ProfilePicture.Size = new System.Drawing.Size(75, 39);
            this.btn_ProfilePicture.TabIndex = 5;
            this.btn_ProfilePicture.Text = "프로필사진 지정";
            this.btn_ProfilePicture.UseVisualStyleBackColor = true;
            this.btn_ProfilePicture.Click += new System.EventHandler(this.btn_ProfilePicture_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(185, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(472, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "프로필 사진이 없습니다.";
            // 
            // ShowPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 475);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_ProfilePicture);
            this.Controls.Add(this.btn_SavePicture);
            this.Controls.Add(this.btn_DeletePicture);
            this.Controls.Add(this.btn_AddPicture);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShowPicture";
            this.Text = "사진추가/삭제";
            this.Load += new System.EventHandler(this.ShowPicture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btn_AddPicture;
        private System.Windows.Forms.Button btn_DeletePicture;
        private System.Windows.Forms.Button btn_SavePicture;
        private System.Windows.Forms.Button btn_ProfilePicture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}