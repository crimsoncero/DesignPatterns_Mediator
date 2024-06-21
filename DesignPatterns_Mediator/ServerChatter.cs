

namespace DesignPatterns_Mediator
{
    public class ServerChatter : AbstractChatter
    {
        public ServerChatter(string name, Chatroom chatroom) : base(name, chatroom)
        {
        }

        public override void Recieve(string from, string message, bool isDirect)
        {
            return;
        }
    }
}
