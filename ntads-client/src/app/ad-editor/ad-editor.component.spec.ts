import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdEditorComponent } from './ad-editor.component';

describe('AdEditorComponent', () => {
  let component: AdEditorComponent;
  let fixture: ComponentFixture<AdEditorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdEditorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
