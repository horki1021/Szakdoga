using RazorLight;
using Spire.Doc;
using System.Reflection;

namespace SzamitogepNyilvantarto.UI.DocumentGenerators;

public class DocxGenerator: IDocumentGenerator
{
    public async Task GenerateDocumentAsync(string templateName, object model, string fileName, WkHtmlToPdfDotNet.Orientation orientation = WkHtmlToPdfDotNet.Orientation.Portrait)
    {
        var rootDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var templateFullPath=Path.Combine(rootDir, "Templates");

        var engine = new RazorLightEngineBuilder().UseFileSystemProject(templateFullPath)
                                                                                      .UseMemoryCachingProvider()
                                                                                      .Build();

        var htmlContent = await engine.CompileRenderAsync(templateName, model);
        var htmlData = Encoding.UTF8.GetBytes(htmlContent);
        
		Document document = new Document(new MemoryStream(htmlData));

        Section section = document.AddSection();
        section.PageSetup.Orientation = Spire.Doc.Documents.PageOrientation.Landscape;
		//új oldal az fektetve

        /*Section section = document.getSections().get[0];
        section.getPageSetup().setOrientation(PageOrientation.Landscape);*/
        document.SaveToFile(fileName, FileFormat.Docx2013);
    }
}
