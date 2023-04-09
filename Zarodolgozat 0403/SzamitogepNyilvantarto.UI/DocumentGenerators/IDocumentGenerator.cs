namespace SzamitogepNyilvantarto.UI.DocumentGenerators;

public interface IDocumentGenerator
{
    Task GenerateDocumentAsync(string templateName, object model, string fileName, WkHtmlToPdfDotNet.Orientation orientation= WkHtmlToPdfDotNet.Orientation.Portrait);
}
