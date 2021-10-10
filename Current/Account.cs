using System;

public class Account
{
	private string fullName;
	public Account()
	{
		Console.WriteLine("A new account has been made");
		fullName = "default name";
	}
	public Account(string fullName)
    {
		this.fullName = fullName;
    }
	public Boolean setFullName(string fullName)
    {
		if (!String.IsNullOrEmpty(fullName)){
			this.fullName = fullName;
			return true;
		}
		return false;
    }
	public void printDetails()
    {
		Console.WriteLine(fullName);
    }
	public string getDetails()
    {
		return fullName;
    }
}
