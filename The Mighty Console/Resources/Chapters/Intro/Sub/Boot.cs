namespace The_Mighty_Console.Resources.Chapters.Intro.Sub
{
    public class Boot
    {
        private Framework Framework => Framework.Instance;
        
        public void BootExec()
        {
            BootRequest();
            BootSequence();
            BootProcessAdding();
            BootFinishing();
        }


        private void BootRequest()
        {
            Framework.commandHistory.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Framework.DelayedPrint("Device on standby mode.", 0);
            Console.ForegroundColor = ConsoleColor.White;
            Framework.DelayedPrint("Enter 'boot' to boot into main OS.", 0);
        }
        private void BootSequence()
        {
            bool BootLoaderText()
            {
                Console.Write("boot-loader> ");
                return true;
            }
            while (BootLoaderText() && !((Console.ReadLine() ?? "") == "boot"))
            {
                ConsoleStorage.Clear();
                Framework.ErrorPrint("Illegal statement. Enter 'boot' to boot into main OS.");
            }
            ConsoleStorage.Clear();
            Framework.DelayedPrint("Booting", 0, false);
            for (int i = 0; i < 4; i++)
            {
                Framework.DelayedPrint("...", 500, false);
                ConsoleStorage.Clear();
                Framework.DelayedPrint("Booting", 0, false);
            }
            ConsoleStorage.Clear();
        }
        private void BootProcessAdding()
        {
            Framework.AddProcess("System", 4, "Services", 3124);
            Framework.AddProcess("Secure System", 116, "Services", 62160);
            Framework.AddProcess("Registry", 160, "Services", 61000);
            Framework.AddProcess("services.exe", 824, "Services", 8535);
            Framework.AddProcess("kernelControl.sys", 0, "Services", 4000);
            Framework.AddProcess("secureKernel.exe", 112, "Services", 62160);
            Framework.AddProcess("registryManager.dll", 186, "Services", 61000);
            Framework.AddProcess("systemd.exe", 872, "Services", 8535);
            Framework.AddProcess("sysguard.exe", 900, "Services", 4432);
            Framework.AddProcess("init.exe", 992, "Services", 4156);
            Framework.AddProcess("serviceHandler.exe", 1232, "Services", 27988);
            Framework.AddProcess("resourceMonitor.dll", 1356, "Services", 15004);
            Framework.AddProcess("graphicsService.sys", 2464, "Services", 23728);
            Framework.AddProcess("driverManager.exe", 2480, "Services", 5744);
            Framework.AddProcess("sessionManager.exe", 2832, "Services", 4132);
            Framework.AddProcess("memoryController.sys", 2996, "Services", 1052684);
            Framework.AddProcess("securityDaemon.exe", 4924, "Console", 228536);
            Framework.AddProcess("explorer.dll", 14188, "Console", 255076);
            Framework.AddProcess("dataAggregator.exe", 3660, "Console", 11716);
            Framework.AddProcess("shell.exe", 8350, "Console", 5592);
            Framework.AddProcess("taskscheduler.bat", 18112, "Console", 11128);
        }
        private void BootFinishing()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Framework.DelayedPrint("TMC-OS");
            Framework.DelayedPrint("Firmware Version: 5.23.9743");
            Framework.DelayedPrint("Firmware Build: HJSA62AD7AD");
            Framework.DelayedPrint("Last Updated: Mon, 19/8/1974");
            Console.WriteLine();
            Framework.InfoPrint("System is in read-only mode.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Framework.DelayedPrint("Press any key to finish boot sequence...");
            Console.ReadKey();
            ConsoleStorage.Clear();
        }
    }
}
