using System.Drawing;

namespace LeagueBot.Game.Misc
{
    public class Item
    {
        public string name = "NoName";
        public int cost = 0;
        public bool got = false;
        public bool canStack = false;
        public int buyOrder = 0;
        public Point point;

        public Item(string name,int cost, bool got, bool canstack, int buyorder, Point position)
        {
            this.name = name;
            this.cost = cost; 
            this.got = got;
            canStack = canstack;
            buyOrder = buyorder;
            point = position;
        }

        public string getItemName()
        {
            return this.name;
        }

        public void setItemName(string name)
        {
            this.name = name;
        }

        public int getCost()
        {
            return this.cost;
        }

        public void setCost(int cost)
        {
            this.cost = cost;
        }

        public bool getGot()
        {
            return this.got;
        }

        public void setGot(bool got)
        {
            this.got = got;
        }

    }
}