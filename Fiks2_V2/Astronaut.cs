using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiks2_V2 {
    internal class Astronaut {
        private ushort index { get; set; }
        private ulong points { get; set; }
        private Astronaut supervisor { get; set; }
        private List<Astronaut> subordinates { get; set; }

        public Astronaut(ushort index, ulong points, Astronaut supervisor) {
            this.index = index;
            this.points = points;
            this.supervisor = supervisor;
            this.subordinates = new List<Astronaut>();
        }

        public void AddSubordinate(Astronaut astronaut) {
            subordinates.Add(astronaut);
        }


    }
}
