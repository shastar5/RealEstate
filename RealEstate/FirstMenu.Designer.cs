namespace RealEstate
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
            this.Panel_InitText = new System.Windows.Forms.Panel();
            this.DBLocation = new System.Windows.Forms.Label();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox_매매 = new System.Windows.Forms.ComboBox();
            this.TB_RoadWidth = new System.Windows.Forms.TextBox();
            this.TB_RoadAddr = new System.Windows.Forms.TextBox();
            this.TB_Distance = new System.Windows.Forms.TextBox();
            this.TB_YearPercent = new System.Windows.Forms.TextBox();
            this.TB_Income = new System.Windows.Forms.TextBox();
            this.TB_TakeOverPrice = new System.Windows.Forms.TextBox();
            this.TB_SellPrice = new System.Windows.Forms.TextBox();
            this.btn_DBFind = new System.Windows.Forms.Button();
            this.btn_찾기 = new System.Windows.Forms.Button();
            this.Text_매매금액 = new System.Windows.Forms.Label();
            this.btn_건물추가 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Page_매매 = new System.Windows.Forms.TabPage();
            this.Page_보류 = new System.Windows.Forms.TabPage();
            this.Page_완료 = new System.Windows.Forms.TabPage();
            this.Page_준비 = new System.Windows.Forms.TabPage();
            this.Init_탭컨트롤 = new System.Windows.Forms.TabControl();
            this.Panel_InitText.SuspendLayout();
            this.Init_탭컨트롤.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_InitText
            // 
            this.Panel_InitText.Controls.Add(this.DBLocation);
            this.Panel_InitText.Controls.Add(this.radioButton6);
            this.Panel_InitText.Controls.Add(this.radioButton5);
            this.Panel_InitText.Controls.Add(this.radioButton4);
            this.Panel_InitText.Controls.Add(this.radioButton3);
            this.Panel_InitText.Controls.Add(this.radioButton2);
            this.Panel_InitText.Controls.Add(this.radioButton1);
            this.Panel_InitText.Controls.Add(this.comboBox3);
            this.Panel_InitText.Controls.Add(this.comboBox1);
            this.Panel_InitText.Controls.Add(this.comboBox_매매);
            this.Panel_InitText.Controls.Add(this.TB_RoadWidth);
            this.Panel_InitText.Controls.Add(this.TB_RoadAddr);
            this.Panel_InitText.Controls.Add(this.TB_Distance);
            this.Panel_InitText.Controls.Add(this.TB_YearPercent);
            this.Panel_InitText.Controls.Add(this.TB_Income);
            this.Panel_InitText.Controls.Add(this.TB_TakeOverPrice);
            this.Panel_InitText.Controls.Add(this.TB_SellPrice);
            this.Panel_InitText.Controls.Add(this.btn_DBFind);
            this.Panel_InitText.Controls.Add(this.btn_찾기);
            this.Panel_InitText.Controls.Add(this.Text_매매금액);
            this.Panel_InitText.Controls.Add(this.btn_건물추가);
            this.Panel_InitText.Controls.Add(this.label1);
            this.Panel_InitText.Controls.Add(this.label5);
            this.Panel_InitText.Controls.Add(this.label2);
            this.Panel_InitText.Controls.Add(this.label6);
            this.Panel_InitText.Controls.Add(this.label3);
            this.Panel_InitText.Controls.Add(this.label7);
            this.Panel_InitText.Controls.Add(this.label4);
            resources.ApplyResources(this.Panel_InitText, "Panel_InitText");
            this.Panel_InitText.Name = "Panel_InitText";
            this.Panel_InitText.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_InitText_Paint);
            // 
            // DBLocation
            // 
            resources.ApplyResources(this.DBLocation, "DBLocation");
            this.DBLocation.Name = "DBLocation";
            this.DBLocation.Click += new System.EventHandler(this.DBLocation_Click);
            // 
            // radioButton6
            // 
            resources.ApplyResources(this.radioButton6, "radioButton6");
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.TabStop = true;
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // radioButton5
            // 
            resources.ApplyResources(this.radioButton5, "radioButton5");
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.TabStop = true;
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // radioButton4
            // 
            resources.ApplyResources(this.radioButton4, "radioButton4");
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.TabStop = true;
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton3
            // 
            resources.ApplyResources(this.radioButton3, "radioButton3");
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.TabStop = true;
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            resources.ApplyResources(this.radioButton2, "radioButton2");
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.TabStop = true;
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            resources.ApplyResources(this.radioButton1, "radioButton1");
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
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
            // TB_RoadWidth
            // 
            this.TB_RoadWidth.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_RoadWidth.ForeColor = System.Drawing.SystemColors.WindowFrame;
            resources.ApplyResources(this.TB_RoadWidth, "TB_RoadWidth");
            this.TB_RoadWidth.Name = "TB_RoadWidth";
            // 
            // TB_RoadAddr
            // 
            resources.ApplyResources(this.TB_RoadAddr, "TB_RoadAddr");
            this.TB_RoadAddr.Name = "TB_RoadAddr";
            // 
            // TB_Distance
            // 
            resources.ApplyResources(this.TB_Distance, "TB_Distance");
            this.TB_Distance.Name = "TB_Distance";
            // 
            // TB_YearPercent
            // 
            resources.ApplyResources(this.TB_YearPercent, "TB_YearPercent");
            this.TB_YearPercent.Name = "TB_YearPercent";
            // 
            // TB_Income
            // 
            resources.ApplyResources(this.TB_Income, "TB_Income");
            this.TB_Income.Name = "TB_Income";
            // 
            // TB_TakeOverPrice
            // 
            resources.ApplyResources(this.TB_TakeOverPrice, "TB_TakeOverPrice");
            this.TB_TakeOverPrice.Name = "TB_TakeOverPrice";
            this.TB_TakeOverPrice.TextChanged += new System.EventHandler(this.TB_TakeOverPrice_TextChanged);
            // 
            // TB_SellPrice
            // 
            resources.ApplyResources(this.TB_SellPrice, "TB_SellPrice");
            this.TB_SellPrice.Name = "TB_SellPrice";
            // 
            // btn_DBFind
            // 
            resources.ApplyResources(this.btn_DBFind, "btn_DBFind");
            this.btn_DBFind.Name = "btn_DBFind";
            this.btn_DBFind.UseVisualStyleBackColor = true;
            this.btn_DBFind.Click += new System.EventHandler(this.btn_DBFind_Click);
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
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
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
            // Page_매매
            // 
            resources.ApplyResources(this.Page_매매, "Page_매매");
            this.Page_매매.Name = "Page_매매";
            this.Page_매매.UseVisualStyleBackColor = true;
            // 
            // Page_보류
            // 
            resources.ApplyResources(this.Page_보류, "Page_보류");
            this.Page_보류.Name = "Page_보류";
            this.Page_보류.UseVisualStyleBackColor = true;
            // 
            // Page_완료
            // 
            resources.ApplyResources(this.Page_완료, "Page_완료");
            this.Page_완료.Name = "Page_완료";
            this.Page_완료.UseVisualStyleBackColor = true;
            // 
            // Page_준비
            // 
            resources.ApplyResources(this.Page_준비, "Page_준비");
            this.Page_준비.Name = "Page_준비";
            this.Page_준비.UseVisualStyleBackColor = true;
            // 
            // Init_탭컨트롤
            // 
            resources.ApplyResources(this.Init_탭컨트롤, "Init_탭컨트롤");
            this.Init_탭컨트롤.Controls.Add(this.Page_준비);
            this.Init_탭컨트롤.Controls.Add(this.Page_완료);
            this.Init_탭컨트롤.Controls.Add(this.Page_보류);
            this.Init_탭컨트롤.Controls.Add(this.Page_매매);
            this.Init_탭컨트롤.HotTrack = true;
            this.Init_탭컨트롤.Multiline = true;
            this.Init_탭컨트롤.Name = "Init_탭컨트롤";
            this.Init_탭컨트롤.SelectedIndex = 0;
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
            this.Load += new System.EventHandler(this.InitialFoam_Load);
            this.Panel_InitText.ResumeLayout(false);
            this.Panel_InitText.PerformLayout();
            this.Init_탭컨트롤.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
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
        private System.Windows.Forms.TextBox TB_SellPrice;
        private System.Windows.Forms.TextBox TB_RoadWidth;
        private System.Windows.Forms.TextBox TB_RoadAddr;
        private System.Windows.Forms.TextBox TB_Distance;
        private System.Windows.Forms.TextBox TB_YearPercent;
        private System.Windows.Forms.TextBox TB_Income;
        private System.Windows.Forms.TextBox TB_TakeOverPrice;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox_매매;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage Page_매매;
        private System.Windows.Forms.TabPage Page_보류;
        private System.Windows.Forms.TabPage Page_완료;
        private System.Windows.Forms.TabPage Page_준비;
        private System.Windows.Forms.TabControl Init_탭컨트롤;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button btn_DBFind;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.Label DBLocation;
    }
}

