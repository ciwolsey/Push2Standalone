using System;
using System.Collections.Generic;
using LanguageExt;

public class EncoderGroup {
    List<PushEncoder> Encoders = new List<PushEncoder>();

    public void Add(PushEncoder encoder)
    {
        Encoders.Add(encoder);
    }

    public void Remove(PushEncoder encoder)
    {
        Encoders.Remove(encoder);
    }

    public void MapTo(int[] CCMapping)
    {
        int i = 0;
        foreach(var encoder in Encoders)
        {
            encoder.MappedToCC = CCMapping[i];
            i++;
        }

    }
}