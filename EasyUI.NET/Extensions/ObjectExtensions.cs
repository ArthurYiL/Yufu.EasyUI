﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace EasyUI.NET
{
  internal static class ObjectExtensions
  {
    public static IDictionary<string, object> ToDictionary(this object @object)
    {
      var dictionary = new Dictionary<string, object>(StringComparer.CurrentCultureIgnoreCase);
      if (@object != null)
      {
        foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(@object))
        {
          dictionary.Add(property.Name.Replace("_", "-"), property.GetValue(@object));
        }
      }
      return dictionary;
    }
  }
}