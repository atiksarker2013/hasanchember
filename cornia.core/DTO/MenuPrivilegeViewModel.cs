using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cornia.core.DTO
{
    public class MenuPrivilegeViewModel
    {
        public int PermissionRef { get; set; }
        public int UserTypeRef { get; set; }
        public Guid Userakey { get; set; }
        public int MenuAddId { get; set; }
        public int MenuDeleteId { get; set; }
        public string UserAkeyToken { get; set; }
    }
}
