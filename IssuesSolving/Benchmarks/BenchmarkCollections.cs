using BenchmarkDotNet.Attributes;

namespace IssuesSolving.Benchmarks
{
    [MemoryDiagnoser]
    public class BenchmarkCollections
    {
        private int _size = 10000;

        [Benchmark]
        public void ForeachListWithCapacity()
        {
            var DataList = new List<int>(_size);
            for (int j = 0; j < _size; j++)
            {
                DataList.Add(j);
            }

            foreach (var item in DataList)
            {
                var temp = item;
            }
        }

        [Benchmark]
        public void ForListWithCapacity()
        {
            var DataList = new List<int>(_size);
            for (int j = 0; j < _size; j++)
            {
                DataList.Add(j);
            }

            for (int i = 0; i < DataList.Count; i++)
            {
                var temp = DataList[i];
            }
        }

        [Benchmark]
        public void WhileListWithCapacity()
        {
            var DataList = new List<int>(_size);
            for (int j = 0; j < _size; j++)
            {
                DataList.Add(j);
            }

            var i = 0;
            while (i < DataList.Count)
            {
                var temp = DataList[i];
                i++;
            }
        }

        [Benchmark]
        public void DoWhileListWithCapacity()
        {
            var DataList = new List<int>(_size);
            for (int j = 0; j < _size; j++)
            {
                DataList.Add(j);
            }

            var i = 0;
            do
            {
                var temp = DataList[i];
                i++;
            } while (i < DataList.Count);
        }

        [Benchmark]
        public void ForeachListNoCapacity()
        {
            var DataList = new List<int>();
            for (int j = 0; j < _size; j++)
            {
                DataList.Add(j);
            }

            foreach (var item in DataList)
            {
                var temp = item;
            }
        }

        [Benchmark]
        public void ForListNoCapacity()
        {
            var DataList = new List<int>();
            for (int j = 0; j < _size; j++)
            {
                DataList.Add(j);
            }

            for (int i = 0; i < DataList.Count; i++)
            {
                var temp = DataList[i];
            }
        }

        [Benchmark]
        public void WhileListNoCapacity()
        {
            var DataList = new List<int>();
            for (int j = 0; j < _size; j++)
            {
                DataList.Add(j);
            }

            var i = 0;
            while (i < DataList.Count)
            {
                var temp = DataList[i];
                i++;
            }
        }

        [Benchmark]
        public void DoWhileListNoCapacity()
        {
            var DataList = new List<int>();
            for (int j = 0; j < _size; j++)
            {
                DataList.Add(j);
            }

            var i = 0;
            do
            {
                var temp = DataList[i];
                i++;
            } while (i < DataList.Count);
        }

        [Benchmark]
        public void ForeachLinkedList()
        {
            var DataList = new LinkedList<int>();
            for (int j = 0; j < _size; j++)
            {
                DataList.AddLast(j);
            }

            foreach (var item in DataList)
            {
                var temp = item;
            }
        }

        [Benchmark]
        public void ForeachArr()
        {
            var DataArr = new int[_size];
            for (int j = 0; j < _size; j++)
            {
                DataArr[j] = j;
            }

            foreach (var item in DataArr)
            {
                var temp = item;
            }
        }

        [Benchmark]
        public void ForArr()
        {
            var DataArr = new int[_size];
            for (int j = 0; j < _size; j++)
            {
                DataArr[j] = j;
            }

            for (int i = 0; i < DataArr.Length; i++)
            {
                var temp = DataArr[i];
            }
        }

        [Benchmark]
        public void WhileArr()
        {
            var DataArr = new int[_size];
            for (int j = 0; j < _size; j++)
            {
                DataArr[j] = j;
            }

            var i = 0;
            while (i < DataArr.Length)
            {
                var temp = DataArr[i];
                i++;
            }
        }

        [Benchmark]
        public void DoWhileArr()
        {
            var DataArr = new int[_size];
            for (int j = 0; j < _size; j++)
            {
                DataArr[j] = j;
            }

            var i = 0;
            do
            {
                var temp = DataArr[i];
                i++;
            } while (i < DataArr.Length);
        }


