using BenchmarkDotNet.Attributes;
using System.Linq;

namespace IssuesSolving.Benchmarks
{
    [MemoryDiagnoser]
    public class BenchmarkSelectVsConvertAll
    {
        private const int _size = 10000;
        private readonly List<OrigenDto> _list = new List<OrigenDto>(_size);
        private readonly OrigenDto[] _array = new OrigenDto[_size];

        private Converter<OrigenDto, DestinationDto> _convertor;

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

            _convertor = new Converter<OrigenDto, DestinationDto>(MapToDestinationDto);
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

            int amount = result.Count;
        }

        [Benchmark]
        public void ConvertAllList()
        {
            var result = _list.ConvertAll(MapToDestinationDto);

            int amount = result.Count;
        }

        [Benchmark]
        public void SelectArray()
        {
            var result = _array.Select(MapToDestinationDto).ToArray();

            int amount = result.Length;
        }

        [Benchmark]
        public void ConvertAllArray()
        {
            var result = System.Array.ConvertAll(_array, _convertor);

            int amount = result.Length;
        }

        private DestinationDto MapToDestinationDto(OrigenDto origenDto)
            => new DestinationDto()
            {
                Id = origenDto.Id,
                IdStr = origenDto.Id.ToString()
            };
    }
}
