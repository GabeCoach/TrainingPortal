import { TestBed, inject } from '@angular/core/testing';

import { HttpRequestInterceptorService } from './http-request-interceptor.service';

describe('HttpRequestInterceptorService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [HttpRequestInterceptorService]
    });
  });

  it('should be created', inject([HttpRequestInterceptorService], (service: HttpRequestInterceptorService) => {
    expect(service).toBeTruthy();
  }));
});
