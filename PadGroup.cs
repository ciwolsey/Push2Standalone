using System;
using System.Collections.Generic;

public class PadGroup {
    List<PushPad> pads = new List<PushPad>();
    int DefaultPadColor = 0;

    public PadGroup(int defaultColor)
    {
        DefaultPadColor = defaultColor;
    }

    public void Add(PushPad pad)
    {
        pad.SetColor(DefaultPadColor);
        pads.Add(pad);
    }

    public void Remove(PushPad pad)
    {
        pads.Remove(pad);
    }

    public void SetColor(int color = 0)
    {
        foreach(var pad in pads)
        {
            pad.SetColor(color);
        }
    }
}