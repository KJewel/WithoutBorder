using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WithoutBorder
{
    public partial class TBonus:IDataErrorInfo
    {
        public TBonus()
        {
            TContract = new HashSet<TContract>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public double PercentBonus { get; set; }

        public virtual ICollection<TContract> TContract { get; set; }

        [NotMapped]
        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "PercentBonus":
                        if ((PercentBonus < 0) || (PercentBonus > 100))
                        {
                            error = "Диапозон должен быть от 0 до 100";
                            PercentBonus = 0;
                        }
                        break;
                    case "Name":
                        //Обработка ошибок для свойства Name
                        break;
                    case "Description":
                        //Обработка ошибок для свойства Position
                        break;
                }
                return error;
            }
        }
        [NotMapped]
        public string Error
        {
            get { throw new NotImplementedException(); }
        }
    }
}
