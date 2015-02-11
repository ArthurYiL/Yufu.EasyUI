namespace EasyUI.NET.UI
{
  public class Tabs : Widget
  {
    public Tabs()
    {
      Tag = "div";
      HtmlAttributes.AppendInValue("class", " ", "easyui-tabs");
    }
  }

  public class TabsPanel : Widget
  {
    public TabsPanel()
    {
      Tag = "div";
    }
  }
}