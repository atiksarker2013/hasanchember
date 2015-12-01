using System.Collections.Generic;

namespace cornia.core.DTO
{
    public class MenuViewModel
    {
        public MenuPrivilegeViewModel MenuPrivilegeModel { get; set; }
        public List<MenuPrivilegeViewModel> MenuPrivilegeModelList { get; set; }
    }
}
