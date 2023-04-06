using RazorLight;
using System.Reflection;
using WkHtmlToPdfDotNet;

namespace SzamitogepNyilvantarto.UI.DocumentGenerators
{
    public class PdfGenerator:IDocumentGenerator
    {
        public async Task GenerateDocumentAsync(string templateName, object model, string fileName)
        {
                var rootDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var templateFullPath = Path.Combine(rootDir, "Templates");

                var engine = new RazorLightEngineBuilder().UseFileSystemProject(templateFullPath)
                                                                                              .UseMemoryCachingProvider()
                                                                                              .Build();

                var htmlContent = await engine.CompileRenderAsync(templateName, model);
                var doc = new HtmlToPdfDocument()
                {
                    GlobalSettings = {
                ColorMode = ColorMode.Color,
                Orientation = WkHtmlToPdfDotNet.Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings() { Top = 10 }
            },
                    Objects = {
                new ObjectSettings() {
                    PagesCount = true,
                    HtmlContent = htmlContent,
                    WebSettings = { DefaultEncoding = "utf-8" },
                    HeaderSettings = { FontSize = 9, Right = "[page]/[toPage] page", Line = true, Spacing = 2.812 }
                }
            }
                };

                var converter = new SynchronizedConverter(new PdfTools());
                var docArray = converter.Convert(doc);

                using var fileWiter = new BinaryWriter(File.OpenWrite(fileName));
                fileWiter.Write(docArray, 0, docArray.Length);
            }
        }
    }
