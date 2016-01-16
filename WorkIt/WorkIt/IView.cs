using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkIt
{
    interface IView
    {
        public void ShowMessage(string msg);
        public void ShowCustomers(DataTable customers);
    }
}
