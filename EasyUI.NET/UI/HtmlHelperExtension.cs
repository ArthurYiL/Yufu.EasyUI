using System.Web.Mvc;

namespace EasyUI.NET.UI
{
  public static class HtmlHelperExtension
  {
    public static WidgetFactory EasyUI(this HtmlHelper helper)
    {
      return new WidgetFactory(helper);
    }

    public static WidgetFactory<TModel> EasyUI<TModel>(this HtmlHelper<TModel> helper)
    {
      return new WidgetFactory<TModel>(helper);
    }
  }
}