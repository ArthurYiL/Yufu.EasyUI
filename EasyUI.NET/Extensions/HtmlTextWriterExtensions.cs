using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace EasyUI.NET
{
  public static class HtmlTextWriterExtensions
  {
    public static void AddAttributes(this HtmlTextWriter writer, IDictionary<string, object> attributes)
    {
      if (attributes!=null && attributes.Any())
      {
        foreach (KeyValuePair<string, object> attribute in attributes)
        {
          writer.AddAttribute(attribute.Key, attribute.Value.ToString(), true);
        }
      }
    }
  }
}