using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public delegate void deShowShip(Dot place, int nr);
    public delegate void deShowFigth(Dot place, Status status);

    public class Sea
    {
        public static Dot size_sea = new Dot(10, 10);
        public static int all_ships = 10;

        public deShowShip ShowShip;
        public deShowFigth ShowFigth;

        protected int[,] map_ships; // -1 null 0...9 
        protected Status[,] map_hits; // indefinitely ... in game changed

        public Ship[] ship;

        public int Created
        { get; protected set; }

        public int Killed
        { get; protected set; }

        public Sea()
        {
            map_ships = new int[size_sea.x, size_sea.y];
            map_hits = new Status[size_sea.x, size_sea.y];
            ship = new Ship[all_ships];
        }



        public Status MapHits(Dot t)
        {
            if (OnSea(t))
                return map_hits[t.x, t.y];
            return Status.indefinitely;
        }

        public bool OnSea(Dot t)
        {
            return (t.x >= 0 && t.x < size_sea.x &&
                    t.y >= 0 && t.y < size_sea.y);
        }

        public Status Shot(Dot t)
        {
            if (!OnSea(t))
                return Status.indefinitely;
            if (map_hits[t.x, t.y] != Status.indefinitely)
                return map_hits[t.x, t.y];
            Status status;
            if(map_ships[t.x,t.y] == -1)
            {
                map_hits[t.x, t.y] = Status.miss;
                status = Status.miss;
            } else
            status = ship[map_ships[t.x, t.y]].Shot(t);
            map_hits[t.x, t.y] = status;
            if (status == Status.kill)
            {
                Killed++;
                if (Killed >= Created)
                    status = Status.win;
            }
            ShowFigth(t, status);
            return status;
        }
    }

     
}
