namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();//初始化组件
        }

        //object sender:触发事件的对象，此处是触发对象是button1
        private void button1_Click(object sender, EventArgs e)
        {


            MessageBox.Show("hello timo!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2(); //创建窗体2
            frm2.Show();              //显示
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SaveForm._saveForm1 = this;     //加载Form1时将Form1的对象赋值给_saveForm1
        }

        //当鼠标进入到按钮区域，给按钮一个新坐标
        private void button3_MouseEnter(object sender, EventArgs e)
        {

            //按钮活动的最大范围，长：form长-button长，宽：form宽 - button宽
            /*this.ClientSize.width :窗口动态宽度（缩放时会自动更新）
             * this.width :当前窗口宽度 （定值，缩放时不会更新）
             */
            int x = this.ClientSize.Width - button3.Width;
            int y = this.ClientSize.Height - button3.Height;
            Random rd = new Random();
            //重新给buttn3一个新坐标
            button3.Location = new Point(rd.Next(0, x), rd.Next(0, y)); 

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("雅蠛蝶...");
            this.Close();
        }
    }
}