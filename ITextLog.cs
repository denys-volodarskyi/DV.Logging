namespace DV.Logging;

public enum Category
{
    Information,
    Warning,
    Error
};

public interface ITextLog
{
    int Indent { get; set; }

    void Write(string text);
    void WriteLine(string text = "");

    void Flush();
}
