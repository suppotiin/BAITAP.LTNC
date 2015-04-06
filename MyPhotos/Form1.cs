using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyPhotos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            mnuView.DropDown = contextMenuStrip1;
            SetStatusStrip(null);
            mnuView.DropDown = contextMenuStrip1;
        }
        private void mnuLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open Photo";
            dlg.Filter = "jpg file(*.jpg)|*.jpg|All files (*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pbxPhoto.Image = new Bitmap(dlg.OpenFile());
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Khong the load files: " + ex.Message);
                    pbxPhoto.Image = null;
                }
                SetStatusStrip(dlg.FileName);
            }


            dlg.Dispose();
        }

        private void mnuImage_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ProcessImageClick(e);
        }
        private void ProcessImageClick(ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            string enumVal = item.Tag as string;
            if (enumVal != null)
                {
                    pbxPhoto.SizeMode = (PictureBoxSizeMode)
                        Enum.Parse(typeof(PictureBoxSizeMode),enumVal);
                }
        }

        private void mnuImage_DropDownOpening(object sender, EventArgs e)
        {
            ProcessImageOpening(sender as ToolStripDropDownItem);
        }

        private void ProcessImageOpening(ToolStripDropDownItem parent)
            {
                if (parent != null)
                    {
                        string enumVal = pbxPhoto.SizeMode.ToString();
                        foreach (ToolStripMenuItem item in parent.DropDownItems)//lay ds cac item(kiem traxem = gia tri voi Photo nhan hay k ?)
                                {
                                        item.Enabled = (pbxPhoto.Image != null);//neu box co anh thi enable no len, nguoc lai
                                        item.Checked = item.Tag.Equals(enumVal);//kiemtra 2 chuoi co bang nhau hay k
                                }
                    }
            }

       private void SetStatusStrip(string path)
       {
           if (pbxPhoto.Image != null)
               {
                   ct2.Text = path;
                   statusImageSize.Text = String.Format("{0:#}x{1:#}", pbxPhoto.Image.Width, pbxPhoto.Image.Height);
                   // statusAlbumPos is set in ch. 6
               }
           else
                {
                    ct2.Text = null;
                    statusImageSize.Text = null;
                    statusAlbumPos.Text = null;
                }
}

       private void mnuExit_Click(object sender, EventArgs e)
       {
           Close();
       }
       }

        

        
    }
