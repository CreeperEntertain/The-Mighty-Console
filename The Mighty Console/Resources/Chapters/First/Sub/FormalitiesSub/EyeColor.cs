using The_Mighty_Console.Resources.GameData.Lists;

namespace The_Mighty_Console.Resources.Chapters.First.Sub.FormalitiesSub
{
    internal class EyeColor
    {
        private Framework Framework => Framework.Instance;
        public void eyeColor() => CommonEyeColor();
        private void CommonEyeColor() => DecideReaction("CommonRequest.txt", CommonEyeColors.GetItems(), CommonResponse, MediumEyeColor);
        private void MediumEyeColor() => DecideReaction("MediumRequest.txt", MediumEyeColors.GetItems(), MediumResponse, RareEyeColor);
        private void RareEyeColor() => DecideReaction("RareRequest.txt", RareEyeColors.GetItems(), RareResponse, OptionsExhaustedResponse);
        private void DecideReaction(string dotPath, List<string> eyeColors, Action<int, List<string>> CurrentResponse, Action NextResponse)
        {
            PrintEyeColorDialogue(dotPath);
            int chosen = Choice(eyeColors);
            if (chosen >= eyeColors.Count - 1)
                NextResponse();
            else CurrentResponse(chosen, eyeColors);
        }

        private void OptionsExhaustedResponse()
        {
            Framework.eyeColor = "Unusual";
            Console.ForegroundColor = ConsoleColor.Red;
            PrintEyeColorDialogue("UnusualResponse.txt");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void RareResponse(int chosen, List<string> rareEyeColors)
            => Responses(chosen, rareEyeColors, new List<string> {
                $"Oh really? {Framework.eyeColor ?? "Violet"}?",
                "So, you're a rare one...",
                "You really don't often come across someone with eyes like yours." });
        private void MediumResponse(int chosen, List<string> mediumEyeColors)
            => Responses(chosen, mediumEyeColors, new List<string> {
                $"So, {(Framework.eyeColor ?? "Amber").ToLower()}?",
                "Unexpected, but welcome.",
                "Stored, comrade." });
        private void CommonResponse(int chosen, List<string> commonEyeColors)
            => Responses(chosen, commonEyeColors, new List<string> {
                $"Ah, {(Framework.eyeColor ?? "Brown").ToLower()} - practical and familiar.",
                "Noted, comrade." });

        private void Responses(int chosen, List<string> eyeColors, List<string> output)
        {
            Framework.eyeColor = eyeColors[chosen];
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (string index in output)
                Framework.DelayedPrint(index);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private int Choice(List<string> options) => Framework.PlayerChoice(options, false, 0, true, true, ConsoleColor.White, true);
        private void PrintEyeColorDialogue(string dotPath) => Framework.PrintStoryDialogue($"Resources.Tables.Dialogue.First.Formalities.EyeColor.{dotPath}");
    }
}