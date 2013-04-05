using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace wpf
{
    class ControllerMain
    {
        static public void ReadMain(System.Windows.Controls.DataGrid dataGrid)
        {

            using (libraryEntities libraryContext = new libraryEntities())
            {

                dataGrid.ItemsSource = (from a in libraryContext.avtors
                                        join b in libraryContext.books on a.id_avtors equals b.id_avtor
                                        orderby b.name
                                        select new { b.name, b.year ,a.secondName, a.firstName, a.patronymic,});

            }

        }
    }
}
