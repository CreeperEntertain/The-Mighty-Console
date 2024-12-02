namespace The_Mighty_Console.Resources.FrameworkMethods.VariableManagement
{
    internal class RemoveDuplicates
    {
        private Framework Framework => Framework.Instance;
        public List<string> Exec(List<string> inputList)
        {
            HashSet<string> uniqueItems = new HashSet<string>(inputList);
            return uniqueItems.ToList();
        }
    }
}