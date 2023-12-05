using FIXCommLink.Service;
using QuickFix;
using QuickFix.Transport;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=============");
        Console.WriteLine("This is only an example program.");
        Console.WriteLine("It's a simple server (e.g. Acceptor) app that will let clients (e.g. Initiators)");
        Console.WriteLine("connect to it.  It will accept and display any application-level messages that it receives.");
        Console.WriteLine("Port is 5001.");
        Console.WriteLine("(see Session.cfg for configuration details)");
        Console.WriteLine("=============");

        if (args.Length != 1)
        {
            Console.WriteLine("usage: SimpleAcceptor CONFIG_FILENAME");
            System.Environment.Exit(2);
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
            Console.ReadKey();
            initiator.Stop();
        }
        catch (System.Exception e)
        {
            Console.WriteLine("==FATAL ERROR==");
            Console.WriteLine(e.ToString());
        }
    }





}