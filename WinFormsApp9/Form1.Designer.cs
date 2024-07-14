namespace WinFormsApp9
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            textBox9 = new TextBox();
            button7 = new Button();
            comboBox2 = new ComboBox();
            treeView1 = new TreeView();
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            tabPage2 = new TabPage();
            textBox8 = new TextBox();
            textBox7 = new TextBox();
            button3 = new Button();
            comboBox1 = new ComboBox();
            button2 = new Button();
            textBox1 = new TextBox();
            listBox1 = new ListBox();
            tabPage3 = new TabPage();
            label9 = new Label();
            comboBox7 = new ComboBox();
            textBox12 = new TextBox();
            label8 = new Label();
            textBox11 = new TextBox();
            label7 = new Label();
            textBox10 = new TextBox();
            label6 = new Label();
            comboBox8 = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            comboBox6 = new ComboBox();
            label3 = new Label();
            comboBox5 = new ComboBox();
            label2 = new Label();
            comboBox4 = new ComboBox();
            label1 = new Label();
            comboBox3 = new ComboBox();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(12, 12);
            tabControl1.Margin = new Padding(5);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1253, 767);
            tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(textBox9);
            tabPage1.Controls.Add(button7);
            tabPage1.Controls.Add(comboBox2);
            tabPage1.Controls.Add(treeView1);
            tabPage1.Controls.Add(textBox6);
            tabPage1.Controls.Add(textBox5);
            tabPage1.Controls.Add(textBox4);
            tabPage1.Controls.Add(textBox3);
            tabPage1.Controls.Add(textBox2);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1245, 739);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "내용";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox9
            // 
            textBox9.Location = new Point(8, 696);
            textBox9.Multiline = true;
            textBox9.Name = "textBox9";
            textBox9.PlaceholderText = "description";
            textBox9.ReadOnly = true;
            textBox9.Size = new Size(990, 35);
            textBox9.TabIndex = 28;
            // 
            // button7
            // 
            button7.Location = new Point(1004, 696);
            button7.Name = "button7";
            button7.Size = new Size(235, 35);
            button7.TabIndex = 26;
            button7.Text = "생성";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "에피소드", "플롯", "스크립트" });
            comboBox2.Location = new Point(1004, 486);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(235, 23);
            comboBox2.TabIndex = 24;
            comboBox2.Text = "에피소드";
            // 
            // treeView1
            // 
            treeView1.HideSelection = false;
            treeView1.Location = new Point(8, 486);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(990, 204);
            treeView1.TabIndex = 19;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(1004, 515);
            textBox6.Multiline = true;
            textBox6.Name = "textBox6";
            textBox6.PlaceholderText = "Synopsis";
            textBox6.Size = new Size(235, 176);
            textBox6.TabIndex = 17;
            textBox6.Text = "20살 남자가 주인공, 여러 여자 히로인들과 맺어지는 과정을 그리는 소설, 이 과정에 여러가지 고난과 역경이 존재해야 함, 고난과 역경은 외부 요인일 수도 있고 히로인과의 성격 차이 등 내부적인 심리 요소가 작용할 수 있음.";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(1004, 50);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.PlaceholderText = "Tone";
            textBox5.Size = new Size(235, 135);
            textBox5.TabIndex = 16;
            textBox5.Text = "구어체 문장 및 단문 위주의 빠른 호흡\r\n묘사와 지문의 적절한 조화\r\n직접적이고 시각적인 묘사\r\n빠른 전개와 몰입도 높은 사건\r\n대중적인 소재와 트렌드 반영\r\n대화문은 화자를 반드시 명시하고 앞뒤로 개행을 추가";
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(1004, 191);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "Style";
            textBox4.Size = new Size(235, 287);
            textBox4.TabIndex = 15;
            textBox4.Text = "심리묘사와 대화 위주의 전개";
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(1004, 10);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Genre";
            textBox3.Size = new Size(235, 34);
            textBox3.TabIndex = 14;
            textBox3.Text = "러브 코미디, 로맨스, 현대 판타지, 프로그래머";
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.Window;
            textBox2.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            textBox2.Location = new Point(8, 10);
            textBox2.Margin = new Padding(5);
            textBox2.MaxLength = 0;
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "본문";
            textBox2.ScrollBars = ScrollBars.Vertical;
            textBox2.Size = new Size(988, 468);
            textBox2.TabIndex = 13;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(textBox8);
            tabPage2.Controls.Add(textBox7);
            tabPage2.Controls.Add(button3);
            tabPage2.Controls.Add(comboBox1);
            tabPage2.Controls.Add(button2);
            tabPage2.Controls.Add(textBox1);
            tabPage2.Controls.Add(listBox1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1245, 739);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "설정";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(412, 6);
            textBox8.Name = "textBox8";
            textBox8.PlaceholderText = "label";
            textBox8.Size = new Size(787, 23);
            textBox8.TabIndex = 23;
            textBox8.Text = "세계관 설정";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(241, 35);
            textBox7.Name = "textBox7";
            textBox7.PlaceholderText = "info";
            textBox7.Size = new Size(958, 23);
            textBox7.TabIndex = 22;
            textBox7.Text = "2024년 한국 현대 배경.";
            // 
            // button3
            // 
            button3.Location = new Point(1205, 6);
            button3.Name = "button3";
            button3.Size = new Size(34, 52);
            button3.TabIndex = 21;
            button3.Text = "생성";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "배경", "등장인물", "장소", "사물", "콘셉트" });
            comboBox1.Location = new Point(241, 6);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(165, 23);
            comboBox1.TabIndex = 20;
            comboBox1.Text = "배경";
            // 
            // button2
            // 
            button2.Location = new Point(1142, 699);
            button2.Name = "button2";
            button2.Size = new Size(97, 34);
            button2.TabIndex = 19;
            button2.Text = "추가";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(241, 64);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(998, 629);
            textBox1.TabIndex = 18;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(6, 6);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(229, 724);
            listBox1.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label9);
            tabPage3.Controls.Add(comboBox7);
            tabPage3.Controls.Add(textBox12);
            tabPage3.Controls.Add(label8);
            tabPage3.Controls.Add(textBox11);
            tabPage3.Controls.Add(label7);
            tabPage3.Controls.Add(textBox10);
            tabPage3.Controls.Add(label6);
            tabPage3.Controls.Add(comboBox8);
            tabPage3.Controls.Add(label5);
            tabPage3.Controls.Add(label4);
            tabPage3.Controls.Add(comboBox6);
            tabPage3.Controls.Add(label3);
            tabPage3.Controls.Add(comboBox5);
            tabPage3.Controls.Add(label2);
            tabPage3.Controls.Add(comboBox4);
            tabPage3.Controls.Add(label1);
            tabPage3.Controls.Add(comboBox3);
            tabPage3.Controls.Add(panel1);
            tabPage3.Controls.Add(button1);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1245, 739);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "이미지";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(715, 405);
            label9.Name = "label9";
            label9.Size = new Size(31, 15);
            label9.TabIndex = 21;
            label9.Text = "얼굴";
            // 
            // comboBox7
            // 
            comboBox7.FormattingEnabled = true;
            comboBox7.Location = new Point(715, 423);
            comboBox7.Name = "comboBox7";
            comboBox7.Size = new Size(180, 23);
            comboBox7.TabIndex = 20;
            // 
            // textBox12
            // 
            textBox12.Location = new Point(715, 380);
            textBox12.Name = "textBox12";
            textBox12.Size = new Size(180, 23);
            textBox12.TabIndex = 19;
            textBox12.Text = "[Silver : Blonde : 0.3] hair";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(715, 493);
            label8.Name = "label8";
            label8.Size = new Size(31, 15);
            label8.TabIndex = 18;
            label8.Text = "기타";
            // 
            // textBox11
            // 
            textBox11.Location = new Point(715, 511);
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(366, 23);
            textBox11.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(715, 449);
            label7.Name = "label7";
            label7.Size = new Size(31, 15);
            label7.TabIndex = 16;
            label7.Text = "의상";
            // 
            // textBox10
            // 
            textBox10.Location = new Point(715, 467);
            textBox10.Name = "textBox10";
            textBox10.PlaceholderText = "상하의, 겉옷, 악세서리, 신발 등";
            textBox10.Size = new Size(366, 23);
            textBox10.TabIndex = 15;
            textBox10.Text = "white dress";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(901, 362);
            label6.Name = "label6";
            label6.Size = new Size(31, 15);
            label6.TabIndex = 14;
            label6.Text = "표정";
            // 
            // comboBox8
            // 
            comboBox8.FormattingEnabled = true;
            comboBox8.Location = new Point(901, 380);
            comboBox8.Name = "comboBox8";
            comboBox8.Size = new Size(180, 23);
            comboBox8.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(715, 362);
            label5.Name = "label5";
            label5.Size = new Size(43, 15);
            label5.TabIndex = 12;
            label5.Text = "머리색";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(901, 318);
            label4.Name = "label4";
            label4.Size = new Size(71, 15);
            label4.TabIndex = 10;
            label4.Text = "머리 스타일";
            // 
            // comboBox6
            // 
            comboBox6.FormattingEnabled = true;
            comboBox6.Location = new Point(901, 336);
            comboBox6.Name = "comboBox6";
            comboBox6.Size = new Size(180, 23);
            comboBox6.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(715, 318);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 8;
            label3.Text = "체형";
            // 
            // comboBox5
            // 
            comboBox5.FormattingEnabled = true;
            comboBox5.Location = new Point(715, 336);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(180, 23);
            comboBox5.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(901, 274);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 6;
            label2.Text = "성별";
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(901, 292);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(180, 23);
            comboBox4.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(715, 274);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 4;
            label1.Text = "구도";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(715, 292);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(180, 23);
            comboBox3.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackColor = Color.FromArgb(64, 64, 64);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(568, 568);
            panel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(512, 512);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(959, 540);
            button1.Name = "button1";
            button1.Size = new Size(122, 64);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1277, 791);
            Controls.Add(tabControl1);
            Name = "Form1";
            Padding = new Padding(12);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TabPage tabPage2;
        private ListBox listBox1;
        private Button button2;
        private TextBox textBox1;
        private TextBox textBox7;
        private Button button3;
        private ComboBox comboBox1;
        private TreeView treeView1;
        private TextBox textBox8;
        private Button button7;
        private ComboBox comboBox2;
        private TextBox textBox9;
        private TabPage tabPage3;
        private Button button1;
        private Panel panel1;
        private PictureBox pictureBox1;
        private ComboBox comboBox3;
        private Label label7;
        private TextBox textBox10;
        private Label label6;
        private ComboBox comboBox8;
        private Label label5;
        private Label label4;
        private ComboBox comboBox6;
        private Label label3;
        private ComboBox comboBox5;
        private Label label2;
        private ComboBox comboBox4;
        private Label label1;
        private Label label8;
        private TextBox textBox11;
        private TextBox textBox12;
        private Label label9;
        private ComboBox comboBox7;
    }
}
