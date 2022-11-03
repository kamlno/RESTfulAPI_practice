﻿using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RESTfulAPI_practice.Libs
{
    public class Initiate
    {
        public static List<Models.Form> InitiateList(string Path1="", string Path2="",
            string orderBy="lastmodified",string direction = "descending",string filterByName="")
        {
            List<Models.Form> FormList = new List<Models.Form>();

            //Combine Path
            var CurrentPath = Directory.GetCurrentDirectory();

            if (Path1 != "" && Path2 != "") CurrentPath = Path.Combine(CurrentPath, "File", Path1 , Path2);
            else if(Path1!="") CurrentPath = Path.Combine(CurrentPath, "File", Path1);
            else CurrentPath = Path.Combine(CurrentPath, "File");
            //Combine Path

            //Creat Wrapper 
            DirectoryInfo CurrentDirectory = new DirectoryInfo(CurrentPath);
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
                    Form.Size = Tmp.Length.ToString();
                }
                else Form.Size = "Directory";

                FormList.Add(Form);
            }

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
        
        public static void FilterByName(List<Models.Form> FormList)
        {
            
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
                    Form.Size = Tmp.Length.ToString();
                }
                else Form.Size = "Directory";

                FormArray[i] = Form;
            }

            return FormArray;
        }
        #endregion
    }
}