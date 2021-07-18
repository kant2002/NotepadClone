using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MyNotepad {
    static class Program {
        [STAThread]
        static void Main() {
            ComWrappers.RegisterForMarshalling(WinFormsComInterop.WinFormsComWrappers.Instance);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var Main = new Main();

            var CommandLine = Environment.CommandLine.Trim();

            var Filename = (string)null;

            if (CommandLine.StartsWith("\"")) {
                var ClosingQuoteIndex = CommandLine.IndexOf('\"', 1);

                if (ClosingQuoteIndex < (CommandLine.Length - 1)) {
                    Filename = CommandLine.Substring(ClosingQuoteIndex + 1).Trim();
                }
            } else {
                var FirstSpaceIndex = CommandLine.IndexOf(' ', 1);

                if (FirstSpaceIndex != -1) {
                    Filename = CommandLine.Substring(FirstSpaceIndex + 1).Trim();
                }
            }

            if (Filename != null) {
                Main.Open(Filename);
            }

            Application.Run(Main);
        }
    }
}
