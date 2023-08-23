namespace LogWork
{
    class Program
    {
        public static void Main(string[] args)
        {
            string issueNumber = args[0];
            string timeSpent = args[1];

            LogWork.LogWorkOnJira(issueNumber, timeSpent).GetAwaiter().GetResult();
        }
    }
}