using System.IO;
using System.Web.Mvc;
using System.Web.UI;

namespace EasyUI.NET.UI
{
  public class LinkButtonBuilder : Builder<LinkButton, LinkButtonBuilder>
  {
    public LinkButtonBuilder(LinkButton component)
      : base(component)
    {
    }

    #region HtmlAttributes

    /// <summary>
    /// set selected.
    /// </summary>
    /// <returns></returns>
    public LinkButtonBuilder Selected(bool selected = true)
    {
      Component.HtmlAttributes.Merge("selected", selected.ToLowerString());
      return this;
    }

    /// <summary>
    /// Click the button below to switch its selected state.
    /// </summary>
    /// <returns></returns>
    public LinkButtonBuilder Toggle(bool toggle = true)
    {
      Component.HtmlAttributes.Merge("toggle", toggle.ToLowerString());
      return this;
    }

    /// <summary>
    /// The buttons with plain style have transparent background.
    /// </summary>
    /// <returns></returns>
    public LinkButtonBuilder Plain(bool plain = true)
    {
      Component.HtmlAttributes.Merge("plain", plain.ToLowerString());
      return this;
    }



    public LinkButtonBuilder Icon(Icons icon, IconAlign align = IconAlign.left)
    {
      base.Icon(icon);
      Component.HtmlAttributes.Merge("iconAlign", align.ToString());
      return this;
    }

    /// <summary>
    /// how to display small buttons and large buttons.
    /// </summary>
    /// <param name="size"></param>
    /// <returns></returns>
    public LinkButtonBuilder Szie(Size size)
    {
      Component.HtmlAttributes.Merge("size", size.ToString());
      return this;
    }

    public LinkButtonBuilder LinkStyle(LinkStyle linkStyle)
    {
      Component.HtmlAttributes.AppendInValue("class", " ", linkStyle.ToString());
      return this;
    }

    public LinkButtonBuilder Url(string url)
    {
      Component.HtmlAttributes.Merge("href", url);
      return this;
    }

    #endregion
  }

  public partial class WidgetFactory
  {
    public LinkButtonBuilder LinkButton()
    {
      return new LinkButtonBuilder(new LinkButton());
    }
  }
}