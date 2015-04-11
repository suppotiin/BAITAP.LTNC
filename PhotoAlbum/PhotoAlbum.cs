using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace PhotoAlbum
{
    class PhotoAlbum : Collection<photo>, IDisposable
    {
        private bool hasChanged = false;
        public bool HasChanged
        {
            get
            {
                if (hasChanged) return true;
                foreach (photo p in this)
                    if (p.HasChanged) return true;
                return false;
            }
            set
            {
                hasChanged = value;
                if (value == false)
                    foreach (photo p in this)
                        p.HasChanged = false;
            }
        }
        public void Dispose()
        {
            foreach (photo p in this)
                p.Dispose();
        }
        protected override void ClearItems()
        {
            if (Count > 0)
            {
                Dispose();
                base.ClearItems();
                HasChanged = true;
            }
        }


        protected override void InsertItem(int index, photo item)
        {
            base.InsertItem(index, item);
            HasChanged = true;
        }
        protected override void RemoveItem(int index)
        {
            Items[index].Dispose();
            base.RemoveItem(index);
            HasChanged = true;
        }
        protected override void SetItem(int index, photo item)
        {
            base.SetItem(index, item);
            HasChanged = true;
        }
    }
}