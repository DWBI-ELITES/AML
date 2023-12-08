import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CddComponent } from './cdd.component';

describe('CddComponent', () => {
  let component: CddComponent;
  let fixture: ComponentFixture<CddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
