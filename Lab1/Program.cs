using OxyPlot.Series;
using OxyPlot.WindowsForms;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using org.mariuszgromada.math.mxparser;
using System.Drawing.Text;

namespace Lab1
{
    interface IView
    {
        string returnFunction();
        double lowLimit();
        double upLimit();
        double Interval();
        double firstSide();
        double secondSide();
        double epsilon();
        Expression Expression();

        Function Function();

        void ShowGraph(PlotModel plotModel, Function outputFunction, Expression outputExpression);
        void ShowResult(double input, double errorCheck);

        event EventHandler<EventArgs> StartDichotomy;
        event EventHandler<EventArgs> CreateGraph;
    }


    // Модель. Основная часть работы программы происходит здесь
    class Model
    {
        public (PlotModel, Function, Expression) CreateGraph(double interval, double downLimitation, double upLimitation, string function)
        {
            Expression expression; 
            Function Function;
            double limit = Convert.ToDouble(interval);
            double functionLimit = Convert.ToDouble(downLimitation);
            double upFunctionLimit = Convert.ToDouble(upLimitation);
            double xIntercept = double.NaN;
            List<DataPoint> dot = new List<DataPoint>();

            var plotModel = new PlotModel { Title = "График функции f(x)" };


            var dataPoints = new List<double> { 0 };


            var absicc = new LineSeries {
                Title = "Абсцисс",
                Color = OxyColor.FromRgb(255, 0, 0), // Красный цвет
                StrokeThickness = 2
            };

            absicc.Points.Add(new DataPoint(-limit, 0));
            absicc.Points.Add(new DataPoint(limit, 0));

            var ordinate = new LineSeries {
                Title = "Ординат",
                Color = OxyColor.FromRgb(255, 0, 0), // Красный цвет
                StrokeThickness = 2,
            };

            ordinate.Points.Add(new DataPoint(0, limit));
            ordinate.Points.Add(new DataPoint(0, -limit));

            // Создаем серию точек графика
            var lineSeries = new LineSeries {
                Title = "f(x)",
                Color = OxyColor.FromRgb(0, 0, 255) // Синий цвет линии
            };

            Function = new Function("f(x) = " + function);

            expression = new Expression($"f({1})", Function);
            int lowIndex = Convert.ToInt32(functionLimit);
            int upIndex = Convert.ToInt32(upFunctionLimit);
            for (int counterI = -lowIndex; counterI <= upIndex; ++counterI)
            {
                expression = new Expression($"f({counterI})", Function);
                expression.setArgumentValue("x", counterI);
                double y = expression.calculate();
                if (y == 0)
                {
                    xIntercept = counterI;
                }
                dot.Add(new DataPoint(counterI, y));
            }

            // Добавляем все точки в серию
            lineSeries.Points.AddRange(dot);

            // Добавляем серию точек к модели графика
            plotModel.Series.Add(lineSeries);
            plotModel.Series.Add(ordinate);
            plotModel.Series.Add(absicc);

            return (plotModel, Function, expression);
        }
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
            mainView.CreateGraph += new EventHandler<EventArgs>(CreateGraph);
        }

        private void Dichotomy(object sender, EventArgs inputEvent)
        {
            var output = model.Dichotomy(mainView.Function(),mainView.Expression(), mainView.firstSide(), mainView.secondSide(), mainView.epsilon());
            mainView.ShowResult(output.Item1, output.Item2);
        }
        private void CreateGraph(object sender, EventArgs inputEvent)
        {
            var output = model.CreateGraph(mainView.Interval(), mainView.lowLimit(), mainView.upLimit(), mainView.returnFunction());
            mainView.ShowGraph(output.Item1, output.Item2, output.Item3);
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

