using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace EasyUI.NET.UI
{
  public interface IWidget
  {
    string Id { get; }
    string Name { get; }
    string Text { get; }
    string Tag { get; }
    ModelMetadata ModelMetadata { get; }
    IDictionary<string, object> HtmlAttributes
    {
      get;
    }
  }
}