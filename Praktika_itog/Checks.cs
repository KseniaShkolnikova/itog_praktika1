//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Praktika_itog
{
    using System;
    using System.Collections.Generic;
    
    public partial class Checks
    {
        public int ID_Check { get; set; }
        public int Good_ID { get; set; }
        public int Order_ID { get; set; }
        public int Employee_ID { get; set; }
        public string Date_Of_Payment { get; set; }
        public decimal Summ { get; set; }
    
        public virtual Employees Employees { get; set; }
        public virtual Goods Goods { get; set; }
        public virtual Orders Orders { get; set; }
    }
}