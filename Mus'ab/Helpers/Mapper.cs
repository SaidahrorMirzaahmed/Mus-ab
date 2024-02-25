using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mus_ab.Helpers;

public static class Mapper
{
    public static T MapTo<T>(this object obj) where T : class, new()
    {
        var objType = obj.GetType();
        var objProperties = objType.GetProperties();

        var dto = new T();
        var dtoType = dto.GetType();
        var dtoProperties = dtoType.GetProperties();

        foreach (var objProperty in objProperties)
        {
            if (dtoProperties.Any(p => p.Name == objProperty.Name))
            {
                var dtoProperty = dtoType.GetProperty(objProperty.Name);
                var value = objProperty.GetValue(obj);
                dtoProperty.SetValue(dto, value);
            }
        }
        return dto;
    }
}
