# CSharpObjectIntro

## Part 1: Diary
Look at the Diary and DiaryEvent classes in CSharpObjectIntro.Classes\Diary</br>
In Program.cs in CSharpObjectIntro in the UseDiary() procedure write code to:</br>
1: Create a new diary object</br>
2: Add some events to your diary</br>
3: Check and output how many events there are on a particular day</br>
Then in Diary.cs add a new method that returns the number of morning events</br>
Add code to UseDiary() to call this new method</br>
Add a test to DiaryTests.cs to test the new method</br>

## Part 2: Bank Account
In this part you will create your own bank account class.</br>
As you complete each task make sure you test your code by calling it from Program.cs UseBankAccount()</br>
You should also add tests to BankAccountTests.cs</br>

Task One</br>
The bank account should have a balance property</br>
It should have a constructor that sets the initial balance (default zero) and the opening date (default today)</br>
It should have methods to deposit and withdraw/make payments from the account.</br> 

Task Two</br>
Give the option to set an overdraft limit. This should be a property or field</br>
Do not allow a withdrawal/payment if the overdraft limit is exceeded. You could return false or throw an invalid operation exception.</br>

Task Three</br>
Create a new class called AccountTransaction. This should be in a separate file.</br>
It could contain properties such as</br>
date, amount, category, counterparty, transactionType, description (optional)</br>
e.g 26/09/2022 16:45, -300, Groceries, Waitrose, Card, Weekly shop</br>
27/09/2022 17:40, 200, Gift, Bob Smith, Cheque, Birthday present</br>
You might wish to use enums for category and transactionType</br>
Amend your bank account to contain a list of transactions</br>
The methods for  deposit and withdraw/make payments should be amended to add transactions</br>

Task Four</br>
Now add some new methods to your account</br>
- See what the balance was at a previous date</br>
- See how much money was spent in a given time period</br>
- See how much money was spent in different categories</br>

Extension</br>
Work out how much interest is payable on your account</br>
For the moment make up the interest rates, though later we could look at loading them from a website</br>
The interest should be added as transactions to your account</br>



