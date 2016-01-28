using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfThronesBoardGame
{
    public class Knight : Army
    {
        private int attackPower;
        private int defensePower;
        private int cost;
        private bool routed;

        public Knight()
        {
            this.attackPower = 2;
            this.defensePower = 2;
            this.cost = 2;
            this.routed = false;
        }

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
