
namespace SLibrary
{
    namespace personData
    {
        public delegate void AccountHandler(string text);
        public class Account
        {
            public AccountHandler? handler;
            public int sum = 0;
            public Account(int sum)
            {
                this.sum = sum;
            }
            public void RegisterHandler(AccountHandler handler)
            {
                this.handler += handler;
            }
            public void UnregisterHandler(AccountHandler handler)
            {
                this.handler -= handler;
            }
            public void Add(int amount)
            {
                if (amount <= 0)
                {
                    Console.WriteLine($"Invalid amount, amount: {amount}");
                }
                else
                {
                    sum += amount;
                    Console.WriteLine($"Successfully added money to your balance, current balance: {sum}");
                }
            }
            public void Transation(int amount)
            {
                if (amount == 0 || amount < 0)
                {
                    handler?.Invoke($"Incorrect amount, amount: {amount}");
                }
                else if (sum < amount)
                {
                    handler?.Invoke($"Not enough money, current balance: {sum}");
                }
                else if (sum >= amount)
                {
                    sum -= amount;
                    handler?.Invoke($"Sent money from your balance, current balance: {sum}");
                }
                else
                {
                    handler?.Invoke($"Error, please try later");
                }
            }
        }
        public class Person
        {
            public string name;
            private int _age;
            public int Age
            {
                get { return _age; }
                set
                {
                    if (value > 164 || value < 0)
                    {
                        Console.WriteLine("Value must be in a range from 164 to 1");
                        throw new ArgumentOutOfRangeException();
                    }
                    else
                    {
                        _age = value; 
                    }
                }
            }
            public Person(string name = "Unknown", int age = 1)
            {
                this.name = name;
                this.Age = age;
            }
            public void Print() => Console.WriteLine($"Имя: {name}, Возраст: {Age}");
            public void Deconstruct(out string personName, out int personAge)
            {
                personAge = Age;
                personName = name;
            }
        }
    }
    namespace features
    {
        public struct Print
        {
            static public void Printl(object input) => Console.WriteLine(input);
            static public void Printt(object input)
            {
                object type = input.GetType();
                Console.WriteLine(type.ToString());
            }
        }
        public struct Comparison
        {
            public static int? Compare(int x, int y)
            {
                int? compareType;
                if (x > y)
                {
                    compareType = 1;
                    return compareType;
                }
                else if (x < y)
                {
                    compareType = -1;
                    return compareType;
                }
                else if (x == y)
                {
                    compareType = 0;
                    return compareType;
                }
                return 0;
            }
            public static bool CCompare(int op, int x, int y)
            {
                bool result;
                switch (op)
                {
                    case 0:
                        result = x == y;
                        return result;
                    case 1:
                        result = x > y;
                        return result;
                    case 2:
                        result = x < y;
                        return result;
                    default: throw new InvalidOperatorException("Invalid Operator", op);
                }
            }
        class InvalidOperatorException : ArgumentException
        {
            public int Op { get; }
            public InvalidOperatorException(string message, int op)
                : base(message)
            {
                Op = op;
            }
        }
        }
    }
}