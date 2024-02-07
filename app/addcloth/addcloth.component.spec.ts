import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddclothComponent } from './addcloth.component';

describe('AddclothComponent', () => {
  let component: AddclothComponent;
  let fixture: ComponentFixture<AddclothComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddclothComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddclothComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
