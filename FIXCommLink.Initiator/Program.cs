using FIXCommLink.Service;
using QuickFix;
using QuickFix.Transport;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Environment.Exit(2);
        }

        try
        {
            SessionSettings settings = new SessionSettings(args[0]);
            IMessageStoreFactory storeFactory = new FileStoreFactory(settings);
            ILogFactory logFactory = new FileLogFactory(settings);
            IMessageFactory messageFactory = new DefaultMessageFactory();

            SocketInitiator initiator = new SocketInitiator(
                new FixAcceptorService(),
                storeFactory,
                settings,
                logFactory,
                messageFactory
            );

            initiator.Start();
            Console.WriteLine("Precione <enter> para sair");
            Console.ReadKey();
            initiator.Stop();
        }
        catch (System.Exception e)
        {
            Console.WriteLine("Ocorreu um erro!");
            Console.WriteLine(e.ToString());
        }
    }





}