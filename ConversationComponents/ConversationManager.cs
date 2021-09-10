<<<<<<< HEAD
﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

=======
﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
namespace ShadowMonsters.ConversationComponents
{
    public class ConversationManager
    {
<<<<<<< HEAD
        #region Field Region
        private static ConversationManager instance = new ConversationManager();
        private Dictionary<string, Conversation> conversationList = new Dictionary<string, Conversation>();

        #endregion

        #region Property Region

=======
        private static ConversationManager instance = new ConversationManager();
        private Dictionary<string, Conversation> conversationList = new Dictionary<string, Conversation>();
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        public static ConversationManager Instance
        {
            get { return instance; }
            set { instance = value; }
        }
<<<<<<< HEAD

        public Dictionary<string, Conversation> ConversationList
=======
        public Dictionary<string,Conversation> ConversationList
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        {
            get { return conversationList; }
            private set { conversationList = value; }
        }
<<<<<<< HEAD

        #endregion

        #region Constructor Region

        private ConversationManager()
        {
        }

        #endregion

        #region Method Region
        public void AddConversation(string name, Conversation conversation)
        {
            if (!conversationList.ContainsKey(name))
                conversationList.Add(name, conversation);
        }

=======
        private ConversationManager()
        {

        }
        public void AddConversation(string name,Conversation conver)
        {
            if (!conversationList.ContainsKey(name))
                conversationList.Add(name, conver);
        }
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        public Conversation GetConversation(string name)
        {
            if (conversationList.ContainsKey(name))
                return conversationList[name];
<<<<<<< HEAD

            return null;
        }

=======
            return null;
        }
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        public bool ContainsConversation(string name)
        {
            return conversationList.ContainsKey(name);
        }
<<<<<<< HEAD

=======
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        public void ClearConversations()
        {
            conversationList = new Dictionary<string, Conversation>();
        }
<<<<<<< HEAD

        public void CreateConversations(Game gameRef)
        {
            ConversationList.Clear();
=======
        public void CreateConversations(Game gameRef)
        {
            conversationList.Clear();
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
            Conversation c = new Conversation("PaulHello", "Hello")
            {
                BackgroundName = "scenebackground",
            };
<<<<<<< HEAD

=======
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
            List<SceneOption> options = new List<SceneOption>();
            SceneOption teach = new SceneOption(
                "Teach",
                "Teach",
<<<<<<< HEAD
                new SceneAction() { Action = ActionType.Teach, Parameter = "none" });
            options.Add(teach);

            SceneOption rest = new SceneOption(
                "Rest",
                "Rest",
                new SceneAction { Action = ActionType.Rest, Parameter = "none" });
            options.Add(rest);

            SceneOption option = new SceneOption(
                "Good bye.",
                "",
                new SceneAction() { Action = ActionType.End, Parameter = "none" });
=======
                new SceneAction() { Action=ActionType.Teach,Parameter="none"}
                );
            options.Add(teach);
            SceneOption option = new SceneOption(
                "Good bye.", "",
                new SceneAction() { Action = ActionType.End, Parameter = "none" }
                );
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
            options.Add(option);

            GameScene scene = new GameScene(
                gameRef,
<<<<<<< HEAD
                "Hello, my name is Paul. I'm still learning about training shadow monsters.",
                options);

            c.AddScene("Hello", scene);

            options = new List<SceneOption>();

            scene = new GameScene(
                gameRef,
                "I have given you Brownie!",
                options);

            option = new SceneOption(
                "Goodbye",
                "",
                new SceneAction() { Action = ActionType.End, Parameter = "none" });

            options.Add(option);
            c.AddScene("Teach", scene);

            options = new List<SceneOption>();

            scene = new GameScene(
                gameRef,
                "I have restored your shadow monsters' health.",
                options);
            options.Add(option);

            option = new SceneOption(
                "Goodbye",
                "",
                new SceneAction() { Action = ActionType.End, Parameter = "none" });

            c.AddScene("Rest", scene);
            
            ConversationList.Add("PaulHello", c);

            c = new Conversation("BonnieHello", "Hello");

            options = new List<SceneOption>();

            option = new SceneOption(
                "Shop",
                "",
                new SceneAction() { Action = ActionType.Shop, Parameter = "none" });

            options.Add(option);

            option = new SceneOption(
                "Goodbye",
                "",
                new SceneAction() { Action = ActionType.End, Parameter = "none" });

            options.Add(option);

            scene = new GameScene(
                gameRef,
                "Hi! I'm Bonnie. Feel free to browse my wares.",
                options);

            c.AddScene("Hello", scene);
            ConversationList.Add("BonnieHello", c);
        }

        #endregion
    }
}
=======
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
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
