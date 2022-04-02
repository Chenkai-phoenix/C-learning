using System.IO;
namespace WinFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //���ڼ���
        private void Form1_Load(object sender, EventArgs e)
        {
            //ͼ�񴰿ڵ�ͼ����ʾģʽStretchImage���
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Image.FromFile(@"picture\girl.jpg");   //ͼ�񴰿ڻ��ͼƬ��
        }
        //�ֶ�
        //���ļ����е������ļ�·���ŵ�picturesPath[]
        string[] picturesPath = Directory.GetFiles(@"picture");
        int nextPicture = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            nextPicture++;
            if (nextPicture == picturesPath.Length)
            {
                nextPicture = 0;
            }
            pictureBox1.Image = Image.FromFile(picturesPath[nextPicture]);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            nextPicture--;
            if (nextPicture == 0)
            {
                nextPicture = picturesPath.Length - 1;
            }
            pictureBox1.Image = Image.FromFile(picturesPath[nextPicture]);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            nextPicture++;
            if (nextPicture == picturesPath.Length)
            {
                nextPicture = 0;

            }
            else

                pictureBox2.Image = Image.FromFile(picturesPath[nextPicture]);
        }

    }
}
