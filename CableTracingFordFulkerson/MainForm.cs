using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CableTracingFordFulkerson
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Text = "Трассировка кабельных соединений - Алгоритм Форда-Фалкерсона";
            this.Size = new Size(1200, 800);

            // Инициализация начальной матрицы
            InitializeMatrix(4);
        }

        private void ButtonCreateMatrix_Click(object sender, EventArgs e)
        {
            int n = (int)numericUpDownVertices.Value;
            InitializeMatrix(n);
        }

        private void InitializeMatrix(int n)
        {
            dataGridViewCapacity.Columns.Clear();
            dataGridViewCapacity.Rows.Clear();

            // Создаем столбцы
            for (int i = 0; i < n; i++)
            {
                dataGridViewCapacity.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = i.ToString(),
                    Name = "Column" + i,
                    Width = 40
                });
            }

            // Создаем строки
            dataGridViewCapacity.Rows.Add(n);
            for (int i = 0; i < n; i++)
            {
                dataGridViewCapacity.Rows[i].HeaderCell.Value = i.ToString();
            }

            // Устанавливаем начальные значения для примера
            if (n >= 4)
            {
                SetExampleValues();
            }
        }

        private void SetExampleValues()
        {
            // Пример
            dataGridViewCapacity.Rows[0].Cells[1].Value = "3";
            dataGridViewCapacity.Rows[0].Cells[2].Value = "2";
            dataGridViewCapacity.Rows[1].Cells[2].Value = "1";
            dataGridViewCapacity.Rows[1].Cells[3].Value = "2";
            dataGridViewCapacity.Rows[2].Cells[3].Value = "3";
        }

        private void ButtonCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                listBoxLog.Items.Clear();
                listBoxPaths.Items.Clear();
                textBoxMaxFlow.Text = "";

                // 1. Получение входных данных
                var input = GetInputData();
                LogMessage("=== ВВОД ДАННЫХ ===");
                LogMessage($"Количество вершин: {input.VertexCount}");
                LogMessage($"Источник: {input.Source}");
                LogMessage($"Сток: {input.Sink}");

                // 2. Вычисление максимального потока
                LogMessage("\n=== ВЫЧИСЛЕНИЕ МАКСИМАЛЬНОГО ПОТОКА ===");
                var result = FordFulkerson(input.CapacityMatrix, input.Source, input.Sink);

                // 3. Декомпозиция потока на пути
                LogMessage("\n=== ДЕКОМПОЗИЦИЯ ПОТОКА НА ПУТИ ===");
                var paths = DecomposeFlow(result.FlowMatrix, input.Source, input.Sink);

                // 4. Вывод результатов
                PrintResults(input, result, paths);

                // 5. Обновление интерфейса
                UpdateFlowMatrix(result.FlowMatrix, input.VertexCount);
                UpdatePathsList(paths);
                textBoxMaxFlow.Text = result.MaxFlow.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private InputData GetInputData()
        {
            int n = dataGridViewCapacity.RowCount;
            int[,] capacity = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    var cell = dataGridViewCapacity.Rows[i].Cells[j];
                    if (cell.Value != null && int.TryParse(cell.Value.ToString(), out int value))
                    {
                        capacity[i, j] = value;
                    }
                }
            }

            int source = (int)numericUpDownSource.Value;
            int sink = (int)numericUpDownSink.Value;

            if (source == sink)
                throw new ArgumentException("Источник и сток не могут совпадать!");
            if (source < 0 || source >= n || sink < 0 || sink >= n)
                throw new ArgumentException("Некорректные номера вершин!");

            return new InputData
            {
                CapacityMatrix = capacity,
                Source = source,
                Sink = sink,
                VertexCount = n
            };
        }

        private void LogMessage(string message)
        {
            listBoxLog.Items.Add(message);
            listBoxLog.SelectedIndex = listBoxLog.Items.Count - 1;
            listBoxLog.SelectedIndex = -1;
        }

        private FordFulkersonResult FordFulkerson(int[,] capacity, int source, int sink)
        {
            int n = capacity.GetLength(0);
            int[,] flow = new int[n, n];
            int[,] residual = new int[n, n];

            // Копирование исходных пропускных способностей
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    residual[i, j] = capacity[i, j];

            int maxFlow = 0;

            // Основной цикл алгоритма
            while (true)
            {
                var path = FindAugmentingPath(residual, source, sink);
                if (path == null || path.Count <= 1)
                    break;

                // Нахождение минимальной остаточной пропускной способности
                int pathFlow = int.MaxValue;
                for (int i = 0; i < path.Count - 1; i++)
                {
                    int u = path[i];
                    int v = path[i + 1];
                    pathFlow = Math.Min(pathFlow, residual[u, v]);
                }

                // Увеличение потока вдоль пути
                for (int i = 0; i < path.Count - 1; i++)
                {
                    int u = path[i];
                    int v = path[i + 1];
                    flow[u, v] += pathFlow;
                    residual[u, v] -= pathFlow;
                    residual[v, u] += pathFlow;
                }

                maxFlow += pathFlow;

                LogMessage($"\nНайден увеличивающий путь: {string.Join(" → ", path)}");
                LogMessage($"Добавлен поток: {pathFlow}");
                LogMessage($"Текущий максимальный поток: {maxFlow}");
            }

            return new FordFulkersonResult
            {
                MaxFlow = maxFlow,
                FlowMatrix = flow,
                ResidualMatrix = residual
            };
        }

        private List<int> FindAugmentingPath(int[,] residual, int source, int sink)
        {
            int n = residual.GetLength(0);
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(source);

            bool[] visited = new bool[n];
            visited[source] = true;

            int[] parent = new int[n];
            for (int i = 0; i < n; i++) parent[i] = -1;

            // BFS
            while (queue.Count > 0)
            {
                int u = queue.Dequeue();

                for (int v = 0; v < n; v++)
                {
                    if (!visited[v] && residual[u, v] > 0)
                    {
                        queue.Enqueue(v);
                        visited[v] = true;
                        parent[v] = u;

                        if (v == sink)
                        {
                            // Восстановление пути
                            List<int> path = new List<int>();
                            for (int node = sink; node != -1; node = parent[node])
                                path.Add(node);
                            path.Reverse();
                            return path;
                        }
                    }
                }
            }

            return null;
        }

        private List<List<int>> DecomposeFlow(int[,] flow, int source, int sink)
        {
            int n = flow.GetLength(0);
            List<List<int>> paths = new List<List<int>>();

            // Создаем копию матрицы потока для работы
            int[,] workingFlow = (int[,])flow.Clone();

            // Поиск путей, пока есть поток от источника к стоку
            while (true)
            {
                var path = FindPathWithFlow(workingFlow, source, sink);
                if (path == null || path.Count <= 1)
                    break;

                // Уменьшаем поток вдоль найденного пути на 1
                for (int i = 0; i < path.Count - 1; i++)
                {
                    int u = path[i];
                    int v = path[i + 1];
                    workingFlow[u, v]--;
                }

                // Сохраняем путь
                paths.Add(path);
                //LogMessage($"Найден путь для кабеля: {string.Join(" → ", path)}");
            }

            return paths;
        }

        private List<int> FindPathWithFlow(int[,] flow, int source, int sink)
        {
            int n = flow.GetLength(0);
            bool[] visited = new bool[n];
            int[] parent = new int[n];
            for (int i = 0; i < n; i++) parent[i] = -1;

            // Рекурсивный DFS
            bool DFS(int u)
            {
                visited[u] = true;

                if (u == sink)
                    return true;

                for (int v = 0; v < n; v++)
                {
                    if (!visited[v] && flow[u, v] > 0)
                    {
                        parent[v] = u;
                        if (DFS(v))
                            return true;
                    }
                }

                return false;
            }

            // Запуск DFS
            if (DFS(source))
            {
                // Восстановление пути
                List<int> path = new List<int>();
                for (int node = sink; node != -1; node = parent[node])
                    path.Add(node);
                path.Reverse();
                return path;
            }

            return null;
        }

        private void PrintResults(InputData input, FordFulkersonResult result, List<List<int>> paths)
        {
            int n = input.VertexCount;

            LogMessage("\n=== РЕЗУЛЬТАТЫ ===");
            LogMessage($"\n1. МАКСИМАЛЬНЫЙ ПОТОК: {result.MaxFlow} кабелей");

            // Проверка ограничений
            LogMessage("\n2. ПРОВЕРКА ОГРАНИЧЕНИЙ:");
            bool allConstraintsOk = true;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (result.FlowMatrix[i, j] > input.CapacityMatrix[i, j])
                    {
                        LogMessage($"  Нарушение: поток {result.FlowMatrix[i, j]} > пропускной способности {input.CapacityMatrix[i, j]} на ребре {i}→{j}");
                        allConstraintsOk = false;
                    }
                }
            }
            if (allConstraintsOk)
                LogMessage("  Все ограничения соблюдены!");

            // Загрузка каналов
            LogMessage("\n3. ЗАГРУЗКА КАНАЛОВ:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (input.CapacityMatrix[i, j] > 0)
                    {
                        double utilization = (double)result.FlowMatrix[i, j] / input.CapacityMatrix[i, j] * 100;
                        LogMessage($"  Канал {i}→{j}: {result.FlowMatrix[i, j]}/{input.CapacityMatrix[i, j]} кабелей ({utilization:F1}%)");
                    }
                }
            }

            // 4. Группировка и вывод путей
            LogMessage("\n4. ПЛАН ТРАССИРОВКИ (сгруппированные пути):");
            var groupedPaths = GroupPaths(paths);

            int cableCount = 1;
            foreach (var group in groupedPaths)
            {
                LogMessage($"  По пути {group.Key} - {group.Value} кабелей");
                cableCount += group.Value;
            }
        }

        private void UpdatePathsList(List<List<int>> paths)
        {
            listBoxPaths.Items.Clear();

            // Группируем пути
            var groupedPaths = GroupPaths(paths);

            if (groupedPaths.Count == 0)
            {
                listBoxPaths.Items.Add("Пути не найдены");
                return;
            }

            listBoxPaths.Items.Add("=== ПЛАН ТРАССИРОВКИ (сгруппированные пути) ===");
            listBoxPaths.Items.Add("");

            int cableNumber = 1;
            foreach (var group in groupedPaths)
            {
                listBoxPaths.Items.Add($"Путь: {group.Key}");
                listBoxPaths.Items.Add($"Количество кабелей: {group.Value}");
                listBoxPaths.Items.Add("---");

                // Для визуального разделения групп
                listBoxPaths.Items.Add("");
            }

            // Общая статистика
            int totalCables = paths.Count;
            int uniquePaths = groupedPaths.Count;
            listBoxPaths.Items.Add($"=== ИТОГО ===");
            listBoxPaths.Items.Add($"Всего кабелей: {totalCables}");
            listBoxPaths.Items.Add($"Уникальных маршрутов: {uniquePaths}");
        }

        // Новый метод для группировки путей
        private Dictionary<string, int> GroupPaths(List<List<int>> paths)
        {
            var groupedPaths = new Dictionary<string, int>();

            foreach (var path in paths)
            {
                string pathString = string.Join(" → ", path);

                if (groupedPaths.ContainsKey(pathString))
                {
                    groupedPaths[pathString]++;
                }
                else
                {
                    groupedPaths[pathString] = 1;
                }
            }

            return groupedPaths;
        }
        private void UpdateFlowMatrix(int[,] flowMatrix, int n)
        {
            dataGridViewFlow.Columns.Clear();
            dataGridViewFlow.Rows.Clear();

            // Создаем столбцы
            for (int i = 0; i < n; i++)
            {
                dataGridViewFlow.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = i.ToString(),
                    Name = "FlowColumn" + i,
                    Width = 40
                });
            }

            // Создаем строки и заполняем значениями
            dataGridViewFlow.Rows.Add(n);
            for (int i = 0; i < n; i++)
            {
                dataGridViewFlow.Rows[i].HeaderCell.Value = i.ToString();
                for (int j = 0; j < n; j++)
                {
                    dataGridViewFlow.Rows[i].Cells[j].Value = flowMatrix[i, j];
                }
            }
        }

        // Структуры данных
        public struct InputData
        {
            public int[,] CapacityMatrix;
            public int Source;
            public int Sink;
            public int VertexCount;
        }

        public struct FordFulkersonResult
        {
            public int MaxFlow;
            public int[,] FlowMatrix;
            public int[,] ResidualMatrix;
        }
    }
}