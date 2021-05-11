using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using HTTPComm;

namespace HTTPCommTester
{
    public partial class Form2 : Form
    {

        //마우스 관련 변수 // form1과 같으므로 생략
        Point fPt;
        bool isMove;

        //화면 밝기와 소리 관련 변수
        int trackbar1_count = 0;
        int trackbar1_line = 5;
        int trackbar2_count = 0;
        int trackbar2_line = 5;

        HTTPWebComm comm = new HTTPWebComm();

        private Timer MonitorTimer = new Timer();//timer 선언


        public Form2()
        {
            InitializeComponent();
            pictureBox4.Image = Properties.Resources.applications;

            //사용자의 기본적인 세팅을 다음과 같이 밝기 50, 소리 32767로 설정
            //local이므로, nircmd의 위치는 실행하는 사람에 따라 바뀌어야 함
            Process.Start("C:\\Users\\gkzns\\OneDrive\\바탕 화면\\nircmd\\nircmd.exe", "setbrightness 60");
            Process.Start("C:\\Users\\gkzns\\OneDrive\\바탕 화면\\nircmd\\nircmd.exe", "setsysvolume 32767");

            //밝기와 소리의 기본 세팅에 대한 trackbar의 기준 값
            trackbar1_line = 5;
            trackbar2_line = 5;

            label15.BackColor = Color.Transparent;
        }

        protected override void OnLoad(EventArgs e)
        {
            //배터리에 대한 정보값을 받아와서 업데이트 하기 위해서 timer를 실행
            base.OnLoad(e);

            this.MonitorTimer.Interval = 2000; // 2초에 한번씩 상태를 체크
            this.MonitorTimer.Tick += new EventHandler(MonitorTimer_Tick);//interval만큼 시간이 지날때마다 해당 기능도 실행
            this.MonitorTimer.Start();
            // 최초 호출
            this.UpdateText();
            this.UpdateIcon();
        }

        protected override void OnClosing(CancelEventArgs e)//종료시 닫고, 타이머도 종료
        {
            base.OnClosing(e);
            this.MonitorTimer.Stop();
        }


        void MonitorTimer_Tick(object sender, EventArgs e)
        {
            this.UpdateText();
            this.UpdateIcon();
        }


        private void UpdateText() //배터리에 대한 정보를 업데이트하는 함수
        {
            PowerStatus status = SystemInformation.PowerStatus;

            //노트북의 배터리 용량에 대한 값 
            if(status.BatteryChargeStatus.ToString() == "High") { this.label11.Text = "배터리 충전량이 높습니다."; }
            else if(status.BatteryChargeStatus.ToString() =="Low") { this.label11.Text = "배터리 충전량이 낮습니다."; }
            else if (status.BatteryChargeStatus.ToString() =="Critical") { this.label11.Text = "배터리 충전량이 매우 낮습니다."; }
            else { this.label11.Text = "-"; }
            
            //노트북이 충전기와 연결되었는지에 대한 여부
            if (status.PowerLineStatus.ToString() == "Offline") { this.label13.Text = "-"; }
            else if (status.PowerLineStatus.ToString() == "Online") { this.label13.Text = "케이블로 충전중"; }
            else { this.label13.Text = " - "; }

            //그외 배터리에 대한 정보들을 받아와 저장하여 출력
            this.label14.Text = "현재 남은 배터리 시간 : " + (status.BatteryLifeRemaining != -1 ? TimeSpan.FromSeconds(status.BatteryLifeRemaining).ToString() : "-");
            this.progressBar1.Value = (int)(status.BatteryLifePercent != 255 ? status.BatteryLifePercent * 100 : 0);
            this.label15.Text = this.progressBar1.Value.ToString() + " % ";
        }


