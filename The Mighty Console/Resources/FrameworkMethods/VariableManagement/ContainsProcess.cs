using The_Mighty_Console.Resources.GameData.Objects;

namespace The_Mighty_Console.Resources.FrameworkMethods.VariableManagement
{
    internal class ContainsProcess
    {
        private Framework Framework => Framework.Instance;

        private List<GameProcesses> processes => Framework.processes;

        public bool Exec(string? processName = null, int? processId = null, string? sessionName = null, int? memoryUsage = null)
        {
            return processes.Any(p =>
                (processName == null || p.ProcessName == processName) &&
                (processId == null || p.ProcessId == processId.Value) &&
                (sessionName == null || p.SessionName == sessionName) &&
                (memoryUsage == null || p.MemoryUsage == memoryUsage.Value));
        }
    }
}