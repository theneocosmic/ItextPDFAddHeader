using iText.IO.Font.Constants;
using iText.Kernel.Events;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Properties;
using System.Configuration;
using System.IO;

namespace AppGuid.Logic
{
    public class brLogic
    {
        public static string ordenDeVenta = "";
        public bool ModificarPDF(string src, string dest, string orden)
        {
            ordenDeVenta = orden;
            var ruta = ConfigurationManager.AppSettings["folderFiles"];
            var filePathsrc = @"C:\Users\ext.david.dzul\source\repos\Guid\Files\" + src;
            var filePathDestino = @"C:\Users\ext.david.dzul\source\repos\Guid\Files\" + dest;
            try
            {
                PdfReader reader = new PdfReader(filePathsrc);
                reader.SetUnethicalReading(true);
                PdfDocument pdfDoc = new PdfDocument(reader, new PdfWriter(filePathDestino));
                Document doc = new Document(pdfDoc);
                pdfDoc.AddEventHandler(PdfDocumentEvent.END_PAGE, new TextFooterEventHandler(doc));
                doc.Close();
                return true;
            }
            catch (System.Exception e)
            {
                string error = e.Message;
                return false;
            }
        }

        private class TextFooterEventHandler : IEventHandler
        {
            protected Document doc;

            public TextFooterEventHandler(Document doc)
            {
                this.doc = doc;
            }


            public void HandleEvent(Event currentEvent)
            {
                PdfDocumentEvent docEvent = (PdfDocumentEvent)currentEvent;
                Rectangle pageSize = docEvent.GetPage().GetPageSize();
                PdfFont font = null;
                try
                {
                    font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                }
                catch (IOException e)
                {

                    string error = e.Message;

                }

                float coordX = 5;
                float headerY = pageSize.GetTop() - 10;

                Canvas canvas = new Canvas(docEvent.GetPage(), pageSize);
                canvas

                    .SetFont(font)
                    .SetFontSize(5)
                    .ShowTextAligned("ORDEN DE VENTA:" + ordenDeVenta, coordX, headerY, TextAlignment.LEFT)
                    .Close();
            }
        }



        /** ESTA VERSION FUNCIONA SIEMPRE Y CUANDO EL DOCUMENTO NO TENGA CONTRASEÑA DE USUARIO**/
        //public bool ModifyPDF(string fileSource, string ordenventa)
        //{

        //
        //    var filePath = @"C:\Users\ext.david.dzul\source\repos\Guid\Files\" + fileSource;
        //    byte[] bytes = System.IO.File.ReadAllBytes(filePath);

        //    PdfReader reader = new PdfReader(filePath);
        //    reader.SetUnethicalReading(true);

        //    //var pdfReader = new PdfReader(bytes);

        //    try
        //    {
        //        using (Stream output = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
        //        {
        //            using (PdfStamper pdfStamper = new PdfStamper(pdfReader, output))
        //            {
        //                for (int pageIndex = 1; pageIndex <= pdfReader.NumberOfPages; pageIndex++)
        //                {
        //                    pdfStamper.FormFlattening = false;
        //                    Rectangle pageRectangle = pdfReader.GetPageSizeWithRotation(pageIndex);
        //                    PdfContentByte pdfData = pdfStamper.GetOverContent(pageIndex);
        //                    pdfData.SetFontAndSize(BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), 10);
        //                    PdfGState graphicsState = new PdfGState
        //                    {
        //                        FillOpacity = 0.3F
        //                    };
        //                    pdfData.SetGState(graphicsState);
        //                    pdfData.BeginText();
        //                    // select the font properties
        //                    BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        //                    pdfData.SetColorFill(BaseColor.BLACK);
        //                    pdfData.SetFontAndSize(bf, 8);
        //                    // write the text in the pdf content
        //                    pdfData.BeginText();
        //                    string text = "ORDEN DE VENTA:" + ordenventa;
        //                    // put the alignment and coordinates here
        //                    pdfData.ShowTextAligned(1, text, 70, 775, 0);
        //                    pdfData.EndText();
        //                    pdfData.BeginText();
        //                    string text1 = "EXEL DEL NORTE";
        //                    pdfData.ShowTextAligned(1, text1, 550, 775, 0);
        //                    pdfData.EndText();

        //                }
        //            }
        //            output.Close();
        //            output.Dispose();
        //        }

        //        return true;

        //    }
        //    catch (System.Exception e)
        //    {
        //        return false;
        //    }
        //}
    }
}

