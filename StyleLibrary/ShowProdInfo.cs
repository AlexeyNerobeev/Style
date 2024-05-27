using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StyleLibrary
{
    public class ShowProdInfo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int Count { get; set; }

        public ShowProdInfo(int id, string name, string brand, int price, string size, string color, int count)
        {
            this.ID = id;
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Size = size;
            this.Color = color;
            this.Count = count;
        }

        public void UpdateValues(int id, string name, string brand, int price, string size, string color, int count)
        {
            this.ID = id;
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Size = size;
            this.Color = color;
            this.Count = count;
        }
    }
}
