using Fiks2_V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Fiks2 {
    internal class InputHandle {
        // The lines of the input file
        private string[] lines;

        public InputHandle(string filePath) {
            // Read the input file
            this.lines = File.ReadAllLines(filePath);
        }

        public Astronaut[] GetAstronouts(ushort index) {
            // Initialize the variables
            Astronaut[] astronauts;
            ushort numberOfAstronauts;
            ulong pointsToDistribute;

            // Get the number of astronouts and points to distribute
            var firstLine = lines[(index*3)+1].Split(' ').Select(ulong.Parse).ToArray();
            numberOfAstronauts = (ushort)firstLine[0];
            pointsToDistribute = firstLine[1];            

            // Initialize the astronouts array
            astronauts = new Astronaut[numberOfAstronauts];


            // Initialize the astronouts
            foreach (var (line, i) in lines[(index * 3) + 2].Split(' ').Select(long.Parse).ToArray().WithIndex()) {
                astronauts[i] = new Astronaut((ushort)i, (ulong)line);
            }
            foreach (var line in lines[(index * 3) + 3].Split(' ').Select(long.Parse).ToArray()) {
                
            }

            // Return the astronouts
            return astronauts;
        }

        public ulong GetPointsToDistribute(ushort index) {
            return lines[(index * 3) + 1].Split(' ').Select(ulong.Parse).ElementAt(1);
        }

        public ushort GetNumberOfCrews() {
            return ushort.Parse(this.lines[0]);
        }
    }
}
