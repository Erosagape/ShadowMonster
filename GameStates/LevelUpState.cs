using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
<<<<<<< HEAD
using ShadowMonsters.ShadowMonsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
=======
using ShadowMonsters;
using ShadowMonsters.GameStates;

using System;
using System.Collections.Generic;
using System.Text;
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b

namespace ShadowMonsters.GameStates
{
    public interface ILevelUpState
    {
<<<<<<< HEAD
        void SetShadowMonster(ShadowMonster playerShadowMonster);
    }

    public class LevelUpState : BaseGameState, ILevelUpState
    {
        #region Field Region

        private Rectangle destination;
        private int points;
        private int selected;
        private ShadowMonster player;
=======
        void SetShadowMonster(Monster playerShadowMonster);
    }
    public class LevelUpState : BaseGameState, ILevelUpState
    {
        #region Field Region
        private Rectangle destination;
        private int points;
        private int selected;
        private Monster player;
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        private readonly Dictionary<string, int> attributes = new Dictionary<string, int>();
        private readonly Dictionary<string, int> assignedTo = new Dictionary<string, int>();
        private Texture2D levelUpBackground;

        #endregion
<<<<<<< HEAD

        #region Property Region
        #endregion

        #region Constructor Region

        public LevelUpState(Game game)
            : base(game)
=======
        #region Property Region
        #endregion
        #region Constructor Region
        public LevelUpState(Game game)
        : base(game)
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        {
            attributes.Add("Attack", 0);
            attributes.Add("Defense", 0);
            attributes.Add("Speed", 0);
            attributes.Add("Health", 0);
            attributes.Add("Done", 0);
<<<<<<< HEAD

            foreach (string s in attributes.Keys)
                assignedTo.Add(s, 0);
        }

        #endregion

        #region Method Region

=======
            foreach (string s in attributes.Keys)
                assignedTo.Add(s, 0);
        }
        #endregion
        #region Method Region
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        public override void Initialize()
        {
            base.Initialize();
        }
<<<<<<< HEAD

        protected override void LoadContent()
        {
            levelUpBackground = new Texture2D(GameRef.GraphicsDevice, 500, 400);

            Color[] buffer = new Color[500 * 400];

=======
        protected override void LoadContent()
        {
            levelUpBackground = new Texture2D(GameRef.GraphicsDevice, 500, 400);
            Color[] buffer = new Color[500 * 400];
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = Color.Gray;
            }
<<<<<<< HEAD

            levelUpBackground.SetData(buffer);

            destination = new Rectangle(
                (GameRef.Window.ClientBounds.Width - levelUpBackground.Width) / 2,
                (GameRef.Window.ClientBounds.Height - levelUpBackground.Height) / 2,
                levelUpBackground.Width,
                levelUpBackground.Height);

            base.LoadContent();
        }

=======
            levelUpBackground.SetData(buffer);
            destination = new Rectangle(
            (GameRef.Window.ClientBounds.Width - levelUpBackground.Width) / 2,
            (GameRef.Window.ClientBounds.Height - levelUpBackground.Height) / 2,
            levelUpBackground.Width,
            levelUpBackground.Height);
            base.LoadContent();
        }
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        public override void Update(GameTime gameTime)
        {
            int i = 0;
            string attribute = "";
<<<<<<< HEAD

=======
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
            if (Xin.CheckKeyReleased(Keys.Down) || Xin.CheckKeyReleased(Keys.S))
            {
                selected++;

                if (selected >= attributes.Count)
                {
                    selected = attributes.Count - 1;
                }
            }
            else if (Xin.CheckKeyReleased(Keys.Up) || Xin.CheckKeyReleased(Keys.W))
            {
                selected--;
<<<<<<< HEAD

=======
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
                if (selected < 0)
                {
                    selected = 0;
                }
            }
<<<<<<< HEAD

=======
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
            if (Xin.CheckKeyReleased(Keys.Space) || Xin.CheckKeyReleased(Keys.Enter))
            {
                if (selected == 4 && points == 0)
                {
                    foreach (string s in assignedTo.Keys)
                    {
                        player.AssignPoint(s, assignedTo[s]);
                    }
<<<<<<< HEAD

=======
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
                    manager.PopState();
                    manager.PopState();
                    manager.PopState();
                    return;
                }
            }
<<<<<<< HEAD

            int increment = 1;

            if ((Xin.CheckKeyReleased(Keys.Right) || Xin.CheckKeyReleased(Keys.D)) && points > 0)
=======
            int increment = 1;
            if ((Xin.CheckKeyReleased(Keys.Right) || Xin.CheckKeyReleased(Keys.D)) && points >
            0)
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
            {
                foreach (string s in assignedTo.Keys)
                {
                    if (s == "Done")
                    {
                        return;
                    }
<<<<<<< HEAD

=======
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
                    if (i == selected)
                    {
                        attribute = s;
                        break;
                    }
<<<<<<< HEAD

                    i++;
                }


=======
                    i++;
                }
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
                if (attribute == "Health")
                {
                    increment *= 5;
                }
<<<<<<< HEAD

=======
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
                points--;
                assignedTo[attribute] += increment;

                if (points == 0)
                {
                    selected = 4;
                }
            }
