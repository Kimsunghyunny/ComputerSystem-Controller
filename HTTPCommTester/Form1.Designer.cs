namespace HTTPCommTester
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.절전모드실행ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.절전모드단축키설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.컴퓨터설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.파워설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(259, 333);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(87, 300);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(142, 82);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.절전모드실행ToolStripMenuItem,
            this.절전모드단축키설정ToolStripMenuItem,
            this.컴퓨터설정ToolStripMenuItem,
            this.파워설정ToolStripMenuItem,
            this.종료ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(191, 114);
            // 
            // 절전모드실행ToolStripMenuItem
            // 
            this.절전모드실행ToolStripMenuItem.Name = "절전모드실행ToolStripMenuItem";
            this.절전모드실행ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.절전모드실행ToolStripMenuItem.Text = "절전모드 실행";
            this.절전모드실행ToolStripMenuItem.Click += new System.EventHandler(this.절전모드실행ToolStripMenuItem_Click_1);
            // 
            // 절전모드단축키설정ToolStripMenuItem
            // 
            this.절전모드단축키설정ToolStripMenuItem.Name = "절전모드단축키설정ToolStripMenuItem";
            this.절전모드단축키설정ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.절전모드단축키설정ToolStripMenuItem.Text = "절전모드 단축키 설정";
            this.절전모드단축키설정ToolStripMenuItem.Click += new System.EventHandler(this.절전모드단축키설정ToolStripMenuItem_Click_1);
            // 
            // 컴퓨터설정ToolStripMenuItem
            // 
            this.컴퓨터설정ToolStripMenuItem.Name = "컴퓨터설정ToolStripMenuItem";
            this.컴퓨터설정ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.컴퓨터설정ToolStripMenuItem.Text = "컴퓨터 설정";
            this.컴퓨터설정ToolStripMenuItem.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // 파워설정ToolStripMenuItem
            // 
            this.파워설정ToolStripMenuItem.Name = "파워설정ToolStripMenuItem";
            this.파워설정ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.파워설정ToolStripMenuItem.Text = "파워 설정";
            this.파워설정ToolStripMenuItem.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.종료ToolStripMenuItem.Text = "종료";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Location = new System.Drawing.Point(370, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(33, 19);
            this.button2.TabIndex = 1;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(405, 428);
            this.panel1.TabIndex = 5;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("HY견고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(15, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "GVS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("한컴 윤고딕 230", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(152, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Only for Laptop";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(3, 5);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(32, 35);
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("HY견고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(107, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Save your Power with GVS saver";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(91, 176);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(33, 27);
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(228, 67);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(144, 85);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(32, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(144, 85);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(117)))), ((int)(((byte)(31)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(715, 5);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(187)))), ((int)(((byte)(62)))));
            this.panel3.Location = new System.Drawing.Point(91, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(227, 3);
            this.panel3.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(406, 423);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "김성현2015111489프로젝트";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 절전모드실행ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 절전모드단축키설정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 컴퓨터설정ToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem 파워설정ToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
    }
}

