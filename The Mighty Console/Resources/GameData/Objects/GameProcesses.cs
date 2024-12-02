namespace The_Mighty_Console.Resources.GameData.Objects
{
    public class GameProcesses
    {
        private Framework Framework => Framework.Instance;

        public string ProcessName { get; set; }
        public int ProcessId { get; set; }
        public string SessionName { get; set; }
        public int MemoryUsage { get; set; }

        public GameProcesses(string processName, int processId, string sessionName, int memoryUsage)
        {
            ProcessName = processName;
            ProcessId = processId;
            SessionName = sessionName;
            MemoryUsage = memoryUsage;
        }

        public override string ToString()
        {
            string processName = Framework.SetStringLength(ProcessName, 25);
            string processId = Framework.SetStringLength(ProcessId.ToString(), 8, true);
            string sessionName = Framework.SetStringLength(SessionName, 16);
            string memoryUsage = Framework.SetStringLength(MemoryUsage.ToString() + " K", 12, true);
            return $"{processName} {processId} {sessionName} {memoryUsage}";
        }
    }
}