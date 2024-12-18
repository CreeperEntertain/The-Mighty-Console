﻿using The_Mighty_Console.Resources.Chapters.First.Sub;

namespace The_Mighty_Console.Resources.Chapters.First
{
    internal class First
    {
        private Framework Framework => Framework.Instance;

        private Formalities formalities = new Formalities();
        private FormFlicker formFlicker = new FormFlicker();

        public void Exec()
        {
            ConsoleStorage.Instance.ResumeRecording();
            formalities.Exec();
            formalities.RespondWithDataPoints();
            formFlicker.Exec();
            Framework.PrintStoryDialogue("Resources.Tables.Dialogue.Intermissions.FirstCompleted.txt");
            ConsoleStorage.Instance.PauseRecording();
        }
    }
}