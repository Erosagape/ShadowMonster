using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
namespace ShadowMonsters.ConversationComponents
{
    public class ConversationManager
    {
        private static ConversationManager instance = new ConversationManager();
        private Dictionary<string, Conversation> conversationList = new Dictionary<string, Conversation>();
        public static ConversationManager Instance
        {
            get { return instance; }
            set { instance = value; }
        }
        public Dictionary<string,Conversation> ConversationList
        {
            get { return conversationList; }
            private set { conversationList = value; }
        }
        private ConversationManager()
        {

        }
        public void AddConversation(string name,Conversation conver)
        {
            if (!conversationList.ContainsKey(name))
                conversationList.Add(name, conver);
        }
        public Conversation GetConversation(string name)
        {
            if (conversationList.ContainsKey(name))
                return conversationList[name];
            return null;
        }
        public bool ContainsConversation(string name)
        {
            return conversationList.ContainsKey(name);
        }
        public void ClearConversations()
        {
            conversationList = new Dictionary<string, Conversation>();
        }
        public void CreateConversations(Game gameRef)
        {
            conversationList.Clear();
            Conversation c = new Conversation("PaulHello", "Hello")
            {
                BackgroundName = "scenebackground",
            };
            List<SceneOption> options = new List<SceneOption>();
            SceneOption teach = new SceneOption(
                "Teach",
                "Teach",
                new SceneAction() { Action=ActionType.Teach,Parameter="none"}
                );
            options.Add(teach);
            SceneOption option = new SceneOption(
                "Good bye.", "",
                new SceneAction() { Action = ActionType.End, Parameter = "none" }
                );
            options.Add(option);

            GameScene scene = new GameScene(
                gameRef,
                "Hello, My Name is Paul,I'm still learning how to capture monster",
                options
                );
            c.AddScene("Hello", scene);

            options = new List<SceneOption>();
            scene = new GameScene(
                gameRef,
                "I have given you Brownie!",
                options
                );
            option = new SceneOption(
                "Good bye",
                "",
                new SceneAction() { Action=ActionType.End,Parameter="none"}
                );
            options.Add(option);
            c.AddScene("Teach", scene);
            conversationList.Add("PaulHello", c);
        }
    }
}
