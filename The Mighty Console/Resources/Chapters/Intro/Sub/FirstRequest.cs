namespace The_Mighty_Console.Resources.Chapters.Intro.Sub
{
    internal class FirstRequest
    {
        private Framework Framework => Framework.Instance;
        public void FirstRequestExec()
        {
            Framework.InfoPrint("You've got mail. Type MAIL to view.");
            ConsoleStorage.Instance.ResumeRecording();
            Framework.InputHandler(true, true);
            ConsoleStorage.Instance.PauseRecording();
        }
    }
}