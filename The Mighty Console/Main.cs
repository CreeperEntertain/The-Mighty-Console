using The_Mighty_Console.Resources;
using The_Mighty_Console.Resources.Chapters.First;
using The_Mighty_Console.Resources.Chapters.Intro;
using The_Mighty_Console.Resources.Chapters.Second;

namespace The_Mighty_Console
{
    class Program
    {
        private static Framework Framework => Framework.Instance;

        private static AppControl appControl = new AppControl();

        static void Main(string[] args)
        {
            appControl.LaunchCheck(args);
            appControl.BufferSetter();
            appControl.ExitKeybindInhibitor();
            appControl.ConsoleInitializer();

            //new Intro().Exec();
            if (Framework.skippedIntro) appControl.ChapterFirstGameState();
            //new First().Exec();
            if (Framework.skippedFirst) appControl.ChapterSecondGameState();
            new Second().Exec();
            if (Framework.skippedSecond) appControl.ChapterThirdGameState();

            Framework.PrintStoryDialogue("Resources.Tables.Dialogue.Intermissions.EndOfDemo.txt");
        }
    }
}