using System;

public class Account
{

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

    public Account()
	{
		Console.WriteLine("A new account has been made");
		Fullname = "default name";
		password = "default password";
		address = "default address";
		username = "default username";
	}
	public Account(string username, string password)
	{
		Console.WriteLine("A new account has been made");
		fullname = "default name";
		this.password = password;
		address = "default ";
		this.username = username;
	}

	
	
	public void printDetails()
    {
		Console.WriteLine("-------------");
		Console.WriteLine(Fullname);
		Console.WriteLine(username);
		Console.WriteLine(password);
		Console.WriteLine(address);
		Console.WriteLine("-------------");
	}

	public Boolean checkLogin(string username,string password)
    {
		return (this.username == username && this.password == password);
    }
	
}

