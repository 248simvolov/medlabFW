//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace medlabafw.DB_
{
    using System;
    using System.Collections.Generic;
    
    public partial class ТипАнализа
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ТипАнализа()
        {
            this.Анализ = new HashSet<Анализ>();
            this.ПараметрыАнализов = new HashSet<ПараметрыАнализов>();
        }
    
        public int КодТипа { get; set; }
        public string Название { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Анализ> Анализ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ПараметрыАнализов> ПараметрыАнализов { get; set; }
    }
}
