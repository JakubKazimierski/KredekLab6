using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JakubKazimierskiLab6.Models
{
    public class CarViewModels
    {
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }
        public string Photo { get; set; }

        public CarViewModels(string model, string manufacturer, decimal price, string photo )
        {
            Model = model;
            Manufacturer = manufacturer;
            Price = price;
            Photo = photo;
        }
    }
}
