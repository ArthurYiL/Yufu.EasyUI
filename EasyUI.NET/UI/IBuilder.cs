using System.Collections.Generic;
using System.Web;

namespace EasyUI.NET.UI
{
  public interface IBuilder<TViewComponent, out TBuilder>
    where TViewComponent : Widget
    where TBuilder : IBuilder<TViewComponent, TBuilder>
  {
    TBuilder Text(string text);
    TBuilder Height(int height);
    TBuilder Width(int width);
    TBuilder Icon(Icons icon);
    TBuilder HtmlAttributes(object htmlAttributes);
    TBuilder HtmlAttributes(IDictionary<string, object> htmlAttributes);

  }
}