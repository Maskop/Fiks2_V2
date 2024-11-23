using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiks2_V2 {
    internal class Astronaut {
        private ulong points;
        private Astronaut? supervisor;
        private List<Astronaut> subordinates;

        public Astronaut(ulong points) {
            this.points = points;
            this.subordinates = new List<Astronaut>();
        }

        public void AddSubordinate(Astronaut astronaut) {
            subordinates.Add(astronaut);
        }

        public void SetSupervisor(Astronaut astronaut) {
            this.supervisor = astronaut;
        }

        public bool SetMax(ref ulong pointsToDistribute) {
            if (this.subordinates.Count == 0 && this.supervisor is not null) {
                if (this.supervisor.GetPoints() <= this.points) {
                    ulong pointsToChange = this.points - this.supervisor.GetPoints() + 1;
                    if (pointsToChange > pointsToDistribute) {
                        pointsToDistribute = 0;
                        return false;
                    }
                    this.supervisor.AddPoints(pointsToChange);
                    pointsToDistribute -= pointsToChange;
                }
                bool result = this.SetMax(this.GetSupervisor(), ref pointsToDistribute);
                if (result)
                    return true;
                else
                    return false;
            } else {
                foreach (var item in this.subordinates) {
                    bool result = item.SetMax(ref pointsToDistribute);;
                    if (result)
                        return true;
                    else
                        return false;
                }
            }
            return true;
        }

        public bool SetMax(Astronaut currentAstronaut, ref ulong pointsToDistribute) {
            if (currentAstronaut is null || !currentAstronaut.HasSupervisor())
                return true;            
            if (currentAstronaut.GetPoints() >= currentAstronaut.GetSupervisor().GetPoints()) {
                ulong pointsToChange = currentAstronaut.GetPoints() - currentAstronaut.GetSupervisor().GetPoints() + 1;
                if (pointsToChange > pointsToDistribute) {
                    pointsToDistribute = 0;
                    return false;
                }
                currentAstronaut.GetSupervisor().AddPoints(pointsToChange);
                pointsToDistribute -= pointsToChange;
            }
            if (currentAstronaut.HasSupervisor()) {
                bool result = SetMax(currentAstronaut.GetSupervisor(), ref pointsToDistribute);
                if (result)
                    return true;
                else 
                    return false;
            }
            return true;
        }

        public bool IsMaster() {
            return supervisor is null;
        }

        public bool HasSubordinates() {
            return subordinates.Count > 0;
        }

        public bool HasSupervisor() {
            return supervisor is not null;
        }

        public List<Astronaut> GetSubordinates() {
            return subordinates;
        }

        public Astronaut GetSupervisor() {
            return supervisor;
        }

        public ulong GetPoints() {
            return points;
        }
        
        public void AddPoints(ulong points) {
            this.points += points;
        }

        public void SetPoints(ulong points) {
            this.points = points;
        }

        public void WriteOutWholeTree() {
            Console.WriteLine(this.ToString());
            foreach (var item in subordinates) {
                Console.Write("-");
                item.WriteOutWholeTree();
            }
        }

        public string ToString() {
            return $"Points: {points}, Has Supervisor: {this.HasSupervisor()}, Subordinates: {subordinates.Count}";
        }
    }
}
