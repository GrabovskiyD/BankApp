using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.ViewModel
{
    public class LoginWindowVM
    {
		private string userName;

		public string UserName
		{
			get { return userName; }
			set { userName = value; }
		}
		private string password;

		public string Password
		{
			get { return password; }
			set { password = value; }
		}


	}
}
