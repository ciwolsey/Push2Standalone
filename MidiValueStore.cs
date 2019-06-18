using System;
using System.Linq;
using Commons.Music.Midi;

public class MidiValueStore
{
    public int[] Values;

    public MidiValueStore(int size = 128)
    {
        Values = new int[size];
    }

    public int SetValue(int index, int value)
    {
        Values[index] = MIDIEngine.Clamp127(value);
        return Values[index];
    }

    public int GetValue(int index)
    {
        return Math.Clamp(Values[index], 0, 127);
    }

    public int IncrementValue(int index)
    {
        return MIDIEngine.Clamp127((Values[index])++);
    }

    public int DecrementValue(int index)
    {
        Values[index] = MIDIEngine.Clamp127(Values[index] - 1);
        return Values[index];
    }
}