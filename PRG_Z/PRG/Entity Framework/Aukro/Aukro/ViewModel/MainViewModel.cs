using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Timers;
using Aukro.Models;
using Microsoft.EntityFrameworkCore;

namespace Aukro.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        private AukroContext db;
        private Timer aTimer;
        private void timer_Tick(object sender, EventArgs e)
        {
            Time = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            ChangeProperty("MaxTime");
            ChangeProperty("MinTime");

        }
        public MainViewModel()
        {
            db = new AukroContext();
            
            Selection = 1;
            AuctionEndTime = DateTime.Now.AddDays(1);
            aTimer = new Timer(1000);
            aTimer.Elapsed += timer_Tick;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            Login = new Command(LoginCommandExecute);
            Register = new Command(RegisterCommandExecute);
            Logout = new Command(LogoutCommandExecute);
            AddAuction = new Command(AddAuctionExecute);
            AuctionBet = new ParametrizedCommand(AuctionBetExecute);
        }
        public Command Login { get; set; }
        public Command Register { get; set; }
        public Command Logout { get; set; }
        public Command AddAuction { get; set; }
        public ParametrizedCommand AuctionBet { get; set; }

        private int _Time;
        private string _Name;
        private string _LogName;
        private string _LogPassword;
        private string _RegName;
        private string _RegPassword;
        private string _AuctionName;
        private string _AuctionDescription;
        private int _AuctionPrice;
        private int _AuctionBuyNowPrice;
        private DateTime _AuctionEndTime;
        private int _UserId;
        private int _Selection;
        private int _Money;
        public int Money
        {
            get { return _Money; }
            set { _Money = value; ChangeProperty("Money"); }
        }
        public DateTime MaxTime
        {
            get { return DateTime.Now.AddSeconds(864000); }
        }
        public DateTime MinTime
        {
            get { return DateTime.Now.AddSeconds(36000); }
        }
        public int Selection
        {
            get { return _Selection; }
            set { _Selection = value; ChangeProperty("Selection"); ChangeProperty("Auctions"); }
        }
        public Visibility Visibility
        {
            get { return IsLogged ? Visibility.Visible : Visibility.Collapsed; }
        }
        public bool Selected
        {
            get { return !IsLogged; }
        }
        private int UserId
        {
            get { return _UserId; }
            set { _UserId = value; ChangeProperty("UserId"); }
        }
        public string AuctionName
        {
            get { return _AuctionName; }
            set { _AuctionName = value; ChangeProperty("AuctionName"); }
        }
        public string AuctionDescription
        {
            get { return _AuctionDescription; }
            set { _AuctionDescription = value; ChangeProperty("AuctionDescription"); }
        }
        public int AuctionPrice
        {
            get { return _AuctionPrice; }
            set { _AuctionPrice = value; ChangeProperty("AuctionPrice"); }
        }
        public int AuctionBuyNowPrice
        {
            get { return _AuctionBuyNowPrice; }
            set { _AuctionBuyNowPrice = value; ChangeProperty("AuctionBuyNowPrice"); }
        }
        public DateTime AuctionEndTime
        {
            get { return _AuctionEndTime; }
            set { _AuctionEndTime = value; ChangeProperty("AuctionEndTime"); }
        }
        public List<Auctions> Auctions
        {
            get
            {
                switch(Selection)
                {
                    case 1:
                        return db.Auctions.ToList();
                    case 2:
                        return db.Auctions.Where(auction => auction.SellerUserId == UserId).ToList();
                    case 3:
                        return db.Auctions.Where(auction => auction.WinnerUserId == UserId && auction.IsEnd == false).ToList();
                    case 4:
                        return db.Auctions.Where(auction => auction.WinnerUserId == UserId && auction.IsEnd == true).ToList();
                    default:
                        return db.Auctions.ToList();
                }
            }
        }
        public List<Users> Users
        {
            get { return db.Users.ToList(); }
        }

        public int Time
        {
            get { return _Time; }
            set { _Time = value; ChangeProperty("Time"); }
        }
        public string Name
        {
           get { return _Name; }
           set { _Name = value; ChangeProperty("Name"); ChangeProperty("IsLogged"); ChangeProperty("Visibility"); ChangeProperty("Selected"); }
        }

        public string LogName
        {
            get { return _LogName; }
            set { _LogName = value; ChangeProperty("LogName"); }
        }
        public string LogPassword
        {
            get { return _LogPassword; }
            set { _LogPassword = value; ChangeProperty("LogPassword"); }
        }
        public string RegName
        {
            get { return _RegName; }
            set { _RegName = value; ChangeProperty("RegName"); }
        }
        public string RegPassword
        {
            get { return _RegPassword; }
            set { _RegPassword = value; ChangeProperty("RegPassword"); }
        }
        public bool IsLogged
        {
            get { return !string.IsNullOrEmpty(Name); }
        }

        private void LoginCommandExecute()
        {
            Users user = db.Users.Where(us => us.Username == LogName && us.Password == LogPassword).FirstOrDefault();
            if (user != null)
            {
                UserId = user.UserId;
                Name = LogName;
                MessageBox.Show("Přihlášení úspěšné", "Úspěch", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Špatné přihlašovací údaje", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void RegisterCommandExecute()
        {
            string errors = "";
            if (RegName == null)
                errors += "Zadejte jméno";
            if (RegPassword == null)
                errors += "Zadejte heslo";
            if (db.Users.Where(user => user.Username == RegName).FirstOrDefault() != null)
                errors += "Zadané jméno již existuje";
            if (errors == "")
            {
                db.Users.Add(new Users { Username = RegName, Password = RegPassword });
                db.SaveChanges();
                ChangeProperty("Users");
                MessageBox.Show("Registrace úspěšná", "Úspěch", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show(errors, "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);

        }
        private void LogoutCommandExecute()
        {
            Name = "";
        }
        private void AddAuctionExecute()
        {
            string errors = "";
            if (AuctionName == null)
                errors += "Zadejte jméno ";
            if (db.Auctions.Where(auction => auction.Name == AuctionName).FirstOrDefault() != null)
                errors += "Zadané jméno již existuje ";
            if (AuctionDescription == null)
                errors += "Zadejte popis ";
            if (AuctionPrice <= 0)
                errors += "Zadejte cenu ";
            if (((DateTimeOffset)AuctionEndTime).ToUnixTimeSeconds() <= 0)
                errors += "Zadejte čas ";
            if (AuctionBuyNowPrice < 0)
                errors += "Zadejte cenu kup teď ";
            if (errors == "")
            {
                db.Auctions.Add(new Auctions { CurrentPrice = AuctionPrice, Description = AuctionDescription, Name = AuctionName, EndTime = (int)((DateTimeOffset)AuctionEndTime).ToUnixTimeSeconds(), IsEnd = false, SellerUserId = UserId, BuyNowPrice = AuctionBuyNowPrice });
                db.SaveChanges();
                ChangeProperty("Auctions");
                MessageBox.Show("Přidání úspěšné", "Úspěch", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show(errors, "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);


        }
        private void AuctionBetExecute(object parameter)
        {
            if (IsLogged)
            {
                Auctions auction = db.Auctions.Where(auc => auc.AuctionId == int.Parse(parameter.ToString())).FirstOrDefault();
                if (auction.SellerUserId == UserId) { }
                else if (auction.EndTime <= Time)
                    auction.IsEnd = true;
                else if (auction.BuyNowPrice != 0 && Money >= auction.BuyNowPrice)
                {
                    auction.CurrentPrice = (int)auction.BuyNowPrice;
                    auction.WinnerUserId = UserId;
                    auction.IsEnd = true;
                }
                else if (auction.CurrentPrice < Money)
                {
                    auction.CurrentPrice = Money;
                    auction.WinnerUserId = UserId;
                }
                else
                    MessageBox.Show("Chyba");
                db.SaveChanges();
                ChangeProperty("Auctions");
            }
        }
        private void ChangeProperty(string nazevVlastnosti)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(nazevVlastnosti));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
