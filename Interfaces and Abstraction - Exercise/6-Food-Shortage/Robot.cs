using System;
using System.Collections.Generic;
using System.Text;

namespace _6_Food_Shortage
{
    public class Robot : IIdentifiable
    {
        public Robot(string iD, string model)
        {
            ID = iD;
            Model = model;
        }

        public string ID { get; }

        public string Model { get; set; }
    }
}
