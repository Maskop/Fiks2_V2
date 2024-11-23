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

        public static void AlgorithmPart2(Astronaut[] astronauts, ushort masterIndex, List<ushort> trashIndices) {
            foreach (var trashIndex in trashIndices) {
                Astronaut currentAstronaut = astronauts[trashIndex];
                Astronaut supervisor = astronauts[trashIndex].GetSupervisor();
                if (supervisor.GetPoints() < currentAstronaut.GetPoints()) {
                    supervisor.SetPoints(currentAstronaut.GetPoints() + 1);
                }
            }

                /*
                foreach (var trashIndex in trashIndices) {
                    Astronaut currentAstronaut = astronauts[trashIndex];
                    Astronaut supervisor = astronauts[trashIndex].GetSupervisor();
                    while (currentAstronaut.HasSupervisor()) {
                        supervisor = supervisor.GetSupervisor();
                        if (supervisor.GetPoints() < currentAstronaut.GetPoints()) {
                            supervisor.SetPoints(currentAstronaut.GetPoints() + 1);
                        }
                        currentAstronaut = supervisor;
                    }
                }
                */
        }
        public static bool AlgorithmPart2V2(Astronaut[] astronauts, ushort masterIndex, List<ushort> trashIndices, ref ulong pointsToDistribute) {
            foreach (var trash in trashIndices) {
                return astronauts[trash].SetMax(astronauts[trash],ref pointsToDistribute);
            }
            return false;
        }
    }
}
