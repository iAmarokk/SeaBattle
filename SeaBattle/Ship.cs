using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class Ship
    {
        int hit;

        public Dot[] deck
        {
            get; private set;
        }

        public Ship(Dot[] deck)
        {
            hit = 0;
            this.deck = deck;
        }

        public Status Shot(Dot t)
        {
            for (int j = 0; j < deck.Length; j++)
                if (deck[j].x == t.x &&
                    deck[j].y == t.y)
                {
                    hit++;
                    if (hit == deck.Length)
                        return Status.kill;
                    else
                        return Status.slash;
                }
            return Status.miss;
        }
    }
}
