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
    public partial class algorithm_Shora : Form
    {
        public algorithm_Shora()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numberToFactor;                                                                   // Число для факторизации
            numberToFactor = Convert.ToInt32(textBox1.Text);
            int registerLength;                                                                   // Число - количество кубитов
            registerLength = Convert.ToInt32(textBox2.Text);
            Shor shor = new Shor(new Random());
            // string a = string.Join(", ", shor.Run(numberToFactor));
            label1.Text = string.Join(", ", shor.Run(numberToFactor,registerLength));             // Вывод результата
        }

        private void back_Click(object sender, EventArgs e)                                       // Кнопка вернуться в главное меню
        {
            main main_form = new main();
            main_form.Show();
            Hide();
        }

        private void exit_Click(object sender, EventArgs e)                                       // Кнопка выхода 
        {
            Close();
        }

        private void button_clear_Click(object sender, EventArgs e)                               // Кнопка для очистки
        {
            textBox1.Text = "";
            textBox2.Text = "";
            label1.Text = "";
        }
    }

    class Shor                                                                                    // Алгоритм Шора
    {
        protected Random Random;

        public Shor(Random random)
        {
            this.Random = random;
        }

        public int[] Run(int n, int registerLength)
        {
            int a = this.Random.Next(n);                                                         // 1.	Выбрать число a случайным образом                                                                            
            int greatestCommonDivisor = GreatestCommonDivisor(a, n);                             // 2.	Вычислить НОД (а, N), используя алгоритм Евклида
           
            if (greatestCommonDivisor != 1)                                                      // Если НОД (а, N) не равен 1, значит существует нетривиальный делитель числа N. Алгоритм завершается
            {
                //Console.WriteLine("Число " + n + " простое");
                return new int[] { greatestCommonDivisor };
            }
            //
            int period = this.Period(n, a, registerLength);                                      // 3найти число r, которое является периодом а по модулю N

            if (period % 2 == 1)                                                                 // 4.	Если число r нечетно, тогда вернуться на шаг 1
            {
                return this.Run(n, registerLength);
            }
            int power = IntPow(a, period / 2);                                                   // 5.	Если аr/2 = -1 mod N, тогда вернуться на шаг 1.
            if (power % n == n - 1)
            {
                return this.Run(n, registerLength);
            }

            //int[] answer = new int[2];
            //answer[0] = GreatestCommonDivisor(power + 1, n);
            // answer[1] = GreatestCommonDivisor(power - 1, n);
            //6.	Вычислить НОД (аr/2+1, N) и НОД (аr/2-1, N). 
            return new int[] { GreatestCommonDivisor(power + 1, n), GreatestCommonDivisor(power - 1, n) };
        }
        protected static int GreatestCommonDivisor(int a, int b)                                 //	Метод вычисляет НОД (а, N)
        {
            return b == 0 ? a : GreatestCommonDivisor(b, a % b);
        }
        protected static int IntPow(int @base, int exponent)                                      // Метод вычисляет целочисленные степени
        {
            int result = 1;

            while (exponent > 0)
            {
                if ((exponent & 1) == 1)
                {
                    result *= @base;
                }

                exponent >>= 1;
                @base *= @base;
            }

            return result;
        }

        //квантовая часть
        public int Period(int n, int a, int registerLength)
        {
                                                                                                            // 2.	Подготовить два квантовых регистра, которые находятся в начальном состоянии |0⟩|0⟩.  
            QuantumRegister inputRegister = new QuantumRegister(0, registerLength);                         // Первый регистр
            QuantumRegister outputRegister = new QuantumRegister(0, registerLength);                        // Второй регистр
            inputRegister = QuantumGate.HadamardGateOfLength(registerLength) * inputRegister;               // 3.	Применить преобразование Адамара к первому регистру 
            Matrix<Complex> modularExponentiationMatrix = ModularExponentiationMatrix(n, a, registerLength);// 4.	Применить унитарный оператор (оракул) 
            QuantumGate modularExponentiationGate = new QuantumGate(modularExponentiationMatrix);
            QuantumRegister fullRegister = new QuantumRegister(inputRegister, outputRegister);
            fullRegister = modularExponentiationGate * fullRegister;
                                                                                                             // 5.	Применить обратное преобразование Фурье к первому регистру
            QuantumGate quantumFourierMatrixPlusIdentity = new QuantumGate(QuantumGate.QuantumFourierTransform(registerLength), QuantumGate.IdentityGateOfLength(registerLength));
            fullRegister = quantumFourierMatrixPlusIdentity * fullRegister;
            
            fullRegister.Collapse(this.Random);                                                              // 6.	Измеряем первый регистр
            int inputRegisterValue = fullRegister.GetValue(0, registerLength);
            float ratio = (float)inputRegisterValue / (1 << registerLength);                                 //7.	Применить алгоритм цепных дробей 
            int denominator = Denominator(ratio, n);
           
            for (int period = denominator; period < n; period += denominator)                                //8. 9.	Убедится, что  . Если да, значит rʹ=r, алгоритм завершается. В противном случае выполнить предыдущий шаг с кратным rʹ
            {
                //if (ShorsAlgorithm.IntPow(a, period) % n == 1)
                if (ModIntPow(a, period, n) == 1)
                {
                    return period;  
                }
            }

           
            return this.Period(n, a, registerLength);                                                         // 10.	В противном случае вернуться ко второму шагу
        }
        protected static Matrix<Complex> ModularExponentiationMatrix(int n, int a, int registerLength)        // Метод для проектирования Оракула
        {
            int matrixSize = 1 << (registerLength * 2);
            Matrix<Complex> modularExponentiationMatrix = Matrix<Complex>.Build.Sparse(matrixSize, matrixSize);

            int blockSize = 1 << registerLength;
            for (int i = 0; i < blockSize; i++)
            {
                int modularExponentiationResult = ModIntPow(a, i, n);

                for (int j = 0; j < blockSize; j++)
                {
                    modularExponentiationMatrix.At(i * blockSize + modularExponentiationResult, i * blockSize + j, 1);
                    Application.DoEvents();
                }
            }

            return modularExponentiationMatrix;
        }
        protected static int ModIntPow(int @base, int exponent, int modulus)                                  // Метод для модульного возвеления в степень
        {
            int result = 1;

            while (exponent > 0)
            {
                if ((exponent & 1) == 1)
                {
                    result = (result * @base) % modulus;
                }

                exponent >>= 1;
                @base = (@base * @base) % modulus;
            }

            return result;
        }
        protected static int Denominator(float realNumber, int maximum)                                       // Метод для Aлгоритма цепных дробей 
        {
            if (realNumber == 0f)
            {
                return 1;
            }

            int coefficient = 0;
            float remainder = realNumber;

            int[] previousNumerators = new int[] { 0, 1 };
            int[] previousDenominators = new int[] { 1, 0 };

            while (remainder != Math.Floor(remainder))
            {
                coefficient = (int)remainder;
                try { remainder = checked(1f / (remainder - coefficient)); }
                catch (System.OverflowException) { return previousDenominators[1]; }

                int numerator = coefficient * previousNumerators[1] + previousNumerators[0];
                int denominator = coefficient * previousDenominators[1] + previousDenominators[0];

                if (denominator >= maximum)
                {
                    return previousDenominators[1];
                }

                previousNumerators[0] = previousNumerators[1];
                previousDenominators[0] = previousDenominators[1];
                previousNumerators[1] = numerator;
                previousDenominators[1] = denominator;
            }

            return previousDenominators[1];
        }

    }
}
