using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace PhotoAlbum
{
    class photo
    {
        private string fileName;
        public string FileName
        {
        get {return this.fileName;}
        }
        private Bitmap bitmap;
        public Bitmap Image
        {
            get
            {
                if (bitmap == null)
                    bitmap = new Bitmap(fileName);
                return bitmap;
            }
        }
            private string caption = "";
        public string Caption
        {
            get { return caption; }
            set
            {
                if (caption  != value)
                {
                    caption = value;
                    HasChanged = true;
                }
            }
        }

        private string notes = "";
        public string Notes
        {
            get { return notes; }
            set
            {
                if (notes != value)
                {
                    notes = value;
                    HasChanged = true;
                }
            }
        }
        private string photographer = "";
        public string Photographer
        {
            get { return photographer; }
            set {
                if (photographer != value)
                {
                    photographer = value;
                    HasChanged = true;
                }    
                }
        }

        private bool hasChanged = true;
        public bool HasChanged
        {
            get { return hasChanged;}
            set { hasChanged = value;}
        }
    }
}
