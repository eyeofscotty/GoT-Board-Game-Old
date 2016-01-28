using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfThronesBoardGame
{
    public class Ship : Army
    {
        private int attackPower;
        private int defensePower;
        private int cost;
        private bool routed;

        public Ship()
        {
            this.attackPower = 1;
            this.defensePower = 1;
            this.cost = 1;
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
