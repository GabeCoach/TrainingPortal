import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SectionsDisplayComponent } from './sections-display.component';

describe('SectionsDisplayComponent', () => {
  let component: SectionsDisplayComponent;
  let fixture: ComponentFixture<SectionsDisplayComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SectionsDisplayComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SectionsDisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
