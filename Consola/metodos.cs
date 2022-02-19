using Consola.dto;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Canvas.Parser;

namespace Consola
{
    public class Metodos
    {
        //     Visual Studio, 2022.
        public string ObtenerLetraASCII() // v
        {
            return Convert.ToChar(118).ToString();
        }

        public string ObterLetraDocTXT() //i
        {
            string value = "";
            TextReader letraTxt = new StreamReader("letra.txt");
            return value = letraTxt.ReadLine();
        }

        public string ObterLetraXML() //s
        {
            XmlTextReader xmlText = new XmlTextReader("letra.xml");
            XmlDocument doc = new XmlDocument();
            XmlNode node = doc.ReadNode(xmlText);
            var letra = "";
            foreach (XmlNode chldNode in node.ChildNodes)
            {
                if (chldNode.Name == "Palabra")
                    return letra = chldNode.Attributes["letra"].Value.Trim();
            }

            return "";
        }

        public string ObterLetraJSON() //u
        {
            string path = "letra.json";
            using (StreamReader jsonStream = File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                Palabra texto = JsonConvert.DeserializeObject<Palabra>(json);

                return texto.letra;
            }
        }

        public string ObterLetraPDF() //a
        {
            var pdf = new PdfDocument(new PdfReader("letra.pdf"));
            string text = "";

            for (int i = 1; i <= pdf.GetNumberOfPages(); i++)
            {
                var page = pdf.GetPage(i);
                text = PdfTextExtractor.GetTextFromPage(page);
            }

            return text.ToString();
        }

        public string ObterLetraSumaChar() //l
        {
            char caracter = 'a';
            for (int i = 1; i <= 11; i++)
            {
                caracter++;
            }

            return caracter.ToString();
        }

        public string ObterLetraDictionary() //
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            dict.Add("letra", " ");

            return dict["letra"];
        }

        public string ObterLetraListaString() // s
        {
            List<string> list = new List<string>() { "s" };
            return list[0];
        }

        public string ObterLetraQueue() //t
        {
            Queue letraQueue = new Queue();
            letraQueue.Enqueue("t");

            return letraQueue.Peek().ToString();
        }

        public string ObterLetraString() //u
        {
            string letra = "u";
            return letra;
        }

        public string ObterLetraChar()// d
        {
            char letra = 'd';
            return letra.ToString();
        }

        public string ObterLetraObjeto() //i
        {
            Palabra palabra = new Palabra();
            palabra.letra = "i";

            return palabra.letra;
        }

        public string ObterLetraVector() // o
        {
            string[] caracteres = new string[1] { "o" };

            return caracteres[0];
        }

        public string ObterLetraReplace() //,
        {
            decimal num = 10.0M;

            return num.ToString().Replace(".", ",").Substring(2, 1);
        }

        public string ObterLetraMatriz() //
        {
            string[,] matriz = new string[1, 1];

            matriz[0, 0] = " ";

            return matriz[0, 0].ToString();
        }

        public string ObterLetraPila() //2
        {
            Stack pila = new Stack();
            pila.Push("0");
            pila.Push("2");

            return pila.Pop().ToString();
        }

        public string ObterLetraParametro(int letra)
        {
            return letra.ToString();
        } //0

        public string ObterLetraCSV()
        {
            string[] lineas = File.ReadAllLines("letra.csv");

            return lineas[0];
        } //2

        public string ObterLetraFloat() // 0
        {
            float num = 2.12F;
            return num.ToString().Substring(0, 1);
        }

        public string ObterLetraWebScraping() //.
        {
            List<string> lista = new List<string>();
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load("https://es.wikipedia.org/wiki/Punto_(puntuaci%C3%B3n)");
            var c = doc.DocumentNode.SelectNodes("//b").ToList();
            foreach (var item in c)
            {
                lista.Add(item.InnerText.Trim());
            }
            return lista[1];
        }

        public string GenerarTexto()
        {
            return $"{ObtenerLetraASCII()}" + //v
                $"{ObterLetraDocTXT()}" +//i
                $"{ObterLetraXML()}" +//s
                $"{ObterLetraJSON()}" +//u
                $"{ObterLetraPDF()}" +//a
                $"{ObterLetraSumaChar()}" +//l
                $"{ObterLetraDictionary()}" +//
                $"{ObterLetraListaString()}" +//s
                $"{ObterLetraQueue()}" +//t
                $"{ObterLetraString()}" +//u
                $"{ObterLetraChar()}" +//d
                $"{ObterLetraObjeto()}" +//i
                $"{ObterLetraVector()}" +//o
                $"{ObterLetraReplace()}" +//,
                $"{ObterLetraMatriz()}" +// 
                $"{ObterLetraPila()}" + //2
                $"{ObterLetraParametro(0)}" + //0
                $"{ObterLetraCSV()}" + //2
                $"{ObterLetraFloat()}" + //0
                $"{ObterLetraWebScraping()}";
        }
    }
}
