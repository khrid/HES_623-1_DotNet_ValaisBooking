using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class Hotel
    {

        public int IdHotel { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public int Category { get; set; }

        public bool HasWifi { get; set; }

        public bool HasParking { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }

        public override string ToString()
        {
            return $"{IdHotel}|{Name}|{Description}|{Location}|{Category}|{HasWifi}|{HasParking}|{Phone}|{Email}|{Website}";
        }
    }

}
