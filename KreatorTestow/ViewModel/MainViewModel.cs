using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KreatorTestow.ViewModel.BaseClass
{  
    using Model;
    using System.ComponentModel;
    using System.IO;
    using System.Windows;
    using System.Windows.Input;
    using BaseClass;
    using System.Collections.ObjectModel;
    using System.Windows.Forms;

    class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {

        }

        private ObservableCollection<Questions> lista = new ObservableCollection<Questions>();


        public ObservableCollection<Questions> Lista 
        {
            get { return lista;  }
            set
            {
                lista = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Lista)));
            }
        }


        private string question;
        public string Question
        {
            get { return question; }
            set
            {
                question = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Question)));
            }
        }

        private bool[] answerChecked;
        public bool[] AnswerChecked
        {
            get { return answerChecked; }
            set
            {
                answerChecked = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AnswerChecked)));
            }
        }
        private bool answerChecked1;
        public bool AnswerChecked1
        {
            get { return answerChecked1; }
            set
            {
                answerChecked1 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AnswerChecked1)));
            }
        }
        private bool answerChecked2;
        public bool AnswerChecked2
        {
            get { return answerChecked2; }
            set
            {
                answerChecked2 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AnswerChecked2)));
            }
        }
        private bool answerChecked3;
        public bool AnswerChecked3
        {
            get { return answerChecked3; }
            set
            {
                answerChecked3 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AnswerChecked3)));
            }
        }
        private bool answerChecked4;
        public bool AnswerChecked4
        {
            get { return answerChecked4; }
            set
            {
                answerChecked4 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AnswerChecked4)));
            }
        }
        private int? correct;
        public int? Correct
        {
            get { return correct; }
            set
            {
                correct = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Correct)));
            }

        }

        private string[] answers;
        public string[] Answers
        {
            get { return answers; }
            set
            {
                answers = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Answers)));
            }
        }
    

        private string answers0;
        public string Answers0
        {
            get { return answers0; }
            set
            {
                answers0 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Answers0)));
            }
        }
        private string answers1;
        public string Answers1
        {
            get { return answers1; }
            set
            {
                answers1 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Answers1)));
            }
        }
        private string answers2;
        public string Answers2
        {
            get { return answers2; }
            set
            {
                answers2 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Answers2)));
            }
        }
        private string answers3;
        public string Answers3
        {
            get { return answers3; }
            set
            {
                answers3 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Answers3)));
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
            }
        }

        public bool[] TemporaryArrayBool(bool A0, bool A1, bool A2, bool A3)
        {
            bool[] t = { A0, A1, A2, A3 };
            return t;
        }

        private ICommand confirm;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand Confirm
        {
            get
            {
                return confirm ?? (confirm = new RelayCommand(
                    (p) =>
                    {
                        AnswerChecked = TemporaryArrayBool(AnswerChecked1, AnswerChecked2, AnswerChecked3, AnswerChecked4);

                        string[] final_answers = QuestionsList.WhichAnswer(Answers0, Answers1, Answers2, Answers3, AnswerChecked);

                        Lista.Add(new Questions(Question, final_answers));
                    },
                    p => true));


            }
        }


        private ICommand save;

        public ICommand Save
        {
            get
            {
                return save ?? (save = new RelayCommand(
                    (p) =>
                    {
                        QuestionsList.Writetxt(Lista, Name, Title);
                        Name = ""; Title = ""; Question = "";
                        Answers0 = ""; Answers1 = ""; Answers2 = ""; Answers3 = "";
                        lista.Clear();
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Lista)));                      

                    },
                    p => true));


            }
        }


        private ICommand load;

        public ICommand Load
        {
            get
            {
                return load ?? (load = new RelayCommand(
                    (p) =>
                    {
                        OpenFileDialog fileDialog = new OpenFileDialog();
                        fileDialog.DefaultExt = "txt";
                        fileDialog.InitialDirectory = @"C:\DYSK_D\studia\programowanie obiektowe i graficzne\próby do 1 projektu\KreatorTestow__correct2\KreatorTestow _correct\KreatorTestow\bin\Debug\";
                        fileDialog.Filter = "Text Files (*.txt)|*.txt";
                        fileDialog.ShowDialog();

                        string path = fileDialog.FileName;

                        QuestionsList.LoadQuestions(Lista,path);
                        string[] lines = File.ReadAllLines(path);
                        string name = lines[0];
                        Name = name;
                        Title = fileDialog.FileName; Title = Title.Remove(0, 144); string[] t = Title.Split('.'); Title = t[0];
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Lista)));
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));

                    },
                    p => true));


            }
        }





        public string Answers01 { get => answers0; set => answers0 = value; }
     
    }
}
