using System;
using System.Linq;
using Commons.Music.Midi;

public class MIDIEngine
{
    // Find an input device by name
    public static IMidiInput UseInput(string name)
    {
        var access = MidiAccessManager.Default;
        var device = access.Inputs.Where((dev) => dev.Name == name).FirstOrDefault();
       
        return device != null ? access.OpenInputAsync(device.Id).Result : null;
    }

    // Find an output device by name
    public static IMidiOutput UseOutput(string name)
    {
        var access = MidiAccessManager.Default;
        var device = access.Outputs.Where((dev) => dev.Name == name).FirstOrDefault();
        return device != null ? access.OpenOutputAsync(device.Id).Result : null;
    }

    // List inputs
    public static void ListInputs()
    {
        Console.WriteLine("---- MIDI INPUTS");
        var access = MidiAccessManager.Default;

        foreach (var device in access.Inputs)
        {
            Console.WriteLine(device.Name);
        }

        Console.WriteLine();
    }

    // List outputs
    public static void ListOutputs()
    {
        Console.WriteLine("---- MIDI OUTPUTS");
        var access = MidiAccessManager.Default;

        foreach (var device in access.Outputs)
        {
            Console.WriteLine(device.Name);
        }

        Console.WriteLine();
    }

    // Pretty print midi data
    public static void PrintMidiData(byte[] data, string additional = "")
    {
        foreach(byte b in data)
        {
            Console.Write(b + " ");
        }
        Console.Write(" " + additional);
        Console.Write("\n");
    }

    public static int Clamp127(int value)
    {
        return Math.Clamp(value, 0, 127);
    }

}