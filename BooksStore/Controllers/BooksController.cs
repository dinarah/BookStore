using BooksStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BooksStore.Controllers
{
    public class BooksController : Controller
    {
        ApplicationDbContext dbContext;

        public BooksController()
        {
            dbContext = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            List<Book> books = dbContext.Books.ToList();
            return View(books);
        }

        public ActionResult SearchByName(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
            {
                return RedirectToAction("Index");
            }

            List<Book> books = dbContext.Books.Where(b => b.Name.Contains(searchString)).ToList();
            return View("Index", books);
        }

        public ActionResult SearchByYearInterval(int beginYear, int endYear)
        {
            if (beginYear == 0 || endYear == 0 || endYear < beginYear)
            {
                return RedirectToAction("Index");
            }

            List<Book> books = dbContext.Books
                .Where(b => b.Year >= beginYear && b.Year <= endYear)
                .ToList();

            return View("Index", books);
        }

        public ActionResult SearchByPrice(float priceFrom, float priceTo)
        {
            if (priceFrom == 0 || priceTo == 0 || priceTo < priceFrom)
            {
                return RedirectToAction("Index");
            }

            List<Book> books = dbContext.Books
                .Where(b => b.Price >= priceFrom && b.Price <= priceTo)
                .ToList();

            return View("Index", books);
        }

        public ActionResult SearchLessThan(float priceLessThan)
        {
            if (priceLessThan < 0)
            {
                return RedirectToAction("Index");
            }

            List<Book> books = dbContext.Books
                .Where(b => b.Price <= priceLessThan).ToList();

            return View("Index", books);   
        }

        public ActionResult SearchStartingFrom(float priceStartingFrom)
        {
            if (priceStartingFrom < 0)
            {
                return RedirectToAction("Index");
            }

            List<Book> books = dbContext.Books
                .Where(b => b.Price >= priceStartingFrom)
                .OrderByDescending(b => b.Price)
                .ToList();

            return View("Index", books);
        }

        public ActionResult New()
        {
            return View("BookForm");
        }

        public ActionResult Edit(int id)
        {
            Book bookFromDb = dbContext.Books.Single(b => b.Id == id);

            return View("BookForm", bookFromDb);
        }

        [HttpPost]
        public ActionResult Save(Book bookFromForm)
        {
            if (!ModelState.IsValid)
            {
                return View("BookForm", bookFromForm);
            }

            if (bookFromForm.Id == 0)
            {
                dbContext.Books.Add(bookFromForm);
            }
            else
            {
                Book bookFromDb = dbContext.Books.Single(b => b.Id == bookFromForm.Id);
                if (bookFromDb == null)
                {
                    return new HttpNotFoundResult();
                }
                else
                {
                    bookFromDb.CoverUrl = bookFromForm.CoverUrl;
                    bookFromDb.Name = bookFromForm.Name;
                    bookFromDb.Author = bookFromForm.Author;
                    bookFromDb.Year = bookFromForm.Year;
                    bookFromDb.Month = bookFromForm.Month;
                    bookFromDb.Price = bookFromForm.Price;
                }
            }

            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Book bookFromDb = dbContext.Books.Single(b => b.Id == id);
            if (bookFromDb == null)
            {
                return new HttpNotFoundResult();
            }
            else
            {
                dbContext.Books.Remove(bookFromDb);
                dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}