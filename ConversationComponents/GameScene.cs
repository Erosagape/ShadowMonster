<<<<<<< HEAD
﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShadowMonsters;
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b

namespace ShadowMonsters.ConversationComponents
{
    public class GameScene
    {
<<<<<<< HEAD
        #region Field Region

        protected Game game;
        protected string text;
        private List<SceneOption> options;
        private int selectedIndex;
        private Color highLight;
        private Color normal;
        private Vector2 textPosition;
        private bool isMouseOver;

        private Vector2 menuPosition = new Vector2(50f, Settings.Resolution.Y * .75f);

        #endregion

        #region Property Region

=======
        protected Game game;
        protected string text;
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
<<<<<<< HEAD

        public List<SceneOption> Options
        {
            get { return options; }
            set { options = value; }
        }

        public SceneAction OptionAction
        {
            get { return options[SelectedIndex].OptionAction; }
        }

        public string OptionScene
        {
            get { return options[SelectedIndex].OptionScene; }
        }

        public string OptionText
        {
            get { return options[SelectedIndex].OptionText; }
        }

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set { selectedIndex = MathHelper.Clamp(value, 0, options.Count - 1); }
        }

        public bool IsMouseOver
        {
            get { return isMouseOver; }
        }

=======
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
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        public Color NormalColor
        {
            get { return normal; }
            set { normal = value; }
        }
<<<<<<< HEAD

        public Color HighLightColor
        {
            get { return highLight; }
            set { highLight = value; }
        }

=======
        private Vector2 textPosition;
        private bool isMouseOver;
        public bool IsMouseOver
        {
            get { return isMouseOver; }
        }
        private Vector2 menuPosition = new Vector2(50, 475);
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        public Vector2 MenuPosition
        {
            get { return menuPosition; }
        }
<<<<<<< HEAD

        #endregion

        #region Constructor Region

        private GameScene()
        {
            NormalColor = Color.Blue;
            HighLightColor = Color.Red;
            options = new List<SceneOption>();
            menuPosition = new Vector2(50f, Settings.Resolution.Y * .75f);
        }

        public GameScene(string text, List<SceneOption> options)
=======
        private GameScene()
        {
            normal = Color.Blue;
            highLight = Color.Red;
            options = new List<SceneOption>();
        }
        public GameScene(string text,List<SceneOption> options)
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
            : this()
        {
            this.text = text;
            this.options = options;
            textPosition = Vector2.Zero;
        }
<<<<<<< HEAD

        public GameScene(Game game, string text, List<SceneOption> options)
=======
        public GameScene(Game game,string text,List<SceneOption> options)
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
            : this(text, options)
        {
            this.game = game;
        }
<<<<<<< HEAD

        #endregion

        #region Method Region

        public void SetText(string text)
        {
            textPosition = new Vector2(Settings.Resolution.X / 3, 50);

            StringBuilder sb = new StringBuilder();
            float currentLength = 0f;

            string[] parts = text.Split(' ');

            foreach (string s in parts)
            {
                Vector2 size = FontManager.GetFont("testfont").MeasureString(s);

                if (currentLength + size.X < Settings.Resolution.X *  (2 / 3f) - 50f)
                {
                    sb.Append(s);
                    sb.Append(" ");
=======
        public void SetText(string text)
        {
            textPosition = new Vector2(500, 50);
            StringBuilder sb = new StringBuilder();
            float currentLength = 0f;
            string[] parts = text.Split(' ');
            foreach(string s in parts)
            {
                Vector2 size = FontManager.GetFont("testfont").MeasureString(s);
                if(currentLength+size.X < 500f)
                {
                    sb.Append(s);                    
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
                    currentLength += size.X;
                }
                else
                {
                    sb.Append("\n\r");
                    sb.Append(s);
<<<<<<< HEAD
                    sb.Append(" ");
                    currentLength = 0;
                }
            }

            this.text = sb.ToString();
        }

        public void Initialize()
        {
        }

        public void Update()
        {
            if (Xin.CheckKeyReleased(Keys.Up) || Xin.CheckKeyReleased(Keys.W))
=======
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
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
            {
                selectedIndex--;
                if (selectedIndex < 0)
                {
                    selectedIndex = options.Count - 1;
                }
<<<<<<< HEAD
            }
            else if (Xin.CheckKeyReleased(Keys.Down) || Xin.CheckKeyReleased(Keys.S))
            {
                selectedIndex++;
                if (selectedIndex > options.Count - 1)
=======
            } else if(Xin.CheckKeyReleased(Keys.Down) || Xin.CheckKeyReleased(Keys.S))
            {
                selectedIndex++;
                if(selectedIndex > options.Count - 1)
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
                {
                    selectedIndex = 0;
                }
            }
        }
<<<<<<< HEAD

        public void Draw(SpriteBatch spriteBatch, Texture2D background)
        {
            Color myColor;

=======
        public void Draw(SpriteBatch spriteBatch,Texture2D background)
        {
            Color myColor;
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
            if (textPosition == Vector2.Zero)
            {
                SetText(text);
            }
<<<<<<< HEAD

=======
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
            if (background != null)
            {
                spriteBatch.Draw(background, Vector2.Zero, Color.White);
            }

<<<<<<< HEAD
            spriteBatch.DrawString(FontManager.GetFont("testfont"),
                text,
                textPosition,
                Color.White);

            Vector2 position = new Vector2(50f, Settings.Resolution.Y * .75f);

            Rectangle optionRect = new Rectangle(
                0, 
                (int)position.Y, 
                Settings.Resolution.X, 
                FontManager.GetFont("testfont").LineSpacing);

            isMouseOver = false;

            for (int i = 0; i < options.Count; i++)
            {
                if (optionRect.Contains(Xin.MouseState.Position))
                {
                    selectedIndex = i;
                    isMouseOver = true;
                }

                if (i == SelectedIndex)
=======
            spriteBatch.DrawString(FontManager.GetFont("testfont"), text, textPosition, Color.White);

            Vector2 position = menuPosition;

            Rectangle optionRect = new Rectangle(0, (int)position.Y, 1280, FontManager.GetFont("testfont").LineSpacing);
            isMouseOver = false;
            for(int i = 0; i < options.Count - 1; i++)
            {
                if (optionRect.Contains(Xin.MouseState.Position))
                {
                    selectedIndex = 1;
                    isMouseOver = true;
                }
                if (i == selectedIndex)
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
                {
                    myColor = HighLightColor;
                }
                else
                {
                    myColor = NormalColor;
                }
<<<<<<< HEAD

                spriteBatch.DrawString(FontManager.GetFont("testfont"),
                    options[i].OptionText,
                    position,
                    myColor);

=======
                spriteBatch.DrawString(FontManager.GetFont("testfont"), options[i].OptionText, position, myColor);
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
                position.Y += FontManager.GetFont("testfont").LineSpacing + 5;
                optionRect.Y += FontManager.GetFont("testfont").LineSpacing + 5;
            }
        }
<<<<<<< HEAD

        #endregion
=======
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
    }
}
