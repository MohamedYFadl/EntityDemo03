using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDemo03.Entities
{
    public abstract class Vechicle
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }

    }
    public class Car:Vechicle {
        public int DoorsCount { get; set; }
        public override string ToString()
            => $"Id = {Id}, Make = {Make}, Model = {Model}, DoorsCount = {DoorsCount}";
    }
    public class Truck : Vechicle {
        public int LoadCapacity { get; set; }
        public override string ToString()
        {
            return $"Id = {Id}, Make = {Make}, Model = {Model}, LoadCapacity= {LoadCapacity}";
        }
    }
}
