using The_Mighty_Console.Resources.Commands.Classes;

namespace The_Mighty_Console.Resources.FrameworkMethods.IO
{
    internal class TrustManager
    {
        private Framework Framework => Framework.Instance;

        private Shutdown shutdown = new Shutdown();

        public void Exec(int newTrustLevel, bool announce = true)
        {
            if (!Framework.aiTrustLevelRequested)
                Framework.InfoPrint("TMC has a trust meter that changes depending on your actions.");
            Framework.aiTrustLevelRequested = true;
            if (newTrustLevel < Framework.aiTrustLevel)
                Framework.InfoPrint("Trust down");
            else if (newTrustLevel > Framework.aiTrustLevel)
                Framework.InfoPrint("Trust up");
            // No message if nothing changed.
            Framework.aiTrustLevel = newTrustLevel;
            Framework.InfoPrint($"New trust level: {Framework.aiTrustLevel}");
            if (announce)
                if (Framework.aiTrustLevel < 3)
                    Framework.positiveTrustAnnounced = false;
                if (Framework.aiTrustLevel <= 3)
                    Shutdown();
                else if (Framework.aiTrustLevel >= 3)
                    Announce();
        }
        private void Shutdown()
        {
            // TODO: Implement trust decrease dialogue.
            shutdown.ShutdownIntermission();
        }
        private void Announce()
        {
            if (!Framework.positiveTrustAnnounced)
            {
                Framework.InfoPrint("Trust high enough.");
                Framework.positiveTrustAnnounced = true;
            }
        }
    }
}