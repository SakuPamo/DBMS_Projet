//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBMSProjet.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public Employee()
        {
            this.Projects = new HashSet<Project>();
            this.Projects1 = new HashSet<Project>();
            this.WorkerAllocations = new HashSet<WorkerAllocation>();
        }
    
        public string EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string WorkCategory { get; set; }
        public string JobTitle { get; set; }
    
        public virtual JobRate JobRate { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Project> Projects1 { get; set; }
        public virtual ICollection<WorkerAllocation> WorkerAllocations { get; set; }
    }
}