using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParalimpiaGUI
{
    public class Paralimpia
    {
        public Paralimpia(int id, string orszag, string varos, int ev, int arany, int ezust, int bronz)
        {
            Id = id;
            Orszag = orszag;
            Varos = varos;
            Ev = ev;
            Arany = arany;
            Ezust = ezust;
            Bronz = bronz;
        }

        public int Id { get; set; }
        public string Orszag { get; set; }
        public string Varos { get; set; }
        public int Ev { get; set; }
        public int Arany { get; set; }
        public int Ezust { get; set; }
        public int Bronz { get; set; }
    }
}
