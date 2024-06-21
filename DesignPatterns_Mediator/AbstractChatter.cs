
namespace DesignPatterns_Mediator
{
    public class AbstractChatter
    {
        public string Name { get; private set; }

        public Chatroom Chatroom { get; set; }

        public bool IsBanned { get; set; }

        public AbstractChatter(string name)
        {
            Name = name;
        }


        public void SendMessage(string message)
        {
           
        }

        public void SendDirectMessage(string message, AbstractChatter recipiant)
        {

        }

        public void Recieve(string from, string message)
        {
            Console.WriteLine($"{Name} recieved message from {from} : \"{message}\"");
        }
    }
}
