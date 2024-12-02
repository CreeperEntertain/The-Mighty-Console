namespace The_Mighty_Console.Resources.FrameworkMethods.IO
{
    internal class ConfirmAction
    {
        Framework Framework => Framework.Instance;
        public bool Exec()
        {
            Framework.DelayedPrint("Y or YES to confirm, else to cancel.", 0);
            Console.Write("> ");
            string response = Console.ReadLine()?.Trim().ToLower() ?? "";
            return response == "y" || response == "yes";
        }
    }
}