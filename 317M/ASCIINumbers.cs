namespace _317M;

public class AsciiNumbers
{
    private static readonly string[] Zero =
    {
        " ### ",
        "#   #",
        "#   #",
        "#   #",
        " ### "
    };

    private static readonly string[] One =
    {
        "  #  ",
        "# #  ",
        "  #  ",
        "  #  ",
        " ### "
    };

    private static readonly string[] Two =
    {
        " ### ",
        "#   #",
        "   # ",
        "  #  ",
        "#####"
    };

    private static readonly string[] Three =
    {
        " ### ",
        "    #",
        "  ## ",
        "    #",
        " ### "
    };

    private static readonly string[] Four =
    {
        "#   #",
        "#   #",
        "#####",
        "    #",
        "    #"
    };

    private static readonly string[] Five =
    {
        "#####",
        "#    ",
        "#### ",
        "    #",
        "#### "
    };

    private static readonly string[] Six =
    {
        " ### ",
        "#    ",
        "#### ",
        "#   #",
        " ### "
    };

    private static readonly string[] Seven =
    {
        "#####",
        "    #",
        "  #  ",
        " #   ",
        "#    "
    };

    private static readonly string[] Eight =
    {
        " ### ",
        "#   #",
        " ### ",
        "#   #",
        " ### "
    };

    private static readonly string[] Nine =
    {
        " ### ",
        "#   #",
        " ####",
        "    #",
        " ### "
    };

    private static readonly string[] Semicolon =
    {
        " ### ",
        " ### ",
        "     ",
        " ### ",
        " ### "
    };


    private static readonly string[][] Number = { Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Semicolon };


    public string[][] GetNumbers()
    {
        return Number;
    }
}