using System;
using System.Web.UI;

namespace EasyUI.NET.UI
{
  public class Panel : Widget
  {
    public Panel()
    {
      Tag = "div";
      HtmlAttributes.AppendInValue("class", " ", "easyui-panel");
    }
  }
}