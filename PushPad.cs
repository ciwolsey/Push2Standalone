using System;
using Commons.Music.Midi;
using System.Linq;

public class PushPad {
    private PushControl PushControl;
    private IMidiInput PushIn;
    private IMidiOutput PushOut;
    private IMidiOutput VirtualOut;
    public int MappedToCC;
    public Action<byte[]> OnNoteOn;
    public Action<byte[]> OnNoteOff;
    
    public PushPad (IMidiInput pushIn, IMidiOutput pushOut, IMidiOutput virtualOutput, PushControl pushControl)
    {
        PushControl = pushControl;
        PushIn = pushIn;
        PushOut = pushOut;
        VirtualOut = virtualOutput;
        PushIn.MessageReceived += OnMidiData;
    }

    ~PushPad ()
    {
        PushIn.MessageReceived -= OnMidiData;
    }

    // All logic for deciding whether the incoming midi is
    // for this controller
    bool IsForMe(byte[] data)
    {
        return 
            (data[0] == MidiEvent.NoteOn || 
            data[0] == MidiEvent.NoteOff) &&
            PushUtils.IsPushControl(data, PushControl);
    }

    void OnMidiData(object a, MidiReceivedEventArgs midi)
    {
        // If the data is for this control
        if(IsForMe(midi.Data))
        {
            if(midi.Data[0] == MidiEvent.NoteOn) NoteOn(midi.Data);
            if(midi.Data[0] == MidiEvent.NoteOff) NoteOff(midi.Data);
        }
    }

    void NoteOn(byte[] data)
    {
        OnNoteOn?.Invoke(data);
    }

    void NoteOff(byte[] data)
    {
        OnNoteOff?.Invoke(data);
    }

    void DebugLog(){
        Console.WriteLine(PushControl.ToString());
    }

    public void SetColor(int color)
    {
        PushOut.Send(new byte [] {MidiEvent.NoteOn, (byte)PushControl, (byte)color}, 0, 3, 0);
    }
}