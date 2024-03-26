import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EquipmentPhotoDialogComponent } from './equipment-photo-dialog.component';

describe('EquipmentPhotoDialogComponent', () => {
  let component: EquipmentPhotoDialogComponent;
  let fixture: ComponentFixture<EquipmentPhotoDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EquipmentPhotoDialogComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EquipmentPhotoDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
