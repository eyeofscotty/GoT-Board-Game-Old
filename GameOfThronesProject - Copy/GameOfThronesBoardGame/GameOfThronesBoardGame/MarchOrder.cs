using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameOfThronesBoardGame
{
    //In here math is done for power of attacking infantry
    public class MarchOrder : OrderToken
    {
        private bool star, zero, neg, isAvailable;
        public MarchOrder(bool star, bool zero, bool neg, bool isAvailable)
        {
            this.isAvailable = isAvailable;
            this.star = star;
            this.zero = zero;
            this.neg = neg;
        }

        public bool Equals(OrderToken orderToken)
        {  
            bool returnBool = false;
            if (orderToken is MarchOrder)
            {
                MarchOrder marchOrder = (MarchOrder)orderToken;
                if (marchOrder.getStar() == this.getStar() && marchOrder.getNegToken() == this.getNegToken() && marchOrder.getZeroToken() == this.getZeroToken())
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

        public bool getZeroToken()
        {
            return this.zero;
        }

        public bool getNegToken()
        {
            return this.neg;
        }

        public string toString()
        {
            string str = "  - ";
            if (star)
            {
                str += "MO*+1";
            }
            else if(zero)
            {
                str += "MO+0";
            }
            else
            {
                str += "MO-1";
            }
            return str;
        }
        
    }
}
