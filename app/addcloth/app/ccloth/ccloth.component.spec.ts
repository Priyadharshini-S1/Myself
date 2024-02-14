import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CclothComponent } from './ccloth.component';

describe('CclothComponent', () => {
  let component: CclothComponent;
  let fixture: ComponentFixture<CclothComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CclothComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CclothComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
