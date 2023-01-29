namespace DV.Logging;

public class TextLog : ITextLog, IDisposable
{
    /// <summary>
    /// Create log to text file.
    /// </summary>
    public static TextLog CreateTextFileLogger(string path) => new(File.CreateText(path), owns: true);

    /// <summary>
    /// Create log to console.
    /// </summary>
    public static ITextLog CreateConsoleLogger() => new TextLog(Console.Out, owns: false);

    private readonly bool OwnsInnerWriter;
    private readonly TextWriter InnerWriter;
    private readonly System.CodeDom.Compiler.IndentedTextWriter Writer;

    public TextLog(TextWriter inner_writer, bool owns)
    {
        InnerWriter = inner_writer;
        OwnsInnerWriter = owns;
        Writer = new(InnerWriter);
    }

    public void Dispose()
    {
        Writer.Dispose();

        if (OwnsInnerWriter)
            InnerWriter.Dispose();

        GC.SuppressFinalize(this);
    }

    public int Indent
    {
        get => Writer.Indent;
        set => Writer.Indent = value;
    }

    public void Flush() => Writer.Flush();

    public void Write(string text) => Writer.Write(text);

    public void WriteLine(string text = "") => Writer.WriteLine(text);
}
