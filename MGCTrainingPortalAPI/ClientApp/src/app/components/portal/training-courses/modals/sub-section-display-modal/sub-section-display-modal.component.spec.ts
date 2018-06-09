import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SubSectionDisplayModalComponent } from './sub-section-display-modal.component';

describe('SubSectionDisplayModalComponent', () => {
  let component: SubSectionDisplayModalComponent;
  let fixture: ComponentFixture<SubSectionDisplayModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SubSectionDisplayModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SubSectionDisplayModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
