using System.Media;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //���ı���textBox1�����������lable1
            label1.Text = textBox1.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {


        }

        //��ʱ��1:����ư���
        private void timer1_Tick(object sender, EventArgs e)
        {
            //�����һ���ַ���ȡ+ʣ���ַ� =���ַ���
            label2.Text = label2.Text.Substring(label2.Text.Length - 1) + label2.Text.Substring(0, label2.Text.Length - 1);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        //��ʱ��2:����
        private void timer2_Tick(object sender, EventArgs e)
        {
            label3.Text = label3.Text.Substring(0, 12) + " " + DateTime.Now.ToString();
            //����16������
            if (DateTime.Now.Hour == 16 && DateTime.Now.Minute == 17 && DateTime.Now.Second == 30)
            {
                //�������ֲ���������
                SoundPlayer sp1 = new SoundPlayer();
                sp1.SoundLocation = @"F:\CSharpCode\��.Winform\WinFormsApp2\bin\Debug\net6.0-windows\1.wav";
                sp1.Play();
            }
        }
    }
}