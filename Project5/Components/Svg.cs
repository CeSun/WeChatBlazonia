using Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSvg = Avalonia.Svg.Skia.Svg;

namespace Project5.Components
{
    public class Svg : Blazonia.Components.Svg.Skia.Svg
    {
        protected override AvaloniaObject CreateNativeElement()
        {
            return new SkiaSvg(new Uri("avares://Project5/Assets/Add.svg"));
        }
    }
}
