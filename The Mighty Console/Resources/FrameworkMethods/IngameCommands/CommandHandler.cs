using The_Mighty_Console.Resources.Commands.Classes;

namespace The_Mighty_Console.Resources.FrameworkMethods.IngameCommands
{
    internal class CommandHandler
    {
        private Framework Framework => Framework.Instance;

        private Aliases aliases = new Aliases();
        private Alwaysontop alwaysontop = new Alwaysontop();
        private Changedirectory changedirectory = new Changedirectory();
        private Clearhistory clearhistory = new Clearhistory();
        private Clearscreen clearscreen = new Clearscreen();
        private Date date = new Date();
        private Dateset dateset = new Dateset();
        private Delete delete = new Delete();
        private Diskusage diskusage = new Diskusage();
        private Echo echo = new Echo();
        private Free free = new Free();
        private Fullscreen fullscreen = new Fullscreen();
        private Help help = new Help();
        private History history = new History();
        private Hostname hostname = new Hostname();
        private Ipconfig ipconfig = new Ipconfig();
        private Leave leave = new Leave();
        private Library library = new Library();
        private Login login = new Login();
        private Mail mail = new Mail();
        private Makedirectory makedirectory = new Makedirectory();
        private Minimize minimize = new Minimize();
        private Net net = new Net();
        private Notes notes = new Notes();
        private Printdirectory printdirectory = new Printdirectory();
        private Printfile printfile = new Printfile();
        private Removedirectory removedirectory = new Removedirectory();
        private Restore restore = new Restore();
        private Shutdown shutdown = new Shutdown();
        private Start start = new Start();
        private Tasklist tasklist = new Tasklist();
        private Time time = new Time();
        private Timecurrent timecurrent = new Timecurrent();
        private Uname uname = new Uname();
        private Commands.Classes.Version version = new Commands.Classes.Version();
        private Whoami whoami = new Whoami();

        private string textInput => Framework.textInput;
        private List<string> commandHistory => Framework.commandHistory;

        private void Clear() => Framework.Clear();
        private void ErrorPrint(string input, bool isWarning, int errorLevel) => Framework.ErrorPrint(input, isWarning, errorLevel);
        private void CommandPermCheck(Action commandMethod) => Framework.CommandPermCheck(commandMethod);

