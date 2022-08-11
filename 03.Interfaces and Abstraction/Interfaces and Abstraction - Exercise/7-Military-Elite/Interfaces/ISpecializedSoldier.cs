using System;
using System.Collections.Generic;
using System.Text;

namespace _7_Military_Elite.Interfaces
{
    public interface ISpecializedSoldier : IPrivate
    {
        public Corps Corps { get; set; }
    }
}
