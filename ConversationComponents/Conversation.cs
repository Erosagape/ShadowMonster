using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace ShadowMonster.ConversationComponents
{
    public class Conversation
    {
        private string name;
        public string Name
        {
            get { return name; }
        }
        private string firstScene;
        public string FirstScene
        {
            get { return firstScene; }
        }
        private string currentScene;
        public GameScene CurrentScene
        {
            get
            {
                if (!string.IsNullOrEmpty(currentScene) && scenes.ContainsKey(currentScene))
                    return scenes[currentScene];
                return null;
            }
        }
        private readonly Dictionary<string, GameScene> scenes;
        public Dictionary<string,GameScene> Scenes
        {
            get { return scenes; }
        }
        private string backgroundName;
        public string BackgroundName
        {
            get { return backgroundName; }
            set { backgroundName = value; }
        }
        private Texture2D background;
        public Texture2D Background
        {
            get { return background; }
        }

        private Conversation()
        {
            scenes = new Dictionary<string, GameScene>();
        }
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
        {
            if (!scenes.ContainsKey(sceneName))
            {
                scenes.Add(sceneName, scene);
            }
        }
        public void RemoveScene(string optionText)
        {
            scenes.Remove(optionText);
        }
        public GameScene GetScene(string sceneName)
        {
            return scenes.ContainsKey(sceneName) ? scenes[sceneName] : null;
        }
        public void StartConversation()
        {
            currentScene = firstScene;
        }
        public void ChangeScene(string sceneName)
        {
            currentScene = sceneName;
        }
    }
}