        private void UpdateIcon()// 받아온 값에 따라서 그림이 달라질 수 있도록 하는 함수
        {
            PowerStatus status = SystemInformation.PowerStatus;
            
            if (status.PowerLineStatus == PowerLineStatus.Offline)//충전중이 아닐때 0.x는 노트북의 배터리가 (10*x)%임을 의미
            {
                //남은 배터리 양에 따라서 다른 그림들을 출력
                if (status.BatteryLifePercent < 0.2)
                {
                    pictureBox1.Image = Properties.Resources.battery__12;
                }
                else if (status.BatteryLifePercent < 0.4 && status.BatteryLifePercent >= 0.2)
                {
                    pictureBox1.Image = Properties.Resources.battery__11;
                }
                else if (status.BatteryLifePercent < 0.6 && status.BatteryLifePercent >= 0.4)
                {
                    pictureBox1.Image = Properties.Resources.battery__10;
                }
                else if (status.BatteryLifePercent < 0.8 && status.BatteryLifePercent >= 0.6)
                {
                    pictureBox1.Image = Properties.Resources.battery__9;
                }
                else
                {
                    pictureBox1.Image = Properties.Resources.battery__8;
                }
            }
            else if (status.PowerLineStatus == PowerLineStatus.Online)//케이블로 충전중일때
            {
                pictureBox1.Image = Properties.Resources.battery__13;
            }
            else if (status.PowerLineStatus == PowerLineStatus.Unknown)//알수없는 상태일때
            {
                pictureBox1.Image = Properties.Resources.info__1;
            }
            
        }

        //마우스 관련 함수들 // form1과 같으므로 생략
        private void panel1_Mousedown(object sender, MouseEventArgs e)
        {
            isMove = true;
            fPt = new Point(e.X, e.Y);
        }

        private void panel1_Mouseup(object sender, MouseEventArgs e)
        {
            isMove = false;
        }

        private void panel1_Mousemove(object sender, MouseEventArgs e)
        {
            if (isMove && (e.Button & MouseButtons.Left) == MouseButtons.Left)
                Location = new Point(this.Left - (fPt.X - e.X), this.Top - (fPt.Y - e.Y));
        }


        //밝기를 조절하려고 trackbar를 조절했을때 실행하는 함수
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            
            trackbar1_count = trackBar1.Value;//현재 trackbar의 값 받아옴
            if (trackbar1_count < trackbar1_line) // 원래보다 작은쪽으로 스크롤 했을 때
            {
                //밝기값 10 감소
                Process.Start("C:\\Users\\gkzns\\OneDrive\\바탕 화면\\nircmd\\nircmd.exe", "changebrightness -10");
            }
            else //원래 기준보다 큰쪽으로 스크롤 했을 때
            {
                //밝기값 10 증가
                Process.Start("C:\\Users\\gkzns\\OneDrive\\바탕 화면\\nircmd\\nircmd.exe", "changebrightness +10");
            }

            //원래 초기화된 값이 5였는데, 사용자가 임의로 줄이거나 늘였기 때문에 기준값을 새로 저장
            trackbar1_line = trackbar1_count;
        }

        //소리를 조절하려고 trackbar를 조절했을때 실행하는 함수
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            trackbar2_count = trackBar2.Value;//현재 trackbar의 값 받아옴
            if (trackbar2_count < trackbar2_line) // 원래보다 작은쪽으로 스크롤 했을 때
            {
                //max볼륨의 1/10만큼을 감소
                Process.Start("C:\\Users\\gkzns\\OneDrive\\바탕 화면\\nircmd\\nircmd.exe", "changesysvolume -6554");
            }
            else //원래 기준보다 큰쪽으로 스크롤 했을 때
            {
                //max볼륨의 1/10만큼 증가
                Process.Start("C:\\Users\\gkzns\\OneDrive\\바탕 화면\\nircmd\\nircmd.exe", "changesysvolume +6554");
            }

            //원래 초기화된 값이 중간값 이였는데, 사용자가 임의로 줄이거나 늘였기 때문에 기준값을 새로 저장
            trackbar2_line = trackbar2_count;
        }

        private void button2_Click_1(object sender, EventArgs e)//x버튼을 눌렀을때 해당 form 종료
        {
            this.Close();
        }

        //mute버튼 클릭시
        private void button3_Click(object sender, EventArgs e)
        {
            trackbar2_count = trackBar2.Value;
            Process.Start("C:\\Users\\gkzns\\OneDrive\\바탕 화면\\nircmd\\nircmd.exe", "mutesysvolume 1");
            trackBar2.Value = 0;//trackbar의 값 0으로 저장

        }

        //max volume 버튼을 눌럿을 때
        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\Users\\gkzns\\OneDrive\\바탕 화면\\nircmd\\nircmd.exe", "setsysvolume 65535");
            //소리관련 변수들 max값인 10으로 저장
            trackBar2.Value = 10;
            trackbar2_count = 10;
            trackbar2_line = 10;

        }

        //unmute버튼을 눌렀을 때
        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\Users\\gkzns\\OneDrive\\바탕 화면\\nircmd\\nircmd.exe", "mutesysvolume 0");
            trackBar2.Value = trackbar2_count;

        }


    }
}


