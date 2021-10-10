using System;

public class Account
{
	private string fullName, password, address, username;
	public Account()
	{
		Console.WriteLine("A new account has been made");
		fullName = "default name";
		password = "default password";
		address = "default address";
		username = "default username";
	}
	public Boolean setFullName(string fullName)
    {
		if (!String.IsNullOrEmpty(fullName)){
			this.fullName = fullName;
			return true;
		}
		return false;
    }
	public Boolean setPassword(string password)
	{
		if (!String.IsNullOrEmpty(password))
		{
			this.password = password;
			return true;
		}
		return false;
	}
	public Boolean setAddress(string address)
	{
		if (!String.IsNullOrEmpty(address))
		{
			this.address = address;
			return true;
		}
		return false;
	}
	public Boolean setUsername(string username)
	{
		if (!String.IsNullOrEmpty(username))
		{
			this.username = username;
			return true;
		}
		return false;
	}
	public void printDetails()
    {
		Console.WriteLine("-------------");
		Console.WriteLine(fullName);
		Console.WriteLine(username);
		Console.WriteLine(password);
		Console.WriteLine(address);
		Console.WriteLine("-------------");
	}
	public string getDetails()
    {
		return fullName;

    }
	public Boolean checkLogin(string username,string password)
    {
		return (this.username == username && this.password == password);
    }
	public string getFullname()
    {
		return fullName;
    }
}

