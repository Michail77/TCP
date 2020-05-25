using System;
using System.Collections.Generic;
using System.Text;

namespace Horak_MailKit.Services
{
    public interface IPrihlaseni
    {
        string Uzivatelske_Jmeno { get; set; }
        string Heslo { get; set; }
        void LoginToServer();
    }
}
