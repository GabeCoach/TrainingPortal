import { Component, OnInit, TemplateRef } from '@angular/core';

// components
import { SubSectionDisplayModalComponent } from '../sub-section-display-modal/sub-section-display-modal.component';

// services
import { BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';
import { TrainingCourseModuleSectionService } from '../../services/training-course-module-section/training-course-module-section.service';
import { TrainingCourseModuleService } from '../../services/training-course-module/training-course-module.service';
// tslint:disable-next-line:max-line-length
import { TrainingCourseModuleSubSectionService } from '../../services/training-course-module-sub-section/training-course-module-sub-section.service';
import { TrainingCourseModuleSection } from '../../models/training-course-module-section';
import { TrainingCourseModuleSubSection } from '../../models/training-course-module-sub-section';
import { HttpErrorResponse } from '@angular/common/http';
import { TrainingCourseModule } from '../../models/training-course-module';

@Component({
    selector: 'app-sections-controller-modal',
    templateUrl: './sections-display-modal.component.html'
})

export class SectionsDisplayModalComponent implements OnInit {

  bsModalRef: BsModalRef;
  items = ['Item 1', 'Item 2', 'Item 3'];
  trainingCourseModuleSections: TrainingCourseModuleSection[] = [];
  trainingCourseModuleSubSections: TrainingCourseModuleSubSection[] = [];
  trainingCourseModule: TrainingCourseModule;

  constructor(
    private bsModalService: BsModalService,
    private moduleSubSectionService: TrainingCourseModuleSubSectionService ,
    private trainingCourseModuleSectionServie: TrainingCourseModuleSectionService,
    private trainingCourseModuleService: TrainingCourseModuleService
  ) {}

  ngOnInit() {
    this.trainingCourseModuleSectionServie.getTrainingCourseModuleSectionByModule(
      this.trainingCourseModuleSectionServie.trainingCourseModuleId
    ).then(resp => {
      this.trainingCourseModuleSections = resp;
    });

    this.trainingCourseModuleService.getTrainingCourseModuleById(this.trainingCourseModuleSectionServie.trainingCourseModuleId)
        .then(resp => {
            this.trainingCourseModule = resp;
        }).catch((err: HttpErrorResponse) => {
            alert(err.message);
        });
  }

  addItem(): void {
    this.items.push(`Item ${this.items.length + 1}`);
  }

  public openSubSectionsModal(iSubSectionId: number): void {
    this.moduleSubSectionService.iSubSectionId = iSubSectionId;
    this.bsModalRef = this.bsModalService.show(SubSectionDisplayModalComponent, {});
  }

  public close(): void {
    this.bsModalRef.hide();
  }
}
