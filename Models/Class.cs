using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTfulAPI_practice.Models
{
    public class Class
    {
        public Class(List<Models.Form> ListForm)  
        {
            isDirectory = true;
            file = new List<string>();

            for (int i = 0; i < ListForm.Count; i++)
            {
                file.Add(ListForm[i].Name);
            }
        }
        public bool isDirectory { set; get; }
        public List<string> file { set; get; }
    }
}
