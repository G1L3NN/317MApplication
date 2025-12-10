using System.Runtime.InteropServices.JavaScript;
using Spectre.Console;

namespace _317M;

class Program
{
    private static List<int> numstodisplay = new List<int>();
    private static ASCIINumbers numbers = new ASCIINumbers();
    private static ArtWork _artWork = new ArtWork();
    private static Commands commandline = new Commands();
    private static bool isUsed = false;
    private static string time;
    public static int yourUTC = 1;
    private static Table uhrtabel = new Table();
    private static readonly object lockObject = new object();

    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Blue;

        Console.SetCursorPosition(0, 0);
        Console.WriteLine(_artWork.Art);

        Thread clockThread = new Thread(Clock);
        clockThread.IsBackground = true;
        clockThread.Start();

        while (true)
        {
            Console.SetCursorPosition(0, 16);
            Console.Write(">");
            commandline.commandline();
        }
    }

    private static void Clock()
    {
        while (true)
        {
            int saveLeft = Console.CursorLeft;
            int saveTop = Console.CursorTop;

            lock (lockObject)
            {
                numstodisplay = commandline.getUTC(yourUTC);
            }
            
            Console.SetCursorPosition(0, 10);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(
                    $"{numbers.GetNumbers()[numstodisplay[0]][i]} {numbers.GetNumbers()[numstodisplay[1]][i]} {numbers.GetNumbers()[10][i]} {numbers.GetNumbers()[numstodisplay[2]][i]} {numbers.GetNumbers()[numstodisplay[3]][i]}");
            }

            numstodisplay.Clear();

            try
            {
                Console.SetCursorPosition(saveLeft,saveTop);

            }
            catch
            {
               // Ignore 
            }
            Thread.Sleep(1000);
        }
    }
}