using BuyTicket.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyTicket
{
    public class Seat : NotifyableObject
    {
        public int Row { get; set; }
        public int Col { get; set; }

        private IsBusy isEmpty;
        public IsBusy IsEmpty
        {
            get => isEmpty;
            set
            {
                isEmpty = value;
                base.OnChanged();
            }
        }
    }
}
