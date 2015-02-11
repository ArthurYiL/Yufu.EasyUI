using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EasyUI.NET
{
  public static class EnumExtensions
  {
    public static string GetDescription(this Enum enumerationValue)
    {
      var type = enumerationValue.GetType();
      if (!type.IsEnum)
      {
        throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
      }
      //Tries to find a DescriptionAttribute for a potential friendly name for the enum
      var memberInfo = type.GetMember(enumerationValue.ToString());
      if (memberInfo.Length > 0)
      {
        var attrsDesc = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
        var attrsDisp = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);

        if (attrsDesc.Length > 0) return ((DescriptionAttribute)attrsDesc[0]).Description;
        if (attrsDisp.Length > 0) return ((DisplayAttribute)attrsDisp[0]).Name;
      }
      //If we have no description attribute, just return the ToString of the enum
      return enumerationValue.ToString();
    }
  }
}