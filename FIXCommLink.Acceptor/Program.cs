using FIXCommLink.Service;
using QuickFix;

class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Environment.Exit(2);
        }

        try
        {
            SessionSettings settings = new SessionSettings(args[0]);
            IApplication app = new FixAcceptorService();
            IMessageStoreFactory storeFactory = new FileStoreFactory(settings);
            ILogFactory logFactory = new FileLogFactory(settings);
            IAcceptor acceptor = new ThreadedSocketAcceptor(
                app,
                storeFactory,
                settings,
                logFactory
            );

            acceptor.Start();
            Console.WriteLine("Precione <enter> para sair");
            Console.Read();
            acceptor.Stop();
        }
        catch (System.Exception e)
        {
            Console.WriteLine("Ocorreu um erro!");
            Console.WriteLine(e.ToString());
        }
    }
}