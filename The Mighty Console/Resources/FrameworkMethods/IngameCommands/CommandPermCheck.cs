namespace The_Mighty_Console.Resources.FrameworkMethods.IngameCommands
{
    internal class CommandPermCheck
    {
        private Framework Framework => Framework.Instance;
        public void Exec(Action commandMethod)
        {
            if (Framework.loggedIn) commandMethod();
            else Framework.ErrorPrint("Missing permissions. Please log in.", false, 1);
        }
    }
}