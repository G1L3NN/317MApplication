namespace _317M;
using System.Text.Json;


using Spectre.Console;

public class Commands
{
    public static readonly ConsoleColor[] colors = (ConsoleColor[])Enum.GetValues(typeof(ConsoleColor));
    private int startZeile = 18;
    private int MaxHeight;
    private int MaxGebrauch;
    static int startLine = 16;
    int bufferHeight = Console.BufferHeight;
    int width = Console.WindowWidth;

    public void commandline()
    {
        var Commandline = Console.ReadLine();

        switch (Commandline.Trim().ToLower())
        {
            case "/utc":
                Console.WriteLine("Gib bitte eine Ganzzahl ein: ");
                string utcinput = Console.ReadLine();
                if (int.TryParse(utcinput, out var utcint) && (utcint >= -12 && utcint <= 14))
                {
                    Program.user.UTC = utcint;
                    SaverUser();
                    updateLable();
                    ClearCommandArea();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not a vialid Input");
                    Console.ForegroundColor = ConsoleColor.Blue;
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
                MaxHeight = Console.WindowHeight - 2;
                MaxGebrauch = MaxHeight - startZeile;
                Console.WriteLine(" Verfügbare Farben: ");


                for (int i = 0; i < Math.Min(colors.Length, MaxGebrauch); i++)
                {
                    Console.SetCursorPosition(0, startZeile + i);
                    Console.ForegroundColor = colors[i];
                    Console.WriteLine($"{i+1}. {colors[i]}");
                }

                // Hinweis wenn nicht alle angezeigt werden
                if (colors.Length > MaxGebrauch)
                {
                    Console.SetCursorPosition(0, MaxHeight);
                    Console.WriteLine($"... und {colors.Length - MaxGebrauch} weitere");
                }

                Console.ForegroundColor = colors[Program.user.PreferdColor];

                string colorInput = Console.ReadLine();
                if (int.TryParse(colorInput, out int answer) && answer >= 1 && answer <= colors.Length)
                {
                    Console.ForegroundColor = colors[answer - 1];
                    Program.user.PreferdColor = answer - 1;
                    SaverUser();
                    Program.redaw();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not a valid input!");
                    Console.ResetColor();
                    Program.redaw();
                }

                break;

            default:
                Console.WriteLine("Not a valid input");
                Thread.Sleep(3000);
                ClearCommandArea();
                break;
        }
    }

    public List<int> getUTC(int UTC)
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
        for (int line = startLine; line < bufferHeight; line++)
        {
            Console.SetCursorPosition(0, line);
            Console.Write(new string(' ', Math.Max(0, width - 1))); //Erstellt einen String der so Gross
            //wie das Fenster ist oder 0.
        }
    }

    private static void SaverUser()
    {
        string json = JsonSerializer.Serialize(Program.user, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText("userData.json", json);
    }
    
    public static void updateLable()
    {
        Console.SetCursorPosition(0,8);
        Console.Write($"Your UTC currently: " + Program.user.UTC);
        Console.SetCursorPosition(0, startLine);

    }
}