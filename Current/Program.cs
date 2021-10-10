using System;
using System.Collections.Generic;
using System.IO;

using CAB201;

namespace UserInterfaceDemo {
	/// <summary>
	/// Demonstration program for UserInterface class.
	/// </summary>
	public class Program {
		static void Main( string[] args ) {
			MainMenu();
		}

		/// <summary>
		/// Displays a menu allowing user to choose an input operation to test.
		/// When user selects 4, program terminates.
		/// </summary>
		static void MainMenu() {
			Account matt = new Account("Matt");
			matt.printDetails();
			Console.WriteLine(matt.getDetails());
			Account ryan = new Account();
			ryan.printDetails();
			return;
			const int REGISTER = 0, LOGIN = 1, EXIT = 2;
			///const int READ_INT = 0, READ_DOUBLE = 1, READ_BOOL = 2, GET_PASSWORD = 3, EXIT = 4;
				
			Console.WriteLine( "Welcome to the UserInterface Demo program." );

			bool running = true;

			while ( running ) {
				int option = UserInterface.GetOption("Select one of the options",
					"Register", "Login", "Exit"
				);
				string fullName, username, password, address;
				switch ( option ) {
					case REGISTER: 
						 fullName = UserInterface.GetInput("Full name");
						 username = UserInterface.GetInput("Username");
						 password = UserInterface.GetPassword("Password");
						 address = UserInterface.GetInput("Address");
						break;
					case LOGIN:
						Console.WriteLine("Logged in");
						username = UserInterface.GetInput("Username");
						password = UserInterface.GetPassword("Password");
						break;
					case EXIT: 
						running = false; 
						break;
					default: break;
				}
			}
		}

		/// <summary>
		/// Demonstrates the GetInt function(s).
		/// </summary>
		private static void DemoGetInt() {
			int lowerBound = UserInterface.GetInt("Please enter an integer lower bound of an interval");
			int upperBound = UserInterface.GetInt("Please enter an integer upper bound of an interval");
			int between = UserInterface.GetInt(
				$"Please enter an integer between {lowerBound} and {upperBound}",
				lowerBound,
				upperBound
			);
			Console.WriteLine( $"The supplied value is {between}." );
		}

		/// <summary>
		/// Demonstrate the GetDouble function(s).
		/// </summary>
		private static void DemoGetDouble() {
			double lowerBound = UserInterface.GetDouble("Please enter a floating point lower bound of an interval");
			double upperBound = UserInterface.GetDouble("Please enter a floating point upper bound of an interval");
			double between = UserInterface.GetDouble(
				$"Please enter a floating point value between {lowerBound} and {upperBound}",
				lowerBound,
				upperBound
			);
			Console.WriteLine( $"The supplied value is {between}." );
		}

		/// <summary>
		/// Demonstrate the GetBool function(s).
		/// </summary>
		private static void DemoGetBool()
		{
			bool boolean = UserInterface.GetBool("Enter a Boolean");
			Console.WriteLine($"The supplied value is {boolean}.");
		}

		/// <summary>
		/// Demonstrate the GetPassword function.
		/// </summary>
		private static void DemoGetPassword() {
			string password = UserInterface.GetPassword("Please type a password");
			Console.WriteLine( $"The supplied value is {password}." );
		}
	}
}
