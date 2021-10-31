using System;

public class Account
{
	/// <summary>
	///  
	
	private string username;
	
	public string Username
	{
		set { username = value; }
		get { return username; }
	}
	private string fullname;
	public string Fullname
    {
        set { fullname = value; }
		get { return fullname; }
    }
    private string password;
	public string Password
    {
		set { password = value; }
        private get { return password;  }
    }
	private string address;
	public string Address
    {
		set { address = value;  }
		private get { return address;  }
    }

	/// <summary>
	/// Default constructer that makes a blank template account.
	/// </summary>
	public Account()
	{
		Console.WriteLine("A new account has been made");
		Fullname = "default name";
		password = "default password";
		address = "default address";
		username = "default username";
	}
	/// <summary>
	/// Makes an account with username and password.
	/// </summary>
	/// <param name="username">Is the unique username for the user.</param>
	/// <param name="password">Is the unique password for the user.</param>
	public Account(string username, string password)
	{
		Console.WriteLine("A new account has been made");
		fullname = "default name";
		this.password = password;
		address = "default ";
		this.username = username;
	}


	/// <summary>
	/// Prints all the details of the account
	/// </summary>
	public void printDetails()
    {
		Console.WriteLine("-------------");
		Console.WriteLine(Fullname);
		Console.WriteLine(username);
		Console.WriteLine(password);
		Console.WriteLine(address);
		Console.WriteLine("-------------");
	}

	/// <summary>
	///Gets the credentials against an account and returns true or false
	/// </summary>
	/// <param name="username">This is the username to check the user account.</param>
	/// <param name="password">This is the password to check the user account.</param>
	/// <returns>Returns true or false based on if the credentials match</returns>	
	public Boolean checkLogin(string username,string password)
    {
		return (this.username == username && this.password == password);
    }
	
}

