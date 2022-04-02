using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Media;

namespace WinFormsApp6
{
    public partial class Form1 : Form
    {
        List<string> songsFullPath = new List<string>();     //存放音乐的全路径
        public Form1()
        {
            InitializeComponent();
        }

        private void openFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();  //打开文件对话框
            ofd.Title = "请选择音乐...";                 //设置对话框标题
            ofd.InitialDirectory = Application.StartupPath + "music";     //初始化文件夹路径(相对路径)
            ofd.Multiselect = true;                     //打开多选选项
            ofd.Filter = "音乐文件|*.wav|所有文件|*.*";  //窗口右下角下拉菜单内容
            ofd.ShowDialog();                           //显示对话框
            string[] fNamesPath = ofd.FileNames;        //存放所有文件路径
            for (int i = 0; i < fNamesPath.Length; i++)
            {
                //将文件名加到listBox1中
                listBox1.Items.Add(Path.GetFileName(fNamesPath[i]));
                //将文件全路径加到List<string>中
                songsFullPath.Add(fNamesPath[i]);
            }
        }

        //双击播放
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            SoundPlayer soundP1 = new SoundPlayer(); //创建播放对象,仅支持.wav
            //获取音乐全路径；listBox1.SelectedIndex：listBox1的索引 = songsFullPath的索引
            soundP1.SoundLocation = songsFullPath[listBox1.SelectedIndex];
            soundP1.Play();

        }

        //上一曲
        private void button2_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedIndex == 0)
            {
                MessageBox.Show("已是第一曲，没有上一曲了哟。");
            }
            else
            {
                listBox1.SelectedIndex--;
                SoundPlayer soundP2 = new SoundPlayer(); //创建播放对象,仅支持.wav
                //获取音乐全路径；listBox1.SelectedIndex：listBox1的索引 = songsFullPath的索引
                soundP2.SoundLocation = songsFullPath[listBox1.SelectedIndex];
                soundP2.Play();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedIndex == (listBox1.Items.Count - 1))
            {
                MessageBox.Show("已是最后一曲，没有下一曲了哟！");
            }
            else
            {
                listBox1.SelectedIndex++;
                SoundPlayer soundP3 = new SoundPlayer(); //创建播放对象,仅支持.wav
                //获取音乐全路径；listBox1.SelectedIndex：listBox1的索引 = songsFullPath的索引
                soundP3.SoundLocation = songsFullPath[listBox1.SelectedIndex];
                soundP3.Play();
            }

        }
    }
}