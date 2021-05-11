using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using HTTPComm;

namespace HTTPCommTester
{
    public partial class Form3 : Form
    {

        //마우스 관련 변수들 
        Point fPt;
        bool isMove;

        String temp;
        int hour = DateTime.Now.Hour;//현재시간의 시를 저장
        int min = DateTime.Now.Minute;//현재시간의 분을 저장
        int sec = DateTime.Now.Second;
        int hour2 = DateTime.Now.Hour;
        int min2 = DateTime.Now.Minute;
        int sec2 = DateTime.Now.Second;
        string datePart;
        
        int com_off_force = 0;//정상종료에 대한 flag
        int com_off_stand = 0;//강제종료에 대한 flag
        int com_standby = 0;
        int com_hibernate = 0;

        HTTPWebComm comm = new HTTPWebComm();

        public Form3()
        {
            InitializeComponent();

            //그림들 불러옴
            pictureBox4.Image = Properties.Resources.applications;
            pictureBox1.Image = Properties.Resources.border;
            pictureBox2.Image = Properties.Resources.border;

            //comboBox의 기본값들 설정
            comboBox1.Text = "사용안함";
            comboBox1.SelectedText = "사용안함";
            comboBox2.Text = "1분";
            comboBox2.SelectedText = "1분";

            //timer의 기본 값 설정 1초마다.
            timer1.Interval = 1000;
            timer1.Start();

            label8.Visible = false;
        }


        // timer의 interval만큼마다 실행하는 이벤트를 생성
        private void timer1_Tick(object sender, EventArgs e)
        {
            //현재시간 불러와서 출력
            DateTime dt = DateTime.Now;
            datePart = dt.ToString("yyyy년MM월dd일hh:mm:ss");
            label6.Text = "현재 시간 : " + datePart;

            //자동종료나 강제종료 관련된 flag가 들어와 있는 경우 몇시에 작동을 할건지 출력하기 위한 조건문
            if (com_off_stand == 1)//정상종료
            {
                label8.Visible = true;
                label8.Text = hour + "시 " + min + "분 " + sec +"초에 정상 자동 종료를 실행\n";
            }
            else if (com_off_force == 1)//강제종료
            {
                label8.Visible = true;
                label8.Text = hour + "시 " + min + "분 " + sec + "초에 강제 자동 종료를 실행\n";
            }
            else if (com_off_stand == 0 || com_off_force == 0)//자동종료가 설정 안된 경우 label을 숨김
                label8.Visible = false;

            if(com_standby ==1)
            {
                if (dt.Hour == hour2 && dt.Minute == min2 && dt.Second == sec2)
                {
                    Standby();
                    com_standby = 0;
                }
            }
            else if (com_hibernate == 1)
            {
                if (dt.Hour == hour2 && dt.Minute == min2 && dt.Second ==sec2)
                {
                    Hibernate();
                    com_hibernate = 0;
                }
            }


            if (com_off_stand == 1)//정상종료 플래그가 들어와있을때
            {
                //자동종료로 지정한 값과 현재 시간이 같을 때
                if (dt.Hour == hour && dt.Minute == min && dt.Second == sec)
                {
                    com_off_stand = 0;//플래그 수정

                    Com_standby();
                }
            }
            else if(com_off_force ==1)//강제종료
            {
                //지정 시간과 현재 시간이 같은 경우에
                if (dt.Hour == hour && dt.Minute == min && dt.Second == sec)
                {
                    com_off_force = 0;//플래그 0으로 저장
                    Com_force();
                }
                    
            }
            
        }

        //마우스 관련 이벤트 함수들
        private void panel1_MouseDown(object sender, MouseEventArgs e)
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


