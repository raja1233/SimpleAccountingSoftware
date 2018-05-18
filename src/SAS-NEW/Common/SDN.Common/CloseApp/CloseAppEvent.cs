using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SDN.Common.CloseApp
{
    public class CloseAppEvent
    {
        List<string> list = new List<string>();
        Stack st = new Stack();
        public void x()
        {
            if(list.Contains(SharedValues.getValue))
            {
                //list.Add(SharedValues.getValue);
                int idx = list.IndexOf(SharedValues.getValue);
                list.RemoveAt(idx);
                list.Add(SharedValues.getValue);
                
            }
            else
            {
                list.Add(SharedValues.getValue);
            }
            list.ToString();
            Application.Current.Resources["something"] = list;

        }
    }
}
