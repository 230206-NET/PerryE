using System;
namespace Budget{
    class BudgetApp{
        public record Expenses(){
            public int Amount{
                get; set;
            }
            public string Description{
                get; set;
            }
        }
        public static Expenses[] resizeArray(Expenses[] prevArray){
            Expenses[] newArr = new Expenses[prevArray.Length * 2];
            for (int i = 0; i < prevArray.Length; i++){
                newArr[i] = prevArray[i];
            }
            prevArray = newArr;
            return prevArray;
        }
        public static void Main(String[] args){
            Expenses[] expenses = new Expenses[2];
            Console.WriteLine("Please enter your initial budget");
            int budget = int.Parse(Console.ReadLine()!);
            int expenseCounter = 0;
            int expenditures = 0;
            while (true){
                if (expenseCounter >= expenses.Length){
                    expenses = resizeArray(expenses);
                }
                Console.WriteLine("Please enter the amount of your next expense");
                int expense = int.Parse(Console.ReadLine()!);
                Console.WriteLine("Please provide a short description of the expense:");
                string expenseDesc = Console.ReadLine()!;
                Expenses expenseToAdd = new Expenses();
                expenses[expenseCounter] = expenseToAdd;
                expenses[expenseCounter].Amount = expense;
                expenses[expenseCounter].Description = expenseDesc;
                expenseCounter++;
                Console.WriteLine("Is this your last expense?");
                string response = Console.ReadLine()!;
                if (response == "y" || response == "yes"){
                    break;
                }


            }
            foreach(Expenses expense in expenses){
                if (expense != null){
                      expenditures+=expense.Amount;
                }
                }
            Console.WriteLine($"Your budget was: {budget}");
            Console.WriteLine($"Your overall expenses were: {expenditures}");
            Console.WriteLine($"Overall, your profit will be {budget - expenditures}");

        }
    }
}