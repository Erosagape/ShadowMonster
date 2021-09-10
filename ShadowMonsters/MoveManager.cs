using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowMonsters
{
    public static class MoveManager
    {
        private static readonly Dictionary<string, IMove> allMoves = new Dictionary<string, IMove>();
        private static readonly Random random = new Random();
        public static Random Random => random;
        public static IMove GetMove(string name)
        {
            if (allMoves.ContainsKey(name))
                return (IMove)allMoves[name].Clone();
            return null;
        }
        public static void FillMoves()
        {
            AddMove("Tackle", new Tackle());
            AddMove("Block", new Block());
        }
        public static void AddMove(string name,IMove move)
        {
            if (!allMoves.ContainsKey(move.Name))
                allMoves.Add(move.Name, move);
        }
    }
}
