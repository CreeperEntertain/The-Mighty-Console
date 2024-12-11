#pragma warning disable CA1416
namespace The_Mighty_Console.Resources.FrameworkMethods.IO
{
    internal class Beep
    {
        public void Exec()
        {
            for (int i = 0; i < 3; i++)
                Console.Beep(1000, 25);
        }
    }
}