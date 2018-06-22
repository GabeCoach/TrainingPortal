import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SubSectionsDisplayComponent } from './sub-sections-display.component';

describe('SubSectionsDisplayComponent', () => {
  let component: SubSectionsDisplayComponent;
  let fixture: ComponentFixture<SubSectionsDisplayComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SubSectionsDisplayComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SubSectionsDisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
