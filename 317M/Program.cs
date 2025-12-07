using System.Runtime.InteropServices.JavaScript;

namespace _317M;

class Program
{
    private static List<int> numstodisplay = new List<int>();
    private static ASCIINumbers numbers = new ASCIINumbers();
    private static ArtWork _artWork = new ArtWork();
    
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(_artWork.Art);
        while (true)
        {
            
            Console.SetCursorPosition(0, 10);
            string time = DateTime.Now.ToString("HH:mm"); 
            int count = 0;
            
           
            foreach (var number in time)
            {
                if (char.IsDigit(number))
                {
                    numstodisplay.Add(number - '0');
                }
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(
                    $"{numbers.GetNumbers()[numstodisplay[0]][i]} {numbers.GetNumbers()[numstodisplay[1]][i]} {numbers.GetNumbers()[10][i]} {numbers.GetNumbers()[numstodisplay[2]][i]} {numbers.GetNumbers()[numstodisplay[3]][i]}");
            }
            numstodisplay.Clear();
            Thread.Sleep(1000);
        }
    }
}