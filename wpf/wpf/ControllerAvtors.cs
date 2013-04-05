using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace wpf
{
    static class ControllerAvtors
    {
        public static void selectAvtor(System.Windows.Controls.DataGrid dataGrid, List<Int32> f)
        {
            try
            {
                using (libraryEntities libraryContext = new libraryEntities())
                {
                    ObjectQuery<avtor> avtorsView = libraryContext.avtors;
                    var query = from avtorsTemp in avtorsView
                                orderby avtorsTemp.secondName
                                select new { avtorsTemp.secondName, avtorsTemp.firstName, avtorsTemp.patronymic, avtorsTemp.id_avtors };

                    f.Clear();
                    foreach (var t in query)
                    {
                        f.Add(t.id_avtors);
                    }

                    dataGrid.ItemsSource = from a in query
                                           orderby a.secondName
                                           select new { a.secondName, a.firstName, a.patronymic };

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string insertAvtor(string firstName, string secondName, string patronymic)
        {
            try
            {
                if ((firstName == string.Empty) || (secondName == string.Empty) || (patronymic == string.Empty))
                {
                    throw new Exception("Одно из полей пустое.");
                }

                using (libraryEntities libraryContext = new libraryEntities())
                {
                    avtor avtorNew = new avtor();
                    avtorNew.firstName = firstName;
                    avtorNew.secondName = secondName;
                    avtorNew.patronymic = patronymic;

                    libraryContext.avtors.AddObject(avtorNew);
                    libraryContext.SaveChanges();
                }

                return "Добавлено.";
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static string updateAvtor(string firstName, string secondName, string patronymic, Int32 id_avtor)
        {
            try
            {
                if ((firstName == string.Empty) || (secondName == string.Empty) || (patronymic == string.Empty))
                {
                    throw new Exception("Одно из полей пустое.");
                }

                if (id_avtor <= 0)
                {
                    throw new Exception("Изменить не удалось. Не корректный id.");
                }
                using (libraryEntities libraryContext = new libraryEntities())
                {
                    avtor avtorNew = new avtor();
                    avtorNew.firstName = firstName;
                    avtorNew.secondName = secondName;
                    avtorNew.patronymic = patronymic;

                    avtorNew.id_avtors = id_avtor;
                    libraryContext.avtors.AddObject(avtorNew);
                    libraryContext.ObjectStateManager.ChangeObjectState(avtorNew, System.Data.EntityState.Modified);

                    libraryContext.SaveChanges();
                }

                return "Изменено.";
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static string deleteAvtors(string firstName, string secondName, string patronymic, Int32 id)
        {
            try
            {
                if ((firstName == string.Empty) || (secondName == string.Empty) || (patronymic == string.Empty))
                {
                    throw new Exception("Одно из полей пустое.");
                }

                if (id <= 0)
                {
                    throw new Exception("Изменить не удалось.Не корректный id.");
                }

                using (libraryEntities libraryContext = new libraryEntities())
                {
                    avtor avtorDelete = new avtor();
                    avtorDelete.firstName = firstName;
                    avtorDelete.secondName = secondName;
                    avtorDelete.patronymic = patronymic;
                    avtorDelete.id_avtors = id;
                    libraryContext.avtors.Attach(avtorDelete);
                    libraryContext.ObjectStateManager.ChangeObjectState(avtorDelete, System.Data.EntityState.Deleted);
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
