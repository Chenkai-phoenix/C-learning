using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Media;

namespace WinFormsApp6
{
    public partial class Form1 : Form
    {
        List<string> songsFullPath = new List<string>();     //������ֵ�ȫ·��
        public Form1()
        {
            InitializeComponent();
        }

        private void openFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();  //���ļ��Ի���
            ofd.Title = "��ѡ������...";                 //���öԻ������
            ofd.InitialDirectory = Application.StartupPath + "music";     //��ʼ���ļ���·��(���·��)
            ofd.Multiselect = true;                     //�򿪶�ѡѡ��
            ofd.Filter = "�����ļ�|*.wav|�����ļ�|*.*";  //�������½������˵�����
            ofd.ShowDialog();                           //��ʾ�Ի���
            string[] fNamesPath = ofd.FileNames;        //��������ļ�·��
            for (int i = 0; i < fNamesPath.Length; i++)
            {
                //���ļ����ӵ�listBox1��
                listBox1.Items.Add(Path.GetFileName(fNamesPath[i]));
                //���ļ�ȫ·���ӵ�List<string>��
                songsFullPath.Add(fNamesPath[i]);
            }
        }

        //˫������
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            SoundPlayer soundP1 = new SoundPlayer(); //�������Ŷ���,��֧��.wav
            //��ȡ����ȫ·����listBox1.SelectedIndex��listBox1������ = songsFullPath������
            soundP1.SoundLocation = songsFullPath[listBox1.SelectedIndex];
            soundP1.Play();

        }

        //��һ��
        private void button2_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedIndex == 0)
            {
                MessageBox.Show("���ǵ�һ����û����һ����Ӵ��");
            }
            else
            {
                listBox1.SelectedIndex--;
                SoundPlayer soundP2 = new SoundPlayer(); //�������Ŷ���,��֧��.wav
                //��ȡ����ȫ·����listBox1.SelectedIndex��listBox1������ = songsFullPath������
                soundP2.SoundLocation = songsFullPath[listBox1.SelectedIndex];
                soundP2.Play();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedIndex == (listBox1.Items.Count - 1))
            {
                MessageBox.Show("�������һ����û����һ����Ӵ��");
            }
            else
            {
                listBox1.SelectedIndex++;
                SoundPlayer soundP3 = new SoundPlayer(); //�������Ŷ���,��֧��.wav
                //��ȡ����ȫ·����listBox1.SelectedIndex��listBox1������ = songsFullPath������
                soundP3.SoundLocation = songsFullPath[listBox1.SelectedIndex];
                soundP3.Play();
            }

        }
    }
}