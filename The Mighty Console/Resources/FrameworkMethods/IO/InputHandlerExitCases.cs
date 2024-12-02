namespace The_Mighty_Console.Resources.FrameworkMethods.IO
{
    internal class InputHandlerExitCases
    {
        private Framework Framework => Framework.Instance;

        public bool Exec()
        {
            if (!Framework.introCompleted && Framework.ContainsProcess(processName: "TMC.exe"))
            {
                Framework.aiRunning = true;
                Framework.introCompleted = true;
                return true;
            }
            return false;
        }
    }
}