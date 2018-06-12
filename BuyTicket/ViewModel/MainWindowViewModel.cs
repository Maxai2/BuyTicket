using BuyTicket.Common;
using BuyTicket.Interfaces;
using Musarium.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
//----------------------------------------------------------------------------------
namespace BuyTicket.ViewModel
{
    public class MainWindowViewModel : NotifyableObject, ITicketBuyViewModel
    {
        public ObservableCollection<Film> Films { get; private set; }
        public ObservableCollection<Type> Types { get; private set; }
        public ObservableCollection<Sean> Seans { get; private set; }
        public ObservableCollection<Sean> SeansForGrid { get; private set; }
        public ObservableCollection<Hall> Halls { get; private set; }
        public ObservableCollection<Seat> Seats { get; private set; }

        public List<Ticket> Tickets { get; set; }

        public ITicketBuyView View { get; private set; }

        private string email;
        public string Email { get => email; set { email = value; base.OnChanged(); } }

        private ObservableCollection<Seat> selectedSeats;
        public ObservableCollection<Seat> SelectedSeats { get => selectedSeats; set { selectedSeats = value; base.OnChanged(); } }

        //----------------------------------------------------------------------------------

        public MainWindowViewModel(ITicketBuyView view)
        {
            this.SelectedSeats = new ObservableCollection<Seat>();
            this.FillData();
            this.SelectedSeans = new Sean();
            this.SelectedFilm = new Film();
            this.SelectedDate = DateTime.Today;
            this.View = view;
            this.View.BindDataContext(this);
        }

        //----------------------------------------------------------------------------------

        private void FillData()
        {
            var db = new FilmTicketEntities();

            SeansForGrid = new ObservableCollection<Sean>();
            Seats = new ObservableCollection<Seat>();

            Films = new ObservableCollection<Film>();

            foreach (Film item in db.Films)
            {
                Films.Add(item);
            }

            Seans = new ObservableCollection<Sean>();

            foreach (Sean item in db.Seans)
            {
                Seans.Add(item);
            }


            Types = new ObservableCollection<Type>();

            foreach (var item in db.Types)
            {
                Types.Add(item);
            }


            Halls = new ObservableCollection<Hall>();

            foreach (var item in db.Halls)
            {
                Halls.Add(item);
            }


            Tickets = new List<Ticket>();

            foreach (var item in db.Tickets)
            {
                Tickets.Add(item);
            }
        }

        //----------------------------------------------------------------------------------

        private DateTime selectedDate;
        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set
            {
                selectedDate = value;
                base.OnChanged();
                this.SeansForGrid.Clear();

                if (SelectedFilm.Film_Name != null && SelectedType != null)
                {
                    foreach (var item in Seans)
                    {
                        if (item.Seans_Data == SelectedDate)
                        {
                            if (item.Film.Id == SelectedFilm.Id && item.Type_Id == SelectedType.Id)
                            {
                                SeansForGrid.Add(item);
                            }
                        }
                    }
                }
                else if (SelectedType == null && SelectedFilm.Film_Name != null)
                {
                    foreach (var item in Seans)
                    {
                        if (item.Film_Id == SelectedFilm.Id && item.Seans_Data == SelectedDate)
                        {
                            SeansForGrid.Add(item);
                        }
                    }
                }
                else if (SelectedDate != null && SelectedType != null)
                {
                    foreach (var item in Seans)
                    {
                        if(item.Seans_Data == SelectedDate && item.Type_Id == SelectedType.Id)
                        {
                            SeansForGrid.Add(item);
                        }
                    }
                }
                else if (SelectedType != null && SelectedFilm.Film_Name == null)
                {
                    foreach (var item in Seans)
                    {
                        if (item.Type_Id == SelectedType.Id)
                        {
                            SeansForGrid.Add(item);
                        }
                    }
                }
                else if (SelectedDate != null && SelectedType == null && SelectedFilm.Film_Name == null)
                {
                    foreach (var item in Seans)
                    {
                        if (item.Seans_Data == SelectedDate)
                        {
                            SeansForGrid.Add(item);
                        }
                    }
                }
            }
        }

        //----------------------------------------------------------------------------------

        private Film film;
        public Film SelectedFilm
        {
            get { return film; }
            set
            {
                film = value;
                base.OnChanged();
                SeansForGrid.Clear();

                if (SelectedFilm != null && SelectedType != null)
                {
                    foreach (var item in Seans)
                    {
                        if (item.Seans_Data == SelectedDate)
                        {
                            if (item.Film_Id == SelectedFilm.Id && item.Type_Id == SelectedType.Id)
                            {
                                SeansForGrid.Add(item);
                            }
                        }
                    }
                }
                else 
                if (SelectedType == null && SelectedFilm != null)
                {
                    foreach (var item in Seans)
                    {
                        if (item.Film_Id == SelectedFilm.Id && item.Seans_Data == SelectedDate)
                        {
                            SeansForGrid.Add(item);
                        }
                    }
                }
                else 
                if (SelectedType != null && SelectedFilm == null)
                {
                    foreach (var item in Seans)
                    {
                        if (item.Type_Id == SelectedType.Id && item.Seans_Data == SelectedDate)
                        {
                            SeansForGrid.Add(item);
                        }
                    }
                }
                else 
                if (SelectedDate != null && SelectedType == null && SelectedFilm == null)
                {
                    foreach (var item in Seans)
                    {
                        if (item.Seans_Data == SelectedDate)
                        {
                            SeansForGrid.Add(item);
                        }
                    }
                }
            }
        }

