using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using HTTPComm;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace HTTPCommTester
{
    public partial class Form1 : Form
    {

        Point fPt;//마우스 커서의 point
        bool isMove;//마우스가 움직인지에 대한 여부

        int standby_key = 0;//단축키 값을 받을 때, 단축키 설정 값을 form4로부터 받아와 저장하기 위한 변수

        HTTPWebComm comm = new HTTPWebComm();

        public Form1()
        {
            InitializeComponent();

            //이미지 불러옴
            pictureBox1.Image = Properties.Resources.computer;
            pictureBox2.Image = Properties.Resources.powerSetting;
            pictureBox3.Image = Properties.Resources.thumbs_up;
            pictureBox4.Image = Properties.Resources.applications;

            //notifyicon 실행
            Tray_Icon();
        }

        private void Tray_Icon()
        {
            //notifyicon을 contexmenustrcip에 연결하고 윈도우 바에 노출
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            textBox1.ContextMenuStrip = contextMenuStrip1;

            notifyIcon1.Visible = true;
            ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
        }


        //form의 스타일을 none으로 지정했기 때문에 panel을 배경에 깔아두고 마우스로 form움직임을 실행하기 위한 함수들
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            fPt = new Point(e.X, e.Y);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove && (e.Button & MouseButtons.Left) == MouseButtons.Left)
                Location = new Point(this.Left - (fPt.X - e.X), this.Top - (fPt.Y - e.Y));
        }

        //단축키
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr itp, int id, KeyInform fsInform, Keys vk);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr itp, int id);
        const int KEYid = 31197;

        public enum KeyInform
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            Windows = 8
        }

        const int HOTKEYGap = 0x0312;
        protected override void WndProc(ref Message message)
        {
            switch (message.Msg)
            {
                case HOTKEYGap:
                    Keys key = (Keys)(((int)message.LParam >> 16) & 0xFFFF); //눌러 진 단축키의 키
                    KeyInform modifier = (KeyInform)((int)message.LParam & 0xFFFF);//눌려진 단축키의 수식어
                    if ((KeyInform.Control) == modifier && Keys.Q == key && standby_key == 0)//단축키 설정에서 q로 저장했을때
                    {
                        comm.SetURL("http://210.94.194.82:52131/log.asp?id=2015111489&cmd=write&action=sleep");
                        comm.SetURL("http://210.94.194.82:52131/log.asp?id=2015111489&cmd=read&action=sleep");
                        comm.setMessage("");
                        comm.Reqeust();
                        string result = comm.Response();
                        textBox1.Text = result;
                        this.절전모드실행ToolStripMenuItem.PerformClick();

                    }
                    else if ((KeyInform.Control) == modifier && Keys.W == key && standby_key == 1)//단축키 설정에서 w로 저장했을때
                    {
                        comm.SetURL("http://210.94.194.82:52131/log.asp?id=2015111489&cmd=write&action=sleep");
                        comm.SetURL("http://210.94.194.82:52131/log.asp?id=2015111489&cmd=read&action=sleep");
                        comm.setMessage("");
                        comm.Reqeust();
                        string result = comm.Response();
                        textBox1.Text = result;
                        this.절전모드실행ToolStripMenuItem.PerformClick();
                        
                    }
                    break;
            }
            base.WndProc(ref message);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)//폼이 닫힐때
        {
            UnregisterHotKey(this.Handle, KEYid);//단축키 제거
        }

        private void button2_Click(object sender, EventArgs e)//x버튼이 눌렸을때 폼 종료 //그러나 윈도우 바에는 나타냄
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)//그림 1을 눌럿을때 컴퓨터 관리 form 실행
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)//그림 2를 눌렀을때 파워 관리 form 실행
        {
            Form3 form3 = new Form3();
            form3.Show();
        }


        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)//종료 contexstripmenu 클릭시
        {
            if (MessageBox.Show("종료하시겠습니까?\n종료시 자동종료 내용이 삭제됩니다.", "Exit GVS program", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.notifyIcon1.Visible = false;//notifyicon 안보이게 하기
                UnregisterHotKey(this.Handle, KEYid);//단축키 제거
                Application.Exit();//실행 종료
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;  //notifyicon 더블 클릭시에 해당 어플리케이션을 보여줌
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal; // 최소화를 멈ㅊ ㅁ
            this.Activate(); // 폼을 활성화
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) //종료하려 할떄
            {
                e.Cancel = true;//종료를 취소
                this.Visible = false;//어플리케이션을 숨김
            }
        }

        private void 절전모드단축키설정ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();//form4 실행
            frm4.ShowDialog();

            standby_key = frm4.Set_standby_key;//form4로부터 받아온 값을 저장


            if(standby_key ==0)//form4로부터 받아온 값에 따라서 다른 단축키 추가
            {
                RegisterHotKey(this.Handle, KEYid, KeyInform.Control, Keys.Q); //CTRL+Q로 단축키 추가
            }
            else if(standby_key ==1)
            {
                RegisterHotKey(this.Handle, KEYid, KeyInform.Control, Keys.W); //CTRL+Wㅗ 단축키 추가
            }
        }

        private void 절전모드실행ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //절전모드 실행, 서버에 log 전송
          

            //nircmd를 이용해서 standby(절전) 실행
            //nircmd의 위치가 local이기 때문에 다른사람이 실행시에는 위치를 변경해야햄
            Process.Start("C:\\Users\\gkzns\\OneDrive\\바탕 화면\\nircmd\\nircmd.exe", "standby");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
