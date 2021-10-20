using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using ShadowMonsters.Items;

namespace ShadowMonsters.GameStates
{
    public interface IItemSelectionState
    {
        int SelectedIndex { get; }
    }
    public class ItemSelectionState : BaseGameState,IItemSelectionState
    {
        private int selected;
        private bool mouseOver;
        public int SelectedIndex { get => selected; }
        public ItemSelectionState(Game game) : base(game)
        {

        }
        protected override void LoadContent()
        {
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (Xin.CheckKeyReleased(Keys.Down)
                || Xin.CheckKeyReleased(Keys.S))
            {
                selected++;
                if (selected >= Game1.Player.Backpack.Items.Count)
                {
                    selected = 0;
                }
            }
            if (Xin.CheckKeyReleased(Keys.Up)
                || Xin.CheckKeyReleased(Keys.W))
            {
                selected--;
                if (selected <0)
                {
                    selected = Game1.Player.Backpack.Items.Count-1;
                }
            }
            if(((Xin.CheckKeyReleased(Keys.Space)|| Xin.CheckKeyReleased(Keys.Enter))
                ||Xin.CheckMouseReleased(MouseButtons.Left) && mouseOver)
                && selected>=0 
                && Game1.Player.Backpack.Items.Count>0 
                && Game1.Player.Backpack.PeekItem(
                    Game1.Player.Backpack.Items[selected].Name
                    ).Usable)
            {
                GameRef.UseItemState.SetItem(
                    Game1.Player.Backpack.GetItem(
                        Game1.Player.Backpack.Items[selected].Name
                        )
                    );
                manager.PushState((UseItemState)GameRef.UseItemState);
            }
            if(Xin.CheckKeyReleased(Keys.Escape) || Xin.CheckMouseReleased(MouseButtons.Right))
            {
                manager.PopState();
            }
        }
        public override void Draw(GameTime gameTime)
        {
            Color tint;
            int i = 0;
            base.Draw(gameTime);
            GameRef.SpriteBatch.Begin();
            GameRef.SpriteBatch.DrawString(
                        FontManager.GetFont("test"),
                        "Item",
                        new Vector2(120, 5)
                        , Color.Red
                        );
            GameRef.SpriteBatch.DrawString(
                FontManager.GetFont("test"),
                "Quantity",
                new Vector2(800, 5)
                , Color.Red
                );
            GameRef.SpriteBatch.DrawString(
                FontManager.GetFont("test"),
                "Price",
                new Vector2(1100, 5)
                , Color.Red
                );
            foreach (var v in Game1.Player.Backpack.Items)
            {
                tint = Color.White;
                if (i == selected)
                {
                    tint = Color.Red;
                }
                IItem item = Game1.Player.Backpack.PeekItem(v.Name);
                if (item != null)
                {
                    Rectangle r = new Rectangle(40, 74 * i + 24, 1200, 64);
                    if (r.Contains(Xin.MouseAsPoint))
                    {
                        selected = i;
                        mouseOver = true;
                    }
                    GameRef.SpriteBatch.DrawString(
                        FontManager.GetFont("test"),
                        v.Name,
                        new Vector2(120, 74 * i + 45),
                        tint
                        );
                    GameRef.SpriteBatch.DrawString(
                        FontManager.GetFont("test"),
                        v.Count.ToString(),
                        new Vector2(800, 74 * i + 45),
                        tint
                        );
                    GameRef.SpriteBatch.DrawString(
                        FontManager.GetFont("test"),
                        item.Price.ToString(),
                        new Vector2(1100, 74 * i + 45),
                        tint
                        );
                    i++;
                }
            }
            GameRef.SpriteBatch.End();
        }
    }
}