<<<<<<< HEAD
            else if ((Xin.CheckKeyReleased(Keys.Left) || Xin.CheckKeyReleased(Keys.A)) && points <= 3)
=======
            else if ((Xin.CheckKeyReleased(Keys.Left) || Xin.CheckKeyReleased(Keys.A)) &&
            points <= 3)
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
            {
                foreach (string s in assignedTo.Keys)
                {
                    if (s == "Done")
                    {
                        return;
                    }
<<<<<<< HEAD

=======
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
                    if (i == selected)
                    {
                        attribute = s;
                        break;
                    }
<<<<<<< HEAD

                    i++;
                }

=======
                    i++;
                }
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
                if (assignedTo[attribute] != attributes[attribute])
                {
                    if (attribute == "Health")
                    {
                        increment *= 5;
                    }
<<<<<<< HEAD

=======
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
                    points++;
                    assignedTo[attribute] -= increment;
                }
            }
<<<<<<< HEAD

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);


            GameRef.SpriteBatch.Begin();
            GameRef.SpriteBatch.Draw(levelUpBackground, destination, Color.White);

            Vector2 textPosition = new Vector2(destination.X + 5, destination.Y + 5);

            GameRef.SpriteBatch.DrawString(FontManager.GetFont("testfont"), player.DisplayName, textPosition, Color.White);
            textPosition.Y += FontManager.GetFont("testfont").LineSpacing * 2;

            int i = 0;

=======
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            GameRef.SpriteBatch.Begin();
            GameRef.SpriteBatch.Draw(levelUpBackground, destination, Color.White);
            Vector2 textPosition = new Vector2(destination.X + 5, destination.Y + 5);
            GameRef.SpriteBatch.DrawString(FontManager.GetFont("testfont"), player.DisplayName,
            textPosition, Color.White);
            textPosition.Y += FontManager.GetFont("testfont").LineSpacing * 2;
            int i = 0;
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
            foreach (string s in attributes.Keys)
            {
                Color tint = Color.White;

                if (i == selected)
                    tint = Color.Red;
<<<<<<< HEAD

                if (s != "Done")
                {
                    GameRef.SpriteBatch.DrawString(FontManager.GetFont("testfont"), s + ":", textPosition, tint);
                    textPosition.X += 125;

                    GameRef.SpriteBatch.DrawString(FontManager.GetFont("testfont"), attributes[s].ToString(), textPosition, tint);
                    textPosition.X += 40;

                    GameRef.SpriteBatch.DrawString(FontManager.GetFont("testfont"), assignedTo[s].ToString(), textPosition, tint);
                    textPosition.X = destination.X + 5;

=======
                if (s != "Done")
                {
                    GameRef.SpriteBatch.DrawString(FontManager.GetFont("testfont"), s + ":",
                    textPosition, tint);
                    textPosition.X += 125;
                    GameRef.SpriteBatch.DrawString(FontManager.GetFont("testfont"),
                    attributes[s].ToString(), textPosition, tint);
                    textPosition.X += 40;
                    GameRef.SpriteBatch.DrawString(FontManager.GetFont("testfont"),
                    assignedTo[s].ToString(), textPosition, tint);
                    textPosition.X = destination.X + 5;
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
                    textPosition.Y += FontManager.GetFont("testfont").LineSpacing;
                }
                else
                {
<<<<<<< HEAD
                    GameRef.SpriteBatch.DrawString(FontManager.GetFont("testfont"), "Done", textPosition, tint);
=======
                    GameRef.SpriteBatch.DrawString(FontManager.GetFont("testfont"), "Done",
                    textPosition, tint);
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
                    textPosition.Y += FontManager.GetFont("testfont").LineSpacing * 2;
                }
                i++;
            }
<<<<<<< HEAD

            GameRef.SpriteBatch.DrawString(
                FontManager.GetFont("testfont"),
                points.ToString() + " point left.",
                textPosition,
                Color.White);
            GameRef.SpriteBatch.End();
        }

        public void SetShadowMonster(ShadowMonster playerShadowMonster)
        {
            player = playerShadowMonster;

=======
            GameRef.SpriteBatch.DrawString(
            FontManager.GetFont("testfont"),
            points.ToString() + " point left.",
            textPosition,
            Color.White);
            GameRef.SpriteBatch.End();
        }
        public void SetShadowMonster(Monster playerShadowMonster)
        {
            player = playerShadowMonster;
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
            attributes["Attack"] = player.BaseAttack;
            attributes["Defense"] = player.BaseDefense;
            attributes["Speed"] = player.BaseSpeed;
            attributes["Health"] = player.BaseHealth;
<<<<<<< HEAD

=======
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
            assignedTo["Attack"] = random.Next(1, 7);
            assignedTo["Defense"] = random.Next(1, 7);
            assignedTo["Speed"] = random.Next(1, 7);
            assignedTo["Health"] = random.Next(5, 21);
<<<<<<< HEAD

            points = 3;
            selected = 0;
        }

=======
            points = 3;
            selected = 0;
        }
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        #endregion
    }
}
