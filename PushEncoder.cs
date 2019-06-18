using System;
using Commons.Music.Midi;
using System.Linq;

public class PushEncoder {
    private PushControl PushControl;
    private IMidiInput PushIn;
    private IMidiOutput PushOut;
    private IMidiOutput VirtualOut;
    private MidiValueStore Store;
    public int MappedToCC;
    
    public PushEncoder (IMidiInput pushIn, IMidiOutput pushOut, IMidiOutput virtualOut, PushControl pushControl, int mapToCC, MidiValueStore store)
    {
        PushControl = pushControl;
        PushIn = pushIn;
        PushOut = pushOut;
        VirtualOut = virtualOut;
        PushIn.MessageReceived += OnMidiData;
        MappedToCC = mapToCC;
        Store = store;
    }

    ~PushEncoder ()
    {
        PushIn.MessageReceived -= OnMidiData;
    }

    // All logic for deciding whether the incoming midi is
    // for this controller
    bool IsForMe(byte[] data)
    {
        return 
            data[0] == MidiEvent.CC &&
            PushUtils.IsPushControl(data, PushControl);
    }

    void OnMidiData(object a, MidiReceivedEventArgs midi)
    {
        // If the data is for this control
        if(IsForMe(midi.Data))
        {
            // IEncoder is being rotated upwards
            if(IsEncoderUp(midi.Data))
                OnEncoderUp(midi.Data);

            // Encoder is being rotated downwards
            if(IsEncoderDown(midi.Data))
                OnEncoderDown(midi.Data);
        }
    }

    void OnEncoderUp(byte[] data)
    {
        Store.IncrementValue(MappedToCC);

        byte[] MutableData = data.ToArray();
        
        MutableData[1] = (byte)MappedToCC;
        MutableData[2] = (byte)Store.GetValue(MappedToCC);

        VirtualOut.Send(MutableData, 0, data.Length, 1);

        DebugLog();
    }

    void OnEncoderDown(byte[] data)
    {
        Store.DecrementValue(MappedToCC);

        byte[] MutableData = data.ToArray();
        
        MutableData[1] = (byte)MappedToCC;
        MutableData[2] = (byte)Store.GetValue(MappedToCC);

        VirtualOut.Send(MutableData, 0, data.Length, 1);

        DebugLog();
    }

    void DebugLog(){
        Console.WriteLine(PushControl.ToString() + " -> " + MappedToCC + ": " + Store.GetValue(MappedToCC));
    }

    public static bool IsEncoderUp(byte [] data)
    {
        if(data.Length < 3) return false;

        return data[2] == 1;
    }

    public static bool IsEncoderDown(byte [] data)
    {
        if(data.Length < 3) return false;

        return data[2] == 127;
    }
}