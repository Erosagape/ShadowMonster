using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShadowMonsters;

namespace ShadowMonsters.ConversationComponents
{
    public class GameScene
    {
        protected Game game;
        protected string text;
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        private List<SceneOption> options;
        public List<SceneOption> Options
        {
            get { return options; }
            set { value = options; }
        }
        public SceneAction OptionAction
        {
            get { return options[selectedIndex].OptionAction; }
        }
        public string OptionText
        {
            get { return options[selectedIndex].OptionText; }
        }
        public string OptionScene
        {
            get { return options[selectedIndex].OptionScene; }
        }
        private int selectedIndex;
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set { selectedIndex = MathHelper.Clamp(value,0,options.Count-1); }
        }
        private Color highLight;
        public Color HighLightColor
        {
            get { return highLight; }
            set { highLight = value; }
        }
        private Color normal;
        public Color NormalColor
        {
            get { return normal; }
            set { normal = value; }
        }
        private Vector2 textPosition;
        private bool isMouseOver;
        public bool IsMouseOver
        {
            get { return isMouseOver; }
        }
        private Vector2 menuPosition = new Vector2(50f, 275f);
        public Vector2 MenuPosition
        {
            get { return menuPosition; }
        }
        private GameScene()
        {
            normal = Color.Blue;
            highLight = Color.Red;
            options = new List<SceneOption>();
            menuPosition = new Vector2(50f, 275f);
        }
        public GameScene(string text,List<SceneOption> options)
            : this()
        {
            this.text = text;
            this.options = options;
            textPosition = Vector2.Zero;
        }
        public GameScene(Game game,string text,List<SceneOption> options)
            : this(text, options)
        {
            this.game = game;
        }
        public void SetText(string text)
        {
            textPosition = new Vector2(250, 50);
            StringBuilder sb = new StringBuilder();
            float currentLength = 0f;
            string[] parts = text.Split(' ');
            foreach(string s in parts)
            {
                Vector2 size = FontManager.GetFont("test").MeasureString(s);
                if(currentLength+size.X < 150f)
                {
                    sb.Append(s);                    
                    currentLength += size.X;
                }
                else
                {
                    sb.Append("\n\r");
                    sb.Append(s);
                    currentLength = 0;
                }
                sb.Append(" ");
            }
            this.text = sb.ToString();
        }
        public void Initialize()
        {

        }
        public void Update()
        {
            if(Xin.CheckKeyReleased(Keys.Up) || Xin.CheckKeyReleased(Keys.W))
            {
                selectedIndex--;
                if (selectedIndex < 0)
                {
                    selectedIndex = options.Count - 1;
                }
            } else if(Xin.CheckKeyReleased(Keys.Down) || Xin.CheckKeyReleased(Keys.S))
            {
                selectedIndex++;
                if(selectedIndex > options.Count - 1)
                {
                    selectedIndex = 0;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch,Texture2D background)
        {
            Color myColor;
            if (textPosition == Vector2.Zero)
            {
                SetText(text);
            }
            if (background != null)
            {
                spriteBatch.Draw(background, Vector2.Zero, Color.White);
            }

            spriteBatch.DrawString(FontManager.GetFont("test"), text, textPosition, Color.White);

            Vector2 position = menuPosition;

            Rectangle optionRect = new Rectangle(0, (int)position.Y, 480, FontManager.GetFont("test").LineSpacing);
            isMouseOver = false;
            for(int i = 0; i < options.Count - 1; i++)
            {
                if (optionRect.Contains(Xin.MouseState.Position))
                {
                    selectedIndex = 1;
                    isMouseOver = true;
                }
                if (i == selectedIndex)
                {
                    myColor = HighLightColor;
                }
                else
                {
                    myColor = NormalColor;
                }
                spriteBatch.DrawString(FontManager.GetFont("test"), options[i].OptionText, position, myColor);
                position.Y += FontManager.GetFont("test").LineSpacing + 5;
                optionRect.Y += FontManager.GetFont("test").LineSpacing + 5;
            }
        }
    }
}
