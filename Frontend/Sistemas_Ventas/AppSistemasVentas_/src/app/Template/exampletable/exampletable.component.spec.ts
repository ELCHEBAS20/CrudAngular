import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExampletableComponent } from './exampletable.component';

describe('ExampletableComponent', () => {
  let component: ExampletableComponent;
  let fixture: ComponentFixture<ExampletableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ExampletableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ExampletableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
