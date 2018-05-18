using SDN.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SASClient.CloseRequest
{
    public class StackList : ViewModelBase
    {
        public bool result;
        public  static List<string> list = new List<string>();
        Stack st = new Stack();
        public bool AddToList()
        {
            if (SharedValues.UserList.Contains(SharedValues.ScreenCheckName)) 
                { 
           
                    if (list.Contains(SharedValues.ViewName))
                    {

                        //list.Add(SharedValues.getValue);
                        int idx = list.IndexOf(SharedValues.ViewName);
                        list.RemoveAt(idx);
                        list.Add(SharedValues.ViewName);

                    }
                    else
                    {
                        list.Add(SharedValues.ViewName);
                    }
                    list.ToString();
                    Application.Current.Resources["views"] = list;
                    var f = Application.Current.Resources["views"];
                result = true;
                }
            else if(SharedValues.ViewName == "Unpaid Sales Invoice" || SharedValues.ViewName == "Unpaid Purchase Invoice" || SharedValues.ViewName == "Undelivered Sales Orders" || SharedValues.ViewName ==
                "Undelivered Purchase Orders" || SharedValues.ViewName == "Stock")
            {
                if (list.Contains(SharedValues.ViewName))
                {

                    //list.Add(SharedValues.getValue);
                    int idx = list.IndexOf(SharedValues.ViewName);
                    list.RemoveAt(idx);
                    list.Add(SharedValues.ViewName);

                }
                else
                {
                    list.Add(SharedValues.ViewName);
                }
                list.ToString();
                Application.Current.Resources["views"] = list;
                var f = Application.Current.Resources["views"];
                result = false;
            }
            else
            {
                result = false;
            }
            return result;
        }

    }
}
