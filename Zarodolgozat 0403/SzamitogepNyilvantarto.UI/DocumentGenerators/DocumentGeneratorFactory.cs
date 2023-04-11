namespace SzamitogepNyilvantarto.UI.DocumentGenerators;

public static class DocumentGeneratorFactory
{
    public static IDocumentGenerator GetGeneratorType(DocumentType type)
    {
        IDocumentGenerator generator = type switch
        {
            DocumentType.PDF => new PdfGenerator(),
            DocumentType.DocX => new DocxGenerator(),
            _ => throw new Exception("Not a valid document type is selected")
        };
        return generator;
    }
}
