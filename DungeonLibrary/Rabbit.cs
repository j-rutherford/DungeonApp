using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Rabbit : Monster
    {

        //fields/properties (using autos)
        public bool IsFluffy { get; set; }

        //constructors, create an FQ ctor, that we can use to make a super bad monster
        public Rabbit(string name, int life, int maxLife, int hitChance,
            int block, int minDamage, int maxDamage, string description,
            bool isFluffy)
            : base(name, life, maxLife, hitChance, block, maxDamage,
            minDamage, description)
        {
            //just handle unique ones
            IsFluffy = isFluffy;
        }

        //methods
        public override string ToString()
        {
            return base.ToString() + (IsFluffy ? "Fluffy" : "Not so fluffy...");
        }

        //override the block to say if they are fluffy they get a bonus
        //50% to their block value
        public override int CalcBlock()
        {
            int calculatedBlock = Block;

            if (IsFluffy)
            {
                calculatedBlock += calculatedBlock / 2;
            }

            return calculatedBlock;
        }
    }
}
