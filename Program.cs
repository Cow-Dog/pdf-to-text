using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
namespace PDFP
{
    class MainClass
    {
        public static String info;
        public static  string name;
        public static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            string file = "/Users/stephenwoodman/Desktop/test.pdf";
            using (PdfReader read = new PdfReader(file))
            {

                int counter = 1;
                Boolean flag = true;

                for (int pageNumber = 0; pageNumber < read.NumberOfPages; pageNumber++)
                {

                    ITextExtractionStrategy s = new SimpleTextExtractionStrategy();
                    string text = PdfTextExtractor.GetTextFromPage(read, counter, s);
                    text = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(text)));
                    sb.Append(text);
                    counter++;


                }
                info = sb.ToString();
                // Console.Write(info);
                //string split = "this, needs, to, split";
                // List<string> list = new List<string>();
                // list = info.Split(' ').ToList();
                System.IO.File.WriteAllText("/Users/stephenwoodman/Desktop/pdfToText.txt", info);


            }
        }
       

        }

    }

        
    

