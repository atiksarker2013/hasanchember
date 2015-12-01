//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace cornia.core.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.UserPermission = new HashSet<UserPermission>();
        }
    
        public int Id { get; set; }
        public System.Guid gKey { get; set; }
        public System.Guid aKey { get; set; }
        public int UserTypeRef { get; set; }
        public Nullable<int> GroupCompanyRef { get; set; }
        public Nullable<int> CustomerRef { get; set; }
        public Nullable<int> FactoryRef { get; set; }
        public Nullable<int> PersonRef { get; set; }
        public Nullable<int> EmployeeRef { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public string PIN { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool ChangePasswordAtNextLogon { get; set; }
        public bool MailNotification { get; set; }
        public string Note { get; set; }
        public int Sort { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
    
        public virtual UserType UserType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserPermission> UserPermission { get; set; }
    }
}