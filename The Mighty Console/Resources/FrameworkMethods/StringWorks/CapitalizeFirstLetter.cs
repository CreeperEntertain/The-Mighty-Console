namespace The_Mighty_Console.Resources.FrameworkMethods.StringWorks
{
    internal class CapitalizeFirstLetter
    {
        public string Exec(string input) => string.IsNullOrEmpty(input) ? input : char.ToUpper(input[0]) + input[1..];
    }
}