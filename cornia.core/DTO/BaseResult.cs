using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cornia.core.DTO
{
    public class BaseResult
    {
        public string ResponseMessage { get; set; }
        public string ResultConstant { get; set; }
        public int ResultValue { get; set; }
    }
}
