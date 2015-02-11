using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI;

namespace EasyUI.NET.UI
{
  public class Widget : IWidget
  {
    public Widget()
    {
      HtmlAttributes = new Dictionary<string, object>();
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public string Text { get; set; }
    public string Tag { get; set; }
    public ModelMetadata ModelMetadata { get; set; }
    public IDictionary<string, object> HtmlAttributes { get; set; }
  }
}