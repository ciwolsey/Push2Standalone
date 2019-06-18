public enum PushControl
{
    Encoder1 = 71,
    Encoder2 = 72,
    Encoder3 = 73,
    Encoder4 = 74,
    Encoder5 = 75,
    Encoder6 = 76,
    Encoder7 = 77,
    Encoder8 = 78,
    Pad11 = 36,
    Pad12 = 37,
    Pad13 = 38,
    Pad14 = 39,
    Pad15 = 40,
    Pad16 = 41,
    Pad17 = 42,
    Pad18 = 43,
    
    Pad21 = 44,
    Pad22 = 45,
    Pad23 = 46,
    Pad24 = 47,
    Pad25 = 48,
    Pad26 = 49,
    Pad27 = 50,
    Pad28 = 51,
}

public class PushUtils
{
    public static PushControl GetControl(byte[] data)
    {
        return (PushControl)data[1];
    }

    public static bool IsPushControl(byte[] data, PushControl pushControl)
    {
        return PushUtils.GetControl(data) == pushControl;
    }
}