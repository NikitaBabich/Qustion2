//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Z2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Instance_Release
    {
        public int Id_Release { get; set; }
        public Nullable<int> Id_Reader { get; set; }
        public Nullable<int> Id_Book { get; set; }
        public Nullable<System.DateTime> Date_Of_Issue { get; set; }
        public Nullable<System.DateTime> Return_Date { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual Reader Reader { get; set; }
    }
}
