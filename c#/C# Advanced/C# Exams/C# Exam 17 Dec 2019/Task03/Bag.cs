using Christmas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        private List<Present> data;

        public Bag(string color, int capacity)
        {
            this.data = new List<Present>();
            this.Color = color;
            this.Capacity = capacity;
        }

        public int Count
        {
            get
            {
                return data.Count;
            }

        }

        public string Color { get; set; }

        public int Capacity { get; set; }

        public void Add(Present present)
        {
            if (this.Count < this.Capacity)
            {
                this.data.Add(present);
            }
        }

        public bool Remove(string name)
        {
            var present = this.data.FirstOrDefault(x => x.Name == name);
            if(present != null)
            {
                this.data.Remove(present);
                return true;
            }
            return false;
        }

        public Present GetHeaviestPresent()
        {
            return this.data.OrderByDescending(x => x.Weight).FirstOrDefault();
        }

        public Present GetPresent(string name)
        {
            return this.data.FirstOrDefault(x => x.Name == name);

        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Color} bag contains:");
            sb.AppendLine(string.Join(Environment.NewLine, this.data));

            return sb.ToString().TrimEnd();
        }
    }
}
