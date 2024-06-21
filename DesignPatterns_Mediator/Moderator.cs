
using System.Security.Cryptography;

namespace DesignPatterns_Mediator
{
    public class Moderator : AbstractChatter
    {
        public Moderator(string name, Chatroom chatroom) : base(name, chatroom) { }


        public void BanChatter(string banned)
        {
            



        }

        public void RecieveReport(string reporter, string reportee, string reason)
        {
            if (reason == "good enough")
                BanChatter(reportee);
        }
    }
}
