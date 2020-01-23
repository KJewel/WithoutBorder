using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WithoutBorder
{
    public partial class TContract
    {
        [Column("id"), Key]
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int? IdDevice { get; set; }
        public int? IdBonus { get; set; }
        public int? IdOperator { get; set; }
        public DateTime ConlusionDate { get; set; }
        public double Price { get; set; }
        public int? IdTarif { get; set; }

        public virtual TBonus IdBonusNavigation { get; set; }
        public virtual TDevice IdDeviceNavigation { get; set; }
        public virtual TUsers IdOperatorNavigation { get; set; }
        public virtual TTarif IdTarifNavigation { get; set; }
        public virtual TUsers IdUserNavigation { get; set; }

        [NotMapped]
        public string GetTypeService
        {
            get
            {
                string text;

                if(IdDeviceNavigation != null)
                {
                    if(IdTarifNavigation != null)
                    {
                        text = "Всё вместе";
                    }
                    else
                    {
                        text = "Покупка телефона";
                    }
                }
                else
                {
                    text = "Подключение тарифа";
                }

                return text;
            }
        }

    }
}
