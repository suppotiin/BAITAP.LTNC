﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Manning.PhotoAlbum;
namespace Photo
{
    public partial class frMain : Form
    {
        private AlbumManager manager;
        private AlbumManager Manager
        {
            get { return manager; }
            set { manager = value; }
        }
        public frMain()
        {
            InitializeComponent();
            NewAlbum();
            mnuView.DropDown = ctxMenuphoto;
          

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
                Enum.Parse(typeof(PictureBoxSizeMode),
                enumVal);
            }
        }
        private void ProcessPhoto(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            string enumVal = item.Tag as string;
            if (enumVal != null)
            {
                pbxPhoto.SizeMode = (PictureBoxSizeMode)
                    Enum.Parse(typeof(PictureBoxSizeMode), enumVal);
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
                foreach (ToolStripMenuItem item in parent.DropDownItems)
                {
                    item.Enabled = (pbxPhoto.Image != null);
                    item.Checked = item.Tag.Equals(enumVal);
                }
            }
        }
        private void SetstatusStrip()
        {
            if (pbxPhoto.Image != null)
            {
                sttInfo.Text = Manager.Current.Caption;
                sttImageSize.Text = String.Format("{0:#}x{1:#}",
                    pbxPhoto.Image.Width, pbxPhoto.Image.Height);
                sttAlbumPos.Text = String.Format(" {0:0}/{1:0}",
                    Manager.Index + 1, Manager.Album.Count);
            }
            else
            {
                sttInfo.Text = null;
                sttImageSize.Text = null;
                sttAlbumPos.Text = null;
            }
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open Album";
            // mở định dạng các file
            dlg.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";

            dlg.InitialDirectory= AlbumManager.DefaultPath;
            dlg.RestoreDirectory = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string path = dlg.FileName;
                if (!SaveAndCloseAlbum())
                    return;
                try
                {
                    Manager = new AlbumManager(path);
                }
                catch (AlbumStorageException aex)
                {
                    string msg = String.Format("Unableto open album file {0}\n({1})",path, aex.Message);
                    MessageBox.Show(msg, "Unable to Open");
                    Manager = new AlbumManager();

                }
                DisplayAlbum();
                
            } dlg.Dispose();
        }
       
        private void DisplayAlbum()
        {
            pbxPhoto.Image = Manager.CurrentImage;
            SetstatusStrip();
            SetTitleBar();
        }
        private void SaveAlbum(string name)
        {
            try
            {
                Manager.Save(name, true);
            }
            catch (AlbumStorageException aex)
            {
                string msg = String.Format(
                    "Unable to save album {0} ({1})\n\n"
                    + "Do you wish to save the album "
                    + "under an alternate name?",
                    name, aex.Message);
                DialogResult result = MessageBox.Show(
                msg,
                "Unable to Save",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                    SaveAsAlbum();
            }
        }
        private void SaveAlbum()
        {
            if (String.IsNullOrEmpty(Manager.FullName))
                SaveAsAlbum();
            else
            {
                // Save the album under the existing name
                SaveAlbum(Manager.FullName);
            }
        }
        private void mnuSave_Click_1(object sender, EventArgs e)
        {
            SaveAlbum();
        }
        private void SaveAsAlbum()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Save Album";
            dlg.DefaultExt = "abm";
            dlg.Filter = "Album files (*.abm)|*.abm|" + "All files|*.*";
            dlg.InitialDirectory = AlbumManager.DefaultPath;
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                SaveAlbum(dlg.FileName);
                // Update title bar to include new name
                SetTitleBar();
            }
            dlg.Dispose();
        }
        private void menuEditAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Title = "Add Photos";
            dlg.Multiselect = true;
            dlg.Filter = "Image Files (JPEG, GIF, BMP, etc.)|"
                + "*.jpg;*.jpeg;*.gif;*.bmp;"
                + "*.tif;*.tiff;*.png|"
                + "JPEG files (*.jpg;*.jpeg)|*.jpg;*.jpeg|"
                + "GIF files (*.gif)|*.gif|"
                + "BMP files (*.bmp)|*.bmp|"
                + "TIFF files (*.tif;*.tiff)|*.tif;*.tiff|"
                + "PNG files (*.png)|*.png|"
                + "All files (*.*)|*.*";
            dlg.InitialDirectory = Environment.CurrentDirectory;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string[] files = dlg.FileNames;
                int index = 0;

                foreach (string s in files)
                {
                    Photograph photo = new Photograph(s);

                    // Add the file (if not already present)
                    index = Manager.Album.IndexOf(photo);
                    if (index < 0)
                        Manager.Album.Add(photo);
                    else
                        photo.Dispose(); // photo already there
                }
                Manager.Index = Manager.Album.Count - 1;
            }

            dlg.Dispose();
            DisplayAlbum();
        }

        private void NewAlbum()
        {
            if (Manager == null || SaveAndCloseAlbum())
            {
                Manager = new AlbumManager();
                DisplayAlbum();
            }
        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            NewAlbum();
        }
       
        
      
       
        private void SetTitleBar()
        {
            Version ver = new Version(Application.ProductVersion);
            string name = Manager.FullName;
            this.Text = String.Format("{2} - MyPhotos {0:0}.{1:0}", ver.Major, ver.Minor,
            String.IsNullOrEmpty(name) ? "Untitled" : name);
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuEditRemove_Click(object sender, EventArgs e)
        {
            if (Manager.Album.Count > 0)
            {
                Manager.Album.RemoveAt(Manager.Index);
                DisplayAlbum();
            }
        }

        private void menuNext_Click(object sender, EventArgs e)
        {
            if (Manager.Index < Manager.Album.Count - 1)
            {
                Manager.Index++;
                DisplayAlbum();
            }
        }

        private void menuPrevious_Click(object sender, EventArgs e)
        {
            if (Manager.Index > 0)
            {
                Manager.Index--;
                DisplayAlbum();
            }
        }

        private void ctxMenuPhoto_Opening(object sender, CancelEventArgs e)
        {
            mnuNext.Enabled = (Manager.Index < Manager.Album.Count - 1);
            mnuPrevious.Enabled = (Manager.Index > 0);
        }

        private bool SaveAndCloseAlbum()
        {
            if (Manager.Album.HasChanged)
            {
                string msg;
                if (String.IsNullOrEmpty(Manager.FullName))
                    msg = "Do you wish to save your changes?";
                else
                    msg = String.Format("Do you wish to "
                    + "save your changes to \n{0}?",
                    Manager.FullName);
                DialogResult result= MessageBox.Show(this, msg,"Save Changes?",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    SaveAlbum();
                else if (result == DialogResult.Cancel)
                    return false;
            }
           if (Manager.Album != null)
                Manager.Album.Dispose();
            Manager = new AlbumManager();
            SetTitleBar();
            return true;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        { 
            if (SaveAndCloseAlbum() == false)
                e.Cancel = true;
            else
                e.Cancel = false;
            base.OnFormClosing(e);
        }
        private void menuPixelData_Click(object sender, EventArgs e)
        {
            // Only check for null as we count on the menuPhoto Opening
            // handler to adjust the PixelForm variable when the user
            // closes the dialog manually.
            if (PixelForm == null)
            {
                menuPixelData.Text = "Hide Pi&xel Data";
                PixelForm = new PixelDialog();
                PixelForm.Owner = this;

                PixelForm.Show();
                Point p = pbxPhoto.PointToClient(Form.MousePosition);
                UpdatePixelDialog(p.X, p.Y);
            }
            else
            {
                menuPixelData.Text = "Pi&xel Data...";
                PixelForm.Close();
                PixelForm = null;
            }
        }

        private void ctxMenuPhoto_Opening(object sender, CancelEventArgs e)
        {
            menuNext.Enabled = (Manager.Index < Manager.Album.Count - 1);
            menuPrevious.Enabled = (Manager.Index > 0);

            if (PixelForm != null && PixelForm.IsDisposed)
            {
                menuPixelData.Text = "Pi&xel Data...";
                PixelForm = null;
            }
        }


        private void UpdatePixelDialog(int x, int y)
        {
            if (PixelForm != null && PixelForm.Visible)
            {
                Bitmap bmp = Manager.CurrentImage;
                PixelForm.Text = (Manager.Current == null
                    ? "Pixel Data" : Manager.Current.Caption);
                if (bmp == null || !pbxPhoto.DisplayRectangle.Contains(x, y))
                    PixelForm.ClearPixelData();
                else
                    PixelForm.UpdatePixelData(x, y, bmp,
                        pbxPhoto.DisplayRectangle,
                        new Rectangle(0, 0, bmp.Width, bmp.Height),
                        pbxPhoto.SizeMode);
            }
        }

        private void pbxPhoto_MouseMove(object sender, MouseEventArgs e)
        {
            UpdatePixelDialog(e.X, e.Y);
        }
   

    }
      

    
    }

