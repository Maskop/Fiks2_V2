using Fiks2;
using System.Linq;

namespace Fiks2_V2 {
    internal class Program {
        static void Main(string[] args) {
            InputHandle input = new InputHandle("sample.in");
            List<ushort> trashIndices;
            for (ushort i = 0; i < input.GetNumberOfCrews(); i++) {
                Console.WriteLine($"Crew: {i}");
                ulong pointsToDistribute = input.GetPointsToDistribute(i);
                Console.WriteLine($"Points to distribute: {pointsToDistribute}");
                trashIndices = new List<ushort>();
                Astronaut[] astronauts = input.GetAstronouts(i);
                ushort masterIndex = Algorithm.AlgorithmPart1(astronauts, trashIndices);
                astronauts[masterIndex].WriteOutWholeTree();
                //Algorithm.AlgorithmPart2V2(astronauts, masterIndex, input.GetPointsToDistribute(i));
                bool failed = Algorithm.AlgorithmPart2V2(astronauts, masterIndex, trashIndices, ref pointsToDistribute);
                Console.WriteLine("----------------------------------------------------");
                astronauts[masterIndex].WriteOutWholeTree();
                //Console.WriteLine(masterIndex + 1);
                //Console.WriteLine(String.Join(" | ", trashIndices.Select(i => i + 1)));
                Console.WriteLine($"This configuration is possible: {failed}");
                Console.WriteLine($"Points left: {pointsToDistribute}");
                Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
            }
        }

        static void Test() {
            InputHandle input = new InputHandle("sample.in");
            for (ushort i = 0; i < input.GetNumberOfCrews(); i++) {
                Console.WriteLine($"Crew index: {i}");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                watch.Start();
                foreach (var item in input.GetAstronouts(i)) {
                    Console.WriteLine(item.ToString());
                }
                watch.Stop();
                Console.WriteLine($"Time elpsed in ms: {watch.ElapsedMilliseconds}");
                Console.ReadLine();
            }
        }
    }
}
