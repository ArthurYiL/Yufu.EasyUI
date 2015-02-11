using System.Web.Mvc;

namespace EasyUI.NET.UI
{
  public class LayoutBuilder : ContainerBuilder<Layout, LayoutBuilder>
  {
    public LayoutBuilder Fit(bool fit=true)
    {
      Component.HtmlAttributes.Merge("fit", fit.ToLowerString());
      return this;
    }

    public LayoutBuilder(Layout component, HtmlHelper htmlHelper)
      : base(component)
    {
      HtmlHelper = htmlHelper;
    }
  }

  public class LayoutRegionBuilder : ContainerBuilder<LayoutRegion, LayoutRegionBuilder>
  {
    #region DataOptions

    public LayoutRegionBuilder Collapsible(bool collapsible = true)
    {
      Component.HtmlAttributes.Merge("collapsible", collapsible.ToLowerString());
      return this;
    }
    public LayoutRegionBuilder Split(bool split = true)
    {
      Component.HtmlAttributes.Merge("split", split.ToLowerString());
      return this;
    }

    public LayoutRegionBuilder Href(string href)
    {
      Component.HtmlAttributes.Merge("href", href);
      return this;
    }
    #endregion

    public LayoutRegionBuilder(LayoutRegion component, HtmlHelper htmlHelper, RegionPlace place)
      : base(component)
    {
      HtmlHelper = htmlHelper;
      Component.HtmlAttributes.Merge("region", place.ToString());
    }
  }

  public partial class WidgetFactory
  {
    public LayoutBuilder BeginLayout()
    {
      return new LayoutBuilder(new Layout(), Html);
    }

    public LayoutRegionBuilder BeginLayoutRegion(RegionPlace place)
    {
      return new LayoutRegionBuilder(new LayoutRegion(), Html, place);
    }
  }
}