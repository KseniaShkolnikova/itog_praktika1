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
    
    public partial class Autorization_Employees
    {
        public int ID_Autorization { get; set; }
        public string Logini { get; set; }
        public string Porol { get; set; }
        public int Employee_ID { get; set; }
    
        public virtual Employees Employees { get; set; }
    }
}
