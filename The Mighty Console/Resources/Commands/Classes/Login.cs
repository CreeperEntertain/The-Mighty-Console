namespace The_Mighty_Console.Resources.Commands.Classes
{
    internal class Login
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string textInput)
        {
            Framework.commandHistory.Add(textInput);
            textInput = Framework.ReplaceWord(textInput, "login");
            if (!Framework.HelpFlagChecker(textInput))
                if (Framework.loggedIn)
                    Framework.ErrorPrint("Already logged in. Please shut down the PC or restart to log into a different account.", false, 1);
                else AccountHandler();
        }
        private void AccountHandler()
        {
            Framework.DelayedPrint("Account: ", 0, false);
            string account = Console.ReadLine() ?? "";
            if (!(account == "Research 827" || account == "rsrch_00827"))
            {
                Framework.ErrorPrint("Account does not exist.");
                Framework.InfoPrint("Enter NET USER for a list of accounts.");
            }
            else PasswordHandler();
        }
        private void PasswordHandler()
        {
            Framework.DelayedPrint("Password: ", 0, false);
            string password = Framework.ReadLineWithMask();
            if (!(password == "V1rusKey!42"))
                Framework.ErrorPrint("Incorrect credentials.");
            else
            {
                Framework.InfoPrint("Logged in as: Research 827");
                Framework.InfoPrint("Use DIR/LIB and CD to navigate.");
                Framework.loggedIn = true;
                Framework.userPath = "main.usrs.rsrch_00827";
            }
        }
    }
}