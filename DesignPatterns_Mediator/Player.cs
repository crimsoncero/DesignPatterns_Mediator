

namespace DesignPatterns_Mediator
{
    public class Player : AbstractChatter
    {
        public Player(string name, Chatroom chatroom) : base(name, chatroom) { }

        public void Report(string reported, string reason)
        {
            Chatroom.Report(Name, reported, reason);
        }

    }
}
