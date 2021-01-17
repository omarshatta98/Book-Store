using Demo.Data.Repositories;
using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Service
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _bookRepository;

        public BookService()
        {
            _bookRepository = new Repository<Book>();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookRepository.GetAll().ToList();
        }

        public Book GetBookById(int id)
        {
            return _bookRepository.Get(id);
        }
        public void CreateBook(Book book)
        {
            _bookRepository.Add(book);
        }

        public void UpdateBook(Book book)
        {
            _bookRepository.Update(book);
        }

        public void DeleteBook(Book book)
        {
            _bookRepository.Delete(book);
        }
    }
}