namespace The_Mighty_Console.Resources.Commands.Classes
{
    internal class Net
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string textInput)
        {
            Framework.commandHistory.Add(textInput);
            textInput = Framework.ReplaceWord(textInput, "net");
            if (!Framework.HelpFlagChecker(textInput))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                bool userFlag = false;
                bool viewFlag = false;
                bool requestFlag = false;
                for (int i = 0; i < 3; i++)
                {
                    if (!userFlag) textInput = Framework.CommandFlagHandler(textInput, "user", out userFlag);
                    if (!viewFlag) textInput = Framework.CommandFlagHandler(textInput, "view", out viewFlag);
                    if (!requestFlag) textInput = Framework.CommandFlagHandler(textInput, "request", out requestFlag);
                }
                int discoveredFlags = 0;
                if (userFlag) discoveredFlags++;
                if (viewFlag) discoveredFlags++;
                if (requestFlag) discoveredFlags++;

                if (discoveredFlags == 0)
                {
                    Framework.ErrorPrint("Invalid or empty flag.");
                    Framework.InfoPrint("Enter NET ? for specific help.");
                }
                else if (discoveredFlags == 1) CheckFlags(textInput, userFlag, viewFlag, requestFlag);
                else Framework.ErrorPrint("Only add one flag.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        private void CheckFlags(string textInput, bool userFlag, bool viewFlag, bool requestFlag)
        {
            if (userFlag) Framework.PrintFromInternalFile("Resources.Tables.Net.User.txt");
            if (viewFlag) Framework.PrintFromInternalFile("Resources.Tables.Net.View.txt");
            if (requestFlag) ResolveRequestId(textInput);
        }
        private void ResolveRequestId(string textInput)
        {
            textInput = Framework.RemoveFirstWord(textInput);
            if (textInput == "")
                Framework.ErrorPrint("IP not provided, no request sent.");
            else if (textInput.StartsWith("192.168.1.106"))
            {
                string requestId = Framework.RemoveFirstWord(textInput);
                string requestedFile = $"Resources.Tables.Net.Request.{requestId}.txt";
                if (requestId == "")
                    Framework.ErrorPrint("No request key provided.");
                else if (Framework.CheckForInternalFile(requestedFile))
                    Framework.PrintFromInternalFile(requestedFile);
                else Framework.ErrorPrint("Key invalid, or missing access permissions.");
            }
            else
            {
                string[] connections = { "192.168.1.101", "192.168.1.102", "192.168.1.105", "192.168.1.110" };
                if (connections.Contains(Framework.ReturnFirstWord(textInput)))
                    if (Framework.RemoveFirstWord(textInput) == "")
                        Framework.ErrorPrint("No request key provided.");
                    else Framework.ErrorPrint("IP could not be reached. Device likely offline.");
                else
                {
                    Framework.ErrorPrint("IP does not exist on the local network.");
                    Framework.InfoPrint("Enter NET VIEW for a list of devices and IPs.");
                }
            }
        }
    }
}