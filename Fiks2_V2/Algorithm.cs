using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiks2_V2 {
    internal static class Algorithm {
        public static ushort AlgorithmPart1(Astronaut[] astronauts, List<ushort> trashIndices) {
            ushort masterIndex = 0;
            foreach (var (astronaut, index) in astronauts.Select((a, i) => (a, i))) {
                if (astronaut.IsMaster()) {
                    masterIndex = (ushort)index;
                }
                if (!astronaut.HasSubordinates()) {
                    trashIndices.Add((ushort)index);
                }
            }
            return masterIndex;
        }
    }
}
