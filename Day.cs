namespace AoC_2024;

public abstract class Day
{
    protected Day() { }

    protected string[] Input { get; set; } = [];

    public void Init(string folder, string file)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), folder, file);
        Input = File.ReadAllLines(path);
    }

    public abstract void Run();
}
