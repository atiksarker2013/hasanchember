using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cornia.core.DTO
{
    public class ProfileResult : BaseResult
    {
        public FocusConstants.FocusResultCode ResponseCode { get; set; }
    }
}
