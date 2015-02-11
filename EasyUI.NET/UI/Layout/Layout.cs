namespace EasyUI.NET.UI
{
  public class Layout : Widget
  {
    public Layout()
    {
      Tag = "div";
      HtmlAttributes.AppendInValue("class", " ", "easyui-layout");
    }
  }

  public class LayoutRegion : Widget
  {
    public LayoutRegion()
    {
      Tag = "div";
    }
  }
}