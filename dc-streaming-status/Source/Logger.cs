
namespace dc_streaming_status.Source
{
    internal class Logger
    {
        public static void Info(string msg) => Console.WriteLine($" [i] {msg}");
        public static void Warn(string msg) => Console.WriteLine($" [-] {msg}");
        public static void Okay(string msg) => Console.WriteLine($" [+] {msg}");
        
        public static string Log(string msg)
        {
            Console.Write($" [?] {msg}");
            return Console.ReadLine();
        }
    }
}