        [Benchmark]
        public void ForeachListRO()
        {
            var DataList = new List<int>(_size);
            for (int j = 0; j < _size; j++)
            {
                DataList.Add(j);
            }

            IReadOnlyList<int> DataROC = DataList.AsReadOnly();
            foreach (var item in DataROC)
            {
                var temp = item;
            }
        }

        [Benchmark]
        public void ForListRO()
        {
            var DataList = new List<int>(_size);
            for (int j = 0; j < _size; j++)
            {
                DataList.Add(j);
            }

            IReadOnlyList<int> DataROC = DataList.AsReadOnly();
            for (int i = 0; i < DataROC.Count; i++)
            {
                var temp = DataROC[i];
            }
        }

        [Benchmark]
        public void WhileListRO()
        {
            var DataList = new List<int>(_size);
            for (int j = 0; j < _size; j++)
            {
                DataList.Add(j);
            }

            IReadOnlyList<int> DataROC = DataList.AsReadOnly();
            var i = 0;
            while (i < DataROC.Count)
            {
                var temp = DataROC[i];
                i++;
            }
        }

        [Benchmark]
        public void DoWhileListRO()
        {
            var DataList = new List<int>(_size);
            for (int j = 0; j < _size; j++)
            {
                DataList.Add(j);
            }

            IReadOnlyList<int> DataROC = DataList.AsReadOnly();
            var i = 0;
            do
            {
                var temp = DataROC[i];
                i++;
            } while (i < DataROC.Count);
        }


        [Benchmark]
        public void ForeachSpan()
        {
            Span<int> span = stackalloc int[_size];
            for (int j = 0; j < _size; j++)
            {
                span[j] = j;
            }

            foreach (var item in span)
            {
                var temp = item;
            }
        }

        [Benchmark]
        public void ForSpan()
        {
            Span<int> span = stackalloc int[_size];
            for (int j = 0; j < _size; j++)
            {
                span[j] = j;
            }

            for (int i = 0; i < span.Length; i++)
            {
                var temp = span[i];
            }
        }

        [Benchmark]
        public void WhileSpan()
        {
            Span<int> span = stackalloc int[_size];
            for (int j = 0; j < _size; j++)
            {
                span[j] = j;
            }

            var i = 0;
            while (i < span.Length)
            {
                var temp = span[i];
                i++;
            }
        }

        [Benchmark]
        public void DoWhileSpan()
        {
            Span<int> span = stackalloc int[_size];
            for (int j = 0; j < _size; j++)
            {
                span[j] = j;
            }

            var i = 0;
            do
            {
                var temp = span[i];
                i++;
            } while (i < span.Length);
        }


        [Benchmark]
        public void ForeachSpanRO()
        {
            Span<int> spanBase = stackalloc int[_size];
            for (int j = 0; j < _size; j++)
            {
                spanBase[j] = j;
            }

            ReadOnlySpan<int> span = spanBase;
            foreach (var item in span)
            {
                var temp = item;
            }
        }

        [Benchmark]
        public void ForSpanRO()
        {
            Span<int> spanBase = stackalloc int[_size];
            for (int j = 0; j < _size; j++)
            {
                spanBase[j] = j;
            }

            ReadOnlySpan<int> span = spanBase;
            for (int i = 0; i < span.Length; i++)
            {
                var temp = span[i];
            }
        }

        [Benchmark]
        public void WhileSpanRO()
        {
            Span<int> spanBase = stackalloc int[_size];
            for (int j = 0; j < _size; j++)
            {
                spanBase[j] = j;
            }

            ReadOnlySpan<int> span = spanBase;
            var i = 0;
            while (i < span.Length)
            {
                var temp = span[i];
                i++;
            }
        }

        [Benchmark]
        public void DoWhileSpanRO()
        {
            Span<int> spanBase = stackalloc int[_size];
            for (int j = 0; j < _size; j++)
            {
                spanBase[j] = j;
            }

            ReadOnlySpan<int> span = spanBase;
            var i = 0;
            do
            {
                var temp = span[i];
                i++;
            } while (i < span.Length);
        }
    }
}
