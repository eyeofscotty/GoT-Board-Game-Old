using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameOfThronesBoardGame
{
    
    public class PlaceHolderOrderToken:OrderToken
    {
        bool isAvailable = true;
        public PlaceHolderOrderToken()
        {

        }

        public bool Equals(OrderToken orderToken)
        {
            return true;
        }

        public bool getStar()
        {
            return true;
        }

        public bool getIsAvailable()
        {
            return this.isAvailable;
        }

        public void setIsAvailable(bool isAvailable)
        {
            this.isAvailable = isAvailable;
        }
        
        public string toString()
        {
            return "";
        }
    }
}
