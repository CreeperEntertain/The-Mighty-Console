using The_Mighty_Console.Resources.GameData.Lists;

namespace The_Mighty_Console.Resources.Chapters.First.Sub.FormalitiesSub
{
    internal class EyeColor
    {
        private Framework Framework => Framework.Instance;
        public void eyeColor() => CommonEyeColor();
        private void CommonEyeColor()
        {
            PrintEyeColorDialogue("CommonRequest.txt");
            List<string> commonEyeColors = CommonEyeColors.GetItems();
            int chosen = Framework.PlayerChoice(commonEyeColors, false, 0, true, true, ConsoleColor.White, true);
            if (chosen >= commonEyeColors.Count - 1) MediumEyeColor();
            else CommonResponse(chosen, commonEyeColors);
        }
        private void MediumEyeColor()
        {
            PrintEyeColorDialogue("MediumRequest.txt");
            List<string> mediumEyeColors = MediumEyeColors.GetItems();
            int chosen = Framework.PlayerChoice(mediumEyeColors, false, 0, true, true, ConsoleColor.White, true);
            if (chosen >= mediumEyeColors.Count - 1) RareEyeColor();
            else MediumResponse(chosen, mediumEyeColors);
        }
        private void RareEyeColor()
        {
            PrintEyeColorDialogue("RareRequest.txt");
            List<string> rareEyeColors = RareEyeColors.GetItems();
            int chosen = Framework.PlayerChoice(rareEyeColors, false, 0, true, true, ConsoleColor.White, true);
            if (chosen >= rareEyeColors.Count - 1) OptionsExhaustedResponse();
            else RareResponse(chosen, rareEyeColors);
        }
        private void OptionsExhaustedResponse()
        {
            Framework.eyeColor = "Unusual";
            Console.ForegroundColor = ConsoleColor.Red;
            PrintEyeColorDialogue("UnusualResponse.txt");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void RareResponse(int chosen, List<string> rareEyeColors)
        {
            Framework.eyeColor = rareEyeColors[chosen];
            Console.ForegroundColor = ConsoleColor.Red;
            Framework.DelayedPrint($"Oh really? {Framework.eyeColor}?");
            Framework.DelayedPrint("So, you're a rare one...");
            Framework.DelayedPrint("You really don't often come across someone with eyes like yours.");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void MediumResponse(int chosen, List<string> mediumEyeColors)
        {
            Framework.eyeColor = mediumEyeColors[chosen];
            Console.ForegroundColor = ConsoleColor.Red;
            Framework.DelayedPrint($"So, {Framework.eyeColor.ToLower()}?");
            Framework.DelayedPrint("Unexpected, but welcome.");
            Framework.DelayedPrint("Stored, comrade.");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void CommonResponse(int chosen, List<string> commonEyeColors)
        {
            Framework.eyeColor = commonEyeColors[chosen];
            Console.ForegroundColor = ConsoleColor.Red;
            Framework.DelayedPrint($"Ah, {Framework.eyeColor.ToLower()} - practical and familiar.");
            Framework.DelayedPrint("Noted, comrade.");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void PrintEyeColorDialogue(string dotPath) => Framework.PrintStoryDialogue($"Resources.Tables.Dialogue.First.Formalities.EyeColor.{dotPath}");
    }
}