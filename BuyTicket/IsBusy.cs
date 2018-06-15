using BuyTicket.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyTicket
{
    public class IsBusy : NotifyableObject
    {
        private bool isEmpty;
        public bool IsEmpty
        {
            get => isEmpty;
            set
            {
                isEmpty = value;
                base.OnChanged();
            }
        }

        public IsBusy(bool value)
        {
            IsEmpty = value;
        }
    }
}
