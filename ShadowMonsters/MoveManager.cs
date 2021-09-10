using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<< HEAD
namespace ShadowMonsters.ShadowMonsters
=======
namespace ShadowMonsters
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
{
    public static class MoveManager
    {
        #region Field Region

        private static readonly Dictionary<string, IMove> allMoves = new Dictionary<string, IMove>();
        private static readonly Random random = new Random();

        #endregion

        #region Property Region

        public static Random Random => random;
        public static Dictionary<string, IMove> Moves { get { return allMoves; } }

        #endregion

        #region Constructor Region
        #endregion

        #region Method Region

        public static void FillMoves()
        {
            allMoves.Clear();
            allMoves.Add("Tackle", new Tackle());
            allMoves.Add("Block", new Block());
            allMoves.Add("Bubble", new Bubble());
            allMoves.Add("Flare", new Flare());
            allMoves.Add("Gust", new Gust());
            allMoves.Add("Heal", new Heal());
            allMoves.Add("Rock Toss", new RockToss());
            allMoves.Add("Shade", new Shade());
        }

        public static IMove GetMove(string name)
        {
            if (allMoves.ContainsKey(name))
                return (IMove)allMoves[name].Clone();

            return null;
        }

        public static void AddMove(IMove move)
        {
            if (!allMoves.ContainsKey(move.Name))
                allMoves.Add(move.Name, move);
        }

        #endregion
    }
}
