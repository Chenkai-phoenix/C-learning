namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();//��ʼ�����
        }

        //object sender:�����¼��Ķ��󣬴˴��Ǵ���������button1
        private void button1_Click(object sender, EventArgs e)
        {


            MessageBox.Show("hello timo!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2(); //��������2
            frm2.Show();              //��ʾ
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SaveForm._saveForm1 = this;     //����Form1ʱ��Form1�Ķ���ֵ��_saveForm1
        }

        //�������뵽��ť���򣬸���ťһ��������
        private void button3_MouseEnter(object sender, EventArgs e)
        {

            //��ť������Χ������form��-button������form�� - button��
            /*this.ClientSize.width :���ڶ�̬��ȣ�����ʱ���Զ����£�
             * this.width :��ǰ���ڿ�� ����ֵ������ʱ������£�
             */
            int x = this.ClientSize.Width - button3.Width;
            int y = this.ClientSize.Height - button3.Height;
            Random rd = new Random();
            //���¸�buttn3һ��������
            button3.Location = new Point(rd.Next(0, x), rd.Next(0, y)); 

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("����...");
            this.Close();
        }
    }
}