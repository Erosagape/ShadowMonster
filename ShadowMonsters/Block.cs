using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowMonster.ShadowMonsters
{
    public class Block :IMove
    {
        private readonly string name;
        private readonly Target target;
        private readonly MoveType moveType;
        private readonly MoveElement moveElement;
        private bool unlocked;
        private int unlockAt;
        private int duration;
        private readonly int attack;
        private readonly int defense;
        private readonly int speed;
        private readonly int health;

        public string Name => name;

        public Target Target => target;

        public MoveType MoveType => moveType;

        public MoveElement MoveElement => MoveElement;

        public int UnlockedAt { get => unlockAt; set => unlockAt = value; }

        public bool Unlocked => unlocked;

        public int Duration { get => duration; set => duration = value; }

        public int Attack => attack;

        public int Defense => defense;

        public int Speed => speed;

        public int Health => health;
        public Block()
        {
            name = "Block";
            target = Target.Self;
            moveType = MoveType.Buff;
            moveElement = MoveElement.None;
            unlocked = false;
            duration = 5;
            attack = MoveManager.Random.Next(0, 0);
            defense = MoveManager.Random.Next(2, 6);
            speed = MoveManager.Random.Next(0, 0);
            health = MoveManager.Random.Next(0, 0);
        }
        public void Unlock()
        {
            unlocked = true;
        }

        public object Clone()
        {
            Block block = new Block
            {
                unlocked = this.unlocked
            };
            return block;
        }
    }
}
