using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace wpf
{
    class ControllerBooks
    {
        public static void selectBooks(System.Windows.Controls.DataGrid dataGrid, List<Int32> f, List<Int32> p,List<Int32> current_avtor,List<string> book_value)
        {
            try
            {
            using (libraryEntities libraryContext = new libraryEntities())
            {
                ObjectQuery<book> bookView = libraryContext.books;
                var query = (from a in libraryContext.avtors
                             join b in libraryContext.books on a.id_avtors equals b.id_avtor
                             orderby b.name
                             select new { b.name, b.year, a.secondName, a.firstName, a.patronymic, b.id_books,a.id_avtors});

                p.Clear();
                f.Clear();
                
                foreach (var t in query)
                {
                    p.Add(t.id_avtors);
                    f.Add(t.id_books);
                }
                
                dataGrid.ItemsSource = from a in query
                                       orderby a.name
                                       select new { a.name, a.year, a.secondName, a.firstName, a.patronymic };

                ObjectQuery<avtor> avtorsView = libraryContext.avtors;
                var query1 = from avtorsTemp in avtorsView
                            orderby avtorsTemp.secondName
                            select new { avtorsTemp.secondName, avtorsTemp.firstName, avtorsTemp.patronymic, avtorsTemp.id_avtors };

                current_avtor.Clear();
                book_value.Clear();
                foreach (var t in query1)
                {
                    current_avtor.Add(t.id_avtors);
                    book_value.Add(t.secondName+" "+t.firstName+" "+t.patronymic);
                }

            }
            }
                catch (Exception ex)
            {
                    throw ex;
                }
            

        }

        public static string insertBooks(string year, string name, Int32 id_avtor)
        {
            try
            {
                if ((year == string.Empty) || (name == string.Empty))
                {
                    throw new Exception("Одно из полей пустое.");
                }

                if (id_avtor <= 0)
                {
                    throw new Exception("Изменить не удалось. Не корректный id.");
                }

                using (libraryEntities libraryContext = new libraryEntities())
                {
                    book bookNew = new book();
                    bookNew.year = Convert.ToInt32(year);
                    bookNew.name = name;
                    bookNew.id_avtor = id_avtor;

                    libraryContext.books.AddObject(bookNew);
                    libraryContext.SaveChanges();
                }

                return "Добавлено.";
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static string updateBooks(string year, string name, Int32 id_avtor, Int32 id_book)
        {
            try
            {
                if ((year == string.Empty) || (name == string.Empty))
                {
                    throw new Exception("Одно из полей пустое.");
                }

                if ((id_book <= 0) || (id_avtor <= 0))
                {
                    throw new Exception("Изменить не удалось. Не корректный id.");
                }
                using (libraryEntities libraryContext = new libraryEntities())
                {
                    book bookNew = new book();
                    bookNew.year = Convert.ToInt32(year);
                    bookNew.id_books = id_book;
                    bookNew.name = name;
                    bookNew.id_avtor = id_avtor;

                    libraryContext.books.AddObject(bookNew);
                    libraryContext.ObjectStateManager.ChangeObjectState(bookNew, System.Data.EntityState.Modified);

                    libraryContext.SaveChanges();
                }

                return "Изменено.";
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static string deleteBooks(string year, string name, Int32 id_avtor, Int32 id_book)
        {
            try
            {
                if ((year == string.Empty) || (name == string.Empty))
                {
                    throw new Exception("Одно из полей пустое.");
                }

                if ((id_book <= 0) || (id_avtor <= 0))
                {
                    throw new Exception("Изменить не удалось. Не корректный id.");
                }

                using (libraryEntities libraryContext = new libraryEntities())
                {
                    book bookDelete = new book();
                    bookDelete.year = Convert.ToInt32(year);
                    bookDelete.id_books = id_book;
                    bookDelete.name = name;
                    bookDelete.id_avtor = id_avtor;
                    libraryContext.books.Attach(bookDelete);
                    libraryContext.ObjectStateManager.ChangeObjectState(bookDelete, System.Data.EntityState.Deleted);
                    libraryContext.SaveChanges();
                }
                return "Удалено.";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
