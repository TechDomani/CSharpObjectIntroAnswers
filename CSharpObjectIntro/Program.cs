using CSharpObjectIntro.Classes.BankAccount;
using CSharpObjectIntro.Classes.Diary;
using System.Diagnostics;

namespace CSharpObjectIntro
{
	internal class Program
	{
		static void Main()
		{
			UseDiary();
			UseBankAccount();
			Console.WriteLine("Press enter to exit the program");
			Console.ReadLine();
		}

		private static void UseDiary()
		{

			// Create a new diary 
			Diary book = new("Bob Smith");
			Console.WriteLine(book.Name);
			DateOnly eventDate = new(2022, 10, 10);

			// Add some events to your diary
			book.AddEvent(eventDate, 19, "Party", "Barnes", 60);
			book.AddEvent(eventDate, 10, "Hockey Training", "Barn Elms", 90);

			// Now check how many events you have on a particular day
			int numEvents = book.CheckDiary(eventDate);
			Console.WriteLine(numEvents);
			Debug.Assert(numEvents == 2);

			// Implement a new method in the Diary class to return the number of morning events on a particular day
			// Call this method
			int numMorningEvents = book.CheckMorningEvents(eventDate);
			Console.WriteLine(numMorningEvents);
			Debug.Assert(numMorningEvents == 1);
		}

		private static void UseBankAccount()
		{
			// Test basic set up
			DateTime openingDate = new(2022, 10, 01);
			var bankAccount = new BankAccount(openingDate);
			bankAccount.UpdateOverdraftLimit(500);
			Console.WriteLine(bankAccount);

			Debug.Assert(bankAccount.OpeningDate == openingDate);
			Debug.Assert(bankAccount.Balance == 0);
			Debug.Assert(bankAccount.OpeningBalance == 0);
			Debug.Assert(bankAccount.OverdraftLimit == 500);

			// Set up Dates
			DateTime day1 = openingDate.AddDays(1);
			DateTime day2 = openingDate.AddDays(2);
			DateTime day3 = openingDate.AddDays(3);
			DateTime day4 = openingDate.AddDays(4);

			// Test deposit and withdrawal
			bankAccount.Deposit(openingDate, 3000, TransactionCategory.Salary, TransactionType.BankTransfer, "CompanyX");
			Debug.Assert(bankAccount.Balance == 3000);

			bool withdrawal1 = bankAccount.Withdraw(day1, 2500, TransactionCategory.Rent, TransactionType.StandingOrder, "LandlordY");
			Debug.Assert(withdrawal1);
			Debug.Assert(bankAccount.Balance == 500);

			// Check overdraft limit
			bool withdrawal2 = bankAccount.Withdraw(day2, 600, TransactionCategory.Groceries, TransactionType.DebitCard, "Waitrose");
			Debug.Assert(withdrawal2);
			Debug.Assert(bankAccount.Balance == -100);

			bool withdrawal3 = bankAccount.Withdraw(day2, 500, TransactionCategory.Other, TransactionType.Cash, "Builder", "Fix drains");
			Debug.Assert(!withdrawal3);
			Debug.Assert(bankAccount.Balance == -100);

			Console.WriteLine(bankAccount);

			// Test methods
			bankAccount.Deposit(day3, 1500, TransactionCategory.Gift, TransactionType.Cheque, "Relatives");
			Debug.Assert(bankAccount.Balance == 1400);

			bool withdrawal4 = bankAccount.Withdraw(day4, 200, TransactionCategory.Groceries, TransactionType.DebitCard, "Waitrose");
			Debug.Assert(withdrawal4);
			Debug.Assert(bankAccount.Balance == 1200);

			bool withdrawal5 = bankAccount.Withdraw(day4, 12.53m, TransactionCategory.EatingOut, TransactionType.DebitCard, "Gails");
			Debug.Assert(withdrawal5);
			Debug.Assert(bankAccount.Balance == 1187.47m);

			decimal balanceAfterThreeDays = bankAccount.CheckBalance(day3);
			Console.WriteLine($"Balance on {day3:d} is {balanceAfterThreeDays:C}");
			Debug.Assert(balanceAfterThreeDays == 1400m);

			decimal spendingDay2ToPresent = bankAccount.CheckSpending(day2, DateTime.Today);
			Console.WriteLine($"Spending between {day2:d} and {DateTime.Today:d} is {spendingDay2ToPresent:C}");
			Debug.Assert(spendingDay2ToPresent == 812.53m);

			decimal groceryBill = bankAccount.CheckSpending(openingDate, DateTime.Today, TransactionCategory.Groceries);
			Console.WriteLine($"Grocery spending between {openingDate:d} and {DateTime.Today:d} is {groceryBill:C}");
			Debug.Assert(groceryBill == 800);

		}
	}
}