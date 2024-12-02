using System.Diagnostics;
using The_Mighty_Console.Resources.GameData.Objects;

namespace The_Mighty_Console.Resources.Commands.Classes
{
    internal class Start
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string textInput)
        {
            Framework.commandHistory.Add(textInput);
            textInput = Framework.ReplaceWord(textInput, "start");
            if (!Framework.HelpFlagChecker(textInput))
            {
                bool flagDetected = false;
                textInput = Framework.CommandFlagHandler(textInput, "external", out flagDetected);
                if (flagDetected) ExternalStartHandler(textInput);
                else InternalStartHandler(textInput);
            }
        }
        private void ExternalStartHandler(string textInput)
        {
            string filePath = Framework.RemoveFirstWord(textInput);
            if (!File.Exists(filePath) && !Directory.Exists(filePath))
            {
                Framework.ErrorPrint("The specified path does not exist.");
                return;
            }
            if (Directory.Exists(filePath))
                Process.Start(
                    new ProcessStartInfo
                    {
                        FileName = filePath,
                        UseShellExecute = true,
                        Verb = "open"
                    }
                );
            else if (File.Exists(filePath))
                Process.Start(
                    new ProcessStartInfo
                    {
                        FileName = filePath,
                        UseShellExecute = true,
                        Verb = "open"
                    }
                );
            else Framework.ErrorPrint("The specified path is neither a file nor a folder.");
        }
        private void InternalStartHandler(string textInput)
        {
            string dotPath = Framework.ConvertToDotPath(Framework.RemoveFirstWord(textInput)) ?? "";
            bool isFolder = Framework.CheckForInternalDirectory(dotPath, out bool isFile);
            if (isFile || isFolder)
                if (dotPath == "IngameDir.main.usrs.rsrch_00827.Desktop.TMCProjectMain.main.exe")
                    if (!Framework.ContainsProcess(processName: "TMC.exe"))
                        StartAi();
                    else Framework.ErrorPrint("Process is already running.");
                else Framework.ErrorPrint("Missing execute permissions.");
            else Framework.ErrorPrint("No file or directory found at path.");
        }
        private void StartAi()
        {
            if (!Framework.aiRunning)
            {
                Framework.ErrorPrint("The requested file is in limited access mode.", true, 1);
                Framework.InfoPrint("Running it might not save data.");
                if (Framework.ConfirmAction())
                {
                    Framework.processes.Add(new GameProcesses("TMC.exe", 9826, "User", 13875237));
                    Framework.aiRunning = true;
                    Framework.skippedIntro = false;
                    Framework.DelayedPrint("Starting main.exe...", 0);
                    Thread.Sleep(1850);
                    Framework.DelayedPrint("Starting modules...", 0);
                    Thread.Sleep(2535);
                    Framework.DelayedPrint("Launching TMC.exe...", 0);
                    Thread.Sleep(325);
                    Framework.DelayedPrint("Loading configuration files...", 0);
                    Thread.Sleep(410);
                    Framework.DelayedPrint("Initializing system resources...", 0);
                    Thread.Sleep(275);
                    Framework.DelayedPrint("Establishing network connections...", 0);
                    Thread.Sleep(460);
                    Framework.DelayedPrint("Loading user settings...", 0);
                    Thread.Sleep(350);
                    Framework.DelayedPrint("Preparing user interface...", 0);
                    Thread.Sleep(480);
                    Framework.DelayedPrint("Starting background services...", 0);
                    Thread.Sleep(390);
                    Framework.DelayedPrint("Verifying system integrity...", 0);
                    Thread.Sleep(2870);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Framework.DelayedPrint("WELCOME!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                } else Framework.InfoPrint("Cancelled.");
            }
        }
    }
}