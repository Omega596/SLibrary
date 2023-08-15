using SLibrary.features;
using SLibrary.personData;

int result;
Account account = new(350);
account.notify += PrintColorText;
account.Transation(200);
account.Transation(200);
account.Transation(-1);
account.Add(4000);
int Fibonacci(int n)
{
    if (n == 0 || n == 1) return n;

    return Fibonacci(n - 1) + Fibonacci(n - 2);
}
bool PalindromeChecker(string text)
{
    char[] textArray = text.ToCharArray();
    char[] textArrayReverse = textArray;
    Array.Reverse(textArrayReverse);
    if (textArrayReverse == textArray)
    {
        return true;
    }
    else
    {
        return false;
    }
}
Console.WriteLine(PalindromeChecker("civic"));
Console.WriteLine(Fibonacci(300));
string ProcessText = "hello world";
for (int i = 0; i < ProcessText.Length; i++)
{
    char[] textArray = new char[ProcessText.Length];
    char Space = ' ';
    if (ProcessText[i].Equals('a') || ProcessText[i].Equals('e') || ProcessText[i].Equals('i') || ProcessText[i].Equals('o') || ProcessText[i].Equals('u'))
    {
        textArray[i] = ' ';
    }
    else
    {
        textArray[i] = ProcessText[i];
    }
    string NoVowels = string.Join(Space, textArray);
    Console.WriteLine(NoVowels);
}
void PrintColorText(Account sender, AccountEventArgs e)
{
    string AccOpText;
    if (e.AccOpType == 0)
    {
        AccOpText = "An transation has sent to your account";
    }
    else if (e.AccOpType == 1)
    {
        AccOpText = "You made a transation";
    }
    else
    {
        AccOpText = "An Operation has been processed";
    }
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(AccOpText);
    Console.WriteLine(e.Message);
    Console.WriteLine($"Current balance on your balance: {sender.sum}");
    Console.WriteLine("-----------------");
    Console.ResetColor();
}
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

