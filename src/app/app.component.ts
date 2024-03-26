import { Component, OnInit,forwardRef } from '@angular/core';
import { EquipmentserviceService } from './equipmentservice.service';
import { Equipments } from './Equipments';
import { AddEquipInt } from './Equipments';
import { Observable } from 'rxjs';
import { MessageService } from 'primeng/api';
import { ActivatedRoute,Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Table } from 'primeng/table';
import { SelectItem } from 'primeng/api';
import { filter } from 'rxjs';
import { FormControl, FormGroup, UntypedFormArray, UntypedFormControl } from '@angular/forms';
import { DialogModule } from 'primeng/dialog';
import { FileUploadEvent } from 'primeng/fileupload';
import { NgForm } from '@angular/forms';
import { LazyLoadEvent } from 'primeng/api';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { EquipmentPhotoDialogComponent } from './equipment-photo-dialog/equipment-photo-dialog.component';
import { MatDialog } from '@angular/material/dialog';
interface Type {
  name: string;
}
interface UploadEvent {
  originalEvent: any;
  files: File[];
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  providers: [MessageService]
})


export class AppComponent implements OnInit{
  equipmentId!: number ;
  equipmentPhotoUrl: string | ArrayBuffer | null = null;
  uploadedFiles: any[] = [];
  url: any;
  url1: any;
  fileToUpload: File | null = null;
  selectedFile: File | null = null;
  displayAddDialog: boolean = false;
displayEditDialog: boolean = false;


addeqpmtRequests: AddEquipInt = {
  eqpmt_No: '',
  eqpmt_size: 0,
  eqpmt_type: '',
  manuf_date: new Date(),
  equipment_owner: '',
  equipment_photo:new File([],'',{type:'image/png'}),
  isp_doc:new File([],'',{type:'image/png'})
};

  addeqpmtRequest:Equipments={
    eqpmt_No:'',
    eqpmt_size:0,
    eqpmt_type:'',
    manuf_date:new Date(),
    equipment_owner:'',
    equipment_photo:new File([],'',{type:'image/png'}),
    isp_doc:new File([],'',{type:'image/png'}),
    eqpmt_Id:0
   };

  types: Type[] | undefined;
  selectedType: Type| undefined;
  selectedEquipment: Equipments | undefined; 
  title = 'Equipment'; 
  equipment:Equipments[]=[];
  displayDialog: boolean = false;
  
  first = 0;
  rows = 20;
  previewUrl: string | ArrayBuffer | null = null;

  constructor(private http: HttpClient,private route:ActivatedRoute,private EquipmentService:EquipmentserviceService,private messageService: MessageService,private router:Router,private sanitizer: DomSanitizer,private dialog: MatDialog){

  }

//   onFileSelect(event: any) {
//     if (event.files && event.files.length > 0) {
//         const file = event.files[0];
//         const reader = new FileReader();
//         reader.readAsDataURL(file);
//         reader.onload = () => {
//             this.previewUrl = this.sanitizer.bypassSecurityTrustUrl(reader.result as string);
//         };
//     } else {
//         this.previewUrl = undefined;
//     }
// }
// onFileSelect(event: any): void {
//   const file = event.files[0];
//   const reader = new FileReader();
//   reader.onload = (e) => {
//     this.previewUrl = reader.result;
//   };
//   reader.readAsDataURL(file);

//   // Send the selected file to the backend
//   this.uploadImage(file);
// }

// uploadImage(file: File): void {
//   const formData = new FormData();
//   formData.append('file', file, file.name);

//   const httpOptions = {
//     headers: new HttpHeaders({
//       'Accept': 'application/json',
//       'Content-Type': 'multipart/form-data'
//     })
//   };

//   this.http.post<any>('http://localhost:5127/api/equipment', formData, httpOptions)
//     .subscribe({
//       next: (response) => {
//         console.log('Image uploaded successfully:', response);
//         const blobData = response.blobData;      
//       },
//       error: (error) => {
//         console.error('Error uploading image:', error);
//       }
//     });
// }
// onUpload(event:UploadEvent) {
//   for(let file of event.files) {
//       this.uploadedFiles.push(file);
//   }

//   this.messageService.add({severity: 'info', summary: 'File Uploaded', detail: ''});
// }

