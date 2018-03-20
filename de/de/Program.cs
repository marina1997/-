using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics;
using Lachesis.QuantumComputing;


namespace de
{
    class Program
    {
        static void Main(string[] args)
        {
            Deutsch deutsch = new Deutsch(new Random());
            deutsch.Run();

        }
    }
}

class Deutsch
{
    protected Random Random;

    public Deutsch(Random random)
    {
        this.Random = random;
    }

    public void Run()
    {
        int registerLength = 1; //кол-во кубитов. квантовый регистр это совокупность некоторого числа кубитов 

        //Подготовка начально состояния
        QuantumRegister inputRegister = new QuantumRegister(0, registerLength); // Входной регистр
        QuantumRegister outputRegister = new QuantumRegister(1, registerLength);  // Выходной регистр 
        QuantumRegister fullRegister = new QuantumRegister(inputRegister, outputRegister); // Полный регистр (получается тензорным произведением)
        //Console.WriteLine(inputRegister);
        //Console.WriteLine(outputRegister);
        //Console.WriteLine(fullRegister);

        fullRegister = QuantumGate.HadamardGateOfLength(2) * fullRegister; // преобразование адамара
        Matrix<Complex> matrixOracle = MatrixOracle(registerLength); //Проектирование оракула
        QuantumGate GateOracle = new QuantumGate(matrixOracle);//Получаем гейт (на основе matrixOracle)
        fullRegister = GateOracle * fullRegister;
        fullRegister = QuantumGate.HadamardGateOfLength(2) * fullRegister; // преобразование адамара
        //Console.WriteLine(fullRegister);

        fullRegister.Collapse(this.Random);//измерение (наблюление) первого регистра
        int inputRegesterValue = fullRegister.GetValue(0, registerLength);
        FunctionDefinition(inputRegesterValue);

        Console.ReadKey();
    }

    protected static Matrix<Complex> MatrixOracle(int registerLength)
    {
        int matrixSize = 1 << (registerLength * 2);//получаем размер оракула(матрицы); в данном случае регистр равен 1. следовательно 1 << 2=4; Мы передали методу четверку
        Matrix<Complex> matrixOracle = Matrix<Complex>.Build.Sparse(matrixSize, matrixSize); // создание разреженной матрицы. Разрежённая матрица — это матрица с преимущественно нулевыми элементами.  

        //заполнение матрицы. f(x)=1 функция для которой я реализую оракул
        // 0 1 0 0
        // 1 0 0 0
        // 0 0 0 1
        // 0 0 1 0
        matrixOracle.At(1, 0, 1);
        matrixOracle.At(0, 1, 1);
        matrixOracle.At(3, 2, 1);
        matrixOracle.At(2, 3, 1);


        return matrixOracle;
    }

    public void FunctionDefinition(int i)
    {
        if (i == 0) Console.WriteLine("Функция f константа");
        else Console.WriteLine("Функция f сбалансирована");
    }
}
