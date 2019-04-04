using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    class Editor : Sea
    {
        static int[] length_ships = { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };
        static Random rand = new Random();

        public Editor()
            : base()
        {

        }

        public bool PlacePrecisely()
        {
            Reset();
            PlaceShips(0,
                new Dot[]
                {
                    new Dot(1,1),
                    new Dot(2,1),
                    new Dot(3,1),
                    new Dot(4,1)});

            PlaceShips(1,
                new Dot[]
                {
                    new Dot(1,3),
                    new Dot(2,3),
                    new Dot(3,3)});

            PlaceShips(2,
                new Dot[]
                {
                    new Dot(5,3),
                    new Dot(6,3),
                    new Dot(7,3) });

            PlaceShips(3,
                new Dot[]
                {
                    new Dot(1,5),
                    new Dot(2,5)});

            PlaceShips(4,
                new Dot[]
                {
                    new Dot(4,5),
                    new Dot(4,5)});

            PlaceShips(5,
                new Dot[]
                {
                    new Dot(7,5),
                    new Dot(8,5)});

            for(int x = 6; x < all_ships; x++)
            { 
            PlaceShips(x,
                new Dot[]{
                    new Dot((x-5)*2-1, 7)});
            }

            return true;
        }

        public void Reset()
        {
            for (int x = 0; x < size_sea.x; x++)
                for (int y = 0; y < size_sea.y; y++)
                {
                    map_ships[x, y] = -1;
                    ShowShip(new Dot(x, y), -1);
                    map_hits[x, y] = Status.indefinitely;
                    ShowFigth(new Dot(x, y), Status.indefinitely);
                }
            for (int k = 0; k < all_ships; k++)
            {
                ship[k] = null;
            }
            Created = 0;
            Killed = 0;
        }

        public bool PlaceForDots(Dot[] deck)
        {
            int length = deck.Length;
            int number = SearchNumber(length);
            if (number < 0)
                return false;
            Dot LT = deck[0];
            Dot RD = deck[0];
            for(int j = 1; j < length; j++)
            {
                LT.x = Math.Min(LT.x, deck[j].x);
                LT.y = Math.Min(LT.y, deck[j].y);

                RD.x = Math.Max(RD.x, deck[j].x);
                RD.y = Math.Max(RD.y, deck[j].y);
            }
            if (LT.x == RD.x) //vertical
            {
                if (RD.y - LT.y + 1 != length)
                    return false;
            }
            else
            if (LT.y == RD.y) //horizontal
            {
                if (RD.x - LT.x + 1 != length)
                    return false;
            }
            else
                return false;
            for (int j = 0; j < length; j++)
                CleanField(deck[j]);
            PlaceShips(number, deck);
            return true;
        }

        protected int SearchNumber(int length)
        {
            for (int j = 0; j < length_ships.Length; j++)
                if (length == length_ships[j])
                    if (NoShip(j))
                        return j;
            return -1;
        }

        public void PlaceShips(int number, Dot[] deck)
        {
            if (ship[number] != null)
                RemoveShip(number);
            ship[number] = new Ship(deck);
            foreach (Dot t in deck)
            {
                map_ships[t.x, t.y] = number;
                ShowShip(t, number);
            }
            Created++;
        }

        public void RemoveShip(int number)
        {
            foreach (Dot t in ship[number].deck)
            {
                map_ships[t.x, t.y] = -1;
                ShowShip(t, -1);
            }
            ship[number] = null;
            Created--;
        }

        public bool NoShip(int number)
        {
            return ship[number] == null;
        }

        public int MapShips(Dot t)
        {
            if (OnSea(t))
                return map_ships[t.x, t.y];
            return -1;
        }

        protected void CleanField(Dot t)
        {
            Dot p;
            for (p.x = t.x - 1; p.x <= t.x + 1; p.x++)
                for (p.y = t.y - 1; p.y <= t.y + 1; p.y++)
                    CleanDot(p);
        }

        public void CleanDot(Dot t)
        {
            if (!OnSea(t))
                return;
            if (map_ships[t.x, t.y] == -1)
                return;
            RemoveShip(map_ships[t.x,t.y]);
        }

        public bool PlaceRandom(int number)
        {
            int length = length_ships[number];
            Dot stern;
            Dot step;
            if (rand.Next(2) == 0) // horizontal
            {
                stern = new Dot(rand.Next(0, size_sea.x - length + 1), rand.Next(0, size_sea.y));
                step = new Dot(1, 0);
            }
            else //  vertical
            {
                stern = new Dot(rand.Next(0, size_sea.x), rand.Next(0, size_sea.y-length+1));
                step = new Dot(0, 1);
            }
            Dot[] deck = new Dot[length];
            for(int j = 0; j < length; j++)
            {
                deck[j] = new Dot(stern.x + j * step.x, stern.y + j * step.y);
                CleanField(deck[j]);
            }

            PlaceShips(number, deck);
            return true;
        }

        public void PlaceRandom()
        {
            Reset();
            int loop = 500;
            while (loop > 0 && Created < Sea.all_ships)
            {
                for (int j = 0; j < Sea.all_ships; j++)
                    if (NoShip(j))
                        PlaceRandom(j);
                loop--;
            }
            if (Created < Sea.all_ships)
                Reset();
        }
    }
}
