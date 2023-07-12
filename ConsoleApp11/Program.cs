using SLibrary.features;
using SLibrary.personData;
int result;
Account account = new Account(350);
account.RegisterHandler(PrintColorText);
account.RegisterHandler(PrintText);
Person tom = new Person("Tom Scott", 34);
tom.Print();
account.Transation(200);
account.Transation(200);
account.Transation(-1);
account.Add(4000);
void PrintColorText(object input)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(input);
    Console.ResetColor();
}
void PrintText(object input) => Console.WriteLine(input);
switch (Comparison.Compare(62, 84))
{
    case -1:
        result = 6 + 2;
        Print.Printl(result);
        return result;
    case 0:
        result = 6 * 2;
        Print.Printl(result);
        return result;
    case 1:
        result = 6 * 2 * 2;
        Print.Printl(result);
        return result;
    default: return 0;
}

