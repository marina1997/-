using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra;
using Lachesis.QuantumComputing;

namespace WKR_2
{
    public partial class algorithm_deutsch : Form
    {
        public algorithm_deutsch()
        {
            InitializeComponent();
        }
        int count;
        private void run_Click(object sender, EventArgs e)
        {
            Matrix<Complex> matrixOracle = Matrix<Complex>.Build.Sparse(4, 4);                     // Создание разреженной матрицы. Матрица для Оракула, заполняется пользователем
            count = 1;
            for (int row = 0; row < 4; row++)                                                      // Цикл в котором заполняется Оракул
            {
                for (int column = 0; column < 4; column++)
                {
                    matrixOracle.At(row, column, Convert.ToInt32(this.Controls["textbox" + count.ToString()].Text));
                    count++;
                }
            }
            Deutsch deutsch = new Deutsch(new Random());                                          // , new TextBox()
            int i = deutsch.Run(matrixOracle);
            FunctionMeasurement(i);                                                               // Вывод результата. Пятый шаг
        }

        private void FunctionMeasurement(int i)                                                  // Интерпретация и вывод результата. Пятый шаг 
        {
            if (i == 0) label1.Text = "Функция f константа";
            else label1.Text = "Функция f сбалансирована";
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            //ClearTextBoxes(this.Controls);
            for (count = 1; count < 17; count++)                                                 // Цикл в котором очищаются все textBox
            {
                this.Controls["textbox" + count.ToString()].Text = "";
            }
            label1.Text = "";
        }
        //private void ClearTextBoxes(Control.ControlCollection cc)
        //{
        //    foreach (Control ctrl in cc)
        //    {
        //        TextBox tb = ctrl as TextBox;
        //        if (tb != null)
        //            tb.Text = "";
        //        else
        //            ClearTextBoxes(ctrl.Controls);
        //    }
        //}

        private void exit_Click(object sender, EventArgs e)                                         // Кнопка закрытия
        {
            Close();
        }

        private void back_Click(object sender, EventArgs e)                                         // Кнопка вернуться в главное меню
        {
            main main_form = new main();
            main_form.Show();
            Hide();
        }

        private void algorithm_deutsch_Load(object sender, EventArgs e)
        {

        }
    }



    class Deutsch                                                                               // Квантовый алгоритм Дойча
    {
        protected Random Random;
        public Deutsch(Random random)                                                          //, TextBox textBox
        {
            this.Random = random;                                                              // this.textBox1 = textBox;                                                                                     
        }

        public int Run(Matrix<Complex> matrixOracle)
        {
            int registerLength = 1;                                                            // Кол-во кубитов. квантовый регистр это совокупность некоторого числа кубитов 
                                                                                               // Подготовка начально состояния
            QuantumRegister inputRegister = new QuantumRegister(0, registerLength);            // Входной регистр
            QuantumRegister outputRegister = new QuantumRegister(1, registerLength);           // Выходной регистр 
            QuantumRegister fullRegister = new QuantumRegister(inputRegister, outputRegister); // Полный регистр (получается тензорным произведением)

            fullRegister = QuantumGate.HadamardGateOfLength(2) * fullRegister;                 // Преобразование Адамара. Первый шаг

            QuantumGate GateOracle = new QuantumGate(matrixOracle);                            // Проектирование оракула. Второй шаг. Получаем гейт (на основе matrixOracle)

            fullRegister = GateOracle * fullRegister;                                          // Применение Оракула к кубитам. Второй шаг
            fullRegister = QuantumGate.HadamardGateOfLength(2) * fullRegister;                 // Преобразование Адамара. Третий шаг


            fullRegister.Collapse(this.Random);                                                // Измерение (наблюление) первого регистра. Четвертый шаг
            int inputRegesterValue = fullRegister.GetValue(0, registerLength);                 // Полечение первого регистра. Четвертый шаг

            return inputRegesterValue;
        }
    }
}


