using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfThronesBoardGame
{
    public interface HouseCards
    {
        int getPower();
        int getSwords();
        int getDefense();
        //Add special moves as needed, may be difficult, especially robb starks
    }
}
