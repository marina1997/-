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

namespace WKR_2
{
    public partial class algorithm_grover : Form
    {
        public algorithm_grover()
        {
            InitializeComponent();
        }

        int count;
        private List<string> answer_mas = new List<string>();                                              // Хранятся все ответы
        private int N;                                                                                     // Сколько раз будет выполняться вся программа
        private int numberIterations;                                                                      // Сколько раз будет выполняться итерация Гровера

        private void run_Click(object sender, EventArgs e)
        {
            int[] array = new int[8];                                                                     // Массив для построения оракула
            for (count=1; count < 9; count++)                                                             // Цикл в котором заполняется Оракул
            {
                    array[count-1]=Convert.ToInt32(this.Controls["textbox" + count.ToString()].Text);
            }
            N = Convert.ToInt32(textBox9.Text);                                                          // Ввод количества выполнений алгоритма Гровера
            numberIterations = Convert.ToInt32(textBox10.Text);

            for (int count = 0; count < N; count++)                                                      // Вызов алгоритма Гровера N раз
            {
                Grover grover = new Grover(new Random());
                answer_mas.Add(grover.Run(numberIterations, array));
            }
            plotting(answer_mas);
        }

        private void plotting(List<string> answer_mas)
        {
            int sum;
            String[] answer_all = { "000", "001", "010", "011", "100", "101", "110", "111" };           // Все возможные ответы. Для построения графика


            chart1.Series[0].Points.Clear();                                                           // Очищение графика      
            for (int count = 0; count < answer_all.Length; count++)                                    // Построение Графика
            {
                sum = 0;
                for (int i = 0; i < answer_mas.Count; i++)
                {
                    if (answer_all[count] == answer_mas[i]) sum++;
                }
                chart1.Series[0].Points.AddXY(answer_all[count], sum);
            }
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;                                      // Убирется сетка у графика
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            answer_mas.Clear();                                                                        // Очищение списка

        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            for (count = 1; count < 11; count++)                                                      // Цикл в котором очищаются все textBox и график
            {
                this.Controls["textbox" + count.ToString()].Text = "";
            }
            chart1.Series[0].Points.Clear();   
            
        }

        private void back_Click(object sender, EventArgs e)                                            // Кнопка вернуться в главное меню
        {
            main main_form = new main();
            main_form.Show();
            Hide();
        }

        private void exit_Click(object sender, EventArgs e)                                            // Кнопка выход
        {
            Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


    }

    class Grover                                                                                       // Алгоритм Гровера
    {
        protected Random Random;

        public Grover(Random random)
        {
            this.Random = random;
        }

        public string Run(int numberIterations, int[] array)
        {
            int registerLength = 3;                                                                     // Кол-во кубитов.
            QuantumRegister fullRegister = new QuantumRegister(0, registerLength);                      // Полный регистр
            fullRegister = QuantumGate.HadamardGateOfLength(registerLength) * fullRegister;             // Преобразование Адамара. Первый шаг
            Matrix<Complex> matrixOracle = MatrixOracle(registerLength, array);                         // Проектирование оракула. Второй шаг
            QuantumGate GateOracle = new QuantumGate(matrixOracle);                                     // Получаем гейт (на основе matrixOracle)


            Matrix<Complex> matrixPhaseInverse = PhaseInverse(registerLength);                          // Проектирование матрицы оператора диффузии (условные сдвиг фазы) 
            QuantumGate GatePhaseInverse = new QuantumGate(matrixPhaseInverse);                         // Гейт условного сдвига фазы
            for (int count = numberIterations; count > 0; count--)                                      // Применение итерации Гровера. Третий шаг
            {
                fullRegister = GateOracle * fullRegister;
                //fullRegister = QuantumGate.HadamardGateOfLength(registerLength) * fullRegister;
                fullRegister = GatePhaseInverse * fullRegister;
                //fullRegister = QuantumGate.HadamardGateOfLength(registerLength) * fullRegister;
            }

            fullRegister.Collapse(this.Random);                                                         // Измерение (наблюление). Четвертый шаг
            int RegisterValue = fullRegister.GetValue(0, registerLength);                               // Измерение
            string BinaryRegisterValue = HexToBin(RegisterValue, registerLength);                       // Перевод из 10 в 2 систему
            return (BinaryRegisterValue);
            ;

        }

        protected static Matrix<Complex> MatrixOracle(int registerLegth, int[] array)                     // Метод для построения Оракула
        {                                                    
            Matrix<Complex> matrixOracle = Matrix<Complex>.Build.Sparse(array.Length, array.Length);      // Создание разреженной матрицы
            for (int RowColumn = 0; RowColumn < array.Length; RowColumn++)                                // Цикл для построений оракула
            {
                if (array[RowColumn] == 0) matrixOracle.At(RowColumn, RowColumn, 1);
                else matrixOracle.At(RowColumn, RowColumn, -1);
            }
            return matrixOracle;
        }
        protected static Matrix<Complex> PhaseInverse(int registerLegth)                                  // Метода для построения оператора условного сдвига фазы
        {
            int matrixSize = 1 << registerLegth;                                                          // Определение размеар оракула(матрицы)
            Complex n = 2 * 1 / Math.Pow(2, registerLegth);
            Matrix<Complex> matrixPhaseInverse = Matrix<Complex>.Build.Dense(matrixSize, matrixSize, n);  // Создание разреженной матрицы
            n = n - 1;
            for (int RowColumn = 0; RowColumn < matrixSize; RowColumn++)
            {
                matrixPhaseInverse.At(RowColumn, RowColumn, n);
            }
            return matrixPhaseInverse;
        }


        private string HexToBin(int a, int n)                                                             //Перевод из 10 в 2 систему и дополнение нулей. n количество кубитов
        {
            string original = Convert.ToString(a, 2);

            if (original.Length < n)
            {
                int length = n - original.Length;
                for (int count = 0; count < length; count++)
                {
                    original = original.Insert(0, "0");
                }
            }
            return original;

        }
    }
}
