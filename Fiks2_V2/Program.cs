using Fiks2;

namespace Fiks2_V2 {
    internal class Program {
        static void Main(string[] args) {
            Test();
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
                watch.Stop(); Console.WriteLine($"Time elpsed in ms: {watch.ElapsedMilliseconds}");
                Console.ReadLine();
            }
        }
    }
}
