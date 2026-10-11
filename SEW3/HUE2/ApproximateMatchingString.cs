using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUE2
{
    class ApproximateMatchingString
    {
        public string word;
        public string pathToWordList; 

        public ApproximateMatchingString(string word, string pathToWordList)
        {
            this.word = word;
            this.pathToWordList = pathToWordList;
        }

        /* Dieses Property soll einen Vorschlag für mögliche korrigierte Wörter liefern. Hier sollen natürlich nur Wörter vorgeschlagen werden, die in der zuvor eingelesenen Wörterliste zu finden sind.*/
        public List<string> Suggestions { get; } = new List<string>();

        /*Es wird versucht einen Buchstaben an jeder möglichen Stelle einzufügen. Zurückgegeben werden mögliche Wörter, welche in der zuvor eingelesenen Wörterliste zu finden sind.
        z.B.: cot  coat*/

        private List<string> Inseration () { return Suggestions; }

        /* Es wird versucht einen einzelnen Buchstaben an jeder möglichen Stelle zu löschen. Zurückgegeben werden mögliche Wörter, welche in der zuvor eingelesenen Wörterliste zu finden sind.
        z.B.: coat  cot*/

        private List<string> Deletion() { return Inseration(); }


    }
}
