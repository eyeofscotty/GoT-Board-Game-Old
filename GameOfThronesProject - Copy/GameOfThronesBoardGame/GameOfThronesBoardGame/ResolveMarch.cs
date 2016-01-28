using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.ComponentModel;

namespace GameOfThronesBoardGame
{
    public class ResolveMarch
    {
        MainWindow main;
        LandTerritory attacker;
        LandTerritory defender;
        Infantry infantry = new Infantry();
        Knight knight = new Knight();
        Ship ship = new Ship();
        int attackingKnights;
        int attackingInfantry;
        bool attack = true;

        public ResolveMarch(MainWindow main)
        {
            this.main = main;
        }

        private void assignAttacker(LandTerritory passedTerritory)
        {
            attackingInfantry = 0;
            attackingKnights = 0;
            main.takeTurn.DisableAllTerritoryButtons();
            foreach (string s in passedTerritory.getConnections())
            {
                main.resources.allLandConnections[s.Trim()].getButton().IsEnabled = true;
            }
            passedTerritory.getButton().IsEnabled = true;
            passedTerritory.getButton().Background = System.Windows.Media.Brushes.DarkOliveGreen;
            passedTerritory.getButton().Content = "Click to cancel";
            attacker = passedTerritory;
            attack = false;
        }

        private void assignDefender(LandTerritory passedTerritory)
        {
            defender = passedTerritory;
            
            if (!attacker.Equals(defender))
            {
                main.PopupLable1.Content = "A: " + attacker.getHouseOccupied().getName()  + ": " + calculateAttack(attacker);
                main.PopupLable2.Content = "D: " + defender.getHouseOccupied().getName() + ": " + calculateDefense(defender);
                main.Popup1.IsOpen = true;
                attacker.setOrderToken(new PlaceHolderOrderToken());
            }
            CancelAttack();
            
        }

        private int calculateAttack(LandTerritory passedTerritory)
        {
            //TODO: ***** calculate support
            int attackPower = 0;

            attackPower += (getAttackingInfantry().Count * infantry.getAttackPower());
            attackPower += (getAttackingKnights().Count * knight.getAttackPower());
            MarchOrder marchOrder = (MarchOrder)passedTerritory.getOrderToken();
            if (marchOrder.getStar())
            {
                attackPower += 1;
            }
            else if (marchOrder.getNegToken())
            {
                attackPower -= 1;
            }
            return attackPower;
        }

        private int calculateDefense(LandTerritory passedTerritory)
        {
            //TODO **** calculate support
            int defensePower = 0;
            defensePower += (getAttackingInfantry().Count * infantry.getDefensePower());
            defensePower += (getAttackingKnights().Count * knight.getDefensePower());
            if (passedTerritory.getOrderToken() is DefenseOrder)
            {
                DefenseOrder defenseOrder = (DefenseOrder)passedTerritory.getOrderToken();
                if (defenseOrder.getStar())
                {
                    defensePower += 2;
                }
                else
                {
                    defensePower += 1;
                }
            }
            return defensePower;
        }

        private void showMarchTroopPopup(LandTerritory passedTerritory)
        {
            main.PopupChooseMarchTroops.IsOpen = true;
            main.KnightListBox.Items.Clear();
            main.FootmanListBox.Items.Clear();            
            int count = 0;
            main.KnightListBox.Items.Add(count);
            foreach (Knight k in passedTerritory.getKnights())
            {
                count++;
                if (!k.getRouted())
                {
                    main.KnightListBox.Items.Add(count);
                }     
            }
            count = 0;
            main.FootmanListBox.Items.Add(count);
            foreach (Infantry i in passedTerritory.getInfantry())
            {
                count++;
                if (!i.getRouted())
                {
                    main.FootmanListBox.Items.Add(count);
                }     
            }
        }

        private List<Knight> getAttackingKnights()
        {
            List<Knight> list = new List<Knight>();
            if(main.KnightListBox.SelectedItem != null)
            {
                attackingKnights = (int)main.KnightListBox.SelectedItem;
            }
            else
            {
                attackingKnights = 0;
            }
            for (int i = 0; i < attackingKnights; i++)
            {
                if (attacker.getKnights()[i].getRouted())
                {
                    list.Add(attacker.getKnights()[i + 1]);
                }
                else
                {
                    list.Add(attacker.getKnights()[i]);
                }
                
            }
            return list;
        }

        private List<Infantry> getAttackingInfantry()
        {
            List<Infantry> list = new List<Infantry>();
            if (main.FootmanListBox.SelectedItem != null)
            {
                attackingInfantry = (int)main.FootmanListBox.SelectedItem;
            }
            else
            {
                attackingInfantry = 0;
            }
            for (int i = 0; i < attackingInfantry; i++)
            {
                if (attacker.getInfantry()[i].getRouted())
                {
                    list.Add(attacker.getInfantry()[i]); ;
                }
                else
                {
                    list.Add(attacker.getInfantry()[i]);
                }
                
            }
            return list;
        }

