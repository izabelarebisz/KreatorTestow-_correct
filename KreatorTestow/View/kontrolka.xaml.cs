using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KreatorTestow
{
    /// <summary>
    /// Logika interakcji dla klasy kontrolka.xaml
    /// </summary>
    public partial class kontrolka : UserControl
    {
        public kontrolka()
        {
            InitializeComponent();
            Question = "Question";
            Answers = new string[4];
            Answers[0] = "Answer 1";
            Answers[1] = "Answer 2";
            Answers[2] = "Answer 3";
            Answers[3] = "Answer 4";


        }

        public static readonly DependencyProperty QuestionProperty =
            DependencyProperty.Register(
                nameof(Question),
                typeof(string),
                typeof(kontrolka));
        public string Question
        {
            get { return (string)GetValue(QuestionProperty); }
            set { SetValue(QuestionProperty, value); }
        }



        public static readonly DependencyProperty AnswersProperty =
            DependencyProperty.Register(
                nameof(Answers),
                typeof(string[]),
                typeof(kontrolka));
        public string[] Answers
        {
            get { return (string[])GetValue(AnswersProperty); }
            set { SetValue(AnswersProperty, value); }
        }
        public bool[] AnswerChecked
        {
            get { return (bool[])GetValue(AnswerCheckedProperty); }
            set { SetValue(AnswerCheckedProperty, value); }
        }

        public static readonly DependencyProperty AnswerCheckedProperty =
            DependencyProperty.Register(
        nameof(AnswerChecked),
        typeof(bool[]),
        typeof(kontrolka)
        );
        public static readonly DependencyProperty WhichAnswerCheckedProperty =
            DependencyProperty.Register(
                nameof(WhichAnswerChecked),
                typeof(int?),
                typeof(kontrolka),
                new PropertyMetadata(new PropertyChangedCallback(ChangeChecked))
                );

        public static readonly DependencyProperty IndexProperty =
           DependencyProperty.Register(
               nameof(Correct),
               typeof(int),
               typeof(kontrolka));
        public int Correct
        {
            get { return (int)GetValue(IndexProperty); }
            set { SetValue(IndexProperty, value); }
        }

        private static void ChangeChecked(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            int? newValue = (int?)e.NewValue;
            if (newValue == null)
            {
                (d as kontrolka).rb_1.IsChecked = false;
                (d as kontrolka).rb_2.IsChecked = false;
                (d as kontrolka).rb_3.IsChecked = false;
                (d as kontrolka).rb_4.IsChecked = false;
            }
            if (newValue == 0)
                (d as kontrolka).rb_1.IsChecked = true;

            if (newValue == 1)
                (d as kontrolka).rb_2.IsChecked = true;

            if (newValue == 2)
                (d as kontrolka).rb_3.IsChecked = true;

            if (newValue == 3)
                (d as kontrolka).rb_4.IsChecked = true;
        }

        public int? WhichAnswerChecked
        {
            get
            {
                return (int?)GetValue(WhichAnswerCheckedProperty);
            }
            set
            {
                SetValue(WhichAnswerCheckedProperty, value);

            }
        }
        private void Answer_Checked(object sender, RoutedEventArgs e)
        {
            WhichAnswerChecked = int.Parse((sender as RadioButton).Tag.ToString());
           
        }

    }
}
