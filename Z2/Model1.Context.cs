﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class libraryEntities : DbContext
    {
        public libraryEntities()
            : base("name=libraryEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book_Type> Book_Type { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Instance_Release> Instance_Release { get; set; }
        public virtual DbSet<Publishing_Houses> Publishing_Houses { get; set; }
        public virtual DbSet<Reader> Readers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
