﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.IO;
namespace Manning.PhotoAlbum
{
    public class Photograph : IDisposable,IFormattable 
    {
        private string _fileName;
        private Bitmap bitmap;

        private string caption = "";
        private string photographer = "";
        private DateTime dateTaken = DateTime.Now;
        private string notes = "";
        private bool hasChanged = true;

        public Photograph(string fileName)
        {
            _fileName = fileName;
            bitmap = null;

            caption = System.IO.Path.
                GetFileNameWithoutExtension(fileName);
        }

        public string FileName
        {
            get { return _fileName; }
        }

        public Bitmap Image
        {
            get
            {
                if (bitmap == null)
                {
                    bitmap = new Bitmap(_fileName);
                }
                return bitmap;
            }
        }

        public bool HasChanged
        {
            get { return hasChanged; }
            internal set { hasChanged = value; }
        }

        public string Caption
        {
            get { return caption; }
            set
            {
                if (caption != value)
                {
                    caption = value;
                    HasChanged = true;
                }
            }
        }

        public string Photographer
        {
            get { return photographer; }
            set
            {
                if (photographer != value)
                {
                    photographer = value;
                    HasChanged = true;
                }
            }
        }

        public DateTime DateTaken
        {
            get { return dateTaken; }
            set
            {
                if (dateTaken != value)
                {
                    dateTaken = value;
                    HasChanged = true;
                }
            }
        }

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

    
        public override bool Equals(object obj)
        {
            if (obj is Photograph)
            {
                Photograph p = (Photograph)obj;
                return (FileName.Equals(p.FileName,
                StringComparison.
                InvariantCultureIgnoreCase));
            }

            return false;
        }

        public override int GetHashCode()
        {
            return FileName.ToLowerInvariant().GetHashCode();
        }

        public override string ToString()
        {
            return FileName;
        }

     
        public void ReleaseImage()
        {
            if (bitmap != null)
            {
                bitmap.Dispose();
                bitmap = null;
            }
        }

        public void Dispose()
        {
            ReleaseImage();
        }
        public string ToString(string format, IFormatProvider fp)
        {
            if (String.IsNullOrEmpty(format))
                format = "f";

            char first = format.ToLower()[0];
            if (format.Length == 1)
            {
                switch (first)
                {
                    case 'c': return Caption;
                    case 'd': return DateTaken.ToShortDateString();
                    case 'f': return FileName;
                }
            }

            else
            {
                string theRest = format.Substring(1);
                if (first == 'd')
                    return DateTaken.ToString(theRest, fp);
                else if (first == 'f')
                {
                    if (theRest == "b")
                        return Path.GetFileName(FileName);
                    else if (theRest == "B")
                        return Path.GetFileNameWithoutExtension(FileName);
                }

            }

            throw new FormatException();
        }

        public string ToString(string format)
        {
            return ToString(format, null);
        }

        public string ToString(IFormatProvider fp)
        {
            return ToString(null, fp);
        }
    }
}
