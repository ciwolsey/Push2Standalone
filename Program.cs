using System;
using System.Linq;
using Commons.Music.Midi;

namespace Push2Standalone 
{
    class Program
    {
        public static float value = 0;

        public static PushEncoder Enc1;
        public static PushEncoder Enc2;
        public static PushEncoder Enc3;
        public static PushEncoder Enc4;
        public static PushEncoder Enc5;
        public static PushEncoder Enc6;
        public static PushEncoder Enc7;
        public static PushEncoder Enc8;

        public static IMidiInput PushIn;
        public static IMidiOutput PushOut;
        public static IMidiOutput VirtualOut;

        public static PushPad Pad11;
        public static PushPad Pad12;
        public static PushPad Pad13;
        public static PushPad Pad14;
        public static PushPad Pad15;
        public static PushPad Pad16;
        public static PushPad Pad17;
        public static PushPad Pad18;
        public static PushPad Pad21;
        public static PushPad Pad22;
        public static PushPad Pad23;
        public static PushPad Pad24;
        public static PushPad Pad25;
        public static PushPad Pad26;
        public static PushPad Pad27;
        public static PushPad Pad28;

        static void Main(string[] args)
        {
            //MIDIEngine.ListInputs();
            //MIDIEngine.ListOutputs();

            PushIn = MIDIEngine.UseInput("Ableton Push 2");
            if(PushIn == null)
            {
                Console.WriteLine("\nCouldn't find an ableton Push 2 midi input, make sure it's plugged in and switched on");
                return;
            }

            PushOut = MIDIEngine.UseOutput("Ableton Push 2");
            if(PushOut == null)
            {
                Console.WriteLine("\nCouldn't find an Ableton Push 2 midi output make sure it's plugged in and switched on");
                return;
            }

            VirtualOut = MIDIEngine.UseOutput("Push2Standalone");
            if(VirtualOut == null)
            {
                Console.WriteLine(
                    "Couldn't find a Virtual midi device.\n" +
                    "Install a virtual midi device (https://www.tobias-erichsen.de/software/loopmidi.html)\n" +
                    "and then create a virtual device named \"Push2Standalone\""
                );
                return;
            }

            Console.WriteLine("USING INPUT: " + PushIn.Details.Name);
            Console.WriteLine("USING OUTPUT: " + VirtualOut.Details.Name);

            var store = new MidiValueStore();

            Enc1 = new PushEncoder(PushIn, PushOut, VirtualOut, PushControl.Encoder1, 1, store);
            Enc2 = new PushEncoder(PushIn, PushOut, VirtualOut, PushControl.Encoder2, 2, store);
            Enc3 = new PushEncoder(PushIn, PushOut, VirtualOut, PushControl.Encoder3, 3, store);
            Enc4 = new PushEncoder(PushIn, PushOut, VirtualOut, PushControl.Encoder4, 4, store);
            Enc5 = new PushEncoder(PushIn, PushOut, VirtualOut, PushControl.Encoder5, 5, store);
            Enc6 = new PushEncoder(PushIn, PushOut, VirtualOut, PushControl.Encoder6, 6, store);
            Enc7 = new PushEncoder(PushIn, PushOut, VirtualOut, PushControl.Encoder7, 7, store);
            Enc8 = new PushEncoder(PushIn, PushOut, VirtualOut, PushControl.Encoder8, 8, store);

            Pad11 = new PushPad(PushIn, PushOut, VirtualOut, PushControl.Pad11);
            Pad12 = new PushPad(PushIn, PushOut, VirtualOut, PushControl.Pad12);
            Pad13 = new PushPad(PushIn, PushOut, VirtualOut, PushControl.Pad13);
            Pad14 = new PushPad(PushIn, PushOut, VirtualOut, PushControl.Pad14);
            Pad15 = new PushPad(PushIn, PushOut, VirtualOut, PushControl.Pad15);
            Pad16 = new PushPad(PushIn, PushOut, VirtualOut, PushControl.Pad16);
            Pad17 = new PushPad(PushIn, PushOut, VirtualOut, PushControl.Pad17);
            Pad18 = new PushPad(PushIn, PushOut, VirtualOut, PushControl.Pad18);
            
            Pad21 = new PushPad(PushIn, PushOut, VirtualOut, PushControl.Pad21);
            Pad22 = new PushPad(PushIn, PushOut, VirtualOut, PushControl.Pad22);
            Pad23 = new PushPad(PushIn, PushOut, VirtualOut, PushControl.Pad23);
            Pad24 = new PushPad(PushIn, PushOut, VirtualOut, PushControl.Pad24);
            Pad25 = new PushPad(PushIn, PushOut, VirtualOut, PushControl.Pad25);
            Pad26 = new PushPad(PushIn, PushOut, VirtualOut, PushControl.Pad26);
            Pad27 = new PushPad(PushIn, PushOut, VirtualOut, PushControl.Pad27);
            Pad28 = new PushPad(PushIn, PushOut, VirtualOut, PushControl.Pad28);

            PadGroup CCSelectGroup = new PadGroup(122);
            CCSelectGroup.Add(Pad11);
            CCSelectGroup.Add(Pad12);
            CCSelectGroup.Add(Pad13);
            CCSelectGroup.Add(Pad14);
            CCSelectGroup.Add(Pad15);
            CCSelectGroup.Add(Pad16);
            CCSelectGroup.Add(Pad17);
            CCSelectGroup.Add(Pad18);
            CCSelectGroup.Add(Pad21);
            CCSelectGroup.Add(Pad22);
            CCSelectGroup.Add(Pad23);
            CCSelectGroup.Add(Pad24);
            CCSelectGroup.Add(Pad25);
            CCSelectGroup.Add(Pad26);
            CCSelectGroup.Add(Pad27);
            CCSelectGroup.Add(Pad28);


            var CCBank1 = Enumerable.Range(0, 8).ToArray();
            var CCBank2 = Enumerable.Range(8, 16).ToArray();
            var CCBank3 = Enumerable.Range(16, 24).ToArray();
            var CCBank4 = Enumerable.Range(24, 32).ToArray();
            var CCBank5 = Enumerable.Range(32, 40).ToArray();
            var CCBank6 = Enumerable.Range(40, 48).ToArray(); 
            var CCBank7 = Enumerable.Range(48, 56).ToArray();
            var CCBank8 = Enumerable.Range(56, 64).ToArray();
            var CCBank9 = Enumerable.Range(64, 72).ToArray();
            var CCBank10 = Enumerable.Range(72, 80).ToArray();
            var CCBank11 = Enumerable.Range(80, 88).ToArray();
            var CCBank12 = Enumerable.Range(88, 96).ToArray();
            var CCBank13 = Enumerable.Range(96, 104).ToArray();
            var CCBank14 = Enumerable.Range(104, 112).ToArray();
            var CCBank15 = Enumerable.Range(112, 120).ToArray();
            var CCBank16 = Enumerable.Range(120, 127).ToArray();

            EncoderGroup Encoders = new EncoderGroup();
            Encoders.Add(Enc1);
            Encoders.Add(Enc2);
            Encoders.Add(Enc3);
            Encoders.Add(Enc4);
            Encoders.Add(Enc5);
            Encoders.Add(Enc6);
            Encoders.Add(Enc7);
            Encoders.Add(Enc8);


            Pad11.OnNoteOn += (data) => {
                CCSelectGroup.SetColor(122);
                Pad11.SetColor(4);
                Encoders.MapTo(CCBank1);
            };

            Pad12.OnNoteOn += (data) => {
                CCSelectGroup.SetColor(122);
                Pad12.SetColor(4);
                Encoders.MapTo(CCBank2);
            };

            Pad13.OnNoteOn += (data) => {
                CCSelectGroup.SetColor(122);
                Pad13.SetColor(4);
                Encoders.MapTo(CCBank3);
            };

            Pad14.OnNoteOn += (data) => {
                CCSelectGroup.SetColor(122);
                Pad14.SetColor(4);
                Encoders.MapTo(CCBank4);
            };

            Pad15.OnNoteOn += (data) => {
                CCSelectGroup.SetColor(122);
                Pad15.SetColor(4);
                Encoders.MapTo(CCBank5);
            };

            Pad16.OnNoteOn += (data) => {
                CCSelectGroup.SetColor(122);
                Pad16.SetColor(4);
                Encoders.MapTo(CCBank6);
            };

            Pad17.OnNoteOn += (data) => {
                CCSelectGroup.SetColor(122);
                Pad17.SetColor(4);
                Encoders.MapTo(CCBank7);
            };

            Pad18.OnNoteOn += (data) => {
                CCSelectGroup.SetColor(122);
                Pad18.SetColor(4);
                Encoders.MapTo(CCBank8);
            };

            Pad21.OnNoteOn += (data) => {
                CCSelectGroup.SetColor(122);
                Pad21.SetColor(4);
                Encoders.MapTo(CCBank9);
            };
            
            Pad22.OnNoteOn += (data) => {
                CCSelectGroup.SetColor(122);
                Pad22.SetColor(4);
                Encoders.MapTo(CCBank10);
            };

            Pad23.OnNoteOn += (data) => {
                CCSelectGroup.SetColor(122);
                Pad23.SetColor(4);
                Encoders.MapTo(CCBank11);
            };

            Pad24.OnNoteOn += (data) => {
                CCSelectGroup.SetColor(122);
                Pad24.SetColor(4);
                Encoders.MapTo(CCBank12);
            };
            
            Pad25.OnNoteOn += (data) => {
                CCSelectGroup.SetColor(122);
                Pad25.SetColor(4);
                Encoders.MapTo(CCBank13);
            };

            Pad26.OnNoteOn += (data) => {
                CCSelectGroup.SetColor(122);
                Pad26.SetColor(4);
                Encoders.MapTo(CCBank14);
            };

            Pad27.OnNoteOn += (data) => {
                CCSelectGroup.SetColor(122);
                Pad27.SetColor(4);
                Encoders.MapTo(CCBank15);
            };

            Pad28.OnNoteOn += (data) => {
                CCSelectGroup.SetColor(122);
                Pad28.SetColor(4);
                Encoders.MapTo(CCBank16);
            };

            Console.WriteLine("\nActive. Press escape to leave...");

            while (true)
            { 
                var key = Console.ReadKey().Key;
                if(key == ConsoleKey.Escape) {
                    break;
                };
            }

            // Turn off lights
            CCSelectGroup.SetColor(0);

            // Clean up
            PushIn.Dispose();
            PushOut.Dispose();
            VirtualOut.Dispose();
        }
    }
}
