using System.Text;

namespace DV.Logging;

public class InMemoryLog : ITextLog
{
    private readonly StringBuilder Builder = new();

    public string GetText() => Builder.ToString();

    public int Indent
    {
        get => 0;
        set => _ = 0;
    }

    public void Flush() { }

    public void Write(string text) => Builder.Append(text);

    public void WriteLine(string text = "") => Builder.AppendLine(text);
}
