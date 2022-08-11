using System;
using System.Linq;
using System.Reflection;

namespace ValidationAttributes
{
    public class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] propertyInfos = obj.GetType().GetProperties()
                .Where(x => x.GetCustomAttributes(typeof(MyValidationAttribute)).Any()).ToArray();

            foreach (var item in propertyInfos)
            {
                object value = item.GetValue(obj);
                MyValidationAttribute attribute = item.GetCustomAttribute<MyValidationAttribute>();

                bool isValid = attribute.isValid(value);

                if (!isValid)
                    return false;                                    
            }

            return true;
        }
    }
}