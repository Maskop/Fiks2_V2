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

        public string ToString() {
            return $"Points: {points}, Supervisor: {supervisor}, Subordinates: {subordinates.Count}";
        }
    }
}
