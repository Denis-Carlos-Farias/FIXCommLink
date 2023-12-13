using QuickFix;

namespace FIXCommLink.Service;

public class FixInitiatorService : MessageCracker, IApplication
{
    public void OnMessage(QuickFix.FIX44.NewOrderSingle message, SessionID sessionID) { }

    public void OnMessage(QuickFix.FIX44.ExecutionReport message, SessionID sessionID) { }

    public void OnCreate(SessionID sessionID)
    {
        Console.WriteLine("Sessão criada: " + sessionID.ToString());
    }

    public void OnLogon(SessionID sessionID)
    {
        Console.WriteLine("Logon recebido para a sessão: " + sessionID.ToString());
    }

    public void OnLogout(SessionID sessionID)
    {
        Console.WriteLine("Logout recebido para a sessão: " + sessionID.ToString());
    }
    public void FromAdmin(Message message, SessionID sessionID) { }
    public void ToAdmin(Message message, SessionID sessionID) { }
    public void FromApp(Message message, SessionID sessionID) { }
    public void ToApp(Message message, SessionID sessionID) { }
}
