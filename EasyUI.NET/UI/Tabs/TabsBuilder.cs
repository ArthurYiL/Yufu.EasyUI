using System.Web.Mvc;

namespace EasyUI.NET.UI
{
  public class TabsBuilder : ContainerBuilder<Tabs, TabsBuilder>
  {
    public TabsBuilder(Tabs component, HtmlHelper htmlHelper)
      : base(component)
    {
      HtmlHelper = htmlHelper;
    }

    #region HtmlAttributes

    /// <summary>
    /// tabWidth
    /// </summary>
    /// <returns></returns>
    public TabsBuilder TabWidth(int tabWidth)
    {
      Component.HtmlAttributes.Merge("tabWidth", tabWidth);
      return this;
    }

    /// <summary>
    /// tabHeight
    /// </summary>
    /// <returns></returns>
    public TabsBuilder TabHeight(int tabHeight)
    {
      Component.HtmlAttributes.Merge("tabHeight", tabHeight);
      return this;
    }

    /// <summary>
    /// selected
    /// </summary>
    /// <returns></returns>
    public TabsBuilder Selected(int index)
    {
      Component.HtmlAttributes.Merge("selected", index);
      return this;
    }

    /// <summary>
    /// tabPosition
    /// </summary>
    /// <returns></returns>
    public TabsBuilder TabPosition(Position position)
    {
      Component.HtmlAttributes.Merge("tabPosition", position.ToString());
      return this;
    }

    /// <summary>
    /// toolPosition
    /// </summary>
    /// <returns></returns>
    public TabsBuilder ToolPosition(PositionX position)
    {
      Component.HtmlAttributes.Merge("toolPosition", position.ToString());
      return this;
    }

    /// <summary>
    /// #Fit
    /// </summary>
    /// <returns></returns>
    public TabsBuilder Fit(bool fit = true)
    {
      Component.HtmlAttributes.Merge("fit", fit.ToLowerString());
      return this;
    }

    #endregion
  }

  public class TabsPanelBuilder : ContainerBuilder<TabsPanel, TabsPanelBuilder>
  {
    public TabsPanelBuilder(TabsPanel component, HtmlHelper htmlHelper)
      : base(component)
    {
      HtmlHelper = htmlHelper;
    }

    #region HtmlAttributes

    /// <summary>
    /// #Closable
    /// </summary>
    /// <returns></returns>
    public TabsPanelBuilder Closable(bool closable = true)
    {
      Component.HtmlAttributes.Merge("closable", closable.ToLowerString());
      return this;
    }

    /// <summary>
    /// #t
    /// </summary>
    /// <returns></returns>
    public TabsPanelBuilder Tools(string selector)
    {
      Component.HtmlAttributes.Merge("tools", selector);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="title">title</param>
    /// <param name="image">image url</param>
    /// <returns></returns>
    public TabsPanelBuilder Title(string title, string image)
    {
      Component.HtmlAttributes.Merge("title",
        string.Format("<span class='tt-inner'><img src='{1}'/><br>{0}</span>", title, image));
      return this;
    }


    #endregion

  }


  public partial class WidgetFactory
  {
    public TabsBuilder BeginTabs()
    {
      return new TabsBuilder(new Tabs(), Html);
    }

    public TabsPanelBuilder BeginTabsPanel()
    {
      return new TabsPanelBuilder(new TabsPanel(), Html);
    }
  }
}