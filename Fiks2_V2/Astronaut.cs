using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiks2_V2 {
    internal class Astronaut {
        private ushort index;
        private ulong points;
        private Astronaut supervisor;
        private List<Astronaut> subordinates;

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
