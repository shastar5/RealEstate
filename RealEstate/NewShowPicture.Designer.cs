namespace RealEstate
{
    partial class NewShowPicture
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewShowPicture));
            this.progressBar1 = new MetroFramework.Controls.MetroProgressBar();
            this.btn_ProfilePicture = new MetroFramework.Controls.MetroButton();
            this.btn_SavePicture = new MetroFramework.Controls.MetroButton();
            this.btn_DeletePicture = new MetroFramework.Controls.MetroButton();
            this.btn_AddPicture = new MetroFramework.Controls.MetroButton();
            this.label2 = new MetroFramework.Controls.MetroLabel();
            this.label1 = new MetroFramework.Controls.MetroLabel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 469);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(743, 30);
            this.progressBar1.TabIndex = 17;
            // 
            // btn_ProfilePicture
            // 
            this.btn_ProfilePicture.Location = new System.Drawing.Point(676, 210);
            this.btn_ProfilePicture.Name = "btn_ProfilePicture";
            this.btn_ProfilePicture.Size = new System.Drawing.Size(75, 39);
            this.btn_ProfilePicture.TabIndex = 13;
            this.btn_ProfilePicture.Text = "프로필사진\r\n 지정";
            this.btn_ProfilePicture.UseSelectable = true;
            this.btn_ProfilePicture.Click += new System.EventHandler(this.btn_ProfilePicture_Click);
            // 
            // btn_SavePicture
            // 
            this.btn_SavePicture.Location = new System.Drawing.Point(676, 159);
            this.btn_SavePicture.Name = "btn_SavePicture";
            this.btn_SavePicture.Size = new System.Drawing.Size(75, 39);
            this.btn_SavePicture.TabIndex = 14;
            this.btn_SavePicture.Text = "저장 /\r\n나가기";
            this.btn_SavePicture.UseSelectable = true;
            this.btn_SavePicture.Click += new System.EventHandler(this.btn_SavePicture_Click);
            // 
            // btn_DeletePicture
            // 
            this.btn_DeletePicture.Location = new System.Drawing.Point(677, 110);
            this.btn_DeletePicture.Name = "btn_DeletePicture";
            this.btn_DeletePicture.Size = new System.Drawing.Size(75, 39);
            this.btn_DeletePicture.TabIndex = 15;
            this.btn_DeletePicture.Text = "제거";
            this.btn_DeletePicture.UseSelectable = true;
            this.btn_DeletePicture.Click += new System.EventHandler(this.btn_DeletePicture_Click);
            // 
            // btn_AddPicture
            // 
            this.btn_AddPicture.Location = new System.Drawing.Point(677, 59);
            this.btn_AddPicture.Name = "btn_AddPicture";
            this.btn_AddPicture.Size = new System.Drawing.Size(75, 39);
            this.btn_AddPicture.TabIndex = 16;
            this.btn_AddPicture.Text = "추가";
            this.btn_AddPicture.UseSelectable = true;
            this.btn_AddPicture.Click += new System.EventHandler(this.btn_AddPicture_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(474, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 19);
            this.label2.TabIndex = 12;
            this.label2.Text = "프로필 사진이 없습니다.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "metroLabel1";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(474, 59);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(196, 400);
            this.listBox1.TabIndex = 10;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            this.listBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listBox1_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 59);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(456, 400);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // NewShowPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 465);
            this.ControlBox = false;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btn_ProfilePicture);
            this.Controls.Add(this.btn_SavePicture);
            this.Controls.Add(this.btn_DeletePicture);
            this.Controls.Add(this.btn_AddPicture);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(783, 513);
            this.MinimumSize = new System.Drawing.Size(783, 465);
            this.Name = "NewShowPicture";
            this.Load += new System.EventHandler(this.NewShowPicture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroProgressBar progressBar1;
        private MetroFramework.Controls.MetroButton btn_ProfilePicture;
        private MetroFramework.Controls.MetroButton btn_SavePicture;
        private MetroFramework.Controls.MetroButton btn_DeletePicture;
        private MetroFramework.Controls.MetroButton btn_AddPicture;
        private MetroFramework.Controls.MetroLabel label2;
        private MetroFramework.Controls.MetroLabel label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}