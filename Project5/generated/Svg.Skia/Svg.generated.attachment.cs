using AC = Avalonia.Controls;
using ASS = Avalonia.Svg.Skia;
using AvaloniaBindableObject = Avalonia.AvaloniaObject;
using Blazonia.Components;
using Blazonia.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;            
using System.Runtime.Versioning;
using Blazonia.Components.Input;

namespace Blazonia.Components
{
    [RequiresPreviewFeatures]
    internal static class SvgInitializer
    {
        [System.Runtime.CompilerServices.ModuleInitializer]
        internal static void RegisterAdditionalHandlers()
        {
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("Svg.Css",
                (element, value) =>
                {
                    if (value?.Equals(Avalonia.AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(ASS.Svg.CssProperty);
                    }
                    else
                    {
                        ASS.Svg.SetCss((Avalonia.AvaloniaObject)element, (string)value);
                    }
                });
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("Svg.CurrentCss",
                (element, value) =>
                {
                    if (value?.Equals(Avalonia.AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(ASS.Svg.CurrentCssProperty);
                    }
                    else
                    {
                        ASS.Svg.SetCurrentCss((Avalonia.AvaloniaObject)element, (string)value);
                    }
                });
        }
    }

    public static class SvgExtensions
    {
        public static AvaloniaObject SvgCss(this AvaloniaObject element, string value)
        {
            element.AttachedProperties["Svg.Css"] = value;
        
            return element;
        }
        public static AvaloniaObject SvgCurrentCss(this AvaloniaObject element, string value)
        {
            element.AttachedProperties["Svg.CurrentCss"] = value;
        
            return element;
        }
    }

    public class Svg_Attachment : NativeControlComponentBase, INonPhysicalChild, IContainerElementHandler
    {
        [Parameter] public string Css { get; set; }

        [Parameter] public string CurrentCss { get; set; }

        private Avalonia.AvaloniaObject _parent;

        public object TargetElement => _parent;

        public override Task SetParametersAsync(ParameterView parameters)
        {
            foreach (var parameterValue in parameters)
            {
                var value = parameterValue.Value;
                switch (parameterValue.Name)
                {
                    case nameof(Css):
                    if (!Equals(Css, value))
                    {
                        Css = (string)value;
                        //NativeControl.CssProperty = Css;
                    }
                    break;

                    case nameof(CurrentCss):
                    if (!Equals(CurrentCss, value))
                    {
                        CurrentCss = (string)value;
                        //NativeControl.CurrentCssProperty = CurrentCss;
                    }
                    break;

                }
            }
        
            TryUpdateParent(_parent);
            return base.SetParametersAsync(ParameterView.Empty);
        }

        private void TryUpdateParent(object parentElement)
        {
            if (parentElement is not null)
            {
                if (Css == global::Avalonia.Svg.Skia.Svg.CssProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.AvaloniaObject)parentElement).ClearValue( global::Avalonia.Svg.Skia.Svg.CssProperty);
                }
                else
                {
                     global::Avalonia.Svg.Skia.Svg.SetCss((Avalonia.AvaloniaObject)parentElement, Css);
                }
                
                if (CurrentCss == global::Avalonia.Svg.Skia.Svg.CurrentCssProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.AvaloniaObject)parentElement).ClearValue( global::Avalonia.Svg.Skia.Svg.CurrentCssProperty);
                }
                else
                {
                     global::Avalonia.Svg.Skia.Svg.SetCurrentCss((Avalonia.AvaloniaObject)parentElement, CurrentCss);
                }
                
            }
        }
    
        void INonPhysicalChild.SetParent(object parentElement)
        {
            var parentType = parentElement?.GetType();
            if (parentType is not null)
            {
                Css = Css != default ? Css : global::Avalonia.Svg.Skia.Svg.CssProperty.GetDefaultValue(parentType);
                CurrentCss = CurrentCss != default ? CurrentCss : global::Avalonia.Svg.Skia.Svg.CurrentCssProperty.GetDefaultValue(parentType);

                TryUpdateParent(parentElement);
            }

            _parent = (Avalonia.AvaloniaObject)parentElement;
        }
        
        
        public void RemoveFromParent(object parentElement)
        {
            var parentType = parentElement?.GetType();
            if (parentType is not null)
            {
                Css = global::Avalonia.Svg.Skia.Svg.CssProperty.GetDefaultValue(parentType);
                CurrentCss = global::Avalonia.Svg.Skia.Svg.CurrentCssProperty.GetDefaultValue(parentType);

                TryUpdateParent(parentElement);
            }

            _parent = null;
        }

        public void AddChild(object child, int physicalSiblingIndex)
        {
        }

        public void RemoveChild(object child, int physicalSiblingIndex)
        {
        }

        protected override void RenderAdditionalElementContent(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder builder, ref int sequence)
        {
            base.RenderAdditionalElementContent(builder, ref sequence);
        }
    }
}
