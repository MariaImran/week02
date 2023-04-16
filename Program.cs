using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using sign_in_sign_up.bl;

namespace signin
{
    class Program
    {
        List<Users> user = new List<Users>();
        double balance = 5000;
        static void Main(string[] args)
        {
            string path = "C:\\Users\\USER\\source\\repos\\sign in sign up\\record.txt";
            string[]  accountHolderName = new string[3];
            string[] password = new string[3];
            int[] accountNumber = new int[3];
            
            double[] amount = new double[3];
            int option;
            do
            {
                readData(path,  accountHolderName, password);
                Console.Clear();
                option = menu();
                Console.Clear();
                if (option == 1)
                {
                    Console.WriteLine("enter your name:");
                    string customerN = Console.ReadLine();
                    Console.WriteLine("enter your password:");
                    string customerP = Console.ReadLine();
                    
                    signin(customerN, customerP, accountHolderName, password);

                }
                else if (option == 2)
                {
                    Console.WriteLine("enter your names:");
                    string name = Console.ReadLine();
                    Console.WriteLine("enter your new password:");
                    string passwords = Console.ReadLine();
                    signUp(path, name, passwords);

                }
            }
            while (option < 3);
            Console.Read();
            

        }
        public static int menu()
        {
            int option;
            Console.WriteLine("1. Sign IN:");
            Console.WriteLine("2. Sign Up:");
            Console.WriteLine("Choose any of the above option:");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        public static void signin(string customerName, string customerPass, string[] names, string[] password)
        {
            bool flag = false;
            for (int index = 0; index < 3; index++)
            {
                if (customerName == names[index] && customerPass == password[index])
                {
                    Console.WriteLine("userValid");
                    flag = true;
                    int option;
                    Console.WriteLine("Enter any option : ");
                    Console.WriteLine("Enter 1 to display");
                    Console.WriteLine("Enter 2 to deposit");
                    Console.WriteLine("Enter 3 to withdraw");
                    Console.WriteLine("Enter 4 to update");
                    Console.WriteLine("Enter 5 to delete");
                    option = int.Parse(Console.ReadLine());
                    if (option == 1)
                    {
                        DisplayAccountInfo(Users);
                        Console.WriteLine("Press any key to continue....");
                        Console.ReadKey();

                    }
                    if (option == 2)
                    {
                        double amount;
                        double balance = 5000;
                        Console.WriteLine("Enter amount you want to deposit : ");
                        amount = double.Parse(Console.ReadLine());
                        Deposit(amount, balance);
                        Console.WriteLine("Press any key to continue....");
                        Console.ReadKey();

                    }
                    if (option == 3)
                    {
                        double amount;
                        double balance = 5000;
                        Console.WriteLine("Enter amount you want to withdraw : ");
                        amount = double.Parse(Console.ReadLine());
                        Withdraw(amount, balance);
                        Console.WriteLine("Press any key to continue....");
                        Console.ReadKey();

                    }
                    if (option == 4)
                    {
                        string newName;
                        Console.WriteLine("enter new name");
                        newName = Console.ReadLine();
                        UpdateAccountHolderName(newName);
                        Console.WriteLine("Press any key to continue....");
                        Console.ReadKey();

                    }
                    if (option == 5)
                    {
                        DeleteAccount(Users);
                        Console.WriteLine("Press any key to continue....");
                        Console.ReadKey();
                    }
                }
            }
            if (flag == false)
            {
                Console.WriteLine("invalid input");
            }
            Console.ReadKey();
        }
        public static void signUp(string path, string name, string password)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(name + "," + password);
            int option;
            Console.WriteLine("Enter any option : ");
            Console.WriteLine("Enter 1 to display");
            Console.WriteLine("Enter 2 to deposit");
            Console.WriteLine("Enter 3 to withdraw");
            Console.WriteLine("Enter 4 to update");
            Console.WriteLine("Enter 5 to delete");
            option = int.Parse(Console.ReadLine());
            if(option == 1)
            {
                DisplayAccountInfo(Users);
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
                
            }
            if (option == 2)
            {
                double amount;
                double balance = 5000;
                Console.WriteLine("Enter amount you want to deposit : ");
                amount = double.Parse(Console.ReadLine());
                Deposit(amount, balance);
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
                
            }
            if (option == 3)
            {
                double amount;
                double balance = 5000;
                Console.WriteLine("Enter amount you want to withdraw : ");
                amount = double.Parse(Console.ReadLine());
                Withdraw(amount, balance);
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
                
            }
            if (option == 4)
            {
                string newName;
                Console.WriteLine("enter new name");
                newName = Console.ReadLine();
                UpdateAccountHolderName(newName);
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
                
            }
            if(option == 5)
            {
                DeleteAccount(Users);
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
            }
            file.Flush();
            file.Close();


        }
        public static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        public static void readData(string path, string[] names, string[] password)
        {
            int x = 0;
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string record;
                while ((record = file.ReadLine()) != null)
                {
                    names[x] = parseData(record, 1);
                    password[x] = parseData(record, 2);
                    x++;
                    if (x >= 3)
                    {
                        break;
                    }

                }
                file.Close();
            }
            else
            {
                Console.WriteLine("Not exists");
            }
        }
        
        public static void DisplayAccountInfo(List<Users> user)
        {
            double balance = 5000;
            int accountNumber = 123;
            string accountHolderName = "Maria";
            Console.WriteLine("Account Number: {0}", accountNumber);
            Console.WriteLine("Account Holder Name: {0}", accountHolderName);
            Console.WriteLine("Account Balance: {0}", balance);
            Console.WriteLine();
        }

        // Deposit money into the account
        public static void Deposit(double amount, double balance)
        {
            
            balance += amount;
            Console.WriteLine("Amount deposited successfully.");
            Console.WriteLine("New account balance: {0}", balance);
            Console.WriteLine();
            for (int i = 0; i < Users.Count; i++)
            {
                Users.add();
            }
        }

        // Withdraw money from the account
        public static void Withdraw(double amount, double balance)
        {
            if (amount > balance)
            {
                Console.WriteLine("Insufficient balance.");
                Console.WriteLine();
            }
            else
            {
                balance -= amount;
                Console.WriteLine("Amount withdrawn successfully.");
                Console.WriteLine("New account balance: {0}", balance);
                Console.WriteLine();
            }
        }

        // Update account holder name
        public static void UpdateAccountHolderName(string newName)
        {
           string accountHolderName = newName;
            Console.WriteLine("Account holder name updated successfully.");
            
            Console.WriteLine();
        }

        // Delete account
        public static void DeleteAccount(List<Users> user)
        {
            
           
            for(int i = 0; i < Users.Count; i++)
            {
                Users.remove();
            }
            Console.WriteLine("Account deleted successfully.");
            Console.WriteLine();
        }
    }


    
}
