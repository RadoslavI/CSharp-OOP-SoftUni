﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Child : Person
    {
        

        public Child(string name, int age) : base(name, age)
        {
        }

        public override int Age
        {
            get { return Age; }

            set
            {
                if (base.Age > 15)
                    base.Age = 15;
                else
                    base.Age = value;
            }
        }
    }
}
