using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfThronesBoardGame
{
    public class SiegeEngine : Army
    {
        private int attackPower;
        private int defensePower;
        private int cost;
        private bool routed;

        public SiegeEngine()
        {
            this.attackPower = 4;
            this.defensePower = 0;
            this.cost = 2;
            this.routed = false;
        }
        //Maybe have siege engines have 0 attack when not attacking stronghold/castle

        public int getAttackPower()
        {
            return this.attackPower;
        }

        public int getDefensePower()
        {
            return this.defensePower;
        }

        public int getCost()
        {
            return this.cost;
        }
        public bool getRouted()
        {
            return this.routed;
        }
        public void setRouted(bool routed)
        {
            this.routed = routed;
        }
    }
}
