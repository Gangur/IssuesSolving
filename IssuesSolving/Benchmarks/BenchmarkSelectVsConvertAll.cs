using BenchmarkDotNet.Attributes;

namespace IssuesSolving.Benchmarks
{
    [MemoryDiagnoser]
    public class BenchmarkSelectVsConvertAll
    {
        private readonly List<OrigenDto> _list = new List<OrigenDto>(10000);
        public BenchmarkSelectVsConvertAll() 
        {
            for (int i = 0; i < _list.Count; i++)
            {
                _list[i] = new OrigenDto()
                {
                    Id = i,
                };
            }
        }

        private class OrigenDto
        {
            public int Id { get; set; }
        }

        private class DestinationDto
        {
            public long Id { get; set; }
            public string IdStr { get; set; }
        }

        [Benchmark]
        public void Select()
        {
            var result = _list.Select(o => new DestinationDto()
            {
                Id = o.Id,
                IdStr = o.Id.ToString()
            }).ToList();
        }

        [Benchmark]
        public void ConvertAll()
        {
            var result = _list.ConvertAll(o => new DestinationDto()
            {
                Id = o.Id,
                IdStr = o.Id.ToString()
            });
        }
    }
}
