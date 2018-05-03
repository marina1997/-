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
    public partial class algorithm_Shora : Form
    {
        public algorithm_Shora()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numberToFactor;//число для факторизации
            numberToFactor = Convert.ToInt32(textBox1.Text);
            Shor shor = new Shor(new Random());
           // string a = string.Join(", ", shor.Run(numberToFactor));
            label1.Text = string.Join(", ", shor.Run(numberToFactor)); 
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            main main_form = new main();
            main_form.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

    class Shor
    {
        protected Random Random;

        public Shor(Random random)
        {
            this.Random = random;
        }

        public int[] Run(int n)
        {
            int a = this.Random.Next(n); //1.	Выбрать число a случайным образом

            //2.	Вычислить НОД (а, N), используя алгоритм Евклида. 
            int greatestCommonDivisor = GreatestCommonDivisor(a, n);
            // Если НОД (а, N) не равен 1, значит существует нетривиальный делитель числа N. Алгоритм завершается.

            if (greatestCommonDivisor != 1)
            {
                //Console.WriteLine("Число " + n + " простое");
                return new int[] { greatestCommonDivisor };
            }

            //3найти число r, которое является периодом а по модулю N
            int period = this.Period(n, a);

            //4.	Если число r нечетно, тогда вернуться на шаг 1
            if (period % 2 == 1)
            {
                return this.Run(n);
            }

            //5.	Если аr/2 = -1 mod N, тогда вернуться на шаг 1.
            int power = IntPow(a, period / 2);
            if (power % n == n - 1)
            {
                return this.Run(n);
            }

            //int[] answer = new int[2];
            //answer[0] = GreatestCommonDivisor(power + 1, n);
           // answer[1] = GreatestCommonDivisor(power - 1, n);
                   //6.	Вычислить НОД (аr/2+1, N) и НОД (аr/2-1, N). 
            return new int[] {GreatestCommonDivisor(power+1, n), GreatestCommonDivisor(power-1, n)};
        }

        //	Вычислить НОД (а, N)
        protected static int GreatestCommonDivisor(int a, int b)
        {
            return b == 0 ? a : GreatestCommonDivisor(b, a % b);
        }

        // Вычисление целочисленных степеней
        protected static int IntPow(int @base, int exponent)
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
        public int Period(int n,int  a)
        {
            //1.	Выбрать число m такое, чтобы m=2l
            int registerLength = RegisterLength(n * n - 1);

            //2.	Подготовить два квантовых регистра, которые находятся в начальном состоянии |0⟩|0⟩.  
            QuantumRegister inputRegister = new QuantumRegister(0, registerLength); // первый регистр
            QuantumRegister outputRegister = new QuantumRegister(0, registerLength); // второй регистр

            //3.	Применить преобразование Адамара к первому регистру. 
            inputRegister = QuantumGate.HadamardGateOfLength(registerLength) * inputRegister;
            //4.	Применить унитарный оператор (оракул) 
            Matrix<Complex> modularExponentiationMatrix = ModularExponentiationMatrix(n, a, registerLength);

            QuantumGate modularExponentiationGate = new QuantumGate(modularExponentiationMatrix);
            QuantumRegister fullRegister = new QuantumRegister(inputRegister, outputRegister);
            fullRegister = modularExponentiationGate * fullRegister;

            //5.	Применить обратное преобразование Фурье к первому регистру

            QuantumGate quantumFourierMatrixPlusIdentity = new QuantumGate(QuantumGate.QuantumFourierTransform(registerLength), QuantumGate.IdentityGateOfLength(registerLength));
            fullRegister = quantumFourierMatrixPlusIdentity * fullRegister;

            //6.	Измеряем первый регистр. 
            fullRegister.Collapse(this.Random);
            int inputRegisterValue = fullRegister.GetValue(0, registerLength);

            //7.	Применить алгоритм цепных дробей 
            float ratio = (float)inputRegisterValue / (1 << registerLength);
            int denominator = Denominator(ratio, n);

            //8. 9.	Убедится, что  . Если да, значит rʹ=r, алгоритм завершается. В противном случае выполнить предыдущий шаг с кратным rʹ.
            for (int period = denominator; period < n; period += denominator)
            {
                //if (ShorsAlgorithm.IntPow(a, period) % n == 1)
                if (ModIntPow(a, period, n) == 1)
                {
                    return period;  ////////
                }
            }

            // 10.	В противном случае вернуться ко второму шагу.
            return this.Period(n, a);
        }


        
        protected static int RegisterLength(int value)   //метод находит m (registerLegth)
        {
            int length = 1;

            for (int bitCount = 16; bitCount > 0; bitCount /= 2)
            {
                if (value >= 1 << bitCount)
                {
                    value >>= bitCount;
                    length += bitCount;
                }
            }

            return length;
        }


        //проектирование оракула
        protected static Matrix<Complex> ModularExponentiationMatrix(int n, int a, int registerLength)
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

        //модульное возвеление в степень
        protected static int ModIntPow(int @base, int exponent, int modulus)
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

        //Aлгоритм цепных дробей 
        protected static int Denominator(float realNumber, int maximum)
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
