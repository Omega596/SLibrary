using SLibrary.features;
int result;

bool shouldbebroken = Comparison.CCompare(1000, 1000, 1);

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
        

