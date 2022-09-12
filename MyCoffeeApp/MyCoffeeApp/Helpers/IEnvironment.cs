using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Color = Microsoft.Maui.Graphics.Color;

namespace MyCoffeeApp.Helpers
{
    public interface IEnvironment
    {
        void SetStatusBarColor(Color color, bool darkStatusBarTint);
    }
}
