using System;
using System.Collections.Generic;
using System.Text;

namespace _7_Military_Elite.Interfaces
{
    public interface ILieutenantGeneral : IPrivate
    {
        public List<IPrivate> Privates { get; set; }
    }
}
