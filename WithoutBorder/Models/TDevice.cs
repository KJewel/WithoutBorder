using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace WithoutBorder
{
    public partial class TDevice
    {
        public TDevice()
        {
            TContract = new HashSet<TContract>();
        }

        public int Id { get; set; }
        public int IdManufacture { get; set; }
        public int IdTypeDevice { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public byte[] Image { get; set; }

        [NotMapped]
        public BitmapImage GetImage 
        {
            get
            {
                MemoryStream ms = new MemoryStream(Image);
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.StreamSource = ms;
                img.CacheOption = BitmapCacheOption.OnLoad;
                img.EndInit();

                return img;
            }
            set
            {
                ImageConverter convert = new ImageConverter();
                Image = (byte[])convert.ConvertTo(value, typeof(byte[]));
            } 
        }

        public virtual TManufacture IdManufactureNavigation { get; set; }
        public virtual TTypeDevice IdTypeDeviceNavigation { get; set; }
        [NotMapped]
        public virtual TManufacture IdManufactureNavigationBack{ get; set; }
        [NotMapped]
        public virtual TTypeDevice IdTypeDeviceNavigationBack { get; set; }
        public virtual TInfoDevice TInfoDevice { get; set; }
        public virtual ICollection<TContract> TContract { get; set; }

    }
}
