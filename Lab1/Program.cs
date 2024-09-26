using OxyPlot.Series;
using OxyPlot.WindowsForms;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using org.mariuszgromada.math.mxparser;

namespace Lab1
{
    interface IView
    {
        double Interval();
        double firstSide();
        double secondSide();
        double epsilon();
        Expression Expression();

        Function Function();
        void ShowResult(double input, double errorCheck);

        event EventHandler<EventArgs> StartDichotomy;
    }


    // Модель. Основная часть работы программы происходит здесь
    class Model
    {
        public (double, double) Dichotomy(Function inputFunction, Expression inputExpression, double leftLimitation, double rightLimitation, double epsilon)
        {
            double result = double.NaN;
            double currentResult = 0;
            double errorCheck = 0;


            double firstValue = SolveFunc(inputFunction, leftLimitation.ToString().Replace(",", "."));

            double secondValue = SolveFunc(inputFunction, rightLimitation.ToString().Replace(",", "."));
                       

            while ((rightLimitation - leftLimitation) >= epsilon)
            {
                currentResult = (leftLimitation + rightLimitation) / 2;
                double position = SolveFunc(inputFunction, currentResult.ToString().Replace(",", "."));

                if (Math.Abs(position) == 0) // Найден точный корень
                {
                    result = currentResult;
                    return (result, errorCheck);
                }
                else if (firstValue  * position < 0) // Корень в левой половине интервала
                {
                    rightLimitation = currentResult;
                    secondValue = SolveFunc(inputFunction, rightLimitation.ToString().Replace(",", "."));
                }
                else // Корень в правой половине интервала
                {
                    leftLimitation = currentResult;
                    firstValue = SolveFunc(inputFunction, leftLimitation.ToString().Replace(",", "."));
                }
            }
            result = currentResult;

            if (firstValue * secondValue > 0)
            {
                errorCheck = 1;
            }
            else
            {
                errorCheck = 0;
            }

            return (result, errorCheck);
        }

        public double SolveFunc(Function function, string x)
        {
            return new org.mariuszgromada.math.mxparser.Expression($"f({x})", function).calculate();
        }
    }

    // Презентер. Извлекает данные из модели, передает в вид. Обрабатывает события
    class Presenter
    {
        private IView mainView;
        private Model model;

        public Presenter(IView inputView)
        {
            mainView = inputView;
            model = new Model();
            mainView.StartDichotomy += new EventHandler<EventArgs>(Dichotomy);
        }

        private void Dichotomy(object sender, EventArgs inputEvent)
        {
            var output = model.Dichotomy(mainView.Function(),mainView.Expression(), mainView.firstSide(), mainView.secondSide(), mainView.epsilon());
            mainView.ShowResult(output.Item1, output.Item2);
        }
    }
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}

