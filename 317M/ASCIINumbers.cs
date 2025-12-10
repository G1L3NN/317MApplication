namespace _317M;

public class ASCIINumbers
{
    private static string[] zero =
    {
        " ### ",
        "#   #",
        "#   #",
        "#   #",
        " ### "
    };

    private static string[] one =
    {
        "  #  ",
        "# #  ",
        "  #  ",
        "  #  ",
        " ### "
    };

    private static string[] two =
    {
        " ### ",
        "#   #",
        "   # ",
        "  #  ",
        "#####"
    };

    private static string[] three =
    {
        " ### ",
        "    #",
        "  ## ",
        "    #",
        " ### "
    };

    private static string[] four =
    {
        "#   #",
        "#   #",
        "#####",
        "    #",
        "    #"
    };

    private static string[] five =
    {
        "#####",
        "#    ",
        "#### ",
        "    #",
        "#### "
    };

    private static string[] six =
    {
        " ### ",
        "#    ",
        "#### ",
        "#   #",
        " ### "
    };

    private static string[] seven =
    {
        "#####",
        "    #",
        "  #  ",
        " #   ",
        "#    "
    };

    private static string[] eight =
    {
        " ### ",
        "#   #",
        " ### ",
        "#   #",
        " ### "
    };

    private static string[] nine =
    {
        " ### ",
        "#   #",
        " ####",
        "    #",
        " ### "
    };

    private static string[] semicolon =
    {
        " ### ",
        " ### ",
        "     ",
        " ### ",
        " ### "
    };


    private static string[][] Number = { zero, one, two, three, four, five, six, seven, eight, nine, semicolon };


    public string[][] GetNumbers()
    {
        return Number;
    }
}