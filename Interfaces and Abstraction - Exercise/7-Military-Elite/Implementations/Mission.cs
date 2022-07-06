﻿using _7_Military_Elite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7_Military_Elite.Implementations
{
    public class Mission : IMission
    {
        private string missionCode;
        private object value;

        public Mission(string codeName, Status status)
        {
            CodeName = codeName;
            Status = status;
        }

        public string CodeName { get; set; }
        public Status Status { get; set; }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {Status}";
        }
    }
}
