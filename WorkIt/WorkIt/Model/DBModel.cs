﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkIt.Model
{
    class DBModel
    {

        private Controller m_controller;
        private DB_helper helper;
        public DBModel(Controller controller)
        {
            m_controller = controller;
            helper = new DB_helper();
        }
        public void UpdateClass(string className, Dictionary<string, string> parameters)
        {
            string query = "Update Classes Set";
            foreach (string paramName in parameters.Keys)
            {
                if (paramName=="Guide_ID"||paramName=="Room_num")
                    query += "[" + paramName + "]" + "=" + parameters[paramName] + ",";
                else
                    query += "[" + paramName + "]" + "='" + parameters[paramName] + "',";
                

            }
            query = query.Substring(0, query.Length - 1);
            query += " where Name='" + className + "'";
            helper.ExecuteNonQuery(query);
            string query2 = "select C.Name,C.Mail from Customers C inner join Customres_In_Classes CIC on C.ID=CIC.Customer_ID where CIC.Class_Name=" + className;
            DataTable res = helper.ExecuteDataTable(query2);
            m_controller.ShowMessage("The Class " + className + " was updated successfuly");
            m_controller.ShowCustomers(res);

        }
        
        
        public void CreateOrder(Dictionary<string, string> parameters) 
        {
            string query = "Insert Into Orders select";
            foreach (string paramName in parameters.Keys)
            {
                if (paramName=="ID")
                    query += "[" + paramName + "]" + "=" + parameters[paramName] + ",";
                else
                    query += "[" + paramName + "]" + "='" + parameters[paramName] + "',";
            }
            query = query.Substring(0, query.Length - 1);
            helper.ExecuteNonQuery(query);
            m_controller.ShowMessage("The Order was added successfuly");
        }

        public void InsertItemsToOrder(List<int> items,int Order_ID)
        { 
            string query="";
            foreach (int i in items)
            {
                query = "NSERT INTO Items_In_Orders VALUES(1,50,2)";
            }
        }
        
        
        public void SendEvent(string eventName) { }

    }
}
