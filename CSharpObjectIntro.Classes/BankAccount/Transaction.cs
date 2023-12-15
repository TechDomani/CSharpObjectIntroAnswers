using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpObjectIntro.Classes.BankAccount
{
	public enum TransactionCategory
	{
		Groceries,
		Utilities,
		Interest,
		EatingOut,
		Salary,
		Rent,
		Gift,
		Other
	}

	public enum TransactionType
	{
		Cash,
		DirectDebit,
		StandingOrder,
		BankTransfer,
		DebitCard,
		Cheque
	}

	public class Transaction
	{
		public DateTime Date { get; private set; }
		public decimal Amount { get; private set; }
		public TransactionCategory Category { get; private set; }
		public TransactionType Type { get; private set; }
		public string CounterParty { get; private set; }
		public string Description { get; private set; }

		public Transaction(DateTime date, decimal amount, TransactionCategory category, TransactionType type, string counterParty, string description = "")
		{
			Date = date.Date;
			Amount = amount;
			Category = category;
			Type = type;
			CounterParty = counterParty;
			Description = description;
		}
	}
}
