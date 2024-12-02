using The_Mighty_Console.Resources;
using The_Mighty_Console.Resources.Chapters.First;
using The_Mighty_Console.Resources.Chapters.Intro;

namespace The_Mighty_Console
{
    class Program
    {
        private static Framework Framework => Framework.Instance;

        private static AppControl appControl = new AppControl();

        private static Intro intro = new Intro();
        private static First first = new First();

        static void Main(string[] args)
        {
            appControl.LaunchCheck(args);
            appControl.BufferSetter();
            appControl.ExitKeybindInhibitor();
            appControl.ConsoleInitializer();

            //intro.Exec();
            if (Framework.skippedIntro) appControl.ChapterFirstGameState();
            first.Exec();

            Framework.PrintStoryDialogue("Resources.Tables.Dialogue.Intermissions.EndOfDemo.txt");
        }
    }
}