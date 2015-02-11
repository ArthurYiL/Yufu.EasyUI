using System.Web.UI;

namespace EasyUI.NET.UI
{
  public class LinkButton : Widget
  {
    public LinkButton()
    {
      Tag = "a";
      HtmlAttributes.AppendInValue("class", " ","easyui-linkbutton");
    }
  }
}