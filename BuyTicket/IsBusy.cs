using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyTicket
{
    public class IsBusy
    {
        public bool IsEmpty { get; set; }

        public IsBusy(bool value)
        {
            IsEmpty = value;
        }
    }
}
