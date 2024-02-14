import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClothlistComponent } from './clothlist.component';

describe('ClothlistComponent', () => {
  let component: ClothlistComponent;
  let fixture: ComponentFixture<ClothlistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ClothlistComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ClothlistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
