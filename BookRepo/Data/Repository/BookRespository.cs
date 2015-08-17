using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BookRepo.Data.Dtos;
using BookRepo.Data.Models;

namespace BookRepo.Data.Repository
{
    public class BookRespository : IBookRespository
    {
        public List<Book> GetBooks()
        {
            using (var context = new BookDb())
            {
               return (from book in context.Books select book).ToList();
            }
        }

        public Book GetLongestBook()
        {
            using (var context = new BookDb())
            {
                return context.Books.OrderByDescending(b => b.Minutes).First();
            }
        }

        public Book GetMostRecentBook()
        {
            using (var context = new BookDb())
            {
                return context.Books.OrderByDescending(b => b.DateCompleted).First();
            }
        }

        public DashboardDto GetDashboardDto()
        {
            using (var context = new BookDb())
                {
                    return new DashboardDto
                    {
                        TotalMinutes = context.Books.Sum(b => b.Minutes),
                        TotalNumberOfBooks = context.Books.Count(),
                        TotalPages = context.Books.Sum(b => b.Pages)
                    };
                }
        }

        public Book GetFastestBook()
        {
            using (var context = new BookDb())
            {
                return context.Books.OrderByDescending(b => b.Minutes / (DbFunctions.DiffDays(b.DateCompleted, b.DateStarted == b.DateCompleted ? DbFunctions.AddDays(b.DateStarted, 1) : b.DateStarted))).First();
            }
        }

        public List<Book> GetLastReadBooks()
        {
            using (var context = new BookDb())
            {
                return context.Books.OrderByDescending(b => b.DateCompleted).Take(5).ToList();
            }
        }
    }
}