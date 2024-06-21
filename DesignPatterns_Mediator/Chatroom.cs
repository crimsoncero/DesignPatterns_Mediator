

namespace DesignPatterns_Mediator
{
    public class Chatroom
    {
        private Dictionary<string,AbstractChatter> _chatters;

        public void Register(AbstractChatter chatter)
        {
            if (!_chatters.ContainsValue(chatter))
            {
                _chatters[chatter.Name] = chatter;
            }

            chatter.Chatroom = this;
        }

        public void SendDirect(string from, string to, string message)
        {
            if (_chatters.ContainsKey(from) && _chatters[from].IsBanned)
                return;
            AbstractChatter chatter = _chatters[to];
            if(chatter != null)
            {
                chatter.Recieve(from,message);
            }
        }

        public void SendAll(string from, string message)
        {
            if (_chatters.ContainsKey(from) && _chatters[from].IsBanned)
                return;
            foreach (var chatter in _chatters)
            {
                if(chatter.Value != null && chatter.Key != from)
                {
                    chatter.Value.Recieve(from, message);
                }
            }
        }

        public void Report(string from, string reportee, string reason)
        {
            if (_chatters.ContainsKey(from) && _chatters[from].IsBanned)
                return;

            foreach(var chatter in _chatters)
            {
                if(chatter.Value is Moderator)
                {
                    (chatter.Value as Moderator).RecieveReport(from, reportee, reason);
                }
            }
        }

    }
}