        public void Exec(bool commandRequired)
        {
            var commandDispatcher = new Dictionary<string, Action<string>>(StringComparer.OrdinalIgnoreCase) // I HATE LOOKUP TABLES; I HATE THEM WITH A BURNING PASSION!!!
            {
                { "als", text => { aliases.Exec(textInput); Clear(); } },
                { "alias", text => { aliases.Exec(textInput); Clear(); } },
                { "aot", text => { alwaysontop.Exec(textInput); Clear(); } },
                { "alwaysontop", text => { alwaysontop.Exec(textInput); Clear(); } },
                { "cd", text => { CommandPermCheck(() => changedirectory.Exec(textInput)); Clear(); } },
                { "chngdir", text => { CommandPermCheck(() => changedirectory.Exec(textInput)); Clear(); } },
                { "changedirectory", text => { CommandPermCheck(() => changedirectory.Exec(textInput)); Clear(); } },
                { "clh", text => { clearhistory.Exec(textInput); Clear(); } },
                { "clrhist", text => { clearhistory.Exec(textInput); Clear(); } },
                { "clearhistory", text => { clearhistory.Exec(textInput); Clear(); } },
                { "cls", text => { clearscreen.Exec(textInput); Clear(); } },
                { "clearscreen", text => { clearscreen.Exec(textInput); Clear(); } },
                { "dt", text => { date.Exec(textInput); Clear(); } },
                { "date", text => { date.Exec(textInput); Clear(); } },
                { "del", text => { CommandPermCheck(() => delete.Exec(textInput)); Clear(); } },
                { "delete", text => { CommandPermCheck(() => delete.Exec(textInput)); Clear(); } },
                { "du", text => { diskusage.Exec(textInput); Clear(); } },
                { "disku", text => { diskusage.Exec(textInput); Clear(); } },
                { "diskusage", text => { diskusage.Exec(textInput); Clear(); } },
                { "echo", text => { CommandPermCheck(() => echo.Exec(textInput)); Clear(); } },
                { "free", text => { free.Exec(textInput); Clear(); } },
                { "full", text => { fullscreen.Exec(textInput); Clear(); } },
                { "fullscreen", text => { fullscreen.Exec(textInput); Clear(); } },
                { "?", text => { help.Exec(textInput); Clear(); } },
                { "help", text => { help.Exec(textInput); Clear(); } },
                { "ch", text => { history.Exec(textInput); Clear(); } },
                { "hist", text => { history.Exec(textInput); Clear(); } },
                { "history", text => { history.Exec(textInput); Clear(); } },
                { "hstn", text => { hostname.Exec(textInput); Clear(); } },
                { "hostname", text => { hostname.Exec(textInput); Clear(); } },
                { "ipc", text => { ipconfig.Exec(textInput); Clear(); } },
                { "ipconfig", text => { ipconfig.Exec(textInput); Clear(); } },
                { "leave", text => { leave.Exec(textInput); Clear(); } },
                { "dir", text => { library.Exec(textInput); Clear(); } },
                { "directory", text => { library.Exec(textInput); Clear(); } },
                { "lib", text => { library.Exec(textInput); Clear(); } },
                { "library", text => { library.Exec(textInput); Clear(); } },
                { "login", text => { login.Exec(textInput); Clear(); } },
                { "mail", text => { mail.Exec(textInput); Clear(); } },
                { "mkdir", text => { CommandPermCheck(() => makedirectory.Exec(textInput)); Clear(); } },
                { "makedir", text => { CommandPermCheck(() => makedirectory.Exec(textInput)); Clear(); } },
                { "makedirectory", text => { CommandPermCheck(() => makedirectory.Exec(textInput)); Clear(); } },
                { "min", text => { minimize.Exec(textInput); Clear(); } },
                { "minimize", text => { minimize.Exec(textInput); Clear(); } },
                { "net", text => { net.Exec(textInput); Clear(); } },
                { "notes", text => { notes.Exec(textInput); Clear(); } },
                { "pd", text => { printdirectory.Exec(textInput); Clear(); } },
                { "prntdir", text => { printdirectory.Exec(textInput); Clear(); } },
                { "printdirectory", text => { printdirectory.Exec(textInput); Clear(); } },
                { "pf", text => { printfile.Exec(textInput); Clear(); } },
                { "prntf", text => { printfile.Exec(textInput); Clear(); } },
                { "printfile", text => { printfile.Exec(textInput); Clear(); } },
                { "rmdir", text => { CommandPermCheck(() => removedirectory.Exec(textInput)); Clear(); } },
                { "removedir", text => { CommandPermCheck(() => removedirectory.Exec(textInput)); Clear(); } },
                { "removedirectory", text => { CommandPermCheck(() => removedirectory.Exec(textInput)); Clear(); } },
                { "rest", text => { restore.Exec(textInput); Clear(); } },
                { "restore", text => { restore.Exec(textInput); Clear(); } },
                { "shtd", text => { shutdown.Exec(textInput); Clear(); } },
                { "shutdown", text => { shutdown.Exec(textInput); Clear(); } },
                { "tl", text => { tasklist.Exec(textInput); Clear(); } },
                { "tasklist", text => { tasklist.Exec(textInput); Clear(); } },
                { "tm", text => { time.Exec(textInput); Clear(); } },
                { "time", text => { time.Exec(textInput); Clear(); } },
                { "tmc", text => { timecurrent.Exec(textInput); Clear(); } },
                { "tmcrr", text => { timecurrent.Exec(textInput); Clear(); } },
                { "timecrr", text => { timecurrent.Exec(textInput); Clear(); } },
                { "timecurrent", text => { timecurrent.Exec(textInput); Clear(); } },
                { "uname", text => { uname.Exec(textInput); Clear(); } },
                { "ver", text => { version.Exec(textInput); Clear(); } },
                { "version", text => { version.Exec(textInput); Clear(); } },
                { "wmi", text => { whoami.Exec(textInput); Clear(); } },
                { "whoami", text => { whoami.Exec(textInput); Clear(); } }
            };

            string commandKey = textInput.ToLower().Split(' ')[0];
            if (commandDispatcher.TryGetValue(commandKey, out var commandAction))
                commandAction(textInput);
            else if (string.IsNullOrWhiteSpace(textInput))
            {
                commandHistory.Add(textInput);
                ErrorPrint("Input cannot be empty.", false, 1);
                Clear();
            }
            else if (commandRequired)
            {
                commandHistory.Add(textInput);
                ErrorPrint("Unknown command. Enter HELP for a list of commands.", false, 1);
                Clear();
            }
        }
    }
}