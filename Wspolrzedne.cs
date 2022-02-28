using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zdarzenia
{
    class Wspolrzedne
    {
        public int x;
        public int y;
        public bool kolo = false;

        public Wspolrzedne(int x, int y, bool kolo)
        {
            this.x = x;
            this.y = y;
            this.kolo = kolo;
        }

        public Wspolrzedne(Wspolrzedne wspolrzedne)
        {
            this.x = wspolrzedne.x;
            this.y = wspolrzedne.y;
            this.kolo = wspolrzedne.kolo;
        }
    }
}
