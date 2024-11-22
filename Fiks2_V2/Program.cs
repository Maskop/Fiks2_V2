using Fiks2;
using System.Linq;

namespace Fiks2_V2 {
    internal class Program {
        static void Main(string[] args) {
            InputHandle input = new InputHandle("sample.in");
            List<ushort> trashIndices = new List<ushort>();
            for (ushort i = 0; i < input.GetNumberOfCrews(); i++) {
                Astronaut[] astronauts = input.GetAstronouts(i);
                ushort masterIndex = Algorithm.AlgorithmPart1(astronauts, trashIndices);
                Console.WriteLine(masterIndex + 1);
                Console.WriteLine(String.Join(" | ", trashIndices.Select(i => i + 1)));
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
