namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ��ʾ�Ӵ���ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //�����Ӵ���
            Form2 form2 = new Form2();
            //�ϸ����壨�ϵ���
            form2.MdiParent = this;
            form2.Show();
            Form3 form3 = new Form3();
            form3.MdiParent = this;
            form3.Show();
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            LayoutMdi(MdiLayout.TileVertical);
        }
    }
}