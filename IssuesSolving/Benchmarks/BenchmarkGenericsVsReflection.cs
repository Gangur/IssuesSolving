using BenchmarkDotNet.Attributes;

namespace IssuesSolving.Benchmarks
{
    public interface InterfaceTest
    {
        public int Int { get; set; }

        public string String { get; set; }

        public DateTime DateTime { get; set; }
    }

    public interface IntefaceEmpty1
    {

    }

    public interface IntefaceEmpty2
    {

    }

    public abstract class Class
    {
        public int Int { get; set; }
    }

    public class Class2 : Class { }

    public class Class3 : Class, IntefaceEmpty1, InterfaceTest, IntefaceEmpty2
    {
        public string String { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
    }

    [MemoryDiagnoser]
    public class BenchmarkGenericsVsReflection
    {
        private const int _size = 1000000;
        private readonly Class[] _testSet = new Class[_size];
        public BenchmarkGenericsVsReflection()
        {
            for (int i = 0; i < _size; i++)
            {
                if (i % 2 == 0)
                {
                    _testSet[i] = new Class2()
                    {
                        Int = i
                    };
                }
                else
                {
                    _testSet[i] = new Class3()
                    {
                        Int = i,
                        String = i.ToString()
                    };
                }
            }
        }

        [Benchmark]
        public void Reflection()
        {
            for (int i = 0; i < _size; i++)
            {
                if (_testSet[i].GetType().GetInterfaces().Contains(typeof(InterfaceTest)))
                {
                    var test = (InterfaceTest)_testSet[i];
                    test.DateTime = DateTime.Now;
                }
            }
        }

        [Benchmark]
        public void Generics()
        {
            for (int i = 0; i < _size; i++)
            {
                var test = _testSet[i] as InterfaceTest;
                if (test != null)
                {
                    test.DateTime = DateTime.Now;
                }
            }
        }
    }
}
