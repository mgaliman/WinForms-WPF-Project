using System;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class FrmChangePicture : Form
    {
        public FrmChangePicture(PictureBox picture)
        {
            InitializeComponent();
            InitSetup(picture);
        }

        private void InitSetup(PictureBox picture)
        {
            pb.Image = picture.Image;
        }

        public PictureBox GetUpdatedPicture()
        {
            return pb;
        }

        private void BtnChangePicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Pictures|*.bmp;*.jpg;*.jfif;*.jpeg;*.png;|All files|*.*",
                InitialDirectory = Application.StartupPath
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                MainForm mainForm = new MainForm();
                mainForm.Refresh();
                pb.ImageLocation = ofd.FileName;
            }
        }
    }
}
