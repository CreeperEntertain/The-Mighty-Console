using The_Mighty_Console.Resources.Commands.Classes;

namespace The_Mighty_Console.Resources.FrameworkMethods.IO
{
    internal class TrustManager
    {
        private Framework Framework => Framework.Instance;

        private Shutdown shutdown = new Shutdown();

        public void Exec(int newTrustLevel, bool announce = true)
        {
            ConsoleColor previousTextColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (!Framework.aiTrustLevelRequested)
                Framework.DelayedPrint("TMC has a trust meter that changes depending on your actions.", 0);
            Framework.aiTrustLevelRequested = true;
            if (newTrustLevel < Framework.aiTrustLevel)
                Framework.DelayedPrint("Trust down", 0);
            else if (newTrustLevel > Framework.aiTrustLevel)
                Framework.DelayedPrint("Trust up", 0);
            // No message if nothing changed.
            Framework.aiTrustLevel = newTrustLevel;
            Framework.DelayedPrint($"New trust level: {Framework.aiTrustLevel}", 0);
            if (announce)
                if (Framework.aiTrustLevel < 3)
                    Framework.positiveTrustAnnounced = false;
                if (Framework.aiTrustLevel <= -3)
                    Shutdown();
                else if (Framework.aiTrustLevel >= 3)
                    Announce();
            Console.ForegroundColor = previousTextColor;
        }
        private void Shutdown()
        {
            Framework.PrintStoryDialogue("Resources.Tables.Dialogue.Intermissions.LostTrust.txt");
            shutdown.ShutdownIntermission();
        }
        private void Announce()
        {
            if (!Framework.positiveTrustAnnounced)
            {
                Framework.DelayedPrint("Trust high enough.", 0);
                Framework.positiveTrustAnnounced = true;
            }
        }
    }
}