import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StatIdComponent } from './stat-id.component';

describe('StatIdComponent', () => {
  let component: StatIdComponent;
  let fixture: ComponentFixture<StatIdComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StatIdComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StatIdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
