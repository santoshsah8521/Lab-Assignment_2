using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Assignment-2");
            Console.ReadLine();
            Console.WriteLine("Question 1 Solution");
            A3Q1 employee = new A3Q1();
            employee.Employee("John Doe", 30, 50000m);
            employee.DisplayEmployeeDetails();
            Console.ReadLine();
            Console.WriteLine("Question 2 Solution");
            A3Q2 account = new A3Q2();
            account.BankAccount("1234567890", "John Doe", 1000.00m);
            account.DisplayAccountDetails();
            Console.WriteLine();
            Console.ReadLine();
            Console.WriteLine("Depositing 500...");
            account.Deposit(500);
            Console.WriteLine();
            Console.ReadLine();
            Console.WriteLine("Withdrawing 200...");
            account.Withdraw(200);
            Console.WriteLine();
            account.DisplayAccountDetails();
            Console.ReadLine();
            Console.WriteLine("Question 3 Solution");
            A3Q3 calculate = new A3Q3();
            int[] numbers = { 10, 20, 30, 40, 50 };
            double average = A3Q3.CalculateAverage(numbers);
            Console.WriteLine($"The average is: {average}");
            Console.ReadLine();
            Console.WriteLine("Question 4 Solution");
            Logger.LogMessage("Application started.");
            try
            {
                Logger.LogMessage("Processing data...");
                throw new Exception("An error occurred while processing data.");
            }
            catch (Exception ex)
            {
                Logger.LogMessage($"Error: {ex.Message}");
            }
            finally
            {
                Logger.LogMessage("Application finished.");
            }
            Console.ReadLine();
            Console.WriteLine("Question 5 Solution");
            Person person = new Person
            {
                FirstName = "John",
                LastName = "Doe"
            };
            person.PrintFullName();
            Console.ReadLine();
            Console.WriteLine("Question 6 Solution");
            Employee employees = new Employee
            {
                EmployeeId = 101,
                Name = "John Doe",
                Department = "IT",
                BaseSalary = 50000,
                HoursWorked = 40,
                HourlyRate = 50
            };
            decimal baseSalary = employees.CalculateSalary();
            decimal salaryWithBonus = employees.CalculateSalaryWithBonus(10);
            decimal salaryWithDeductions = employees.CalculateSalaryWithDeductions(200);
            decimal netSalary = employees.CalculateNetSalary(10, 200);
            Console.WriteLine("Base Salary: " + baseSalary);
            Console.WriteLine("Salary with Bonus: " + salaryWithBonus);
            Console.WriteLine("Salary with Deductions: " + salaryWithDeductions);
            Console.WriteLine("Net Salary: " + netSalary);
            Console.ReadLine();
            Console.WriteLine("Question 7 Solution");
            Shape circle = new Circle(5);
            Console.WriteLine("Area of Circle: " + circle.CalculateArea());
            Shape rectangle = new Rectangle(4, 6);
            Console.WriteLine("Area of Rectangle: " + rectangle.CalculateArea());
            Console.ReadLine();
            Console.WriteLine("Question 8 Solution");
            Animal dog = new Dog("Buddy", 3);
            dog.MakeSound();
            dog.Sleep();
            ((Dog)dog).Fetch();  // Call the unique method Fetch
            Console.WriteLine();
            // Create a Cat object
            Animal cat = new Cat("Whiskers", 2);
            cat.MakeSound();
            cat.Sleep();
            ((Cat)cat).Climb();
            Console.ReadLine();
            Console.WriteLine("Question 9 Solution");
            {
                // Create a Car object
                Car myCar = new Car
                {
                    Make = "Toyota",
                    Model = "Camry",
                    NumberOfDoors = 4
                };
                myCar.StartEngine();
                myCar.HonkHorn();
                myCar.StopEngine();
                Console.ReadLine();
                Console.WriteLine("Question 10 Solution");
                SavingsAccount mySavings = new SavingsAccount("SA12345", 1000, 5);
                // Deposit some money
                mySavings.Deposit(500);
                // Withdraw some money
                mySavings.Withdraw(300);
                // Calculate interest and update balance
                mySavings.CalculateInterest();
                // Display the final balance
                Console.WriteLine($"Final balance: {mySavings.Balance}");
                Console.ReadLine();
            }
        }
        class A3Q1
        {
            private string Name { get; set; }
            private int Age { get; set; }
            private decimal Salary { get; set; }
            public void Employee(string name, int age, decimal salary)
            {
                Name = name;
                Age = age;
                Salary = salary;
            }
            public void DisplayEmployeeDetails()
            {
                Console.WriteLine("Employee Details:");
                Console.WriteLine($"Name: {Name}");
                Console.WriteLine($"Age: {Age}");
                Console.WriteLine($"Salary: {Salary:C}");
            }
        }
        class A3Q2
        {
            public string AccountNumber { get; private set; }
            public string AccountHolderName { get; private set; }
            public decimal Balance { get; private set; }
            public void BankAccount(string accountNumber, string accountHolderName, decimal initialBalance)
            {
                AccountNumber = accountNumber;
                AccountHolderName = accountHolderName;
                Balance = initialBalance;
            }
            public void Deposit(decimal amount)
            {
                if (amount > 0)
                {
                    Balance += amount;
                    Console.WriteLine($"{amount} has been deposited. New balance: {Balance}");
                }
                else
                {
                    Console.WriteLine("Deposit amount must be greater than zero.");
                }
            }
            public void Withdraw(decimal amount)
            {
                if (amount > 0 && amount <= Balance)
                {
                    Balance -= amount;
                    Console.WriteLine($"{amount} has been withdrawn. New balance: {Balance}");
                }
                else
                {
                    Console.WriteLine("Invalid withdrawal amount or insufficient funds.");
                }
            }
            public void DisplayAccountDetails()
            {
                Console.WriteLine("Account Details:");
                Console.WriteLine($"Account Number: {AccountNumber}");
                Console.WriteLine($"Account Holder: {AccountHolderName}");
                Console.WriteLine($"Balance: {Balance}");
            }
        }
        class A3Q3
        {
            public static double CalculateAverage(int[] numbers)
            {
                if (numbers == null || numbers.Length == 0)
                {
                    throw new ArgumentException("The array cannot be null or empty.");
                }
                int sum = 0;
                foreach (int number in numbers)
                {
                    sum += number;
                }
                return (double)sum / numbers.Length;
            }
        }
        // question 4
        public static class Logger
        {
            public static void LogMessage(string message)
            {
                Console.WriteLine($"{DateTime.Now}: {message}");
            }
        }
        // question 5
        public partial class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
        public partial class Person
        {
            public void PrintFullName()
            {
                Console.WriteLine($"Full Name: {FirstName} {LastName}");
            }
        }
        // question 6 
        public partial class Employee
        {
            public int EmployeeId { get; set; }
            public string Name { get; set; }
            public string Department { get; set; }
            public decimal BaseSalary { get; set; }
            public int HoursWorked { get; set; }
            public decimal HourlyRate { get; set; }
        }
        public partial class Employee
        {
            public decimal CalculateSalary()
            {
                return BaseSalary + (HoursWorked * HourlyRate);
            }
            public decimal CalculateSalaryWithBonus(decimal bonusPercentage)
            {
                decimal bonus = BaseSalary * (bonusPercentage / 100);
                return CalculateSalary() + bonus;
            }
            public decimal CalculateSalaryWithDeductions(decimal deductionAmount)
            {
                return CalculateSalary() - deductionAmount;
            }
            public decimal CalculateNetSalary(decimal bonusPercentage, decimal deductionAmount)
            {
                return CalculateSalaryWithBonus(bonusPercentage) - deductionAmount;
            }
        }
        // question 7
        public abstract class Shape
        {
            public abstract double CalculateArea();
        }
        public class Circle : Shape
        {
            public double Radius { get; set; }
            public Circle(double radius)
            {
                Radius = radius;
            }
            public override double CalculateArea()
            {
                return Math.PI * Math.Pow(Radius, 2);
            }
        }
        public class Rectangle : Shape
        {
            public double Length { get; set; }
            public double Width { get; set; }
            public Rectangle(double length, double width)
            {
                Length = length;
                Width = width;
            }
            public override double CalculateArea()
            {
                return Length * Width;
            }
        }
        // question 8
        public abstract class Animal
        {
            // Properties common to all animals
            public string Name { get; set; }
            public int Age { get; set; }
            // Constructor to initialize the name and age of the animal
            public Animal(string name, int age)
            {
                Name = name;
                Age = age;
            }
            // Abstract method that derived classes must implement
            public abstract void MakeSound();
            // Method that can be overridden by derived classes if needed
            public virtual void Sleep()
            {
                Console.WriteLine(Name + " is sleeping.");
            }
        }
        // Dog.cs
        public class Dog : Animal
        {
            // Constructor for Dog, calling base class constructor
            public Dog(string name, int age) : base(name, age) { }
            // Implementation of the abstract method
            public override void MakeSound()
            {
                Console.WriteLine(Name + " says: Woof Woof!");
            }
            // Unique method for Dog class
            public void Fetch()
            {
                Console.WriteLine(Name + " is fetching the ball.");
            }
        }
        // Cat.cs
        public class Cat : Animal
        {
            // Constructor for Cat, calling base class constructor
            public Cat(string name, int age) : base(name, age) { }
            // Implementation of the abstract method
            public override void MakeSound()
            {
                Console.WriteLine(Name + " says: Meow!");
            }
            // Unique method for Cat class
            public void Climb()
            {
                Console.WriteLine(Name + " is climbing a tree.");
            }
            // Override the Sleep method if needed
            public override void Sleep()
            {
                Console.WriteLine(Name + " is curled up and purring while sleeping.");
            }
        }
        // question 9
        // Vehicle.cs
        public class Vehicle
        {
            public string Make { get; set; }
            public string Model { get; set; }
            // Method to start the engine
            public void StartEngine()
            {
                Console.WriteLine("The engine is starting.");
            }
            // Method to stop the engine
            public void StopEngine()
            {
                Console.WriteLine("The engine is stopping.");
            }
        }
        // Car.cs
        public sealed class Car : Vehicle
        {
            public int NumberOfDoors { get; set; }
            // Method specific to Car
            public void HonkHorn()
            {
                Console.WriteLine("The car is honking the horn!");
            }
        }
        // SportsCar.cs
        // This will cause a compile-time error because Car is sealed
        public class SportsCar
        {
            public int TopSpeed { get; set; }
            public void TurboBoost()
            {
                Console.WriteLine("Turbo boost activated!");
            }
        }
        // BankAccount.cs
        public class BankAccount
        {
            // Properties for AccountNumber and Balance
            public string AccountNumber { get; set; }
            public decimal Balance { get; protected set; }
            // Constructor to initialize the account
            public BankAccount(string accountNumber, decimal initialBalance)
            {
                AccountNumber = accountNumber;
                Balance = initialBalance;
            }
            // Method to deposit money into the account
            public void Deposit(decimal amount)
            {
                if (amount > 0)
                {
                    Balance += amount;
                    Console.WriteLine($"{amount} deposited. New balance: {Balance}");
                }
                else
                {
                    Console.WriteLine("Deposit amount must be positive.");
                }
            }
            // Method to withdraw money from the account
            public virtual void Withdraw(decimal amount)
            {
                if (amount > 0 && amount <= Balance)
                {
                    Balance -= amount;
                    Console.WriteLine($"{amount} withdrawn. New balance: {Balance}");
                }
                else
                {
                    Console.WriteLine("Invalid withdrawal amount.");
                }
            }
        }
        // SavingsAccount.cs
        public sealed class SavingsAccount : BankAccount
        {
            public decimal InterestRate { get; set; }
            // Constructor to initialize SavingsAccount with interest rate
            public SavingsAccount(string accountNumber, decimal initialBalance, decimal interestRate)
                : base(accountNumber, initialBalance)
            {
                InterestRate = interestRate;
            }
            // Method to calculate interest based on the balance and interest rate
            public void CalculateInterest()
            {
                decimal interest = Balance * InterestRate / 100;
                Console.WriteLine($"Interest calculated: {interest}");
                Deposit(interest); // Add interest to balance
            }
            // Override the Withdraw method to impose restrictions specific to SavingsAccount
            public override void Withdraw(decimal amount)
            {
                if (amount > 0 && amount <= Balance)
                {
                    // Savings account might have additional rules for withdrawal (e.g., max withdrawal limit)
                    Console.WriteLine("Processing withdrawal from SavingsAccount...");
                    base.Withdraw(amount);
                }
                else
                {
                    Console.WriteLine("Invalid withdrawal amount or insufficient balance.");
                }
            }
        }
    }
}