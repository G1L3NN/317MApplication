namespace _317M;
using Spectre.Console;

public class Commands
{
    private ConsoleColor[] colors = (ConsoleColor[])Enum.GetValues(typeof(ConsoleColor));
    private int startZeile = 18;
    private int MaxHeight;
    private int MaxGebrauch;
    public void commandline()
    {
       
        
        var Commandline = Console.ReadLine();
        
        switch (Commandline)
        {
            case "/UTC":
                Console.WriteLine("Gib bitte eine Ganzzahl ein: ");
                string utcinput = Console.ReadLine();
                if (int.TryParse(utcinput, out var utcint) && (utcint >= -12 && utcint <= 14))
                {
                    Program.yourUTC = utcint;
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
                Console.WriteLine("mit /UTC kannst du die Uhrzeit anpassen");
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
                    Console.WriteLine($"{i + 1}. {colors[i]}");
                }

                // Hinweis wenn nicht alle angezeigt werden
                if (colors.Length > MaxGebrauch)
                {
                    Console.SetCursorPosition(0, MaxHeight);
                    Console.WriteLine($"... und {colors.Length - MaxGebrauch} weitere");
                }

                Console.ForegroundColor = ConsoleColor.Blue;

                string colorInput = Console.ReadLine();
                if (int.TryParse(colorInput, out int answer) && answer >= 1 && answer <= colors.Length)
                {
                    Console.ForegroundColor = colors[answer - 1];
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

        string utc = DateTime.UtcNow.AddHours(UTC).ToString("HH:mm");


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
        for (int i = 0; i < 20; i++)
        {
            Console.SetCursorPosition(0, 16 + i);
            Console.Write(new string(' ', Console.WindowWidth - 1)); // Minus eins, weil sonst eins zu viel Replaced.
        }
    }
}