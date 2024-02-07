import { TestBed } from '@angular/core/testing';

import { ClothserviceService } from './clothservice.service';

describe('ClothserviceService', () => {
  let service: ClothserviceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ClothserviceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
