using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameOfThronesBoardGame
{
    public class OrderTokenPopup
    {
        MainWindow main;

        public OrderTokenPopup(MainWindow main)
        {
            this.main = main;
        }

        public void createButtons(List<OrderToken> availableOrderTokens, List<OrderToken> allOrderTokens, Dictionary<OrderToken, Button> orderTokenButtonDict)
        {
            foreach (OrderToken o in availableOrderTokens)
            {
                
                foreach (OrderToken ot in allOrderTokens)
                {
                    if (Equals(ot, o) && o.getIsAvailable())
                    {
                        orderTokenButtonDict[ot].IsEnabled = true;
                    }
                        

                }
            }
        }

    }
}
