using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameOfThronesBoardGame
{
    public interface OrderToken
    {
        //add these as a field in each house???
       // void setToken(Territory territory);
        //OrderToken getToken();
        //void starToken();
        string toString();
        bool getStar();
        bool getIsAvailable();
        void setIsAvailable(bool isAvailable);
        bool Equals(OrderToken order);
    }
}
