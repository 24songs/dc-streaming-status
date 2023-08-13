using Discord;
using Discord.Gateway;

using static System.Reflection.Assembly;
using dc_streaming_status.Source;

namespace dc_streaming_status
{
    class Program
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        /* If you prefer not to input the token every time the program runs, you can  set it directly here as a string. */
        private static string _token = "YOUR_TOKEN_HERE";

        static void Main()
        {
            Console.WriteLine("");

            Logger.Info( $"streaming status v{ GetExecutingAssembly().GetName().Version }\n" );

            if ( _token == "YOUR_TOKEN_HERE" ) {
                _token = Logger.Log( "enter your token: " );

                Console.Clear();

                Console.WriteLine("");
                Logger.Info($"streaming status v{GetExecutingAssembly().GetName().Version}\n");
            }

            // messy code ik lol 

            Logger.Info($"trying to log in.\n");

            DiscordSocketClient client = new DiscordSocketClient();

            try
            {
                client.Login(_token);
            }
            catch (Exception ex)
            {
                Logger.Warn($"an error occured: {ex.Message}");
            }

            Logger.Okay($"logged in as {client.User.Username}.\n");

            string streamText = Logger.Log("enter the stream name: ");
            string streamUrl = Logger.Log("enter the stream url: ");

            client.UpdatePresence(new PresenceProperties()
            {
                Status = UserStatus.DoNotDisturb,
                Activity = new StreamActivityProperties() { Name = streamText, Url = streamUrl }
            });

            if (Logger.Log("do you want to hide the console window and run in the background? (y/n): ").ToLower() == "y") ShowWindow(GetConsoleWindow(), 0);

            Thread.Sleep(-1);
        }

    }
}