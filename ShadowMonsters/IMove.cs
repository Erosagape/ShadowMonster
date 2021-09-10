using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowMonsters
{
    public enum Target
    {
        Self,Enemy
    }
    public enum MoveType
    {
        Attack,Heal,Buff,Debuff,Status
    }
    public enum MoveElement
    {
        None,Dark,Earth,Fire,Light,Water,Wind
    }

    public interface IMove
    {
        string Name { get; }
        Target Target { get; }
        MoveType MoveType { get; }
        MoveElement MoveElement { get; }
        int UnlockedAt { get; set; }
        bool Unlocked { get; }
        int Duration { get; set; }
        int Attack { get; }
        int Defense { get; }
        int Speed { get; }
        int Health { get; }
        void Unlock();
        object Clone();
    }
}
