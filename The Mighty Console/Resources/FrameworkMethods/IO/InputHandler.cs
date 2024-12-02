using The_Mighty_Console.Resources.Commands.Classes;

namespace The_Mighty_Console.Resources.FrameworkMethods.IO
{
    internal class InputHandler
    {
        private Framework Framework => Framework.Instance;

        private Leave leave = new Leave();

        public void Exec(bool isCommand = false, bool commandRequired = false)
        {
            bool loop;
            do
            {
                loop = false;
                Framework.Clear();
                Framework.InputDisplay();
                Framework.textInput = Console.ReadLine() ?? "";
                if (Framework.textInput.ToLower() == "leave" && Framework.ContainsProcess(processName: "TMC.exe"))
                {
                    leave.Exec(Framework.textInput);
                    Framework.textInput = "";
                    loop = true;
                    continue;
                }
                if (isCommand) Framework.CommandHandler(commandRequired);
                if (Framework.InputHandlerExitCases()) return;
            } while (string.IsNullOrEmpty(Framework.textInput) && commandRequired || loop);
        }
    }
}