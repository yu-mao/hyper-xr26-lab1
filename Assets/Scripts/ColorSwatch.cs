using System.Collections.Generic;
using UnityEngine;

public class ColorSwatch
{
    public List<string> colors = new List<string>
    {
        "#99e6ff",
        "#ffffff",
        "#ff5bc6",
        "#dbb480",
        "#95c409", 
        "#9791f4",
        "#fc982a",
        "#473134",
        "#ff5bd2",
    };

    public Color HexToColor(string hex)
    {
        if (ColorUtility.TryParseHtmlString(hex, out Color color))
        {
            return color;
        }
        else
        {
            return Color.black;
        }
    }
}