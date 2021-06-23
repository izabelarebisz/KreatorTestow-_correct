using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Collections.ObjectModel;

namespace KreatorTestow.Model
{
    class QuestionsList
    {

        private System.Collections.ObjectModel.ObservableCollection<Questions> listOfQuestions = new System.Collections.ObjectModel.ObservableCollection<Questions>();
      

        public QuestionsList(System.Collections.ObjectModel.ObservableCollection<Questions> listOfQuestions)
        {
            this.listOfQuestions = listOfQuestions;

        }

        public void Add(Questions q) => listOfQuestions.Add(q);

        public Questions this[int correct]
        {
            get { return listOfQuestions[correct]; }
        }

        public static void Writetxt(ObservableCollection<Questions> lista, string name, string title)
        {
            title += ".txt";
            string path = title;
            if (File.Exists(path)) File.Delete(path);
            string ReturnString = "";
            foreach (Questions QuestionA in lista)
            {            
                string T = QuestionA.ToString();
                ReturnString = $"{ReturnString}\n{T}\n**********";               
            }
            File.AppendAllText(path, name);
            File.AppendAllText(path, ReturnString + Environment.NewLine);
        }



        public static void LoadQuestions(ObservableCollection<Questions> lista, string path)
        {          
            if (File.Exists(path))
            {
 
                lista.Clear();
                string[] lines = File.ReadAllLines(path);
                string name = lines[0];
                for (int i = 1; i < lines.Length; i += 6)
                {
                    if (lines[i] == "") break;
                    string question = lines[i];
                    string[] answers = { lines[i + 1], lines[i + 2], lines[i + 3], lines[i + 4] };
                    lista.Add(new Questions(question, answers));
                }
            }
            else
            {
                throw new FileNotFoundException("Nie znaleziono pliku z pytaniami.");
            }
        }


        public static string[] WhichAnswer(string A1, string A2, string A3, string A4, bool[] AnswerChecked)
        {
            string[] answers = { A1, A2, A3, A4 };
            for (int i=0; i<4; i++)
            {
                if (AnswerChecked[i]) answers[i] = "1 | " + answers[i];
                else answers[i] = "0 | " + answers[i];
            }

            return answers;
        }

        public override string ToString()
        {
            string ReturnString = "";
            foreach (Questions QuestionA in listOfQuestions)
            {
                string T = QuestionA.ToString();
                ReturnString = $"{ReturnString}\n{T}";
            }
            return ReturnString;
        }

    }

}
