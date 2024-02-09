namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SoulMaster master = new SoulMaster("zavulon", 20);

            System.Console.WriteLine(master);
        }
    }
}