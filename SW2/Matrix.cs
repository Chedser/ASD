using System;
using System.Linq;
using System.Collections;

namespace StudyWork2
{
    class Matrix
    {
        int _rows;                  // Количество строк
        int _cols;                  // Количество столбцов
        int[] _dim = new int[2];    //Размерность
        int[,] _matrix;     // Матрица
        int _zero_elements_count;

        public Matrix(int rows, int cols, int max_value = 4)          //Конструктор
        {
            GenerateMatrix(rows, cols, max_value);

        }

        /* Свойства */
        public int Rows { get { return _rows; } }
        public int Cols { get { return _cols; } }
        public string Dim { get { return "[" + _dim[0] + "," + _dim[1] + "]"; } }
        public int ZeroElementsCount { get { return _zero_elements_count; } }
      
        /* Печать матрицы */
        public void Print()
        {
            foreach (int i in Enumerable.Range(0, _rows))
            {
                foreach (int j in Enumerable.Range(0, _cols))
                {
                    Console.Write(_matrix[i, j] + " ");
                }
                Console.WriteLine("\n");

            }
        }

        /* Установка значения матрицы */
        public void SetValue(int i, int j, int value)
        {
            _matrix[i, j] = value;
        }

        /* Получить значение матрицы */
        public int GetValue(int i, int j)
        {
            return _matrix[i, j];
        }

        /* Сложение матриц */
        public Matrix Add(ref Matrix sm)
        {

            if ((sm.Rows != this.Rows) || (sm.Cols != this.Cols))
            {
                throw new Exception();
            }

            Matrix new_matrix = new Matrix(sm.Rows, sm.Cols);

            int current_element = 0;

            foreach (int i in Enumerable.Range(0, this.Rows))
            {
                foreach (int j in Enumerable.Range(0, this.Cols))
                {
                    current_element = this.GetValue(i, j) + sm.GetValue(i, j);

                    new_matrix.SetValue(i, j, current_element);
                }
            }

            return new_matrix;

        }

        /* Создание разреженной матрицы */
        public ArrayList Sparse() {

            ArrayList A = new ArrayList(); // Массив ненулевых значений
            ArrayList LJ = new ArrayList(); // Массив номеров столбцов ненулевых значений
            ArrayList LI = new ArrayList(); // Массив количества ненулевых значений

            int NNZ = 0; //Количество ненулевых элементов в текущей строке

            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    if (_matrix[i, j] != 0)
                    {
                        A.Add(_matrix[i, j]); // Добавить ненулевой элемент
                        LJ.Add(j); //Добавить номер столбца
                        NNZ++; // Увеличить количество ненулевых элементов
                    }
                }
                LI.Add(NNZ); //Добавить количество ненулевых элементов
            }

            ArrayList total = new ArrayList(); // Результирующая матрица

            total.Add(A);
            total.Add(LJ);
            total.Add(LI);

            return total;

        }

        /* Генерация матрицы */
        private void GenerateMatrix(int rows, int cols, int max_value = 4)
        {
            _rows = rows;
            _cols = cols;
            _dim[0] = _rows;
            _dim[1] = _cols;

            _matrix = new int[rows, cols];

            foreach (int i in Enumerable.Range(0, rows))
            {
                foreach (int j in Enumerable.Range(0, cols))
                {
                    _matrix[i, j] = new Random().Next(0, max_value + 1);
                }
            }

            SetZeroElementsCount();

        }

        private void SetZeroElementsCount() {

            foreach (int i in Enumerable.Range(0, _rows))
            {
                foreach (int j in Enumerable.Range(0, _cols))
                {
                    if (_matrix[i, j] == 0) { ++_zero_elements_count; };
                }
            }

        }

    }
}
