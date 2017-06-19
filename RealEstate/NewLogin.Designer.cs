namespace RealEstate
{
    partial class NewLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewLogin));
            this.TB_ID = new MetroFramework.Controls.MetroTextBox();
            this.TB_PW = new MetroFramework.Controls.MetroTextBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TB_ID
            // 
            // 
            // 
            // 
            this.TB_ID.CustomButton.Image = null;
            this.TB_ID.CustomButton.Location = new System.Drawing.Point(271, 2);
            this.TB_ID.CustomButton.Name = "";
            this.TB_ID.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.TB_ID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TB_ID.CustomButton.TabIndex = 1;
            this.TB_ID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TB_ID.CustomButton.UseSelectable = true;
            this.TB_ID.CustomButton.Visible = false;
            this.TB_ID.DisplayIcon = true;
            this.TB_ID.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.TB_ID.Lines = new string[0];
            this.TB_ID.Location = new System.Drawing.Point(23, 230);
            this.TB_ID.MaxLength = 32767;
            this.TB_ID.Name = "TB_ID";
            this.TB_ID.PasswordChar = '\0';
            this.TB_ID.PromptText = "계정";
            this.TB_ID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TB_ID.SelectedText = "";
            this.TB_ID.SelectionLength = 0;
            this.TB_ID.SelectionStart = 0;
            this.TB_ID.ShortcutsEnabled = true;
            this.TB_ID.Size = new System.Drawing.Size(299, 30);
            this.TB_ID.TabIndex = 0;
            this.TB_ID.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TB_ID.UseSelectable = true;
            this.TB_ID.WaterMark = "계정";
            this.TB_ID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TB_ID.WaterMarkFont = new System.Drawing.Font("함초롬바탕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // TB_PW
            // 
            // 
            // 
            // 
            this.TB_PW.CustomButton.Image = null;
            this.TB_PW.CustomButton.Location = new System.Drawing.Point(271, 2);
            this.TB_PW.CustomButton.Name = "";
            this.TB_PW.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.TB_PW.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TB_PW.CustomButton.TabIndex = 1;
            this.TB_PW.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TB_PW.CustomButton.UseSelectable = true;
            this.TB_PW.CustomButton.Visible = false;
            this.TB_PW.DisplayIcon = true;
            this.TB_PW.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.TB_PW.Lines = new string[0];
            this.TB_PW.Location = new System.Drawing.Point(23, 281);
            this.TB_PW.MaxLength = 32767;
            this.TB_PW.Name = "TB_PW";
            this.TB_PW.PasswordChar = '●';
            this.TB_PW.PromptText = "비밀번호";
            this.TB_PW.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TB_PW.SelectedText = "";
            this.TB_PW.SelectionLength = 0;
            this.TB_PW.SelectionStart = 0;
            this.TB_PW.ShortcutsEnabled = false;
            this.TB_PW.Size = new System.Drawing.Size(299, 30);
            this.TB_PW.TabIndex = 1;
            this.TB_PW.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TB_PW.UseSelectable = true;
            this.TB_PW.UseSystemPasswordChar = true;
            this.TB_PW.WaterMark = "비밀번호";
            this.TB_PW.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TB_PW.WaterMarkFont = new System.Drawing.Font("함초롬바탕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // metroButton1
            // 
            this.metroButton1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.metroButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.metroButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButton1.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButton1.Location = new System.Drawing.Point(23, 329);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(298, 50);
            this.metroButton1.TabIndex = 2;
            this.metroButton1.Text = "로그인";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroButton1.UseCustomBackColor = true;
            this.metroButton1.UseCustomForeColor = true;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.UseStyleColors = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RealEstate.Properties.Resources.Icon;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(119, 83);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(115, 112);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Login_
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackLocation = MetroFramework.Forms.BackLocation.BottomRight;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(345, 437);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.TB_PW);
            this.Controls.Add(this.TB_ID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(345, 437);
            this.MinimumSize = new System.Drawing.Size(345, 437);
            this.Name = "Login_";
            this.Resizable = false;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox TB_ID;
        private MetroFramework.Controls.MetroTextBox TB_PW;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}