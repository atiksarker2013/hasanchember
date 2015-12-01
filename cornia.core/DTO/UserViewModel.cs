using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cornia.core.DTO
{
    public class UserViewModel  
    {
        public int Id { get; set; }
        public Guid gKey { get; set; }
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
        public string SecurityToken { get; set; }
        public string UserTypeName { get; set; }
        public string EmployeeName { get; set; }
        public string GroupCompanyName { get; set; }
        public string CustomerName { get; set; }
        public string FactoryName { get; set; }

        public string PersonName { get; set; }
        public int MenuEditId { get; set; }

        public int UserRefId { get; set; }

        public Guid aKey { get; set; }
        public Guid Userakey { get; set; }
        public int MenuAddId { get; set; }
        public int MenuDeleteId { get; set; }
        public string UserAkeyToken { get; set; }
        public bool isLocked { get; set; }
    }
}
