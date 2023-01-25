import { Component } from '@angular/core';
import {HttpClient} from '@angular/common/http'

@Component({
  selector: 'app-studentcrud',
  templateUrl: './studentcrud.component.html',
  styleUrls: ['./studentcrud.component.scss']
})
export class StudentcrudComponent {
  StudentArray : any[] = [];
  isResultLoaded = false;
  isUpdateFormActive = false;

  firstname: string ="";
  lastname: string ="";
  course: string ="";
  currentStudentID = "";

  constructor(private http: HttpClient )
  {
    this.getAllStudent();
  }

  ngOnInit(): void {
  }

  getAllStudent()
  {
    this.http.get("https://localhost:7073/api/Student/GetStudent")
    .subscribe((resultData: any)=>
    {
        this.isResultLoaded = true;
        console.log(resultData);
        this.StudentArray = resultData;
    });
  }

  register()
  {
    let bodyData = {
      "firstname" : this.firstname,
      "lastname":this.lastname,
      "course" : this.course,

    };

    this.http.post("https://localhost:7073/api/Student/AddStudent",bodyData).subscribe((resultData: any)=>
    {
        console.log(resultData);
        alert("Student Registered Successfully")
        this.getAllStudent();

    });
  }

  setUpdate(data: any)
  {
   this.firstname = data.firstName;
   this.lastname = data.lastname;
   this.course = data.course;


   this.currentStudentID = data.id;
  }

  UpdateRecords()
  {
    let bodyData =
    {
      "firstname" : this.firstname,
      "lastname" : this.lastname,
      "course" : this.course,
    };

    this.http.patch("https://localhost:7073/api/Student/UpdateStudent"+"/"+ this.currentStudentID,bodyData).subscribe((resultData: any)=>
    {
        console.log(resultData);
        alert("Student Registered Updated")
        this.getAllStudent();

    });
  }
  save()
  {
    if(this.currentStudentID == '')
    {
        this.register();
    }
      else
      {
       this.UpdateRecords();
      }

  }


  setDelete(data: any)
  {
    this.http.delete("https://localhost:7073/api/Student/DeleteStudent"+ "/"+ data.id).subscribe((resultData: any)=>
    {
        console.log(resultData);
        alert("Student Deleted")
        this.getAllStudent();
    });
  }
}
