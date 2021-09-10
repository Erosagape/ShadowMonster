<<<<<<< HEAD
﻿using Microsoft.Xna.Framework;
=======
﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShadowMonsters.Characters;
using ShadowMonsters.ConversationComponents;
<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

=======
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
namespace ShadowMonsters.GameStates
{
    public interface IConversationState
    {
        void SetConversation(Character character);
        void StartConversation();
    }
<<<<<<< HEAD

    public class ConversationState : BaseGameState, IConversationState
    {
        #region Field Region

        private Conversation conversation;
        private Character speaker;
        private int frameCount = 0;

        #endregion

        #region Property Region
        #endregion

        #region Constructor Region

=======
    public class ConversationState : BaseGameState, IConversationState
    {
        private Conversation conversation;
        private Character speaker;
        private int frameCount = 0;
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        public ConversationState(Game game)
            : base(game)
        {
            game.Services.AddService(typeof(IConversationState), this);
        }
<<<<<<< HEAD

        #endregion

        #region Method Region

=======
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        public override void Initialize()
        {
            base.Initialize();
        }
<<<<<<< HEAD

=======
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        protected override void LoadContent()
        {
            base.LoadContent();
        }
<<<<<<< HEAD

        public override void Update(GameTime gameTime)
        {
            if (conversation.CurrentScene == null)
            {
                return;
            }
            frameCount++;
            if ((Xin.CheckKeyReleased(Keys.Space) ||
                Xin.CheckKeyReleased(Keys.Enter) ||
                (Xin.CheckMouseReleased(MouseButtons.Left) &&
                conversation.CurrentScene.IsMouseOver)) && frameCount > 5)
=======
        
        public override void Update(GameTime gameTime)
        {
            if (conversation.CurrentScene == null)
                return;
            if ((Xin.CheckKeyReleased(Keys.Space) ||
                Xin.CheckKeyReleased(Keys.Enter) ||
                (Xin.CheckMouseReleased(MouseButtons.Left) &&
                conversation.CurrentScene.IsMouseOver)) && frameCount>5)
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
            {
                frameCount = 0;
                switch (conversation.CurrentScene.OptionAction.Action)
                {
                    case ActionType.Teach:
                        BuyShadowMonster();
                        break;
                    case ActionType.Change:
                        speaker.SetConversation(conversation.CurrentScene.OptionScene);
                        manager.PopState();
                        break;
                    case ActionType.End:
                        manager.PopState();
                        break;
                    case ActionType.GiveItems:
                        break;
                    case ActionType.GiveKey:
                        if (conversation.CurrentScene.OptionAction.Parameter != null)
                        {
                            bool success = int.TryParse(
                                conversation.CurrentScene.OptionAction.Parameter,
<<<<<<< HEAD
                                out int key);

                            if (success)
                            {
                            }

=======
                                out int key
                                );
                            if (success)
                            {

                            }
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
                            conversation.ChangeScene(conversation.CurrentScene.OptionScene);
                        }
                        break;
                    case ActionType.Quest:
                        CheckQuest();
                        break;
                    case ActionType.Rest:
<<<<<<< HEAD
                        Game1.Player.HealBattleShadowMonsters();
                        conversation.ChangeScene(conversation.CurrentScene.OptionScene);
                        break;
                    case ActionType.Shop:
                        GameRef.ShopState.SetMerchant((Merchant)speaker);
                        manager.PopState();
                        manager.PushState(GameRef.ShopState);
=======
                        conversation.ChangeScene(conversation.CurrentScene.OptionScene);
                        break;
                    case ActionType.Shop:
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
                        break;
                    case ActionType.Talk:
                        conversation.ChangeScene(conversation.CurrentScene.OptionScene);
                        break;
                }
            }
<<<<<<< HEAD

            conversation.Update();
            base.Update(gameTime);
        }

        private void BuyShadowMonster()
        {
            Game1.Player.AddShadowMonster(speaker.GiveMonster);

            for (int i = 0; i < Player.MaxShadowMonsters; i++)
=======
            conversation.Update();
            base.Update(gameTime);
        }
        private void BuyShadowMonster()
        {
            Game1.Player.AddShadowMonster(speaker.GiveMonster);
            for(int i = 0; i < Player.MaxShadowMonsters; i++)
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
            {
                if (Game1.Player.BattleShadowMonsters[i] == null)
                {
                    Game1.Player.BattleShadowMonsters[i] = speaker.GiveMonster;
                    break;
                }
            }
<<<<<<< HEAD

            string scene = conversation.CurrentScene.OptionScene;

            conversation.CurrentScene.Options.RemoveAt(conversation.CurrentScene.SelectedIndex);
            conversation.CurrentScene.SelectedIndex = 0;
            conversation.ChangeScene(scene);
        }

        private void CheckQuest()
        {
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            GameRef.SpriteBatch.Begin();
            conversation.Draw(GameRef.SpriteBatch);
            GameRef.SpriteBatch.End();
        }

        public void SetConversation(Character character)
        {
            speaker = character;

=======
            string scene = conversation.CurrentScene.OptionScene;
            conversation.CurrentScene.Options.RemoveAt(conversation.CurrentScene.SelectedIndex);
            conversation.CurrentScene.SelectedIndex--;
            conversation.ChangeScene(scene);
        }
        private void CheckQuest()
        {

        }
        public void SetConversation(Character character)
        {
            speaker = character;
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
            if (ConversationManager.Instance.ConversationList.ContainsKey(character.Conversation))
            {
                conversation = ConversationManager.Instance.ConversationList[character.Conversation];
            }
            else
            {
                manager.PopState();
            }
        }
<<<<<<< HEAD

=======
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        public void StartConversation()
        {
            if (conversation != null)
            {
                conversation.StartConversation();
            }
        }
<<<<<<< HEAD

        #endregion
=======
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            GameRef.SpriteBatch.Begin();
            conversation.Draw(GameRef.SpriteBatch);
            GameRef.SpriteBatch.End();

        }
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
    }
}
