using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameOfThronesBoardGame
{
    public class RaidOrder : OrderToken
    {
        private bool star;
        private bool isAvailable;
        public RaidOrder(bool star, bool isAvailable)
        {
            this.isAvailable = isAvailable;
            this.star = star;
        }

        public bool Equals(OrderToken orderToken)
        {
            bool returnBool = false;
            if (orderToken is RaidOrder)
            {
                RaidOrder raidOrder = (RaidOrder)orderToken;
                if (raidOrder.getStar() == this.getStar())
                {
                    returnBool = true;
                }
            }
            return returnBool;
        }

        public bool getStar()
        {
            return this.star;
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
            string str = "  - ";
            if (star)
            {
                str += "RO*";
            }
            else
            {
                str += "RO";
            }
            return str;
        }
    }
}