   onUploads(event: FileUploadEvent) {

    const originalEvent = event.originalEvent;
     this.messageService.add({ severity: 'info', summary: 'Success', detail: 'File Uploaded Successfully' });
     const fileList: File[] = event.files;
     if (fileList.length > 0) {
       this.addeqpmtRequests.equipment_photo = fileList[0]; 
     }
    }
    onUpload(event: FileUploadEvent) {

      const originalEvent = event.originalEvent;
       this.messageService.add({ severity: 'info', summary: 'Success', detail: 'File Uploaded Successfully' });
       const fileList: File[] = event.files;
       if (fileList.length > 0) {
         this.addeqpmtRequests.isp_doc = fileList[0]; 
       }
      }
  //   onUpload(event: UploadEvent) {
  //     this.messageService.add({ severity: 'info', summary: 'Success', detail: 'File Uploaded with Basic Mode' });
  // }
  ngOnInit(): void {
    
    this.EquipmentService.getAllequipments()
    .subscribe({
      next:(equipment)=>
      {
        console.log(this.equipment=equipment);
        
      },
      error:(response)=>
      {
        console.log(response);
      }
    });

    this.route.paramMap.subscribe({
      next:(params)=>
      {
       const eqNO=params.get('eqpmt_No');
        if(eqNO)
        {
          this.EquipmentService.getEquipmentByNo(eqNO)
          .subscribe({
            next:(response)=>{
              this.addeqpmtRequests=response;
            }
          })
        }
        
      }
     })

    this.types= [
      { name: 'CON' },
      { name: 'GP'},
      { name: 'REF'},
      { name: 'INK' }
     
  ];
  
  }

  updateEquipment(form: NgForm) {
    
    this.EquipmentService.updateEquipmentDetails(this.addeqpmtRequest.eqpmt_No, this.addeqpmtRequest)
      .subscribe({
        next: (response) => {
          console.log('Update successful:', response);
          this.displayEditDialog = false; 
          setTimeout(() => {
            window.location.reload();
            this.router.navigate(['app']); 
          }, 1000); 
        },
        error: (error) => {
          console.error('Update failed:', error);
        }
      });
  }
  

  onRowSelect(event: any, equipment: Equipments) {
    if (event.target.checked) {
      this.selectedEquipment = equipment;
      this.EquipmentService.getEquipmentByNo(equipment.eqpmt_No)
        .subscribe({
          next: (response) => {
            this.addeqpmtRequest = response;
          },
          error: (error) => {
            console.error('Error fetching equipment details:', error);
          }
        });
        
    } else {
      this.selectedEquipment = undefined;
    }
  }
  showDialog(isAddDialog: boolean) {
    if (isAddDialog) {
     
      this.addeqpmtRequests = {
        eqpmt_No: '',
        eqpmt_size: 0,
        eqpmt_type: '',
        manuf_date: new Date(),
        equipment_owner: '',
        equipment_photo:new File([],'',{type:'image/png'}),
        isp_doc:new File([],'',{type:'image/png'})
      };
    }
    
    this.displayAddDialog = true;
  }

