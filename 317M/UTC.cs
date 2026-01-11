namespace _317M;

public class UTC
{
    public string name { get; set; }
    public double timezone_offset { get; set; }
    public string latlong { get; set; }
}

public class Root
{
    public List<UTC> countries { get; set; }
}