using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.IO;
using System.Text;

namespace PdfToText
{
    class Program 
    {
        static void Main(string[] args)
        { 

            ReadPdfFile(@"path-to-export-file.pdf");  //read pdf file from location
        }

        public static void ReadPdfFile(string fileName)
        {
            StringBuilder text = new();

            try
            {
                using (PdfReader pdfReader = new(fileName))
                {

                    for (int page = 1; page <= pdfReader.NumberOfPages; page++)
                    {
                        ITextExtractionStrategy strategy = new LocationTextExtractionStrategy();

                        string currentText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);
                        string[] theLines = currentText.Split('\n');

                        foreach (var theLine in theLines)
                        {
                            text.AppendLine(theLine);
                        }

                    }
                }
                var dataDir = @"Ctext-file-export-path.txt";
                // Save the text file
                File.WriteAllText(dataDir, text.ToString());
            }
            catch (Exception ex)
            {
            }

        }

         
    }
} 


