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
        double firstSide();
        double secondSide();
        double epsilon();
        Expression Expression();

        Function Function();
        void ShowResult(double[] input);

        event EventHandler<EventArgs> StartDichotomy;
    }


    // Модель. Основная часть работы программы происходит здесь
    class Model
    {
        public double[] Dichotomy(Function inputFunction, Expression inputExpression, double leftLimitation, double rightLimitation, double epsilon)
        {
            bool isFind = false;
            double[] outputArray = new double[2];

            inputExpression = new Expression($"f({leftLimitation})", inputFunction);

            inputFunction.checkSyntax();
            inputExpression.setArgumentValue("x", leftLimitation);
            double firstValue = inputExpression.calculate();

            inputExpression = new Expression($"f({rightLimitation})", inputFunction);
            inputExpression.setArgumentValue("x", rightLimitation);
            double secondValue = inputExpression.calculate();
            
            if (firstValue * secondValue >= 0)
            {
                outputArray[1] = 1;
            }
            else
            {
                outputArray[1] = 0;
            }

            while ((rightLimitation - leftLimitation) >= epsilon && !isFind)
            {
                double currentResult = (leftLimitation + rightLimitation) / 2;

                inputExpression = new Expression($"f({currentResult})", inputFunction);
                inputExpression.setArgumentValue("x", currentResult);
                inputExpression.checkSyntax();

                if (inputExpression.calculate() == 0) // Найден точный корень
                {
                    outputArray[0] = currentResult;
                    isFind = true;
                }
                else if (firstValue  * inputExpression.calculate() < 0) // Корень в левой половине интервала
                {
                    rightLimitation = currentResult;
                }
                else // Корень в правой половине интервала
                {
                    leftLimitation = currentResult;
                }
            }

            
            return outputArray;
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
            double[] output = model.Dichotomy(mainView.Function(),mainView.Expression(), mainView.firstSide(), mainView.secondSide(), mainView.epsilon());
            mainView.ShowResult(output);
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

