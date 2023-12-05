using QuickFix;

namespace FIXCommLink.Service
{
    public class FixMessageHandler: MessageCracker
    {
        public void OnMessage(QuickFix.FIX44.NewOrderSingle message, SessionID sessionID)
        {
            // Lógica para lidar com a mensagem NewOrderSingle
        }

        public void OnMessage(QuickFix.FIX44.ExecutionReport message, SessionID sessionID)
        {
            // Lógica para lidar com a mensagem ExecutionReport
        }
    }
}
