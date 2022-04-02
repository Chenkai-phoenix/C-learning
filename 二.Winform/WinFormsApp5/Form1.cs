using System.IO;
namespace WinFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //窗口加载
        private void Form1_Load(object sender, EventArgs e)
        {
            //图像窗口的图像显示模式StretchImage填充
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Image.FromFile(@"picture\girl.jpg");   //图像窗口获得图片；
        }
        //字段
        //将文件夹中的所有文件路径放到picturesPath[]
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
