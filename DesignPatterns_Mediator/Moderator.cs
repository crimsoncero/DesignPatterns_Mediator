
using System.Security.Cryptography;

namespace DesignPatterns_Mediator
{
    public class Moderator : AbstractChatter
    {
        public Moderator(string name, Chatroom chatroom) : base(name, chatroom) { }


        public void BanChatter(string banned, string reason)
        {
            Chatroom.BanChatter(banned, reason);

        }

        public void RecieveReport(string reporter, string reportee, string reason)
        {
            if (reason == "A Good Enough Reason")
                BanChatter(reportee, reason);
        }
    }
}
