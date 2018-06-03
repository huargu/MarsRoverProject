using System;
using System.ComponentModel;
using System.Reflection;

public static class EnumExtensions
{
    public static string GetDescription(this Enum _enum)
    {
        Type _type = _enum.GetType();
        string name = Enum.GetName(_type, _enum);
        if (name != null)
        {
            FieldInfo fieldInfo = _type.GetField(name);
            if (fieldInfo != null)
            {
                DescriptionAttribute attr = Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attr != null)
                {
                    return attr.Description;
                }
            }
        }
        throw new Exception("Enum Description Exception");
    }

    public static Enum ParseByDescription(this Enum _enum, string desc)
    {
        Type type = _enum.GetType();
        string [] names = Enum.GetNames(type);
        
        foreach(string name in names)
        {
            if (GetDescription((Enum)Enum.Parse(type, name)).Equals(desc)) 
            { 
                return (Enum)Enum.Parse(type, name);
            } 
        }

        throw new Exception("Enum Parsing Exception");
    }
}