        private void routeTroops(LandTerritory passedTerritory)
        {


            if (passedTerritory.Equals(attacker))
            {

                //attacker lost

            }
            else
            {
                foreach (string s in passedTerritory.getConnections())
                {
                    if (main.resources.allLandConnections[s].getHouseOccupied().Equals(passedTerritory.getHouseOccupied()) || main.resources.allLandConnections[s].getHouseOccupied() is HouseNeutral)
                    {
                        main.resources.allLandConnections[s].getButton().IsEnabled = true;
                    }
                }

                //defender lost
                main.takeTurn.disableButtons(passedTerritory.getHouseOccupied());
            }
        }

        public void performCombat()
        {
            if (calculateAttack(attacker) >= calculateDefense(defender))
            {
                routeTroops(defender);
                attacker.setNumKnight(attacker.getNumKnight() - getAttackingKnights().Count);
                attacker.setNumInfantry(attacker.getNumInfantry() - getAttackingInfantry().Count);
                defender.setHouseOccupied(attacker.getHouseOccupied());
                defender.setOrderToken(new PlaceHolderOrderToken());
            }
            else
            {
                routeTroops(attacker);
            }

            main.drawUnits.DrawIt(defender);
            main.drawUnits.DrawIt(attacker);
        }

        public void doMarchOrder(SeaTerritory passedTerritory, TextBlock passedText)
        {

        }

        public void doMarchOrder(LandTerritory passedTerritory)
        {
            if (attack)
            {
                if (passedTerritory.getOrderToken() is MarchOrder)
                {   
                    showMarchTroopPopup(passedTerritory);
                    assignAttacker(passedTerritory);
                }
            }
            else
            {
                //main.PopupChooseMarchTroops.IsOpen = false;
                
                //has enemy troops
                if (passedTerritory.getNumKnight() > 0 || passedTerritory.getNumInfantry() > 0 && !(passedTerritory.getHouseOccupied().Equals(attacker.getHouseOccupied())))
                {
                    assignDefender(passedTerritory);
                }
                //Click on same territory to cancel attack
                else if (passedTerritory.Equals(attacker))
                {
                    CancelAttack();
                }
                //Moving between friendly territories
                else if (passedTerritory.getHouseOccupied().Equals(attacker.getHouseOccupied()))
                {
                    passedTerritory.setNumInfantry(passedTerritory.getNumInfantry() + getAttackingInfantry().Count);
                    passedTerritory.setNumKnight(passedTerritory.getNumKnight() + getAttackingKnights().Count);
                    attacker.setNumKnight(attacker.getNumKnight() - getAttackingKnights().Count);
                    attacker.setNumInfantry(attacker.getNumInfantry() - getAttackingInfantry().Count);
                    showMarchTroopPopup(attacker);
                }
                //Empty territory/has just a power token
                else
                {
                    MoveToNewTerritory(passedTerritory);
                    showMarchTroopPopup(attacker);
                }
                main.drawUnits.DrawIt(passedTerritory);
                main.drawUnits.DrawIt(attacker);
                
            }
        }

        public void CancelAttack()
        {
            main.PopupChooseMarchTroops.IsOpen = false;
            attack = true;
            main.takeTurn.disableButtons(attacker.getHouseOccupied());
            attacker.getButton().Content = attacker.getName();
            //Redraw the textBlock after removing order token
            attacker.getButton().Background = System.Windows.Media.Brushes.White;
        }

        private void MoveToNewTerritory(LandTerritory passedTerritory)
        {
            Infantry placeHolderInfantry;
            Knight placeHolderKnight;
            passedTerritory.setNumKnight(getAttackingKnights().Count);
            passedTerritory.setNumInfantry(getAttackingInfantry().Count);
            attacker.setNumKnight(attacker.getNumKnight() - getAttackingKnights().Count);
            attacker.setNumInfantry(attacker.getNumInfantry() - getAttackingInfantry().Count);
            passedTerritory.setHouseOccupied(attacker.getHouseOccupied());
            passedTerritory.setOrderToken(new PlaceHolderOrderToken());

            foreach(Knight k in getAttackingKnights())
            {
                attacker.getKnights().Remove(k);
                passedTerritory.getKnights().Add(k);
            }

            foreach(Infantry i in getAttackingInfantry())
            {    
                attacker.getInfantry().Remove(i);
                passedTerritory.getInfantry().Add(i);  
            }
        }
        
    }
}
