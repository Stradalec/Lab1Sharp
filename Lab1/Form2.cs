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

        double IView.Interval()
        {
            return Convert.ToDouble(interval.Text);
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

        void IView.ShowResult(double result, double errorCheck) 
        {
            if (errorCheck != 1)
            {
                result = Math.Round(result, Convert.ToInt16(LimitationBox.Text));
                MessageBox.Show("Результат:" + result.ToString(), "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("В выбранном интервале корней нет", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Ошибка ввода левого ограничения интервала", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(SecondIntervalLimitation.Text) || (mathces = regex.IsMatch(SecondIntervalLimitation.Text)) == false)
            {
                result = false;
                MessageBox.Show("Ошибка ввода правого ограничения интервала", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(epsilonBox.Text) || (mathces = regex.IsMatch(epsilonBox.Text)) == false)
            {
                result = false;
                MessageBox.Show("Ошибка ввода значения epsilon", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(LimitationBox.Text) || (mathces = regex.IsMatch(LimitationBox.Text)) == false)
            {
                result = false;
                MessageBox.Show("Ошибка ввода значения требуемой точности", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(string.IsNullOrEmpty(interval.Text) || (mathces = regex.IsMatch(interval.Text)) == false) {
                result = false;
                MessageBox.Show("Ошибка ввода значения числа точек построения осей", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(functionLimitBox.Text) || (mathces = regex.IsMatch(functionLimitBox.Text)) == false)
            {
                result = false;
                MessageBox.Show("Ошибка ввода значения числа точек построения отрицательной стороны  функции", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(textBox1.Text) || (mathces = regex.IsMatch(textBox1.Text)) == false)
            {
                result = false;
                MessageBox.Show("Ошибка ввода значения числа точек построения положительной стороны функции", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            if (ValidateText())
            {
                double limit = Convert.ToDouble(interval.Text);
                double functionLimit = Convert.ToDouble(functionLimitBox.Text);
                double upFunctionLimit = Convert.ToDouble(textBox1.Text);
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

                Function = new Function("f(x) = " + function.Text);

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


                this.pvGraph.Model = plotModel;
            }
        }

        private void toolStripTextBox2_Click(object sender, EventArgs inputEvent)
        {
            if (ValidateText())
            {
                StartDichotomy(sender, inputEvent);
            }
        }
    }
}





