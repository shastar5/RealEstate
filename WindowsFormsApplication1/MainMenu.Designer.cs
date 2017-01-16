namespace WindowsFormsApplication1
{
    partial class InitialFoam
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitialFoam));
            this.Init_탭컨트롤 = new System.Windows.Forms.TabControl();
            this.Page_준비 = new System.Windows.Forms.TabPage();
            this.Page_완료 = new System.Windows.Forms.TabPage();
            this.Page_보류 = new System.Windows.Forms.TabPage();
            this.Page_매매 = new System.Windows.Forms.TabPage();
            this.Page_전체 = new System.Windows.Forms.TabPage();
            this.Panel_InitText = new System.Windows.Forms.Panel();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_찾기 = new System.Windows.Forms.Button();
            this.Text_매매금액 = new System.Windows.Forms.Label();
            this.btn_건물추가 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_매매 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.Init_탭컨트롤.SuspendLayout();
            this.Panel_InitText.SuspendLayout();
            this.SuspendLayout();
            // 
            // Init_탭컨트롤
            // 
            resources.ApplyResources(this.Init_탭컨트롤, "Init_탭컨트롤");
            this.Init_탭컨트롤.Controls.Add(this.Page_준비);
            this.Init_탭컨트롤.Controls.Add(this.Page_완료);
            this.Init_탭컨트롤.Controls.Add(this.Page_보류);
            this.Init_탭컨트롤.Controls.Add(this.Page_매매);
            this.Init_탭컨트롤.Controls.Add(this.Page_전체);
            this.Init_탭컨트롤.HotTrack = true;
            this.Init_탭컨트롤.Multiline = true;
            this.Init_탭컨트롤.Name = "Init_탭컨트롤";
            this.Init_탭컨트롤.SelectedIndex = 0;
            // 
            // Page_준비
            // 
            resources.ApplyResources(this.Page_준비, "Page_준비");
            this.Page_준비.Name = "Page_준비";
            this.Page_준비.UseVisualStyleBackColor = true;
            this.Page_준비.Click += new System.EventHandler(this.tabPage1_Click_1);
            // 
            // Page_완료
            // 
            resources.ApplyResources(this.Page_완료, "Page_완료");
            this.Page_완료.Name = "Page_완료";
            this.Page_완료.UseVisualStyleBackColor = true;
            // 
            // Page_보류
            // 
            resources.ApplyResources(this.Page_보류, "Page_보류");
            this.Page_보류.Name = "Page_보류";
            this.Page_보류.UseVisualStyleBackColor = true;
            // 
            // Page_매매
            // 
            resources.ApplyResources(this.Page_매매, "Page_매매");
            this.Page_매매.Name = "Page_매매";
            this.Page_매매.UseVisualStyleBackColor = true;
            // 
            // Page_전체
            // 
            resources.ApplyResources(this.Page_전체, "Page_전체");
            this.Page_전체.Name = "Page_전체";
            this.Page_전체.UseVisualStyleBackColor = true;
            // 
            // Panel_InitText
            // 
            this.Panel_InitText.Controls.Add(this.comboBox3);
            this.Panel_InitText.Controls.Add(this.comboBox2);
            this.Panel_InitText.Controls.Add(this.comboBox1);
            this.Panel_InitText.Controls.Add(this.comboBox_매매);
            this.Panel_InitText.Controls.Add(this.textBox7);
            this.Panel_InitText.Controls.Add(this.textBox6);
            this.Panel_InitText.Controls.Add(this.textBox5);
            this.Panel_InitText.Controls.Add(this.textBox4);
            this.Panel_InitText.Controls.Add(this.textBox3);
            this.Panel_InitText.Controls.Add(this.textBox2);
            this.Panel_InitText.Controls.Add(this.textBox1);
            this.Panel_InitText.Controls.Add(this.btn_찾기);
            this.Panel_InitText.Controls.Add(this.Text_매매금액);
            this.Panel_InitText.Controls.Add(this.btn_건물추가);
            this.Panel_InitText.Controls.Add(this.label5);
            this.Panel_InitText.Controls.Add(this.label2);
            this.Panel_InitText.Controls.Add(this.label6);
            this.Panel_InitText.Controls.Add(this.label3);
            this.Panel_InitText.Controls.Add(this.label7);
            this.Panel_InitText.Controls.Add(this.label4);
            resources.ApplyResources(this.Panel_InitText, "Panel_InitText");
            this.Panel_InitText.Name = "Panel_InitText";
            // 
            // textBox7
            // 
            resources.ApplyResources(this.textBox7, "textBox7");
            this.textBox7.Name = "textBox7";
            // 
            // textBox6
            // 
            resources.ApplyResources(this.textBox6, "textBox6");
            this.textBox6.Name = "textBox6";
            // 
            // textBox5
            // 
            resources.ApplyResources(this.textBox5, "textBox5");
            this.textBox5.Name = "textBox5";
            // 
            // textBox4
            // 
            resources.ApplyResources(this.textBox4, "textBox4");
            this.textBox4.Name = "textBox4";
            // 
            // textBox3
            // 
            resources.ApplyResources(this.textBox3, "textBox3");
            this.textBox3.Name = "textBox3";
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // btn_찾기
            // 
            resources.ApplyResources(this.btn_찾기, "btn_찾기");
            this.btn_찾기.Name = "btn_찾기";
            this.btn_찾기.UseVisualStyleBackColor = true;
            this.btn_찾기.Click += new System.EventHandler(this.btn_찾기_Click);
            // 
            // Text_매매금액
            // 
            resources.ApplyResources(this.Text_매매금액, "Text_매매금액");
            this.Text_매매금액.Name = "Text_매매금액";
            // 
            // btn_건물추가
            // 
            resources.ApplyResources(this.btn_건물추가, "btn_건물추가");
            this.btn_건물추가.Name = "btn_건물추가";
            this.btn_건물추가.UseVisualStyleBackColor = true;
            this.btn_건물추가.Click += new System.EventHandler(this.btn_건물추가_Click);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // comboBox_매매
            // 
            this.comboBox_매매.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBox_매매.FormattingEnabled = true;
            this.comboBox_매매.Items.AddRange(new object[] {
            resources.GetString("comboBox_매매.Items"),
            resources.GetString("comboBox_매매.Items1")});
            resources.ApplyResources(this.comboBox_매매, "comboBox_매매");
            this.comboBox_매매.Name = "comboBox_매매";
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            resources.GetString("comboBox1.Items"),
            resources.GetString("comboBox1.Items1")});
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.Name = "comboBox1";
            // 
            // comboBox2
            // 
            this.comboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            resources.GetString("comboBox2.Items"),
            resources.GetString("comboBox2.Items1")});
            resources.ApplyResources(this.comboBox2, "comboBox2");
            this.comboBox2.Name = "comboBox2";
            // 
            // comboBox3
            // 
            this.comboBox3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            resources.GetString("comboBox3.Items"),
            resources.GetString("comboBox3.Items1")});
            resources.ApplyResources(this.comboBox3, "comboBox3");
            this.comboBox3.Name = "comboBox3";
            // 
            // InitialFoam
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.Panel_InitText);
            this.Controls.Add(this.Init_탭컨트롤);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MaximizeBox = false;
            this.Name = "InitialFoam";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Init_탭컨트롤.ResumeLayout(false);
            this.Panel_InitText.ResumeLayout(false);
            this.Panel_InitText.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Init_탭컨트롤;
        private System.Windows.Forms.TabPage Page_준비;
        private System.Windows.Forms.TabPage Page_완료;
        private System.Windows.Forms.TabPage Page_보류;
        private System.Windows.Forms.TabPage Page_매매;
        private System.Windows.Forms.TabPage Page_전체;
        private System.Windows.Forms.Panel Panel_InitText;
        private System.Windows.Forms.Button btn_찾기;
        private System.Windows.Forms.Label Text_매매금액;
        private System.Windows.Forms.Button btn_건물추가;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox_매매;
    }
}