  showDialogedit() {
    if (this.selectedEquipment) {
      this.EquipmentService.getEquipmentByNo(this.selectedEquipment.eqpmt_No)
        .subscribe({
          next: (response) => {
            this.addeqpmtRequest = response;
            this.displayEditDialog = true;
          },
          error: (error) => {
            console.error('Error fetching equipment details:', error);
          }
        });
    } else {
      console.log('Please select a row to edit.');
    }
  }
  // addequipment(form: NgForm):void {
  //   this.EquipmentService.addequipments(this.addeqpmtRequests)
  //     .subscribe(
  //       (response) => {
  //         console.log('Equipment added successfully:', response);
  //         form.resetForm();
  //         this.displayAddDialog = false;
  //         setTimeout(() => {
  //           window.location.reload();
  //         }, 1000);
  //       },
  //       (error) => {
  //         console.error('Error adding equipment:', error);
  //       }
  //     );
  // }
  addequipment(form: NgForm): void {
  
    this.EquipmentService.addequipments(this.addeqpmtRequests)
      .subscribe({
        next: (response) => {
          console.log('Equipment added successfully:', response);
          form.resetForm();
          this.displayAddDialog = false;
          setTimeout(() => {
            window.location.reload();
          }, 1000);
        },
        error: (error) => {
          console.error('Error adding equipment:', error);
        }
      });
  }

// addequipment(form: NgForm): void {
//   if (!this.fileToUpload) {
//     console.error('No file uploaded');
//     return;
//   }

//   const reader = new FileReader();
//   reader.onload = () => {
//     if (reader.result) {
//       const blob = new Blob([reader.result], { type: this.fileToUpload!.type });

//       // Pass the blob directly to the service method
//       this.EquipmentService.addequipments(this.addeqpmtRequest, blob)
//         .subscribe(
//           (response) => {
//             console.log('Equipment added successfully:', response);
//             form.resetForm();
//             this.displayAddDialog = false;
//             setTimeout(() => {
//               window.location.reload();
//             }, 1000);
//           },
//           (error) => {
//             console.error('Error adding equipment:', error);
//           }
//         );
//     } else {
//       console.error('Error reading file: result is null');
//     }
//   };
//   if (this.fileToUpload) {
//     reader.readAsArrayBuffer(this.fileToUpload);
//   } else {
//     console.error('No file uploaded');
//   }
// }

deleteEquipment(eqpmt_No:string)
{
  this.EquipmentService.deleteEquipments(eqpmt_No)
  .subscribe({
    next:(response)=>
    {
      this.router.navigate(['app']);
      console.log('Equipment deleted successfully:', response);
      setTimeout(() => {
        window.location.reload(); 
      }, 1000); 
    },
    error:(response)=>
    {
      console.log(response);
    }
  });
}
getEquipmentPhoto(equipmentId: number): void {
  this.EquipmentService.getEquipmentPhoto(equipmentId)
    .subscribe({
      next: (data: Blob) => {
        this.createImageFromBlob(data);
      },
      error: (error) => {
        console.error('Error fetching equipment photo:', error);
      }
    });
}

// createImageFromBlob(image: Blob): void {
//   const reader = new FileReader();
//   reader.addEventListener('load', () => {
//     const base64String = reader.result as string;
//     const imageUrl = 'data:image/png;base64,' + base64String.split(',')[1]; // Construct the image URL
//     console.log('Image URL:', imageUrl); // Log the image URL
//     if (imageUrl) {
//       this.navigateToNextPageWithImage(imageUrl);
//     } else {
//       console.error('Failed to construct image URL');
//     }
//   }, false);

//   reader.addEventListener('error', (error) => {
//     console.error('Error reading image blob:', error);
//   });

//   if (image) {
//     reader.readAsDataURL(image);
//   } else {
//     console.error('Invalid image data received');
//   }
// }

// navigateToNextPageWithImage(imageUrl: string) {
//   console.log('Navigating to next page with image URL:', imageUrl); // Log navigation
//   this.router.navigate(['/next-page'], { state: { imageUrl } });
// }
createImageFromBlob(image: Blob): void {
  const reader = new FileReader();
  reader.addEventListener('load', () => {
    const base64String = reader.result as string;
    const imageUrl = 'data:image/png;base64,' + base64String.split(',')[1]; // Construct the image URL
    console.log('Image URL:', imageUrl); // Log the image URL
    if (imageUrl) {
      this.openImageDialog(imageUrl);
    } else {
      console.error('Failed to construct image URL');
    }
  }, false);

  reader.addEventListener('error', (error) => {
    console.error('Error reading image blob:', error);
  });

  if (image) {
    reader.readAsDataURL(image);
  } else {
    console.error('Invalid image data received');
  }
}

openImageDialog(imageUrl: string): void {
  this.dialog.open(EquipmentPhotoDialogComponent, {
    data: imageUrl,
    maxWidth: '90vw',
    maxHeight: '90vh',
    width: '800px',
    height: '600px'
  });
}
getInspectionDocument(equipmentId:number): void {
  this.EquipmentService.getInspectionDocument(this.equipmentId).subscribe(
    (documentData: Blob) => {

    },
    (error) => {
      console.error('Error fetching inspection document:', error);
    }
  );
}

onSelectFile(event: Event) {
  const inputElement = event.target as HTMLInputElement;
  if (inputElement.files && inputElement.files[0]) {
    const reader = new FileReader();

    reader.onload = (e: any) => {
      this.url = e.target.result;
    };

    reader.readAsDataURL(inputElement.files[0]);
  }


}
onSelectFiles(event: Event) {
  const inputElement = event.target as HTMLInputElement;
  if (inputElement.files && inputElement.files[0]) {
    const reader = new FileReader();

    reader.onload = (e: any) => {
      this.url1 = e.target.result;
    };

    reader.readAsDataURL(inputElement.files[0]);
  }


}
 

}