        //----------------------------------------------------------------------------------

        private Type seletedType;
        public Type SelectedType
        {
            get { return seletedType; }
            set
            {
                seletedType = value;
                base.OnChanged();
                SeansForGrid.Clear();

                if (SelectedFilm != null && SelectedType != null)
                {
                    foreach (var item in Seans)
                    {
                        if (item.Seans_Data == SelectedDate)
                        {
                            if (item.Film_Id == SelectedFilm.Id && item.Type_Id == SelectedType.Id)
                            {
                                SeansForGrid.Add(item);
                            }
                        }
                    }
                }
                else
                if (SelectedType == null && SelectedFilm != null)
                {
                    foreach (var item in Seans)
                    {
                        if (item.Film_Id == SelectedFilm.Id && item.Seans_Data == SelectedDate)
                        {
                            SeansForGrid.Add(item);
                        }
                    }
                }
                else
                if (SelectedType != null && SelectedFilm == null)
                {
                    foreach (var item in Seans)
                    {
                        if (item.Type_Id == SelectedType.Id && item.Seans_Data == SelectedDate)
                        {
                            SeansForGrid.Add(item);
                        }
                    }
                }
                else
                if (SelectedDate != null && SelectedType == null && SelectedFilm == null)
                {
                    foreach (var item in Seans)
                    {
                        if (item.Seans_Data == SelectedDate)
                        {
                            SeansForGrid.Add(item);
                        }
                    }
                }
            }
        }

        //----------------------------------------------------------------------------------

        private Sean sean;
        public Sean SelectedSeans
        {   
            get => sean;
            set
            {
                sean = value;
                base.OnChanged();
                Seats.Clear();

                var seansTickets = new List<Ticket>();
                seansTickets.Clear();

                if (SelectedSeans != null)
                {
                    foreach (var item in Tickets)
                    {
                        if (item.Seans_Id == SelectedSeans.Id)
                        {
                            seansTickets.Add(item);
                        }
                    }

                    if (SelectedSeans.Hall != null)
                    {
                        var current = Halls.First(h => h.Id == SelectedSeans.Hall_Id);

                        for (int i = 0; i < current.SeatRowCount; i++)
                        {
                            for (int j = 0; j < current.SeatColCount; j++)
                            {
                                Seat seat = new Seat
                                {
                                    Row = i,
                                    Col = j
                                };

                                seat.IsEmpty = new IsBusy(false);

                                foreach (var item in seansTickets)
                                {
                                    if (item.Seat_Col == seat.Col && item.Seat_Row == seat.Row)
                                    {
                                        seat.IsEmpty = new IsBusy(true);
                                        break;
                                    }
                                }

                                Seats.Add(seat);
                            }
                        }
                    }
                }
            }
        }

        //----------------------------------------------------------------------------------

        private ICommand reservation;
        public ICommand Reservation
        {
            get
            {
                if (this.reservation is null)
                {
                    this.reservation = new RelayCommand(
                        (param) => 
                        {
                            using (FilmTicketEntities context = new FilmTicketEntities())
                            {
                                try
                                {
                                    foreach (Seat seat in SelectedSeats)
                                    {
                                        var ticket = new Ticket
                                        {
                                            Email = this.Email,
                                            Seat_Col = seat.Col,
                                            Seat_Row = seat.Row,
                                            Seans_Id = SelectedSeans.Id,
                                            Ticket_DateTime = DateTime.Now
                                        };
                                        context.Tickets.Add(ticket);
                                        context.SaveChanges();
                                    }
                                    this.View.ShowAlert("Successfully reserved!", "INFO");
                                }
                                catch (Exception)
                                {
                                    this.View.ShowAlert("Is this seat taken!", "Error");
                                }

                            }
                        },
                        (param) => 
                        {
                            return this.CheckReserve();
                        }
                    );
                }
                return this.reservation;
            }
        }

        //----------------------------------------------------------------------------------

        private bool CheckReserve()
        {
            if (this.SelectedSeats.Count > 0 && this.Email.Length > 0 && (this.Email.Contains("@gmail.com") || this.Email.Contains("@mail.ru") || this.Email.Contains("@yandex.ru")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
//----------------------------------------------------------------------------------