using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpObjectIntro.Classes.BankAccount
{
	public class BankAccount
	{
		// Fields
		private const int MaxLimit = 1000;
		private readonly List<Transaction> _transactions = new();

		// Properties
		public decimal Balance { get; private set; }
		public decimal OpeningBalance { get; private set; }
		public DateTime OpeningDate { get; private set; }
		public int OverdraftLimit { get; private set; }

		// Constructors
		public BankAccount(DateTime date, decimal openingBalance = 0)
		{
			OpeningBalance = openingBalance;
			Balance = openingBalance;
			OpeningDate = date;
		}

		public BankAccount()
		{
			Balance = 0;
			OpeningBalance = 0;
			OpeningDate = DateTime.Today;
		}

		// Private Methods
		private bool DecrementBalance(decimal amount)
		{
			bool updated = false;
			decimal newBalance = Balance - amount;
			if (newBalance > OverdraftLimit * -1)
			{
				Balance = newBalance;
				updated = true;
			}
			return updated;
		}

		// Public Methods
		public bool UpdateOverdraftLimit(int limit)
		{
			bool updated = false;
			limit = Math.Abs(limit);
			if ((limit < MaxLimit) && (Balance >= 0))
			{
				OverdraftLimit = limit;
				updated = true;
			}
			return updated;
		}

		public bool Withdraw(DateTime date, decimal amount, TransactionCategory category, TransactionType type, string counterParty, string description = "")
		{
			bool succeeded = false;
			if (DecrementBalance(amount))
			{
				var transaction = new Transaction(date, amount * -1, category, type, counterParty, description);
				_transactions.Add(transaction);
				succeeded = true;
			}
			return succeeded;
		}

		public bool Withdraw(decimal amount, TransactionCategory category, TransactionType type, string counterParty, string description = "")
		{
			return Withdraw(DateTime.Today, amount, category, type, counterParty, description);
		}

		public void Deposit(DateTime date, decimal amount, TransactionCategory category, TransactionType type, string counterParty, string description = "")
		{
			Balance += amount;
			var transaction = new Transaction(date, amount, category, type, counterParty, description);
			_transactions.Add(transaction);
		}

		public void Deposit(decimal amount, TransactionCategory category, TransactionType type, string counterParty, string description = "")
		{
			Deposit(DateTime.Today, amount, category, type, counterParty, description);
		}

		public decimal CheckBalance(DateTime date)
		{
			decimal totalTransactions = _transactions.Sum(t => t.Date <= date ? t.Amount : 0.0m);
			return OpeningBalance + totalTransactions;
		}

		public decimal CheckSpending(DateTime startDate, DateTime endDate)
		{
			decimal moneySpent = _transactions.Sum(t =>
			{
				if ((t.Amount < 0) && (t.Date >= startDate) && (t.Date <= endDate))
				{
					return Math.Abs(t.Amount);
				}
				return 0.0m;
			});
			return moneySpent;
		}

		public decimal CheckSpending(DateTime startDate, DateTime endDate, TransactionCategory category)
		{
			decimal moneySpent = _transactions.Sum(t =>
			{
				if ((t.Amount < 0) && (t.Date >= startDate) && (t.Date <= endDate) && (t.Category == category))
				{
					return Math.Abs(t.Amount);
				}
				return 0.0m;
			});
			return moneySpent;
		}

		public override string ToString()
		{
			return $"BankAccount: OpeningDate: {OpeningDate:d} OverdraftLimit: {OverdraftLimit} Balance: {Balance:C} ";
		}
	}
}


