namespace _317M;
using Spectre.Console;

public class Commands
{
    private Table table = new Table();
    public void commandline()
    {
        table.Border(TableBorder.Square);
        
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
        for (int i = 0; i < 10; i++)
        {
            Console.SetCursorPosition(0, 16 + i);
            Console.Write(new string(' ', Console.WindowWidth - 1)); // Minus eins, weil sonst eins zu viel Replaced.
        }
    }
}