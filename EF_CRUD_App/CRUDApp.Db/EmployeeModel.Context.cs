﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRUDApp.Db
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class EmployeeDbEntities : DbContext
    {
        public EmployeeDbEntities()
            : base("name=EmployeeDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Employee> Employees { get; set; }
    
        public virtual ObjectResult<usp_getEmp_Result> usp_getEmp()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_getEmp_Result>("usp_getEmp");
        }
    
        public virtual ObjectResult<Nullable<int>> usp_GetEmpWithOutput(ObjectParameter totalCount)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("usp_GetEmpWithOutput", totalCount);
        }
    }
}
