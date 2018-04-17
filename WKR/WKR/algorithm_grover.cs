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

namespace WKR
{
    public partial class algorithm_grover : Form
    {
        public algorithm_grover()
        {
            InitializeComponent();
        }
        private void back_Click(object sender, EventArgs e)                                                // Кнопка назад
        {
            main main_form = new main();
            main_form.Show();
            Hide();
        }

        private void f_1_Click(object sender, EventArgs e)           
        {
            int sum, k=1;
            //String [] all_answer = { "000", "001", "010", "011", "100", "101", "110", "111" };
            //String[] answer_mas=new String[20];
            List<string> answer_mas = new List<string>();
            string answer;

            for (int count = 0; count < 5; count++)
            {
                Grover grover = new Grover(new Random());
                answer = grover.Run();
                answer_mas.Add(answer);
                //answer_mas[count] = answer;
                //label1.Text = answer;
            }
            for (int count = 0; count < answer_mas.Count; count++)
            {
                sum = 0;
                for (int j = k; j <= answer_mas.Count; j++)
                {
                    if (answer_mas.ElementAt<string>(count) == answer_mas.ElementAt<string>(j-1))
                    {
                        sum++;
                        if (answer_mas.Count == j)
                        {
                            answer_mas.RemoveAt(j - 1);
                            j--;
                        }
                        if (j - 1 != 0)
                        {
                            answer_mas.RemoveAt(j);
                            j--;
                        }
                        
                    }
                }
                if (sum == 0) continue;
                chart1.Series[0].Points.AddXY(answer_mas.ElementAt<string>(count), sum);
                k++;


            }

            //chart1.Series[0].Points.AddXY(all_answer,answer_mas[count]);

            
        }
    }

    class Grover                                                                                           // Алгоритм Гровера
    {
        protected Random Random;

        public Grover(Random random)
        {
            this.Random = random;
        }

        public string Run()
        {
            int registerLength = 3;                                                                        // Кол-во кубитов.
            QuantumRegister fullRegister = new QuantumRegister(0, registerLength);                         // Полный регистр
            fullRegister = QuantumGate.HadamardGateOfLength(registerLength) * fullRegister;                // Преобразование Адамара. Первый шаг
            Matrix<Complex> matrixOracle = MatrixOracle(registerLength);                                   // Проектирование оракула. Второй шаг
            QuantumGate GateOracle = new QuantumGate(matrixOracle);                                        // Получаем гейт (на основе matrixOracle)


            Matrix<Complex> matrixPhaseInverse = PhaseInverse(registerLength);                             // Проектирование матрицы оператора диффузии (условные сдвиг фазы) 
            QuantumGate GatePhaseInverse = new QuantumGate(matrixPhaseInverse);                            // Гейт условного сдвига фазы
            for (int count = 2; count > 0; count--)                                                        //Применение итерации Гровера. Третий шаг
            {
                fullRegister = GateOracle * fullRegister;
                //fullRegister = QuantumGate.HadamardGateOfLength(registerLength) * fullRegister;
                fullRegister = GatePhaseInverse * fullRegister;
                //fullRegister = QuantumGate.HadamardGateOfLength(registerLength) * fullRegister;
            }

            fullRegister.Collapse(this.Random);                                                            // Измерение (наблюление). Четвертый шаг
            int RegisterValue = fullRegister.GetValue(0, registerLength);                                  // Измерение
            string BinaryRegisterValue = Convert.ToString(RegisterValue, 2);                               // Перевод из 10 в 2 систему
            return (BinaryRegisterValue);
            ;

        }

        protected static Matrix<Complex> MatrixOracle(int registerLegth)                                    // Метод для построения Оракула
        {
            int matrixSize = 1 << registerLegth;                                                            // Определение размера оракула(матрицы)
            Matrix<Complex> matrixOracle = Matrix<Complex>.Build.Sparse(matrixSize, matrixSize);            // Создание разреженной матрицы
            for (int RowColumn = 0; RowColumn < matrixSize; RowColumn++)                                    // Заполнение матрицы для функции x1^x2^x3
            {
                matrixOracle.At(RowColumn, RowColumn, 1);
            }
            matrixOracle.At(matrixSize - 1, matrixSize - 1, -1);                                            // Заполнение матрицы для функции x1^x2^x3
            return matrixOracle;
        }
        protected static Matrix<Complex> PhaseInverse(int registerLegth)                                    // Метода для построения оператора условного сдвига фазы
        {
            int matrixSize = 1 << registerLegth;                                                            // Определение размеар оракула(матрицы)
            Complex n = 2 * 1 / Math.Pow(2, registerLegth);
            Matrix<Complex> matrixPhaseInverse = Matrix<Complex>.Build.Dense(matrixSize, matrixSize, n);    // Создание разреженной матрицы
            n = n - 1;
            for (int RowColumn = 0; RowColumn < matrixSize; RowColumn++)
            {
                matrixPhaseInverse.At(RowColumn, RowColumn, n);
            }
            return matrixPhaseInverse;
        }
    }
}
