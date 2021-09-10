using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
namespace ShadowMonsters
{
    public interface IStateManager
    {
        GameState CurrentState { get; }
        event EventHandler StateChanged;
        void PushState(GameState state);
        void ChangeState(GameState state);
        void PopState();
        bool ContainsState(GameState state);
    }
    public class GameStateManager : GameComponent,IStateManager
    {
        private readonly Stack<GameState> gameStates = new Stack<GameState>();
        private const int startDrawOrder = 5000;
        private const int drawOrderInc = 50;
        private int drawOrder;
        public event EventHandler StateChanged;
        public GameState CurrentState
        {
            get { return gameStates.Peek(); }
        }
        public GameStateManager(Game game) :base(game)
        {
            Game.Services.AddService(typeof(IStateManager), this);
            drawOrder = startDrawOrder;
        }
        public void PushState(GameState state)
        {
            drawOrder += drawOrderInc;
            AddState(state);
            OnStateChanged();
        }
        public void ChangeState(GameState state)
        {
            while (gameStates.Count > 0)
            {
                RemoveState();
            }
            drawOrder = startDrawOrder;
            state.DrawOrder = drawOrder;
            drawOrder += drawOrderInc;
            AddState(state);
            OnStateChanged();
        }
        public bool ContainsState(GameState state)
        {
            return gameStates.Contains(state);
        }
        public void PopState()
        {
            if (gameStates.Count != 0)
            {
                RemoveState();
                drawOrder -= drawOrderInc;
                OnStateChanged();
            }
        }
        protected internal virtual void OnStateChanged()
        {
            StateChanged?.Invoke(this, null);
        }
        private void RemoveState()
        {
            GameState state = gameStates.Peek();
            StateChanged -= state.StateChanged;
            Game.Components.Remove(state);
            gameStates.Pop();
        }
        private void AddState(GameState state)
        {
            gameStates.Push(state);
            Game.Components.Add(state);
            StateChanged += state.StateChanged;
        }
    }
}
