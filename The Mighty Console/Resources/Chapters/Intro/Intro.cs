using The_Mighty_Console.Resources.Chapters.Intro.Sub;

namespace The_Mighty_Console.Resources.Chapters.Intro
{
    public class Intro
    {
        private Framework Framework => Framework.Instance;

        private Prelog Prelog = new Prelog();
        private Boot Boot = new Boot();
        private FirstRequest FirstRequest = new FirstRequest();
        
        public void Exec()
        {
            Prelog.PrelogExec();
            Boot.BootExec();
            FirstRequest.FirstRequestExec();
            Framework.PrintStoryDialogue("Resources.Tables.Dialogue.Intermissions.IntroCompleted.txt");
        }
    }
}