using BenchmarkDotNet.Attributes;
using System.Linq;

namespace IssuesSolving.Benchmarks
{
    [MemoryDiagnoser]
    public class BenchmarkContains
    {
        private const int _sizeCollections = 100;
        private readonly string[][] _arraies = new string[_sizeCollections][];
        private readonly HashSet<string>[] _sets = new HashSet<string>[_sizeCollections];

        public BenchmarkContains()
        {
            for (int i = 0; i < _sizeCollections; i++) 
            {
                int length = i + 1;
                _arraies[i] = new string[length];
                _sets[i] = new HashSet<string>(length);
                for (int j = 0; j < length; j++)
                {
                    _arraies[i][j] = j.ToString();
                    _sets[i].Add(j.ToString());
                }
            }
        }

        private const string zero = "0";
        private const string five = "4";
        private const string ten = "9";
        private const string twenty = "19";
        private const string fifty = "49";
        private const string hundred = "99";


        [Benchmark]
        public bool Arr1() => _arraies[0].Contains(zero);

        [Benchmark]
        public bool Arr5() => _arraies[4].Contains(five);

        [Benchmark]
        public bool Arr10() => _arraies[9].Contains(ten);

        [Benchmark]
        public bool Arr20() => _arraies[19].Contains(twenty);

        [Benchmark]
        public bool Arr50() => _arraies[49].Contains(fifty);

        [Benchmark]
        public bool Arr100() => _arraies[99].Contains(hundred);



        [Benchmark]
        public bool Set1() => _sets[0].Contains(zero);

        [Benchmark]
        public bool Set5() => _sets[4].Contains(five);

        [Benchmark]
        public bool Set10() => _sets[9].Contains(ten);

        [Benchmark]
        public bool Set20() => _sets[19].Contains(twenty);

        [Benchmark]
        public bool Set50() => _sets[49].Contains(fifty);

        [Benchmark]
        public bool Set100() => _sets[99].Contains(hundred);
    }
}
