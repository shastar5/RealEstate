namespace RealEstate
{
    partial class FirstMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirstMenu));
            this.Panel_InitText = new System.Windows.Forms.Panel();
            this.btn_Back_UP = new System.Windows.Forms.Button();
            this.HiddenBox = new System.Windows.Forms.CheckBox();
            this.DBLocation = new System.Windows.Forms.Label();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.CB_RoadWidth = new System.Windows.Forms.ComboBox();
            this.CB_YearPercent = new System.Windows.Forms.ComboBox();
            this.CB_Income = new System.Windows.Forms.ComboBox();
            this.CB_TakeOverPrice = new System.Windows.Forms.ComboBox();
            this.CB_sellPrice = new System.Windows.Forms.ComboBox();
            this.TB_RoadWidth = new System.Windows.Forms.TextBox();
            this.TB_Addr = new System.Windows.Forms.TextBox();
            this.TB_Distance = new System.Windows.Forms.TextBox();
            this.TB_YearPercent = new System.Windows.Forms.TextBox();
            this.TB_Income = new System.Windows.Forms.TextBox();
            this.TB_TakeOverPrice = new System.Windows.Forms.TextBox();
            this.TB_SellPrice = new System.Windows.Forms.TextBox();
            this.btn_DBFind = new System.Windows.Forms.Button();
            this.btn_find = new System.Windows.Forms.Button();
            this.Text_매매금액 = new System.Windows.Forms.Label();
            this.btn_addBuilding = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Page_sell = new System.Windows.Forms.TabPage();
            this.Page_wait = new System.Windows.Forms.TabPage();
            this.Page_complete = new System.Windows.Forms.TabPage();
            this.Page_prepare = new System.Windows.Forms.TabPage();
            this.Tab_control = new System.Windows.Forms.TabControl();
            this.label8 = new System.Windows.Forms.Label();
            this.RB_CornerExist = new System.Windows.Forms.RadioButton();
            this.RB_CornerNone = new System.Windows.Forms.RadioButton();
            this.RB_CornerAll = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Panel_InitText.SuspendLayout();
            this.Tab_control.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_InitText
            // 
            this.Panel_InitText.Controls.Add(this.panel1);
            this.Panel_InitText.Controls.Add(this.btn_Back_UP);
            this.Panel_InitText.Controls.Add(this.HiddenBox);
            this.Panel_InitText.Controls.Add(this.DBLocation);
            this.Panel_InitText.Controls.Add(this.radioButton6);
            this.Panel_InitText.Controls.Add(this.radioButton5);
            this.Panel_InitText.Controls.Add(this.radioButton4);
            this.Panel_InitText.Controls.Add(this.radioButton3);
            this.Panel_InitText.Controls.Add(this.radioButton2);
            this.Panel_InitText.Controls.Add(this.radioButton1);
            this.Panel_InitText.Controls.Add(this.CB_RoadWidth);
            this.Panel_InitText.Controls.Add(this.CB_YearPercent);
            this.Panel_InitText.Controls.Add(this.CB_Income);
            this.Panel_InitText.Controls.Add(this.CB_TakeOverPrice);
            this.Panel_InitText.Controls.Add(this.CB_sellPrice);
            this.Panel_InitText.Controls.Add(this.TB_RoadWidth);
            this.Panel_InitText.Controls.Add(this.TB_Addr);
            this.Panel_InitText.Controls.Add(this.TB_Distance);
            this.Panel_InitText.Controls.Add(this.TB_YearPercent);
            this.Panel_InitText.Controls.Add(this.TB_Income);
            this.Panel_InitText.Controls.Add(this.TB_TakeOverPrice);
            this.Panel_InitText.Controls.Add(this.TB_SellPrice);
            this.Panel_InitText.Controls.Add(this.btn_DBFind);
            this.Panel_InitText.Controls.Add(this.btn_find);
            this.Panel_InitText.Controls.Add(this.Text_매매금액);
            this.Panel_InitText.Controls.Add(this.btn_addBuilding);
            this.Panel_InitText.Controls.Add(this.label1);
            this.Panel_InitText.Controls.Add(this.label5);
            this.Panel_InitText.Controls.Add(this.label2);
            this.Panel_InitText.Controls.Add(this.label6);
            this.Panel_InitText.Controls.Add(this.label3);
            this.Panel_InitText.Controls.Add(this.label8);
            this.Panel_InitText.Controls.Add(this.label7);
            this.Panel_InitText.Controls.Add(this.label4);
            resources.ApplyResources(this.Panel_InitText, "Panel_InitText");
            this.Panel_InitText.Name = "Panel_InitText";
            // 
            // btn_Back_UP
            // 
            resources.ApplyResources(this.btn_Back_UP, "btn_Back_UP");
            this.btn_Back_UP.Name = "btn_Back_UP";
            this.btn_Back_UP.UseVisualStyleBackColor = true;
            this.btn_Back_UP.Click += new System.EventHandler(this.btn_Back_UP_Click);
            // 
            // HiddenBox
            // 
            resources.ApplyResources(this.HiddenBox, "HiddenBox");
            this.HiddenBox.Name = "HiddenBox";
            this.HiddenBox.TabStop = false;
            this.HiddenBox.UseVisualStyleBackColor = true;
            this.HiddenBox.CheckedChanged += new System.EventHandler(this.HiddenBox_CheckedChanged);
            // 
            // DBLocation
            // 
            resources.ApplyResources(this.DBLocation, "DBLocation");
            this.DBLocation.Name = "DBLocation";
            // 
            // radioButton6
            // 
            resources.ApplyResources(this.radioButton6, "radioButton6");
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton5
            // 
            resources.ApplyResources(this.radioButton5, "radioButton5");
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton4
            // 
            resources.ApplyResources(this.radioButton4, "radioButton4");
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton3
            // 
            resources.ApplyResources(this.radioButton3, "radioButton3");
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton2
            // 
            resources.ApplyResources(this.radioButton2, "radioButton2");
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton1
            // 
            resources.ApplyResources(this.radioButton1, "radioButton1");
            this.radioButton1.Checked = true;
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // CB_RoadWidth
            // 
            this.CB_RoadWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_RoadWidth.FormattingEnabled = true;
            this.CB_RoadWidth.Items.AddRange(new object[] {
            resources.GetString("CB_RoadWidth.Items"),
            resources.GetString("CB_RoadWidth.Items1"),
            resources.GetString("CB_RoadWidth.Items2")});
            resources.ApplyResources(this.CB_RoadWidth, "CB_RoadWidth");
            this.CB_RoadWidth.Name = "CB_RoadWidth";
            this.CB_RoadWidth.SelectedIndexChanged += new System.EventHandler(this.CB_RoadWidth_SelectedIndexChanged);
            // 
            // CB_YearPercent
            // 
            this.CB_YearPercent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_YearPercent.FormattingEnabled = true;
            this.CB_YearPercent.Items.AddRange(new object[] {
            resources.GetString("CB_YearPercent.Items"),
            resources.GetString("CB_YearPercent.Items1"),
            resources.GetString("CB_YearPercent.Items2")});
            resources.ApplyResources(this.CB_YearPercent, "CB_YearPercent");
            this.CB_YearPercent.Name = "CB_YearPercent";
            this.CB_YearPercent.TabStop = false;
            this.CB_YearPercent.SelectedIndexChanged += new System.EventHandler(this.CB_YearPercent_SelectedIndexChanged);
            // 
            // CB_Income
            // 
            this.CB_Income.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Income.FormattingEnabled = true;
            this.CB_Income.Items.AddRange(new object[] {
            resources.GetString("CB_Income.Items"),
            resources.GetString("CB_Income.Items1"),
            resources.GetString("CB_Income.Items2")});
            resources.ApplyResources(this.CB_Income, "CB_Income");
            this.CB_Income.Name = "CB_Income";
            this.CB_Income.TabStop = false;
            this.CB_Income.SelectedIndexChanged += new System.EventHandler(this.CB_Income_SelectedIndexChanged);
            // 
            // CB_TakeOverPrice
            // 
            this.CB_TakeOverPrice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_TakeOverPrice.FormattingEnabled = true;
            this.CB_TakeOverPrice.Items.AddRange(new object[] {
            resources.GetString("CB_TakeOverPrice.Items"),
            resources.GetString("CB_TakeOverPrice.Items1"),
            resources.GetString("CB_TakeOverPrice.Items2")});
            resources.ApplyResources(this.CB_TakeOverPrice, "CB_TakeOverPrice");
            this.CB_TakeOverPrice.Name = "CB_TakeOverPrice";
            this.CB_TakeOverPrice.TabStop = false;
            this.CB_TakeOverPrice.SelectedIndexChanged += new System.EventHandler(this.CB_TakeOverPrice_SelectedIndexChanged);
            // 
            // CB_sellPrice
            // 
            this.CB_sellPrice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_sellPrice.FormattingEnabled = true;
            this.CB_sellPrice.Items.AddRange(new object[] {
            resources.GetString("CB_sellPrice.Items"),
            resources.GetString("CB_sellPrice.Items1"),
            resources.GetString("CB_sellPrice.Items2")});
            resources.ApplyResources(this.CB_sellPrice, "CB_sellPrice");
            this.CB_sellPrice.Name = "CB_sellPrice";
            this.CB_sellPrice.TabStop = false;
            this.CB_sellPrice.SelectedIndexChanged += new System.EventHandler(this.CB_sellPrice_SelectedIndexChanged);
            // 
            // TB_RoadWidth
            // 
            this.TB_RoadWidth.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_RoadWidth.ForeColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this.TB_RoadWidth, "TB_RoadWidth");
            this.TB_RoadWidth.Name = "TB_RoadWidth";
            this.TB_RoadWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.typeOnlyNum);
            // 
            // TB_Addr
            // 
            resources.ApplyResources(this.TB_Addr, "TB_Addr");
            this.TB_Addr.Name = "TB_Addr";
            // 
            // TB_Distance
            // 
            resources.ApplyResources(this.TB_Distance, "TB_Distance");
            this.TB_Distance.Name = "TB_Distance";
            this.TB_Distance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.typeOnlyNum);
            // 
            // TB_YearPercent
            // 
            resources.ApplyResources(this.TB_YearPercent, "TB_YearPercent");
            this.TB_YearPercent.Name = "TB_YearPercent";
            this.TB_YearPercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.typeOnlyNum);
            // 
            // TB_Income
            // 
            resources.ApplyResources(this.TB_Income, "TB_Income");
            this.TB_Income.Name = "TB_Income";
            this.TB_Income.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.typeOnlyNum);
            // 
            // TB_TakeOverPrice
            // 
            resources.ApplyResources(this.TB_TakeOverPrice, "TB_TakeOverPrice");
            this.TB_TakeOverPrice.Name = "TB_TakeOverPrice";
            this.TB_TakeOverPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.typeOnlyNum);
            // 
            // TB_SellPrice
            // 
            this.TB_SellPrice.ForeColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this.TB_SellPrice, "TB_SellPrice");
            this.TB_SellPrice.Name = "TB_SellPrice";
            this.TB_SellPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.typeOnlyNum);
            // 
            // btn_DBFind
            // 
            resources.ApplyResources(this.btn_DBFind, "btn_DBFind");
            this.btn_DBFind.Name = "btn_DBFind";
            this.btn_DBFind.TabStop = false;
            this.btn_DBFind.UseVisualStyleBackColor = true;
            this.btn_DBFind.Click += new System.EventHandler(this.btn_DBFind_Click);
            // 
            // btn_find
            // 
            resources.ApplyResources(this.btn_find, "btn_find");
            this.btn_find.Name = "btn_find";
            this.btn_find.TabStop = false;
            this.btn_find.UseVisualStyleBackColor = true;
            this.btn_find.Click += new System.EventHandler(this.btn_find_Click);
            // 
            // Text_매매금액
            // 
            resources.ApplyResources(this.Text_매매금액, "Text_매매금액");
            this.Text_매매금액.Name = "Text_매매금액";
            // 
            // btn_addBuilding
            // 
            resources.ApplyResources(this.btn_addBuilding, "btn_addBuilding");
            this.btn_addBuilding.Name = "btn_addBuilding";
            this.btn_addBuilding.TabStop = false;
            this.btn_addBuilding.UseVisualStyleBackColor = true;
            this.btn_addBuilding.Click += new System.EventHandler(this.btn_addBuilding_Click);
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
            // Page_sell
            // 
            resources.ApplyResources(this.Page_sell, "Page_sell");
            this.Page_sell.Name = "Page_sell";
            this.Page_sell.UseVisualStyleBackColor = true;
            // 
            // Page_wait
            // 
            resources.ApplyResources(this.Page_wait, "Page_wait");
            this.Page_wait.Name = "Page_wait";
            this.Page_wait.UseVisualStyleBackColor = true;
            // 
            // Page_complete
            // 
            resources.ApplyResources(this.Page_complete, "Page_complete");
            this.Page_complete.Name = "Page_complete";
            this.Page_complete.UseVisualStyleBackColor = true;
            // 
            // Page_prepare
            // 
            resources.ApplyResources(this.Page_prepare, "Page_prepare");
            this.Page_prepare.Name = "Page_prepare";
            this.Page_prepare.UseVisualStyleBackColor = true;
            // 
            // Tab_control
            // 
            resources.ApplyResources(this.Tab_control, "Tab_control");
            this.Tab_control.Controls.Add(this.Page_prepare);
            this.Tab_control.Controls.Add(this.Page_complete);
            this.Tab_control.Controls.Add(this.Page_wait);
            this.Tab_control.Controls.Add(this.Page_sell);
            this.Tab_control.HotTrack = true;
            this.Tab_control.Multiline = true;
            this.Tab_control.Name = "Tab_control";
            this.Tab_control.SelectedIndex = 0;
            this.Tab_control.TabStop = false;
            this.Tab_control.SelectedIndexChanged += new System.EventHandler(this.Tabs_SelectedIndexChanged);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // RB_CornerExist
            // 
            resources.ApplyResources(this.RB_CornerExist, "RB_CornerExist");
            this.RB_CornerExist.Name = "RB_CornerExist";
            this.RB_CornerExist.UseVisualStyleBackColor = true;
            this.RB_CornerExist.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // RB_CornerNone
            // 
            resources.ApplyResources(this.RB_CornerNone, "RB_CornerNone");
            this.RB_CornerNone.Name = "RB_CornerNone";
            this.RB_CornerNone.UseVisualStyleBackColor = true;
            this.RB_CornerNone.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // RB_CornerAll
            // 
            resources.ApplyResources(this.RB_CornerAll, "RB_CornerAll");
            this.RB_CornerAll.Checked = true;
            this.RB_CornerAll.Name = "RB_CornerAll";
            this.RB_CornerAll.TabStop = true;
            this.RB_CornerAll.UseVisualStyleBackColor = true;
            this.RB_CornerAll.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.RB_CornerAll);
            this.panel1.Controls.Add(this.RB_CornerExist);
            this.panel1.Controls.Add(this.RB_CornerNone);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // FirstMenu
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.Panel_InitText);
            this.Controls.Add(this.Tab_control);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MaximizeBox = false;
            this.Name = "FirstMenu";
            this.Load += new System.EventHandler(this.FirstMenu_Load);
            this.Panel_InitText.ResumeLayout(false);
            this.Panel_InitText.PerformLayout();
            this.Tab_control.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Panel_InitText;
        private System.Windows.Forms.Button btn_find;
        private System.Windows.Forms.Label Text_매매금액;
        private System.Windows.Forms.Button btn_addBuilding;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TB_SellPrice;
        private System.Windows.Forms.TextBox TB_RoadWidth;
        private System.Windows.Forms.TextBox TB_Addr;
        private System.Windows.Forms.TextBox TB_Distance;
        private System.Windows.Forms.TextBox TB_YearPercent;
        private System.Windows.Forms.TextBox TB_Income;
        private System.Windows.Forms.TextBox TB_TakeOverPrice;
        private System.Windows.Forms.ComboBox CB_RoadWidth;
        private System.Windows.Forms.ComboBox CB_YearPercent;
        private System.Windows.Forms.ComboBox CB_sellPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage Page_sell;
        private System.Windows.Forms.TabPage Page_wait;
        private System.Windows.Forms.TabPage Page_complete;
        private System.Windows.Forms.TabPage Page_prepare;
        private System.Windows.Forms.TabControl Tab_control;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button btn_DBFind;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.CheckBox HiddenBox;
        private System.Windows.Forms.ComboBox CB_Income;
        private System.Windows.Forms.ComboBox CB_TakeOverPrice;
        private System.Windows.Forms.Label DBLocation;
        private System.Windows.Forms.Button btn_Back_UP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton RB_CornerAll;
        private System.Windows.Forms.RadioButton RB_CornerNone;
        private System.Windows.Forms.RadioButton RB_CornerExist;
        private System.Windows.Forms.Panel panel1;
    }
}

