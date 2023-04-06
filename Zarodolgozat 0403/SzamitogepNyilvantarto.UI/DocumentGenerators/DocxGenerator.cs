using RazorLight;
using Spire.Doc;
using System.Reflection;
using XAct.Library.Settings;

namespace SzamitogepNyilvantarto.UI.DocumentGenerators;

public class DocxGenerator: IDocumentGenerator
{
    public async Task GenerateDocumentAsync(string templateName, object model, string fileName)
    {
        var rootDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var templateFullPath=Path.Combine(rootDir, "Templates");

        var engine = new RazorLightEngineBuilder().UseFileSystemProject(templateFullPath)
                                                                                      .UseMemoryCachingProvider()
                                                                                      .Build();

        var htmlContent = await engine.CompileRenderAsync(templateName, model);
        var htmlData = Encoding.UTF8.GetBytes(htmlContent);
        
		Document document = new Document(new MemoryStream(htmlData));
		document.SaveToFile(fileName, FileFormat.Docx2013);
    }
}
