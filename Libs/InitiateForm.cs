using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

namespace RESTfulAPI_practice.Libs
{
    public class Initiate
    {
        public static string CheckUrl(string Path1="",string Path2="")
        {
            var CurrentPath = Directory.GetCurrentDirectory();

            //Combine Path
            if (Path1 != "" && Path2 != "") CurrentPath = Path.Combine(CurrentPath, "File", Path1, Path2);
            else if (Path1 != "") CurrentPath = Path.Combine(CurrentPath, "File", Path1);
            else CurrentPath = Path.Combine(CurrentPath, "File");

            return CurrentPath;
        }
        public static bool CheckFile(string Path)
        {
            FileAttributes fileAttributes = File.GetAttributes(Path);

            if (fileAttributes.HasFlag(FileAttributes.Directory))
            { 
                return false;
            }
            else return true;
        }
        public static List<Models.Form> InitiateList(string Path="",
            string orderBy="lastmodified",string direction = "descending",string filterByName="")
        {
            List<Models.Form> FormList = new List<Models.Form>();

            //Creat Wrapper 
            DirectoryInfo CurrentDirectory = new DirectoryInfo(Path);
            FileSystemInfo[] baseDir = CurrentDirectory.GetFileSystemInfos();

            //Initiate List By Wrapper
            foreach (FileSystemInfo info in baseDir)
            {
                Models.Form Form = new Models.Form();
                Form.Name = info.Name;
                Form.LastModified = info.LastWriteTime;
                if (!info.Attributes.HasFlag(FileAttributes.Directory))
                {
                    FileInfo Tmp = new FileInfo(info.FullName);
                    Form.Size = Tmp.Length;
                    Form.type = "file";
                }
                else
                {
                    Form.Size = -1;
                    Form.type = "directory";
                }
                FormList.Add(Form);
            }
            //Filter Pipeline
            FormList = FilterByName(FormList, filterByName);

            //Order Pipeline
            FormList = OrderBy(FormList, orderBy, direction);
            
            return FormList;
        }

        public static List<Models.Form> OrderBy
            (List<Models.Form> FormList,string orderBy,string direction)
        {
            orderBy = orderBy.ToLower();
            direction = direction.ToLower();

            if(direction == "ascending")
            {
                switch (orderBy)
                {
                    case "lastmodified":
                        FormList = FormList.OrderBy(x => x.LastModified).ToList();
                        break;
                    case "size":
                        FormList = FormList.OrderBy(x => x.Size).ToList();
                        break;
                    case "filename":
                        FormList = FormList.OrderBy(x => x.Name).ToList();
                        break;
                }
            }
            else
            {
                switch (orderBy)
                {
                    case "lastmodified":
                        FormList = FormList.OrderByDescending(x => x.LastModified).ToList();
                        break;
                    case "size":
                        FormList = FormList.OrderByDescending(x => x.Size).ToList();
                        break;
                    case "filename":
                        FormList = FormList.OrderByDescending(x => x.Name).ToList();
                        break;
                }
            }
            
            return FormList;
        }
        
        public static List<Models.Form> FilterByName(List<Models.Form> FormList,string filterByName = "")
        {
            if(filterByName =="") return FormList;

            else
            {
                List<Models.Form> FilteredList = new List<Models.Form>();

                foreach (Models.Form Form in FormList)
                {
                    if (Form.Name.Contains(filterByName)) FilteredList.Add(Form);
                }

                if (FilteredList.Count <= 0)
                {
                    Models.Form res = new Models.Form() { Name = "結果不存在!" };
                    FilteredList.Add(res);
                }
                return FilteredList;
            }
        }

        //unuse
        #region
        public static Models.Form[] InitiateArray (string Path1 = "", string Path2 = "")
        {
            Models.Form[] FormArray = new Models.Form[3];

            var CurrentPath = Directory.GetCurrentDirectory();

            if (Path1 != "" && Path2 != "") CurrentPath = Path.Combine(CurrentPath, "File", Path1, Path2);
            else if (Path1 != "") CurrentPath = Path.Combine(CurrentPath, "File", Path1);
            else CurrentPath = Path.Combine(CurrentPath, "File");

            DirectoryInfo CurrentDirectory = new DirectoryInfo(CurrentPath);
            FileSystemInfo[] baseDir = CurrentDirectory.GetFileSystemInfos();

            for(int i =0;i<3;i++)
            {
                //FormArray[i] = baseDir[i];
                Models.Form Form = new Models.Form();
                Form.Name = baseDir[i].Name;
                Form.LastModified = baseDir[i].LastWriteTime;
                if (!baseDir[i].Attributes.HasFlag(FileAttributes.Directory))
                {
                    FileInfo Tmp = new FileInfo(baseDir[i].FullName);
                    Form.Size = Tmp.Length;
                    Form.type = "file";
                }
                else
                {
                    Form.Size = -1;
                    Form.type = "directory";
                }

                FormArray[i] = Form;
            }

            return FormArray;
        }
        #endregion
    }
}