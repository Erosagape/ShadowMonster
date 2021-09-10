<<<<<<< HEAD
﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
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
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
namespace ShadowMonsters.ConversationComponents
{
    public class Conversation
    {
<<<<<<< HEAD
        #region Field Region

        private string name;
        private string firstScene;
        private string currentScene;
        private readonly Dictionary<string, GameScene> scenes;
        private string backgroundName;
        private Texture2D background;

        #endregion

        #region Property Region

=======
        private string name;
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        public string Name
        {
            get { return name; }
        }
<<<<<<< HEAD

=======
        private string firstScene;
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        public string FirstScene
        {
            get { return firstScene; }
        }
<<<<<<< HEAD

        [ContentSerializerIgnore]
=======
        private string currentScene;
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        public GameScene CurrentScene
        {
            get
            {
                if (!string.IsNullOrEmpty(currentScene) && scenes.ContainsKey(currentScene))
                    return scenes[currentScene];
                return null;
            }
        }
<<<<<<< HEAD

        public Dictionary<string, GameScene> Scenes
        {
            get { return scenes; }
        }

=======
        private readonly Dictionary<string, GameScene> scenes;
        public Dictionary<string,GameScene> Scenes
        {
            get { return scenes; }
        }
        private string backgroundName;
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        public string BackgroundName
        {
            get { return backgroundName; }
            set { backgroundName = value; }
        }
<<<<<<< HEAD

        [ContentSerializerIgnore]
=======
        private Texture2D background;
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        public Texture2D Background
        {
            get { return background; }
        }

<<<<<<< HEAD
        #endregion

        #region Constructor Region

=======
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        private Conversation()
        {
            scenes = new Dictionary<string, GameScene>();
        }
<<<<<<< HEAD

        public Conversation(string name, string firstScene)
        {
            this.scenes = new Dictionary<string, GameScene>();
            this.name = name;
            this.firstScene = firstScene;
        }

        #endregion

        #region Method Region

        public void LoadContent(ContentManager conetnt)
        {
            background = conetnt.Load<Texture2D>(@"Textures\" + BackgroundName);
        }

        public void RemoveScene(string optionText)
        {
            scenes.Remove(optionText);
        }

        public void Update()
        {
            if (CurrentScene != null)
            {
                CurrentScene.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (CurrentScene != null)
            {
                CurrentScene.Draw(spriteBatch, background);
            }
        }

        public void AddScene(string sceneName, GameScene scene)
=======
        public Conversation(string name,string firstScene)
            :this()
        {
            this.name = name;
            this.firstScene = firstScene;
        }
        public void LoadContent(ContentManager content)
        {
            background = content.Load<Texture2D>("Textures/" + backgroundName);
        }
        public void Update()
        {
            if (CurrentScene != null)
                CurrentScene.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (CurrentScene != null)
                CurrentScene.Draw(spriteBatch, background);
        }
        public void AddScene(string sceneName,GameScene scene)
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        {
            if (!scenes.ContainsKey(sceneName))
            {
                scenes.Add(sceneName, scene);
            }
        }
<<<<<<< HEAD

=======
        public void RemoveScene(string optionText)
        {
            scenes.Remove(optionText);
        }
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        public GameScene GetScene(string sceneName)
        {
            return scenes.ContainsKey(sceneName) ? scenes[sceneName] : null;
        }
<<<<<<< HEAD

=======
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        public void StartConversation()
        {
            currentScene = firstScene;
        }
<<<<<<< HEAD

=======
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        public void ChangeScene(string sceneName)
        {
            currentScene = sceneName;
        }
<<<<<<< HEAD
        #endregion
=======
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
    }
}
