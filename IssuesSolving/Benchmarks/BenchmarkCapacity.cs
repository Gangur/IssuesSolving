using BenchmarkDotNet.Attributes;
using System.Text;

namespace IssuesSolving.Benchmarks
{
    [MemoryDiagnoser]
    public class BenchmarkCapacity
    {
        private int _size = 1000000;

        [Benchmark]
        public void ListNoCapacity()
        {
            var data = new List<int>();
            for (int j = 0; j < _size; j++)
            {
                data.Add(j);
            }
        }

        [Benchmark]
        public void HashSetNoCapacity()
        {
            var data = new HashSet<int>();
            for (int j = 0; j < _size; j++)
            {
                data.Add(j);
            }
        }

        [Benchmark]
        public void StringBuilderNoCapacity()
        {
            var data = new StringBuilder();
            for (int j = 0; j < _size; j++)
            {
                data.Append(j.ToString());
            }
        }

        [Benchmark]
        public void ListWithCapacity()
        {
            var data = new List<int>(_size);
            for (int j = 0; j < _size; j++)
            {
                data.Add(j);
            }
        }

        [Benchmark]
        public void HashSetWithCapacity()
        {
            var data = new HashSet<int>(_size);
            for (int j = 0; j < _size; j++)
            {
                data.Add(j);
            }
        }


        [Benchmark]
        public void StringBuilderWithCapacity()
        {
            var data = new StringBuilder(_size);
            for (int j = 0; j < _size; j++)
            {
                data.Append(j.ToString());
            }
        }
    }
}
