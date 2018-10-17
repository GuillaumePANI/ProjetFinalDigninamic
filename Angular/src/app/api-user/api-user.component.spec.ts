import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ApiUserComponent } from './api-user.component';

describe('ApiUserComponent', () => {
  let component: ApiUserComponent;
  let fixture: ComponentFixture<ApiUserComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ApiUserComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApiUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
