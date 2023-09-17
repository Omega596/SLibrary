using System.Text.RegularExpressions;

namespace SLibrary
{
    namespace personData
    {
        public class Account
        {
            internal int AddUID = 0;
            internal int TransactionUID = 1;
            public delegate void AccountHandler(Account sender, AccountEventArgs e);
            public AccountHandler? handler;
            public int sum = 0;
            AccountHandler? Notify;
            public event AccountHandler? notify
            {
                add
                {
                    Notify += value;
                    Console.WriteLine($"{value?.Method.Name} Added");
                }
                remove
                {
                    Notify -= value;
                    Console.WriteLine($"{value?.Method.Name} Removed");
                }
            }
            public Account(int sum)
            {
                this.sum = sum;
            }
            public void Add(int amount)
            {
                if (amount <= 0)
                {
                    Notify?.Invoke(this, new AccountEventArgs($"Invalid amount, amount: {amount}", sum, AddUID));
                }
                else
                {
                    sum += amount;
                    Notify?.Invoke(this, new AccountEventArgs($"Successfully added money to your balance, current balance: {sum}", sum, AddUID));
                }
            }
            public void Transation(int amount)
            {
                if (amount == 0 || amount < 0)
                {
                    Notify?.Invoke(this, new AccountEventArgs($"Incorrect amount, amount: {amount}", sum, TransactionUID));
                }
                else if (sum < amount)
                {
                    Notify?.Invoke(this, new AccountEventArgs($"Not enough money, current balance: {sum}", sum, TransactionUID));
                }
                else if (sum >= amount)
                {
                    sum -= amount;
                    Notify?.Invoke(this, new AccountEventArgs($"Sent money from your balance, current balance: {sum}", sum, TransactionUID));
                }
                else
                {
                    Notify?.Invoke(this, new AccountEventArgs($"Error, please try later", sum, TransactionUID));
                }
            }
        }
        public class AccountEventArgs
        {
            public string? Message { get; }
            public int? Sum { get; }
            public int AccOpType;
            public AccountEventArgs(string Message, int Sum, int AccOpType)
            {
                this.Sum = Sum;
                this.Message = Message;
                this.AccOpType = AccOpType;
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
        public struct Seperator
        {
            public static string[] SeparateString(string input)
            {
                string[] words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                return words;
            }
        }
        public static class ArrayExtensions
        {
            public static void Fill<T>(this T[] array, T value)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = value;
                }
            }
            public static void Fill<T>(this List<T> list, T value)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    list[i] = value;
                }
            }
            public static List<int> findOccurrences(this string input, char character)
            {
                List<int> occurrences = new List<int>();
                int index = -1;

                do
                {
                    index = input.IndexOf(character, index + 1);
                    if (index != -1)
                    {
                        occurrences.Add(index);
                    }
                } while (index != -1);

                return occurrences;
            }
        }
        public static class ObjectExtensions
        {
            public static void Freeze<T>(this T target)
            {
                
                T permanentObject = target;
                if ((bool)!target?.Equals(permanentObject))
                {
                    target = permanentObject;
                }
            }
        }
    }
}