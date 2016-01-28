using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameOfThronesBoardGame
{
    //In this class math is done for defending infantry with token
    public class DefenseOrder : OrderToken
    {

        private bool star;
        private bool isAvailable;

        public DefenseOrder(bool star, bool isAvailable)
        {
            this.isAvailable = isAvailable;
            this.star = star;
        }

        public bool Equals(OrderToken orderToken)
        {
            bool returnBool = false;
            if (orderToken is DefenseOrder)
            {
                DefenseOrder defenseOrder = (DefenseOrder)orderToken;
                if (defenseOrder.getStar() == this.getStar())
                {
                    returnBool = true;
                }
            }
            
            return returnBool;
        }

        public bool getIsAvailable()
        {
            return this.isAvailable;
        }

        public void setIsAvailable(bool isAvailable)
        {
            this.isAvailable = isAvailable;
        }

        public bool getStar()
        {
            return this.star;
        }

        public string toString()
        {
            string str = "  - ";
            if (star)
            {
                str += "DO*+2";
            }
            else
            {
                str += "Do+1";
            }
            return str;
        }
    }
}
