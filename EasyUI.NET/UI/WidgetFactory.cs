using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace EasyUI.NET.UI
{
  public partial class WidgetFactory
  {
    public HtmlHelper Html;

    public WidgetFactory(HtmlHelper html)
    {
      Html = html;
    }
  }

  public class WidgetFactory<TModel> : WidgetFactory
  {
    public WidgetFactory(HtmlHelper<TModel> html)
      : base(html)
    {
    }
  }
}