import { Component,Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
@Component({
  selector: 'app-equipment-photo-dialog',
  templateUrl: './equipment-photo-dialog.component.html',
  styleUrl: './equipment-photo-dialog.component.css'
})
export class EquipmentPhotoDialogComponent {
  constructor(@Inject(MAT_DIALOG_DATA) public data: any) {}

  get imageUrl(): string {
    return this.data.imageUrl;
  }
}
