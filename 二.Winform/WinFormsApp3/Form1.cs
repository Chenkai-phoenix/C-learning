using System.Media;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = userName.Text.Trim();
            string password = userPassword.Text;
            if (checkStudent.Checked == true)
            {
                if (name == "student" && password == "123456")
                {
                    SoundPlayer sp = new SoundPlayer();
                    sp.SoundLocation = @"welcom.wav";
                    sp.Play();
                    MessageBox.Show("欢迎登录学生信息系统！");
                }
                else 
                {
                    SoundPlayer sp = new SoundPlayer();
                    sp.SoundLocation = @"alarm.wav";
                    sp.Play();
                    MessageBox.Show("用户名或密码错误！！！");
                }
            }
            else if (checkTeacher.Checked == true)
            {
                if(name == "teacher" && password == "654321")
                {
                    SoundPlayer sp = new SoundPlayer();
                    sp.SoundLocation = @"welcom.wav";
                    sp.Play();
                    MessageBox.Show("欢迎登录教职工信息系统！");
                }
                else
                {
                    SoundPlayer sp = new SoundPlayer();
                    sp.SoundLocation= @"alarm.wav";
                    sp.Play();
                    MessageBox.Show("用户名或密码错误！！！");
                }

            }
            else 
            {
                MessageBox.Show("请选择一个身份！");
            }


        }

        private void checkStudent_CheckedChanged(object sender, EventArgs e)
        {
            if (checkStudent.Checked == true)
                checkTeacher.Checked = false;

            
          
        }

        private void checkTeacher_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTeacher.Checked == true)
                checkStudent.Checked = false;
        }
    }
}