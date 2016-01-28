using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfThronesBoardGame
{
    public interface Army
    {
        int getAttackPower();
        int getDefensePower();
        int getCost();
        bool getRouted();
        void setRouted(bool routed);
    }
}