        //종료 모드에 대해서 저장 버튼을 눌렀을 때
        private void button1_Click(object sender, EventArgs e)
        {
            //라디오 버튼에 대해서 아무것도 적히지 않은채 저장 버튼이 눌렸을 때
            if (!(radioButton2.Checked) && !(radioButton4.Checked) && !(radioButton5.Checked))
            {
                MessageBox.Show("종료 모드를 선택해주세요.");//메세지창 출력
            }
            else if (radioButton2.Checked)//사용안함 버튼 선택시
            {
                //자동 종료 관련 플래그들 값을 0으로 지정
                com_off_stand = 0;
                com_off_force = 0;
            }
            else//정상 종료나 강제 종료 버튼이 눌러진 상태로 저장을 누른 경우
            {
                if (((com_off_force == 1) || (com_off_stand == 1)))//현재 자동종료가 설정되어 있는 경우가 아닐때만 실행 //둘중 하나라도 1일떄
                {
                    MessageBox.Show("이미 자동 종료모드가 실행중입니다. \n 모드를 변경하려면 사용안함을 저장 한 후, 새로 저장해주세요.");
                }
                else//현재 자동종료가 설정되어 있는 경우가 아닐때만 실행
                {
                    //현재시간의 시와 분을 변수에 따로 각자 저장 
                    hour = DateTime.Now.Hour;
                    min = DateTime.Now.Minute;
                    sec = DateTime.Now.Second;
                    if (comboBox2.Text != "1분")//시간으로 저장되어 있는 것들 
                    {
                        //temp에 선택한 시간에 대해서 숫자만 받아와서 hour변수에 저장
                        temp = comboBox2.Text.Substring(0, comboBox2.Text.IndexOf("시간"));
                        String temp2 = hour + temp;
                        hour = Convert.ToInt32(temp) + hour;

                        //24시부터는 -24를 해서 0시로 만듦
                        if (hour >= 24) { hour -= 24; }
                    }
                    else if (comboBox2.Text == "1분")//첫번째 값인 30분일때.
                    {
                        min += 1;//분에 해당 분을 더해줌
                        if (min >= 60)//더한값이 60분일때.
                        {
                            min -= 60;//60을 빼고
                            hour += 1;//시간을 1시간 더해줌
                            if (hour == 24) hour = 0;//더한 시간이 24시가 되면 0으로 지정
                        }
                    }

                    if (radioButton4.Checked) //정상종료 버튼이 눌린경우
                    {
                        com_off_stand = 1;//정상종료 플래그를 1로 저장
                    }
                    else if (radioButton5.Checked)//강제종료 버튼이눌린경우
                    {
                        com_off_force = 1;//강제종료 플래그를 1로 저장
                    }
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)//x버튼을 눌렀을 때
        {
            this.Visible = false;//form 숨김
        }

        private void Standby()
        {
            comm.SetURL("http://210.94.194.82:52131/log.asp?id=2015111489&cmd=write&action=sleep");
            comm.SetURL("http://210.94.194.82:52131/log.asp?id=2015111489&cmd=read&action=sleep");
            comm.setMessage("");
            comm.Reqeust();
            string result = comm.Response();
            textBox1.Text = result;
            Process.Start("C:\\Users\\gkzns\\OneDrive\\바탕 화면\\nircmd\\nircmd.exe", "standby");//nircmd를 이용해서 절전모드 바로 실행
        }

        private void Com_standby()//로그를 보내고 정상종료 실행
        {
            comm.SetURL("http://210.94.194.82:52131/log.asp?id=2015111489&cmd=write&action=shutdown");
            comm.SetURL("http://210.94.194.82:52131/log.asp?id=2015111489&cmd=read&action=shutdown");
            comm.setMessage("");
            comm.Reqeust();
            string result = comm.Response();
            textBox1.Text = result;
            //현재 실행중인 프로세스의 모곡을 받아와 배열에 저장
            Process[] pro = Process.GetProcesses();

            //프로세스가 켜져있는게 존재하게 되면 
            if (pro.Length > 0)
            {
                //메세지 창을 띄움
                MessageBox.Show("프로세스가 실행중이기 때문에, 자동종료를 거부합니다.");
            }
            else if (pro.Length == 0)
            {// 켜져있는 프로세스가 없으면 nircmd를 이용해서 컴퓨터 종료
                Process.Start("C:\\Users\\gkzns\\OneDrive\\바탕 화면\\nircmd\\nircmd.exe", "exitwin poweroff ");
            }
        }

        private void Com_force() //log를 보내고 강제종료실행
        {
            comm.SetURL("http://210.94.194.82:52131/log.asp?id=2015111489&cmd=write&action=shutdown");
            comm.SetURL("http://210.94.194.82:52131/log.asp?id=2015111489&cmd=read&action=shutdown");
            comm.setMessage("");
            comm.Reqeust();
            string result = comm.Response();
            textBox1.Text = result;
            com_off_force = 0;//플래그 0으로 저장
            Process.Start("C:\\Users\\gkzns\\OneDrive\\바탕 화면\\nircmd\\nircmd.exe", "exitwin poweroff ");//nircmd를 이용해서 강제종료
        }

        private void Hibernate()
        {
            comm.SetURL("http://210.94.194.82:52131/log.asp?id=2015111489&cmd=write&action=hibernate");
            comm.SetURL("http://210.94.194.82:52131/log.asp?id=2015111489&cmd=read&action=hibernate");
            comm.setMessage("");
            comm.Reqeust();
            string result = comm.Response();
            textBox1.Text = result;
            Process.Start(fileName: "rundll32", arguments: "powrprof.dll, SetSuspendState");//nircmd를 이용해서 최대절전모드 바로 실행
        }


        private void button3_Click(object sender, EventArgs e)//절전모드 바로실행 버튼을 눌렀을때 실행되는 이벤트
        {
            //절전모드를 선택하는 라디오 버튼 아무것도 선택하지 않고 바로실행 버튼을 눌렀을 대
            if (!(radioButton1.Checked) && !(radioButton3.Checked))
            {
                MessageBox.Show("절전모드를 선택해 주세요.");//메세지 박스 출력
            }
            else if (radioButton1.Checked)//최소절전 선택시
            {
                Standby();

            }
            else if(radioButton3.Checked)//최대절전 선택시
            {
                Hibernate();
            }
        }

        private void button4_Click(object sender, EventArgs e)//절전모드에서 저장 버튼을 눌렀을 때
        {
            if (!(radioButton1.Checked) && !(radioButton3.Checked))//절전모드 선택안하고 저장 버튼 클릭시 
            {
                MessageBox.Show("절전모드를 선택해 주세요.");//메세지 박스 출력
            }
            else
            {
                hour2 = DateTime.Now.Hour;
                min2 = DateTime.Now.Minute;
                sec2 = DateTime.Now.Second;
                if (comboBox1.Text != "사용안함" && radioButton1.Checked)//최소절전
                {
                    if (com_hibernate == 1) com_hibernate = 0;

                    comm.SetURL("http://210.94.194.82:52131/log.asp?id=2015111489&cmd=write&action=sleep");

                    String msg = comboBox1.Text.Substring(0, comboBox1.Text.IndexOf("분"));
                    min2 += Convert.ToInt32(msg);
                    if (min2 >= 60)
                    {
                        min2 -= 60;
                        hour2++;
                        if (hour2 == 24) hour2 -= 24;
                    }
                    com_standby = 1;
                }
                else if (comboBox1.Text != "사용안함" && radioButton3.Checked)//최대절전
                {
                    if (com_standby == 1) com_standby = 0;

                    comm.SetURL("http://210.94.194.82:52131/log.asp?id=2015111489&cmd=write&action=hibernate");

                    String msg = comboBox1.Text.Substring(0, comboBox1.Text.IndexOf("분"));
                    min2 += Convert.ToInt32(msg);
                    if (min2 >= 60)
                    {
                        min2 -= 60;
                        hour2++;
                        if (hour2 == 24) hour2 -= 24;
                    }
                    com_hibernate = 1;
                }
                else if (comboBox1.Text == "사용안함" && radioButton1.Checked)//최소절전을 사용안함으로 저장하면
                {
                    com_standby = 0;
                }
                else if (comboBox1.Text == "사용안함" && radioButton3.Checked)//최대절전을 사용안함으로 저장하면
                {
                    com_hibernate = 0;
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)//절전모드 도움말 클릭시
        {
            MessageBox.Show("최소 절전은 마우스와 키보드 키 등으로 절전모드를 종료할 수 있습니다.\n\n최대 절전은 power on 버튼을 눌러 절전모드를 종료할 수 있습니다.");
        }

        private void label1_Click(object sender, EventArgs e)//자동종료 도움말 클릭시
        {
            MessageBox.Show("자동 종료는 어떤 파일이나 문서가 켜져있으면 종료되지 않습니다.\n\n강제 종료는 어떤 문서나 파일이 켜져있어도 컴퓨터가 종료됩니다.");
        }


    }
}
