# RESTfulAPI_practice

* BASIC



Endpoint can be called as file's path in root folder"file" , and there's two way below to present.

ex1 : https://localhost:44368/file/

this will return a JSON list with a bool and filenames list like :

    {
    "isDirectory": true,
    "file": 
        [
            "testFolder",
            "RESTfulAPI_practice - 捷徑.lnk",
            "image_2.png",
            "forTest.txt",
            "01_CoordinateSystem.pdf"
        ]
    }


ex2 : https://localhost:44368/file/list/

this will return files'detail by JASON like :

    [
        {
            "name": "testFolder",
            "lastModified": "2023-04-25T15:38:20.6277138+08:00",
            "size": -1,
            "type": "directory"
        },
        {
            "name": "RESTfulAPI_practice - 捷徑.lnk",
            "lastModified": "2023-03-19T16:32:34.6521234+08:00",
            "size": 990,
            "type": "file"
        },
        {
            "name": "image_2.png",
            "lastModified": "2022-09-27T08:49:33.1905001+08:00",
            "size": 108142,
            "type": "file"
        },
        {
            "name": "forTest.txt",
            "lastModified": "2022-11-27T19:03:23.3388031+08:00",
            "size": 56,
            "type": "file"
        },
        {
            "name": "01_CoordinateSystem.pdf",
            "lastModified": "2022-09-03T10:18:44.0118478+08:00",
            "size": 547308,
            "type": "file"
        }
    ]



* FEATURE:



These contents can be filtered by filename and sort by "size"、"lastmodified".

orderBy:"filename"、"size"、"lastmodified"
directions:"descending"、"ascending"

ex3 : https://localhost:44368/file/list?orderBy=size&direction=ascending 

    [  
        {  
            "name": "testFolder",  
            "lastModified": "2023-04-25T15:38:20.6277138+08:00",  
            "size": -1,  
            "type": "directory"  
        },  
        {  
            "name": "forTest.txt",  
            "lastModified": "2022-11-27T19:03:23.3388031+08:00",  
            "size": 56,  
            "type": "file"  
        },  
        {
            "name": "RESTfulAPI_practice - 捷徑.lnk",
            "lastModified": "2023-03-19T16:32:34.6521234+08:00",
            "size": 990,
            "type": "file"
        },
        {
            "name": "image_2.png",
            "lastModified": "2022-09-27T08:49:33.1905001+08:00",
            "size": 108142,
            "type": "file"
        },
        {
            "name": "01_CoordinateSystem.pdf",
            "lastModified": "2022-09-03T10:18:44.0118478+08:00",
            "size": 547308,
            "type": "file"
        }
    ]

use filter:

ex4 : https://localhost:44368/file/list/?orderBy=size&direction=ascending&filterbyname=est

    [
        {
            "name": "testFolder",
            "lastModified": "2023-04-25T15:38:20.6277138+08:00",
            "size": -1,
            "type": "directory"
        },
        {
            "name": "forTest.txt",
            "lastModified": "2022-11-27T19:03:23.3388031+08:00",
            "size": 56,
            "type": "file"
        }
    ]
