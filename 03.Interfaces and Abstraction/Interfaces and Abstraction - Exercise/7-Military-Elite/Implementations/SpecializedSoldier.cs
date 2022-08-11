using _7_Military_Elite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7_Military_Elite.Implementations
{
    public abstract class SpecializedSoldier : Private, ISpecializedSoldier
    {
        protected SpecializedSoldier(int iD, string firstName, string lastName, decimal salary, Corps corps) 
            : base(iD, firstName, lastName, salary)
        {
            Corps = corps;
        }

        public Corps Corps { get ; set ; }
    }
}
