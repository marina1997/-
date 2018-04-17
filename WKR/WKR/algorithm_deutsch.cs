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
using MathNet.Numerics;
using Lachesis.QuantumComputing;
using System.IO;

namespace WKR
{
    public partial class algorithm_deutsch : Form
    {
        

        public algorithm_deutsch()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, EventArgs e)
        {
            main main_form = new main();
            main_form.Show();
            Hide();
        }






                                                                      
        private void f_1_Click(object sender, EventArgs e)                                        // ƒ(x) = 0 - константа
        {
            int number = 1;                                                                       // Для определения функции

            Deutsch deutsch = new Deutsch(new Random());                                          // , new TextBox()
            int i=deutsch.Run(number);
            FunctionMeasurement(i);                                                               // Вывод результата. Пятый шаг
            //string path1 = Path.GetDirectoryName(Application.ExecutablePath) + "\\picture\\f_1AlgDo.jpg";
            //schema_pic.Image = new Bitmap(path1);
           // schema_pic.
            //schema_pic.ImageLocation = Path.GetDirectoryName(Application.ExecutablePath) + "\\picture\\f_1AlgDo.jpg";
            //schema_pic.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void f_2_Click(object sender, EventArgs e)                                        // ƒ(x) = 1 - константа
        {
            int number = 2;                                                                       // Для определения функции
            Deutsch deutsch = new Deutsch(new Random());                                         
            int i = deutsch.Run(number);
            FunctionMeasurement(i);                                                               // Вывод результата. Пятый шаг
        }

        private void f_3_Click(object sender, EventArgs e)                                        // ƒ(x) = x - сбалансирована
        {
            int number = 3;                                                                       // Для определения функции
            Deutsch deutsch = new Deutsch(new Random());
            int i = deutsch.Run(number);
            FunctionMeasurement(i);                                                               // Вывод результата. Пятый шаг
        }
        private void button4_Click(object sender, EventArgs e)                                    // ƒ(x) = ~x - сбалансирована
        {
            int number = 4; 
            Deutsch deutsch = new Deutsch(new Random());
            int i = deutsch.Run(number);
            FunctionMeasurement(i);                                                               // Вывод результата. Пятый шаг
        }
        private void FunctionMeasurement(int i)                                                   // Интерпретация и вывод результата. Пятый шаг 
        {
            if (i == 0) label4.Text = "Функция f константа";
            else label4.Text = "Функция f сбалансирована";
        }    
    }

    class Deutsch                                                                               // Квантовый алгоритм Дойча
    {
        protected Random Random;
                                                                                               //protected TextBox textBox1;
        public Deutsch(Random random)                                                          //, TextBox textBox
        {
            this.Random = random;                                                              // this.textBox1 = textBox;                                                                                     
        }
        public int Run(int number)
        {
            int registerLength = 1;                                                            // Кол-во кубитов. квантовый регистр это совокупность некоторого числа кубитов 
                                                                                               // Подготовка начально состояния
            QuantumRegister inputRegister = new QuantumRegister(0, registerLength);            // Входной регистр
            QuantumRegister outputRegister = new QuantumRegister(1, registerLength);           // Выходной регистр 
            QuantumRegister fullRegister = new QuantumRegister(inputRegister, outputRegister); // Полный регистр (получается тензорным произведением)

            fullRegister = QuantumGate.HadamardGateOfLength(2) * fullRegister;                 // Преобразование Адамара. Первый шаг

            Matrix<Complex> matrixOracle = MatrixOracle(registerLength, number);               // Проектирование оракула. Второй шаг
            QuantumGate GateOracle = new QuantumGate(matrixOracle);                            // Получаем гейт (на основе matrixOracle)

            fullRegister = GateOracle * fullRegister;                                          // Применение Оракула к кубитам. Второй шаг
            fullRegister = QuantumGate.HadamardGateOfLength(2) * fullRegister;                 // Преобразование Адамара. Третий шаг


            fullRegister.Collapse(this.Random);                                                // Измерение (наблюление) первого регистра. Четвертый шаг
            int inputRegesterValue = fullRegister.GetValue(0, registerLength);                 // Полечение первого регистра. Четвертый шаг

            //FunctionMeasurement(inputRegesterValue);                                           //Вывод результата. Пятый шаг
            return inputRegesterValue;
        }

        protected static Matrix<Complex> MatrixOracle(int registerLength, int identifier)         // Метод для построения Оракула
        {
            int matrixSize = 1 << (registerLength * 2);                                           // Получаем размер оракула(матрицы); в данном случае регистр равен 1. следовательно 1 << 2=4
            Matrix<Complex> matrixOracle = Matrix<Complex>.Build.Sparse(matrixSize, matrixSize);  // Создание разреженной матрицы. Разрежённая матрица — это матрица с нулевыми элементами.  
            // Заполнение Матрицы
            if (identifier == 1)                                                                  // Функция f(x)=0
            {
                matrixOracle.At(0, 0, 1);
                matrixOracle.At(1, 1, 1);
                matrixOracle.At(2, 2, 1);
                matrixOracle.At(3, 3, 1);
            }
            else if (identifier == 2)                                                             // Функция f(x)=1
            {
                matrixOracle.At(1, 0, 1);
                matrixOracle.At(0, 1, 1);
                matrixOracle.At(3, 2, 1);
                matrixOracle.At(2, 3, 1);
            }
            else if (identifier == 3)                                                             // Функция f(x)=х
            {
                matrixOracle.At(0, 0, 1);
                matrixOracle.At(1, 1, 1);
                matrixOracle.At(3, 2, 1);
                matrixOracle.At(2, 3, 1);
            }
            else                                                                                  // Функция f(x)=~х
            {
                matrixOracle.At(1, 0, 1);
                matrixOracle.At(0, 1, 1);
                matrixOracle.At(2, 2, 1);
                matrixOracle.At(3, 3, 1);
            }

            return matrixOracle;
        }

        //public void FunctionMeasurement(int i)                                                    // Интерпретация и вывод результата. Пятый шаг
        //{
        //    if (i == 0) 
        //    {
        //        textBox1.Text = "Функция f константа";
        //       // Console.WriteLine("Функция f константа");
        //    }


        //    else Console.WriteLine("Функция f сбалансирована");
        //}

    }

}
