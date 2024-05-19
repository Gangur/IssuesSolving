using BenchmarkDotNet.Attributes;

namespace IssuesSolving.Benchmarks
{
    [MemoryDiagnoser]
    public class BenchmarkSelectVsConvertAll
    {
        private const int _size = 10000000;
        private readonly List<OrigenDto> _list = new List<OrigenDto>(_size);
        private readonly OrigenDto[] _array = new OrigenDto[_size];

        public BenchmarkSelectVsConvertAll() 
        {
            for (int i = 0; i < _array.Length; i++)
            {
                var entity = new OrigenDto()
                {
                    Id = i,
                };

                _list.Add(entity);

                _array[i] = entity;
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
        public void SelectList()
        {
            var result = _list.Select(MapToDestinationDto).ToList();
        }

        [Benchmark]
        public void ConvertAllList()
        {
            var result = _list.ConvertAll(MapToDestinationDto);
        }

        [Benchmark]
        public void SelectArray()
        {
            var result = _array.Select(MapToDestinationDto).ToArray();
        }

        [Benchmark]
        public void ConvertAllArray()
        {
            var result = System.Array.ConvertAll(_array, new Converter<OrigenDto, DestinationDto>(MapToDestinationDto));
        }

        private DestinationDto MapToDestinationDto(OrigenDto origenDto)
            => new DestinationDto()
            {
                Id = origenDto.Id,
                IdStr = origenDto.Id.ToString()
            };
    }
}
