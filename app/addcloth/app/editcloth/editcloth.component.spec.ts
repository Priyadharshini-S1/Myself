import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditclothComponent } from './editcloth.component';


describe('EditclothComponent', () => {
  let component: EditclothComponent;
  let fixture: ComponentFixture<EditclothComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EditclothComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EditclothComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
