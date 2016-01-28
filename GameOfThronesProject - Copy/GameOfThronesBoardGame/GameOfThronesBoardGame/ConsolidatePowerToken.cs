using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameOfThronesBoardGame
{
    //In this class it adds powertokens or musters on a castle/stronghold
    public class ConsolidatePower : OrderToken
    {

        private bool star;
        private bool isAvailable;
        public ConsolidatePower(bool star, bool isAvailable)
        {
            this.isAvailable = isAvailable;
            this.star = star;
        }

        public bool Equals(OrderToken orderToken)
        {
            bool returnBool = false;
            if(orderToken is ConsolidatePower)
            {
                ConsolidatePower consolidatePower = (ConsolidatePower)orderToken;
                if (consolidatePower.getStar() == this.getStar())
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
                str += "CP*";
            }
            else
            {
                str += "CP";
            }
            return str;
        }

    }
}
