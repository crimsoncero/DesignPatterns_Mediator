
namespace DesignPatterns_Mediator
{
    public class AbstractChatter
    {
        public string Name { get; private set; }

        public Chatroom Chatroom { get; set; }


        public AbstractChatter(string name, Chatroom chatroom)
        {
            Name = name;
            Chatroom = chatroom;

            chatroom.Register(this);
        }


        public void SendMessage(string message)
        {
           Chatroom.SendAll(Name, message);
        }

        public void SendDirectMessage(string message, string to)
        {
            Chatroom.SendDirect(Name, to, message);
        }

        public virtual void Recieve(string from, string message, bool isDirect)
        {
            if(isDirect)
            {
                Console.Write("PRIVATE: ");
            }
            Console.WriteLine($"{Name} recieved message from {from} : \"{message}\"");
        }
    }
}
