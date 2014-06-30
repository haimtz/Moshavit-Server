using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ReflectionTest
{
    public class Equal
    {
        public static bool IsEqual(IEnumerable<object> listA, IEnumerable<object> listB)
        {
            var enumerable = listA as object[] ?? listA.ToArray();
            var objects = listB as object[] ?? listB.ToArray();

            for (var index = 0; index < enumerable.Count(); index++)
            {
                var objA = enumerable.ToList()[index];    
                var objB = objects.ToList()[index];

                if (!IsEqualObject(objA, objB))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsEqualObject(object objA, object objB)
        {
            var typeA = objA.GetType();
            var typeB = objB.GetType();

            return typeA == typeB && IsPropertyEqual(typeA.GetProperties(), typeA.GetProperties()) && 
                    IsValuesEqual(typeA.GetProperties(), objA, objB);
        }


        private static bool IsPropertyEqual(ICollection<PropertyInfo> propertyA, ICollection<PropertyInfo> propertyB)
        {
            if(propertyA.Count != propertyB.Count)
                return false;
            
            var arrA = propertyA.ToList();
            var arrB = propertyB.ToList();
            return !arrA.Where((t, index) => t.Name != arrB[index].Name).Any();
        }

        private static bool IsValuesEqual(IEnumerable<PropertyInfo> property, object objA, object objB)
        {
            var listProp = property.ToList();

            foreach (var propertyInfo in listProp)
            {
                var valueA = propertyInfo.GetValue(objA);
                var valueB = propertyInfo.GetValue(objB);

                if (valueA == null && valueB == null)
                    continue;

                if (valueA is string && !valueA.Equals(valueB))
                    return false;

                if (valueA is int && !valueA.Equals(valueB))
                    return false;

                if (!(valueA is string) && objA.GetType().IsClass && !IsEqualObject(valueA, valueB))
                    return false;
            }
            return true;
        }
    }
}
