using AppGuid.Logic;
using System;

namespace AppGuid
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("AGREGAR TEXTO A PDF");
            string src = "MYL9997_123456789_O.pdf";
            string dest = "MYL9997_123456789.pdf";
            //string oldFile = "MYL9997_123456789.pdf";
            string ordenventa = "123456789";
            brLogic logic = new brLogic();
            var modificado = logic.ModificarPDF(src, dest, ordenventa);
            //var modificado = logic.ModifyPDF(oldFile, ordenventa);

            if (modificado)
                Console.WriteLine("Documento Modificado");

            Console.ReadLine();

        }
    }
}
