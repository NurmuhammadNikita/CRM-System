using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.Application.UseCases
{
    public class Token
    {
        public string RefundableToken { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
