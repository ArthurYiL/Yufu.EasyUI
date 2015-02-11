using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace EasyUI.NET.UI
{
  public class TextBoxBuilder : Builder<TextBox, TextBoxBuilder>
  {
    #region HtmlAttributes
    public TextBoxBuilder Prompt(string prompt)
    {
      Component.HtmlAttributes.Merge("prompt", prompt);
      return this;
    }

    public TextBoxBuilder Icon(Icons icon, IconAlign align = IconAlign.left)
    {
      base.Icon(icon);
      Component.HtmlAttributes.Merge("iconAlign", align.ToString());
      return this;
    }

    public TextBoxBuilder Multiline(bool multiline = true)
    {
      Component.HtmlAttributes.Merge("multiline", multiline.ToLowerString());
      return this;
    }

    public TextBoxBuilder IconWidth(int width=0)
    {
      Component.HtmlAttributes.Merge("iconWidth", width);
      return this;
    }

    public TextBoxBuilder ButtonText(string buttonText)
    {
      Component.HtmlAttributes.Merge("buttonText", buttonText);
      return this;
    }

    public TextBoxBuilder ButtonIcon(Icons icon)
    {
      Component.HtmlAttributes.Merge("buttonIcon", icon.GetDescription());
      return this;
    }

    public TextBoxBuilder ButtonAlign(IconAlign align = IconAlign.left)
    {
      Component.HtmlAttributes.Merge("buttonAlign", align.ToString());
      return this;
    }

    #endregion

    public TextBoxBuilder(TextBox component)
      : base(component)
    {

    }

    public TextBoxBuilder(TextBox component, ModelMetadata metadata)
      : base(component)
    {
      Component.ModelMetadata = metadata;
    }
  }

  public partial class WidgetFactory
  {
    public TextBoxBuilder TextBox()
    {
      return new TextBoxBuilder(new TextBox());
    }

    //public TextBoxBuilder TextBoxFor<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression)
    //{
    //  var metadata = ModelMetadata.FromLambdaExpression(expression, (ViewDataDictionary<TModel>) Html.ViewData);
    //  return new TextBoxBuilder(new TextBox(), metadata);
    //}
  }
}