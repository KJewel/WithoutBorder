using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Windows.Media.Imaging;

namespace WithoutBorder
{
    public partial class TUsers
    {
        public TUsers()
        {
            TContractIdOperatorNavigation = new HashSet<TContract>();
            TContractIdUserNavigation = new HashSet<TContract>();
        }

        [Column("idUser"), Key]
        public int IdUser { get; set; }
        [Required]
        public int IdRole { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Middlename { get; set; }
        [Required]
        public int PassportSeria { get; set; }
        [Required]
        public int PassportNumber { get; set; }
        [Required]
        public byte[] Photo { get; set; }

        public virtual TRole IdRoleNavigation { get; set; }
        [NotMapped]
        public virtual TRole IdRoleNavigationLog { get; set; }
        [NotMapped]
        public string GetRole 
        { 
            get
            {
                if (IdRoleNavigationLog == null)
                {
                    if (IdRoleNavigation != null)
                    {
                        return IdRoleNavigation.Title;
                    }
                    else return "NULL";
                }
                else return IdRoleNavigationLog.Title;
            }
        }
        [NotMapped]
        public int GetRoleId
        {
            get
            {
                if (IdRoleNavigationLog == null)
                {
                    if (IdRoleNavigation != null)
                    {
                        return IdRoleNavigation.Id;
                    }
                    else return 1;
                }
                else return IdRoleNavigationLog.Id;
            }
            set
            {
                IdRoleNavigationLog = new TRole();
                IdRoleNavigationLog.Id = value;
            }
        }
        public virtual TSpec TSpec { get; set; }
        public virtual ICollection<TContract> TContractIdOperatorNavigation { get; set; }
        public virtual ICollection<TContract> TContractIdUserNavigation { get; set; }

        [NotMapped]
        public string Passport
        {
            get
            {
                return PassportSeria.ToString() + " " + PassportNumber.ToString();
            }
        }

        [NotMapped]
        public BitmapImage GetImage
        {
            get
            {
                MemoryStream ms = new MemoryStream(Photo);

                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = ms;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.EndInit();

                return image;
            }
        }

        [NotMapped]
        public string GetFIO
        {
            get
            {
                return Surname + " " + Name +  " " + Middlename;
            }
        }

        public void ConvertPathToImage(string path)
        {
            Photo = File.ReadAllBytes(path);
        }

    }
}
