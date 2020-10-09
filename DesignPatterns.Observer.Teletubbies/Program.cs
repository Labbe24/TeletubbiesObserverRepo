namespace DesignPatterns.Observer.Teletubbies
{
    public class Program
    {
        static void Main(string[] args)
        {
            BigTelephone provider = new BigTelephone();
            Teletubbie tubbie1 = new Teletubbie("Tinky Winky");
            tubbie1.Subscribe(provider);
            Teletubbie tubbie2 = new Teletubbie("Dipsy");
            tubbie2.Subscribe(provider);
            Teletubbie tubbie3 = new Teletubbie("Laa-Laa");
            tubbie3.Subscribe(provider);
            Teletubbie tubbie4 = new Teletubbie("Po");
            tubbie4.Subscribe(provider);

            provider.Notify(TubbieCommands.Wakeup);
            tubbie1.Unsubscribe();
            provider.Notify(TubbieCommands.Watchtv);
            tubbie2.Unsubscribe();
            provider.Notify(TubbieCommands.Eatdinner);
            provider.Notify(TubbieCommands.Byebye);
            provider.EndCommanding();
        }
    }
}