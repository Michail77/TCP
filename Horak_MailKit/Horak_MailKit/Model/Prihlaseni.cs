using Horak_MailKit.Services;
using Postal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Horak_MailKit.Model
{
    class Prihlaseni : IPrihlaseni
    {
        private readonly IEmail _email;

        public string Uzivatelske_Jmeno { get; set; }
        public string Heslo { get; set; }

        /// <summary>
        /// Login page logic
        /// </summary>
        public LoginPageManager(IEmail email)
        {
            _email = email;
        }

        public void LoginToServer()
        {
            _email.EstablishIMAPConnection(Uzivatelske_Jmeno, Heslo);
        }
    }
}
