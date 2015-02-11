using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace EasyUI.NET.UI
{
  public class PanelBuilder : ContainerBuilder<Panel, PanelBuilder>
  {
    public PanelBuilder(Panel component, HtmlHelper htmlHelper)
      : base(component)
    {
      HtmlHelper = htmlHelper;
    }

    #region DataOptions

    /// <summary>
    /// #footer
    /// </summary>
    /// <param name="selector"></param>
    /// <returns></returns>
    public PanelBuilder Footer(string selector)
    {
      DataOptions.Merge("footer", selector);
      return this;
    }
    #endregion

    #region HtmlAttributes
    /// <summary>
    /// #tt
    /// </summary>
    /// <param name="selector"></param>
    /// <returns></returns>
    public PanelBuilder Tools(string selector)
    {
      Component.HtmlAttributes.Merge("tools", selector);
      return this;
    }

    public PanelBuilder Closable(bool closable = true)
    {
      Component.HtmlAttributes.Merge("closable", closable.ToLowerString());
      return this;
    }

    public PanelBuilder Collapsible(bool collapsible = true)
    {
      Component.HtmlAttributes.Merge("collapsible", collapsible.ToLowerString());
      return this;
    }

    public PanelBuilder Minimizable(bool minimizable = true)
    {
      Component.HtmlAttributes.Merge("minimizable", minimizable.ToLowerString());
      return this;
    }

    public PanelBuilder Maximizable(bool maximizable = true)
    {
      Component.HtmlAttributes.Merge("maximizable", maximizable.ToLowerString());
      return this;
    }

    #endregion
  }

  public partial class WidgetFactory
  {
    public PanelBuilder BeginPanel()
    {
      return new PanelBuilder(new Panel(), Html);
    }
  }
}