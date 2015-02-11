using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace EasyUI.NET.UI
{
  public class BaseBuilder<TViewComponent, TBuilder> : IBuilder<TViewComponent, TBuilder>
    where TViewComponent : Widget
    where TBuilder : BaseBuilder<TViewComponent, TBuilder>
  {
    #region Builder

    public TViewComponent Component;

    public IDictionary<string, object> DataOptions;

    public BaseBuilder()
    {
      
    }

    public BaseBuilder(TViewComponent component)
    {
      Component = component;

      DataOptions = new Dictionary<string, object>();
    }

    public string DataOptionsToString
    {
      get
      {
        var stringBuilder = new StringBuilder();
        if (DataOptions != null && DataOptions.Any())
        {
          foreach (var attribute in DataOptions)
          {
            if (attribute.Value is bool)
            {
              stringBuilder.AppendFormat("{0}:{1},", attribute.Key, attribute.Value.ToString().ToLower());
            }
            else
            {
              stringBuilder.AppendFormat("{0}:'{1}',", attribute.Key, attribute.Value);
            }
          }
        }
        return stringBuilder.ToString().TrimEnd(',');
      }
    }

    #endregion

    #region IBuilder

    public TBuilder Text(string text)
    {
      Component.Text = text;
      return this as TBuilder;
    }

    public TBuilder Icon(Icons icon)
    {
      Component.HtmlAttributes.Merge("iconCls", icon.GetDescription());
      return this as TBuilder;
    }

    public TBuilder Disabled(bool disabled = true)
    {
      Component.HtmlAttributes.Merge("disabled", disabled.ToLowerString());
      return this as TBuilder;
    }

    public TBuilder Readonly(bool @readonly = true)
    {
      Component.HtmlAttributes.Merge("readonly", @readonly.ToLowerString());
      return this as TBuilder;
    }

    public TBuilder Height(int height)
    {
      if (height > 0)
        DataOptions.Merge("height", height);
      return this as TBuilder;
    }

    public TBuilder Width(int width)
    {
      if (width > 0)
        DataOptions.Merge("width", width);
      return this as TBuilder;
    }

    public TBuilder HtmlAttributes(object htmlAttributes)
    {
      return HtmlAttributes(htmlAttributes.ToDictionary());
    }

    public TBuilder HtmlAttributes(IDictionary<string, object> htmlAttributes)
    {
      Component.HtmlAttributes.Merge(htmlAttributes);
      return this as TBuilder;
    }

    #endregion
  }

  public class Builder<TViewComponent, TBuilder> : BaseBuilder<TViewComponent, TBuilder>, IHtmlString
    where TViewComponent : Widget
    where TBuilder : Builder<TViewComponent, TBuilder>
  {
    #region IBuilder

    public Builder(TViewComponent component) : base(component)
    {
    }

    public virtual string ToHtmlString()
    {
      var dataOptionsString = DataOptionsToString;
      if (!string.IsNullOrEmpty(dataOptionsString))
        Component.HtmlAttributes.Merge("data-options", dataOptionsString);
      var sw = new StringWriter();
      var writer = new HtmlTextWriter(sw);
      foreach (var htmlAttribute in Component.HtmlAttributes)
      {
        writer.AddAttribute(htmlAttribute.Key, htmlAttribute.Value.ToString(), false);
      }
      writer.RenderBeginTag(Component.Tag);
      writer.Write(Component.Text);
      writer.RenderEndTag();
      return sw.ToString();
    }

    #endregion
  }

  public class ContainerBuilder<TViewComponent, TBuilder> : BaseBuilder<TViewComponent, TBuilder>, IDisposable
    where TViewComponent : Widget
    where TBuilder : ContainerBuilder<TViewComponent, TBuilder>
  {
    protected HtmlHelper HtmlHelper;
    private TagBuilder _tagBuilder;
    private bool _disposed;

    public TBuilder Render()
    {
      _tagBuilder = new TagBuilder(Component.Tag);
      var dataOptionsString = DataOptionsToString;
      if (!string.IsNullOrEmpty(dataOptionsString))
        Component.HtmlAttributes.Merge("data-options", dataOptionsString);
      _tagBuilder.MergeAttributes(Component.HtmlAttributes, true);
      var start = HttpUtility.HtmlDecode(_tagBuilder.ToString(TagRenderMode.StartTag));
      HtmlHelper.ViewContext.Writer.WriteLine(start);
      return this as TBuilder;
    }

    public ContainerBuilder(TViewComponent component)
      : base(component)
    {
    }

    public void Dispose()
    {
      Dispose(true /* disposing */);
      GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!_disposed)
      {
        _disposed = true;
        if (_tagBuilder != null)
        {
          HtmlHelper.ViewContext.Writer.WriteLine(_tagBuilder.ToString(TagRenderMode.EndTag));
        }
      }
    }


    #region HtmlAttributes
    public TBuilder Title(string title)
    {
      Component.HtmlAttributes.Merge("title", title);
      return this as TBuilder;
    } 
    #endregion
  }
}