using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HTTPComm;

namespace HTTPCommTester
{
    public partial class Form4 : Form
    {
        //마우스 관련 변수
        Point fPt;
        bool isMove;

        private int Form4_value_key;//단축키의 순서 값을 저장할 변수

        public int Set_standby_key
        {
            get { return this.Form4_value_key; } //get 접근자
            set { this.Form4_value_key = value; }  // set 접근자
        }

        public Form4()
        {
            InitializeComponent();

            //combobox의 디폴트값
            comboBox1.Text = "Ctrl+Q";
            comboBox1.SelectedText = "Ctrl+Q";
        }

        //마우스 관련 함수들
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

        //확인 버튼을 누르면 
        private void button2_Click(object sender, EventArgs e)
        {

            //ctrl+q인 경우에는 0값 저장
            if (comboBox1.Text == "Ctrl+Q")
            {
                Set_standby_key = 0;
            }
            else Set_standby_key = 1;//ctrl+w인 경우에는 1값 저장
            this.Hide();//form 숨김
        }
    }
}
