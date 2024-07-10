using SmartHelper.Forms;
using NTDLS.Persistence;
using SmartHelper.Config;
using SmartHelper.Hooks;

namespace SmartHelper
{
    internal static class Program
    {
        public static Settings Settings { get; set; } = new();

        [STAThread]
        static void Main()
        {
            var mutex = new Mutex(true, "SmartHelper", out bool createdNew);

            try
            {
                if (createdNew == false)
                {
                    MessageBox.Show("Another instance of SmartHelper is already running... check the system tray?",
                        "SmartHelper", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                ApplicationConfiguration.Initialize();

                try
                {
                    Settings = LocalUserApplicationData.LoadFromDisk("SmartHelper", new Settings());

                    KeyboardHook.Install();

                    Application.Run(new FormMain());
                }
                finally
                {
                    KeyboardHook.Remove();
                }
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }
    }
}