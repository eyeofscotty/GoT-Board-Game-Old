using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameOfThronesBoardGame
{
    public class SupportOrder: OrderToken
    {
        bool star;
        bool isAvailable;
        public SupportOrder(bool star, bool isAvailable)
        {
            this.isAvailable = isAvailable;
            this.star = star;
        }

        public bool Equals(OrderToken orderToken)
        {
            bool returnBool = false;
            if (orderToken is SupportOrder)
            {
                SupportOrder supportOrder = (SupportOrder)orderToken;
                if (this.getStar() == supportOrder.getStar())
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
                str += "SO*+1";
            }
            else
            {
                str += "SO";
            }
            return str;
        }
    }
}
