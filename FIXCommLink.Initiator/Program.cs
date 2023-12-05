using FIXCommLink.Service;
using QuickFix;
using QuickFix.Transport;

class Program
{
    static void Main(string[] args)
    {
        SessionSettings settings = new SessionSettings("YourInitiatorConfigFile.cfg");
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
}