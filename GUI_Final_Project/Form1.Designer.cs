namespace GUI_Final_Project
{
    partial class Form1
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.search_textbox = new System.Windows.Forms.TextBox();
            this.search_button = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.large_button = new System.Windows.Forms.Button();
            this.small_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.key_textbox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "지역쿼리:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // search_textbox
            // 
            this.search_textbox.Location = new System.Drawing.Point(76, 9);
            this.search_textbox.Name = "search_textbox";
            this.search_textbox.Size = new System.Drawing.Size(198, 21);
            this.search_textbox.TabIndex = 1;
            this.search_textbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_textbox_KeyDown);
            // 
            // search_button
            // 
            this.search_button.Location = new System.Drawing.Point(280, 9);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(101, 23);
            this.search_button.TabIndex = 2;
            this.search_button.Text = "검색";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(14, 36);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(165, 364);
            this.listBox1.TabIndex = 4;
            this.listBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseClick);
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(185, 36);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(603, 400);
            this.webBrowser1.TabIndex = 5;
            // 
            // large_button
            // 
            this.large_button.Location = new System.Drawing.Point(14, 406);
            this.large_button.Name = "large_button";
            this.large_button.Size = new System.Drawing.Size(72, 30);
            this.large_button.TabIndex = 6;
            this.large_button.Text = "+";
            this.large_button.UseVisualStyleBackColor = true;
            this.large_button.Click += new System.EventHandler(this.large_button_Click);
            // 
            // small_button
            // 
            this.small_button.Location = new System.Drawing.Point(103, 408);
            this.small_button.Name = "small_button";
            this.small_button.Size = new System.Drawing.Size(76, 28);
            this.small_button.TabIndex = 7;
            this.small_button.Text = "-";
            this.small_button.UseVisualStyleBackColor = true;
            this.small_button.Click += new System.EventHandler(this.small_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(387, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "키워드:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // key_textbox
            // 
            this.key_textbox.Location = new System.Drawing.Point(438, 9);
            this.key_textbox.Name = "key_textbox";
            this.key_textbox.Size = new System.Drawing.Size(214, 21);
            this.key_textbox.TabIndex = 9;
            this.key_textbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.key_textbox_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(658, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.key_textbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.small_button);
            this.Controls.Add(this.large_button);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.search_button);
            this.Controls.Add(this.search_textbox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Map";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox search_textbox;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button large_button;
        private System.Windows.Forms.Button small_button;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox key_textbox;
        private System.Windows.Forms.Button button1;
    }
}

