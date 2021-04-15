using System;
using MMapper.Application;

namespace MMapper.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookEntity = new BookEntity
            {
                Title = "Soul Music",
                Author = "Terry Pratchett",
                Created = new DateTime(21, 02, 01)
            };
            var test = Mapper.Map<BookModel>(bookEntity);
        }
    }
}
