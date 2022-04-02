namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool flag1 = false;
        public  string[] redNum = new string[7];
        public  string blueNum = null;

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (flag1 == false)
            {
                flag1 = true;
                button1.Text = "Pause";
                Thread thread1 = new Thread(PlayGame);
                thread1.IsBackground = true;
                thread1.Start();
            }
            else 
            {
                flag1 = false;
                button1.Text = "Start";
              
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;  //取消UI线程间检查
        }

        public void PlayGame()
        {
            Random r = new Random();
            while (flag1)
            {
                label2.Text = r.Next(1, 33).ToString();     //红色
                label3.Text = r.Next(1, 33).ToString();     //红色
                label4.Text = r.Next(1, 33).ToString();     //红色
                label5.Text = r.Next(1, 33).ToString();     //红色
                label6.Text = r.Next(1, 33).ToString();     //红色
                label7.Text = r.Next(1, 33).ToString();     //红色
                label8.Text = r.Next(1, 33).ToString();     //红色
                label9.Text = r.Next(1, 16).ToString();     //蓝色
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("谢谢惠顾");
            this.Close();
        }
    }
}