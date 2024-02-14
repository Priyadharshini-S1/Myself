import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CartcheckComponent } from './cartcheck.component';

describe('CartcheckComponent', () => {
  let component: CartcheckComponent;
  let fixture: ComponentFixture<CartcheckComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CartcheckComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CartcheckComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
