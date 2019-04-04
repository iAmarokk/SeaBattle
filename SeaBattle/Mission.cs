using System;

namespace SeaBattle
{
    public class Mission
    {
        Sea sea;
        Random rand;
        int[,] shape =
        {
            {1, 2, 1, 3, 1, 2, 1, 3, 1, 2 },
            {2, 1, 3, 1, 2, 1, 3, 1, 2, 1 },
            {1, 3, 1, 2, 1, 3, 1, 2, 1, 3 },
            {3, 1, 2, 1, 3, 1, 2, 1, 3, 1 },
            {1, 1, 1, 3, 1, 2, 1, 3, 1, 2 },
            {2, 1, 3, 1, 2, 1, 3, 1, 2, 1 },
            {1, 3, 1, 2, 1, 3, 1, 2, 1, 3 },
            {3, 1, 2, 1, 3, 1, 2, 1, 3, 1 },
            {1, 2, 1, 3, 1, 2, 1, 3, 1, 2 },
            {2, 1, 3, 1, 2, 1, 3, 1, 2, 1 }
        };
        bool modeDanger;

        int[] shiplength = new int[5];
        int[,] map;
        int[,] put;

        public Mission(Sea sea)
        {
            this.sea = sea;
            rand = new Random();
            map = new int[Sea.size_sea.x, Sea.size_sea.y];
            put = new int[Sea.size_sea.x, Sea.size_sea.y];
            Reset();
        }

        private void Reset()
        {
            shiplength[1] = 4;
            shiplength[2] = 3;
            shiplength[3] = 2;
            shiplength[4] = 1;
            for (int x = 0; x < Sea.size_sea.x; x++)
                for (int y = 0; y < Sea.size_sea.y; y++)
                    map[x, y] = 0;
            modeDanger = false;
        }

        public Status Fight(out Dot target)
        {
            if (modeDanger)
                target = fightDanger();
            else
                target = fightShapes();
            Status status = sea.Shot(target);
            switch (status)
            {
                case Status.miss: map[target.x, target.y] = 1; break;
                case Status.slash:
                    map[target.x, target.y] = 2;
                    modeDanger = true;
                    break;
                case Status.kill:
                case Status.win:
                    map[target.x, target.y] = 2;
                    int len = markKilledShip(target);
                    shiplength[len]--;
                    modeDanger = false;
                    break;
            }

            return status;
        }

        private Dot fightShapes()
        {
            InitPut();
            for (int x = 0; x < Sea.size_sea.x; x++)
                for (int y = 0; y < Sea.size_sea.y; y++)
                    if (map[x, y] == 0)
                        put[x, y] = shape[x, y];
            return RandomPut();
        }

        private Dot fightDanger()
        {
            InitPut();
            for (int x = 0; x < Sea.size_sea.x; x++)
                for (int y = 0; y < Sea.size_sea.y; y++)
                    if (map[x, y] == 2)
                    {
                        bool longer = false;
                        Dot ship = new Dot(x, y);
                        for (int length = shiplength.Length - 1; length >= 2; length--)
                            if (longer || shiplength[length] > 0)
                            {
                                CheckShipDirection(ship, -1, 0, length);
                                CheckShipDirection(ship, 1, 0, length);
                                CheckShipDirection(ship, 0, -1, length);
                                CheckShipDirection(ship, 0, 1, length);
                                longer = true;
                            }
                    }
            return RandomPut();
        }

        private void CheckShipDirection(Dot ship, int sx, int sy, int length)
        {
            if (Map(ship.x, ship.y) != 2)
                return;
            if (Map(ship.x - sx, ship.y - sy) == 2)
                return;
            if (sx == 0)
            {
                if (Map(ship.x - 1, ship.y) == 2) return;
                if (Map(ship.x + 1, ship.y) == 2) return;
            }
            if (sx == 0)
            {
                if (Map(ship.x, ship.y - 1) == 2) return;
                if (Map(ship.x, ship.y + 1) == 2) return;
            }
            int unknown = 0;
            int unknown_j = 0;
            for (int j = 1; j < length; j++)
            {
                int p = Map(ship.x + j * sx, ship.y + j * sy);
                if (p == 1) return;
                if (p == -1) return;
                if (p == 0)
                {
                    unknown++;
                    if (unknown == 1)
                        unknown_j = j;
                }
            }
            if (unknown >= 1)
                put[ship.x + unknown_j * sx, ship.y + unknown_j * sy]++;

        }

        private int Map(int x, int y)
        {
            if (sea.OnSea(new Dot(x, y)))
                return map[x, y];
            return -1;
        }

        private void InitPut()
        {
            for (int x = 0; x < Sea.size_sea.x; x++)
                for (int y = 0; y < Sea.size_sea.y; y++)
                    put[x, y] = 0;
        }

        private Dot RandomPut()
        {
            //ShowPutArray();
            int max = -1;
            int qty = 0;

            for (int x = 0; x < Sea.size_sea.x; x++)
                for (int y = 0; y < Sea.size_sea.y; y++)
                    if (put[x, y] > max)
                    {
                        max = put[x, y];
                        qty = 1;
                    }
                    else
                        if (put[x, y] == max)
                        qty++;
            int nr = rand.Next(0, qty);
            for (int x = 0; x < Sea.size_sea.x; x++)
                for (int y = 0; y < Sea.size_sea.y; y++)
                    if (put[x, y] == max)
                        if (nr-- == 0)
                            return new Dot(x, y);
            return new Dot(0, 0);
        }

        private int markKilledShip(Dot place)
        {
            if (!sea.OnSea(place))
                return 0;
            if (map[place.x, place.y] == 2)
            {
                map[place.x, place.y] = 3;
                int x, y;
                for (x = place.x - 1; x <= place.x + 1; x++)
                    for (y = place.y - 1; y <= place.y + 1; y++)
                        if (Map(x, y) == 0)
                            map[x, y] = 1;
                int length = 1;
                length += markKilledShip(new Dot(place.x - 1, place.y));
                length += markKilledShip(new Dot(place.x + 1, place.y));
                length += markKilledShip(new Dot(place.x, place.y - 1));
                length += markKilledShip(new Dot(place.x, place.y + 1));
                return length;
            }
            return 0;
        }

        private void ShowPutArray()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            for (int x = 0; x < Sea.size_sea.x; x++)
                for (int y = 0; y < Sea.size_sea.y; y++)
                {
                    Console.SetCursorPosition(x + 1, y + 12);
                    Console.Write(put[x, y] > 0 ?
                        put[x, y].ToString() : " ");
                }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ReadKey();
        }
    }
}

