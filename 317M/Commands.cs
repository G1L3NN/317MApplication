namespace _317M;
using System.Text.Json;
using System.Linq;


using Spectre.Console;

public class Commands
{
    public static readonly ConsoleColor[] Colors = (ConsoleColor[])Enum.GetValues(typeof(ConsoleColor));
    private readonly int _startZeile = 18;
    private int _maxHeight;
    private int _maxGebrauch;
    static readonly int StartLine = 16;
    readonly int _bufferHeight = Console.BufferHeight;
    private static int _width = Console.WindowWidth;

    public void Commandline()
    {
        var commandline = Console.ReadLine();

        switch (commandline.Trim().ToLower())
        {
            case "/utc":
                Console.WriteLine("Gib bitte eine Ganzzahl ein: ");
                string utcinput = Console.ReadLine();
                if (int.TryParse(utcinput, out var utcint) && (utcint >= -12 && utcint <= 14))
                {
                    Program.User.UTC = utcint;
                    SaverUser();
                    UpdateLable();
                    ClearCommandArea();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not a vialid Input");
                    Console.ForegroundColor = Colors[Program.User.PreferdColor];
                    Thread.Sleep(3000);
                    ClearCommandArea();
                }

                break;
            case "/help":
                Console.WriteLine("mit /UTC kannst du die Uhrzeit anpassen und mit /color die Farbe");
                Thread.Sleep(3000);
                ClearCommandArea();
                break;

            case "/color":
                _maxHeight = Console.WindowHeight - 2;
                _maxGebrauch = _maxHeight - _startZeile;
                Console.WriteLine(" Verfügbare Farben: ");


                for (int i = 0; i < Math.Min(Colors.Length, _maxGebrauch); i++)
                {
                    Console.SetCursorPosition(0, _startZeile + i);
                    Console.ForegroundColor = Colors[i];
                    Console.WriteLine($"{i+1}. {Colors[i]}");
                }

                // Hinweis wenn nicht alle angezeigt werden
                if (Colors.Length > _maxGebrauch)
                {
                    Console.SetCursorPosition(0, _maxHeight);
                    Console.WriteLine($"... und {Colors.Length - _maxGebrauch} weitere");
                }

                Console.ForegroundColor = Colors[Program.User.PreferdColor];

                string colorInput = Console.ReadLine();
                if (int.TryParse(colorInput, out int answer) && answer >= 1 && answer <= Colors.Length)
                {
                    Console.ForegroundColor = Colors[answer - 1];
                    Program.User.PreferdColor = answer - 1;
                    SaverUser();
                    Program.Redaw();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not a valid input!");
                    Console.ResetColor();
                    Program.Redaw();
                }

                break;

            default:
                Console.WriteLine("Not a valid input");
                Thread.Sleep(3000);
                ClearCommandArea();
                break;
        }
    }

    public List<int> GetUtc(int UTC)
    {
        List<int> utctodisply = new List<int>();

        string utc = DateTime.UtcNow.AddHours(UTC).ToString("HH:mm:ss");


        foreach (var number in utc)
        {
            if (char.IsDigit(number))
            {
                utctodisply.Add(number - '0');
            }
        }

        return utctodisply;
    }

    private void ClearCommandArea()
    {
        for (int line = StartLine; line < _bufferHeight; line++)
        {
            Console.SetCursorPosition(0, line);
            Console.Write(new string(' ', Math.Max(0, _width - 1))); //Erstellt einen String der so Gross
                                                                            //wie das Fenster ist oder 0.
        }
    }

    private static void SaverUser()
    {
        string json = JsonSerializer.Serialize(Program.User, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText("userData.json", json);
    }
    
    public static void UpdateLable()
    {
        string country = "Country not found";
        string sing = "+";

        if (Program.User.UTC > 0)
        {
            sing = "+";
        }
        else
        {
            sing = "";
        }

        foreach (var c in Program.Usercoutrytimename.countries)
        {
            if (c.timezone_offset == Program.User.UTC)
            {
                country = c.name;
                break;
            }
        }
        
        Console.SetCursorPosition(0,8);
        Console.Write(new string(' ', Math.Max(0, _width - 1)));
        Console.SetCursorPosition(0,8);
        Console.Write($"Your are in: " + country +" UTC: " + sing + Program.User.UTC);
        Console.SetCursorPosition(0, StartLine);

    }
}