using OxyPlot.Series;
using OxyPlot.WindowsForms;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using org.mariuszgromada.math.mxparser;
using LiveCharts.Wpf.Charts.Base;
using System.Text.RegularExpressions;

namespace Lab1
{
    public partial class dichotomyForm : Form, IView
    {
        private Expression expression;
        private Function Function;
        public dichotomyForm()
        {
            InitializeComponent();
            Presenter presenter = new Presenter(this);
        }

        double IView.firstSide() 
        {
            return Convert.ToDouble(FirstIntervalLimitation.Text); 
        }

        double IView.secondSide()
        {
            return Convert.ToDouble(SecondIntervalLimitation.Text);
        }

        double IView.epsilon()
        {
            return Convert.ToDouble(epsilonBox.Text);
        }

        Expression IView.Expression() 
        {
            return expression; 
        }

        Function IView.Function()
        {
            return Function;
        }

        public event EventHandler<EventArgs> StartDichotomy;

        void IView.ShowResult(double[] input) 
        {
            if (input[1] != 1)
            {
                input[0] = Math.Round(input[0], Convert.ToInt16(LimitationBox.Text));
                resultBox.Text = input[0].ToString();
            }
            else
            {
                resultBox.Text = "В выбранном интервале корней нет";
            }
        }

        private void DrawButton_Click(object sender, EventArgs e)
        {
            double xIntercept = double.NaN;
            List<DataPoint> dot = new List<DataPoint>();

            var plotModel = new PlotModel { Title = "График функции f(x)" };


            var dataPoints = new List<double> { 0 };


            var absicc = new LineSeries {
                Title = "Абсцисс",
                Color = OxyColor.FromRgb(255, 0, 0), // Красный цвет
                StrokeThickness = 2
            };

            absicc.Points.Add(new DataPoint(-100, 0));
            absicc.Points.Add(new DataPoint(100, 0));

            var ordinate = new LineSeries {
                Title = "Ординат",
                Color = OxyColor.FromRgb(255, 0, 0), // Красный цвет
                StrokeThickness = 2,
            };

            ordinate.Points.Add(new DataPoint(0, 100));
            ordinate.Points.Add(new DataPoint(0, -100));

            // Создаем серию точек графика
            var lineSeries = new LineSeries {
                Title = "f(x)",
                Color = OxyColor.FromRgb(0, 0, 255) // Синий цвет линии
            };

            Function = new Function("f(x) = " + function.Text);

            for (int counterI = -150; counterI <= 150; ++counterI)
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


            this.pvGraph.Model = plotModel;
          
            if (!double.IsNaN(xIntercept))
            {
                textBox1.Text = "Функция пересекает ось абсцисс в точке.";
                xIntercept = double.NaN;
            }
            else
            {
                textBox1.Text = "Функция не пересекает ось абсцисс";
            }
        }

        private void SetIntervalButton_Click(object sender, EventArgs inputEvent)
        {
            if (ValidateText()) 
            {
                StartDichotomy(sender, inputEvent);
            }
            
        }

        private bool ValidateText()
        {
            Regex regex = new Regex(@"^[\d,-]+$");
            bool result = true;
            bool mathces;
            if (string.IsNullOrEmpty(FirstIntervalLimitation.Text) || (mathces = regex.IsMatch(FirstIntervalLimitation.Text)) == false) 
            {
                result = false;
                mathces = false;
                FirstIntervalLimitation.Text = "Ошибка ввода";
            }
            else if (string.IsNullOrEmpty(SecondIntervalLimitation.Text) || (mathces = regex.IsMatch(SecondIntervalLimitation.Text)) == false)
            {
                result = false;
                SecondIntervalLimitation.Text = "Ошибка ввода";
            }
            else if (string.IsNullOrEmpty(epsilonBox.Text) || (mathces = regex.IsMatch(epsilonBox.Text)) == false)
            {
                result = false;
                epsilonBox.Text = "Ошибка ввода";
            }
            else if (string.IsNullOrEmpty(LimitationBox.Text) || (mathces = regex.IsMatch(LimitationBox.Text)) == false)
            {
                result = false;
                LimitationBox.Text = "Ошибка ввода";
            }
            return result;
        }
    }
}





