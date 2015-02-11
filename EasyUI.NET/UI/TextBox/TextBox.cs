namespace EasyUI.NET.UI
{
  public class TextBox : Widget
  {
    public TextBox()
    {
      Tag = "input";
      HtmlAttributes.AppendInValue("class", " ", "easyui-textbox");
    }
  }
}