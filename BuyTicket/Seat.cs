using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyTicket
{
    public class Seat 
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public bool IsBusy { get; set; }
        private Boolean selectedSeansForSeat;
        public Boolean SelectedSeansForSeat
        {
            get { return selectedSeansForSeat; }
            set { selectedSeansForSeat = value; base.OnChanged(); }
        }

    }
}
