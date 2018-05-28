import { Component, OnInit } from '@angular/core';
// tslint:disable-next-line:max-line-length
import { TrainingCourseModuleSubSectionService } from '../../services/training-course-module-sub-section/training-course-module-sub-section.service';
import { TrainingCourseModuleSubSection } from '../../models/training-course-module-sub-section';

@Component({
    selector: 'app-sub-section-display-modal',
    templateUrl: './sub-section-display-modal.component.html'
})

export class SubSectionDisplayModalComponent implements OnInit {

    public moduleSubSections: TrainingCourseModuleSubSection[] = [];

    constructor(private moduleSubSectionService: TrainingCourseModuleSubSectionService) {}

    ngOnInit() {
        this.moduleSubSectionService.getModuleSubSectionByModuleSection(this.moduleSubSectionService.iSubSectionId)
        .then(resp => {
            this.moduleSubSections = resp;

            this.moduleSubSections.forEach((value, index, array) => {
                // tslint:disable-next-line:curly
                if (value.module_sub_section_name === null)
                    value.module_sub_section_name = '';
            });
        }).catch(err => {
            alert(err);
        });
    }

}
