using Agentstvo23.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agentstvo23.ViewModels.Test
{
    internal class DataTableViewModel : ViewModel
    {
        private DataTable _table;
        private DateTime _begin;
        private DateTime _end;

        public DataTable Table { get => _table; set => Set(ref _table, value); }
        public DateTime Begin { get => _begin; private set => Set(ref _begin, value); }
        public DateTime End { get => _end; private set => Set(ref _end, value); }

        private void SetRangeDates(DateTime begin, DateTime end)
        {
            begin = begin.Date;
            end = end.Date;
            if (Begin == begin && End == end)
                return;

            if (begin < end)
            {
                Begin = begin;
                End = end;
            }
            else
            {
                End = begin;
                Begin = end;
            }

            DataTable table = new DataTable();
            int length = (End - Begin).Days + 1;

            for (int i = 0; i < length; i++)
                table.Columns.Add(Begin.AddDays(i).ToString("dd.MM.yyyyг."), typeof(string));

            Table = table;
        }

        //public bool SetRangeCanMethod(object parameter)
        //    => parameter is object[] array
        //        && array.Length == 2
        //        && (array[0] is DateTime || (array[0] is string str && DateTime.TryParse(str, out _)))
        //        && (array[1] is DateTime || (array[1] is string str1 && DateTime.TryParse(str1, out _)));

        //public void SetRangeMethod(object parameter)
        //{
        //    object[] array = (object[])parameter;

        //    if (array[0] is not DateTime begin)
        //        begin = DateTime.Parse((string)array[0]);

        //    if (array[1] is not DateTime end)
        //        end = DateTime.Parse((string)array[1]);

        //    SetRangeDates(begin, end);
        //}

        public DataTableViewModel()
        {
            DateTime now = DateTime.Now.Date;
 
            DateTime begin = now;
            DateTime end = begin.AddDays(100);
 
            SetRangeDates(begin, end);
        }
    }
}
