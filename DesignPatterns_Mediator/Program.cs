
using DesignPatterns_Mediator;

Chatroom chatroom = new Chatroom();

Moderator mod1 = new Moderator("Dor Ben Dor", chatroom);
Player player1 = new Player("Ido Folkman", chatroom);
Player player2 = new Player("Max", chatroom);

player1.SendMessage("Hello");
mod1.SendDirectMessage("Stop it", "Ido Folkman");
player2.Report("Ido Folkman", "A Good Enough Reason");
player1.SendMessage("Can you hear me?");