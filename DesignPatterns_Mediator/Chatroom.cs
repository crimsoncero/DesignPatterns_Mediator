

namespace DesignPatterns_Mediator
{
    public class Chatroom
    {
        private Dictionary<string,AbstractChatter> _chatters;

        private Dictionary<string, string> _banList;
        public Chatroom()
        {
            _chatters = new Dictionary<string,AbstractChatter>();
            _banList = new Dictionary<string,string>();
            ServerChatter server = new ServerChatter("Server", this);
        }


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
            if (!_chatters.ContainsKey(from)) return;
            if (_banList.ContainsKey(from))
            {
                SendDirect("Server", from, "You were banned for: " + _banList[from]);
                return;
            }
            AbstractChatter chatter = _chatters[to];
            if(chatter != null)
            {
                chatter.Recieve(from,message, true);
            }
        }

        public void SendAll(string from, string message)
        {
            if (!_chatters.ContainsKey(from)) return;
            if (_banList.ContainsKey(from))
            {
                SendDirect("Server", from, "You were banned for: " + _banList[from]);
                return;
            }
            foreach (var chatter in _chatters)
            {
                if(chatter.Value != null && chatter.Key != from)
                {
                    chatter.Value.Recieve(from, message, false);
                }
            }
        }

        public void Report(string from, string reportee, string reason)
        {
            if (!_chatters.ContainsKey(from)) return;
            if (_banList.ContainsKey(from))
            {
                SendDirect("Server", from, "You were banned for: " + _banList[from]);
                return;
            }

            foreach (var chatter in _chatters)
            {
                if(chatter.Value is Moderator)
                {
                    (chatter.Value as Moderator).RecieveReport(from, reportee, reason);
                }
            }
        }

        public void BanChatter(string name, string reason)
        {
            if (_banList.ContainsKey(name)) return;

            _banList.Add(name, reason);
        }

    }
}
