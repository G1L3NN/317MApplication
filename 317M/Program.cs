namespace _317M;

using System.Text.Json;

class Program
{
    public static readonly User User = JsonSerializer.Deserialize<User>(File.ReadAllText("userData.json"));

    public static readonly Root Usercoutrytimename = JsonSerializer.Deserialize<Root>(File.ReadAllText("utcZones.json"));

    private static List<int> _numstodisplay = new List<int>();
    private static AsciiNumbers _numbers = new AsciiNumbers();
    private static ArtWork _artWork = new ArtWork();
    private static Commands _commandline = new Commands();
    private static string _time;
    private static readonly object _lockObject = new object();

    static void Main(string[] args)
    {
        Console.ForegroundColor = Commands.Colors[User.PreferdColor];
        Commands.UpdateLable();

        Console.SetCursorPosition(0, 0);
        Console.WriteLine(_artWork.Art);

        Thread clockThread = new Thread(Clock);
        clockThread.IsBackground = true;
        clockThread.Start();

        while (true)
        {
            Console.SetCursorPosition(0, 16);
            Console.Write(">");
            _commandline.Commandline();
        }
    }

    private static void Clock()
    {
        while (true)
        {
            int saveLeft = Console.CursorLeft;
            int saveTop = Console.CursorTop;

            lock (_lockObject)
            {
                _numstodisplay = _commandline.GetUtc(User.Utc);
            }

            Console.SetCursorPosition(0, 10);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(
                    $"{_numbers.GetNumbers()[_numstodisplay[0]][i]} " +// Stunde
                    $"{_numbers.GetNumbers()[_numstodisplay[1]][i]} " +
                    $"{_numbers.GetNumbers()[10][i]} " +
                    $"{_numbers.GetNumbers()[_numstodisplay[2]][i]} " + // Minute
                    $"{_numbers.GetNumbers()[_numstodisplay[3]][i]} " +
                    $"{_numbers.GetNumbers()[10][i]} " +
                    $"{_numbers.GetNumbers()[_numstodisplay[4]][i]} " + // Sekunde
                    $"{_numbers.GetNumbers()[_numstodisplay[5]][i]} ");
            }

            _numstodisplay.Clear();

            try
            {
                Console.SetCursorPosition(saveLeft, saveTop);
            }
            catch
            {
                // Ignore 
            }

            Thread.Sleep(1000);
        }
    }

    public static void Redraw()
    {
        Console.Clear();
        Console.WriteLine(_artWork.Art);
        Commands.UpdateLable();
    }
}