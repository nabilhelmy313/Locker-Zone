import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditLockerComponent } from './edit-locker.component';

describe('EditLockerComponent', () => {
  let component: EditLockerComponent;
  let fixture: ComponentFixture<EditLockerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditLockerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditLockerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
