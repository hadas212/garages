import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GarageSelectComponent } from './garage-select.component';

describe('GarageSelectComponent', () => {
  let component: GarageSelectComponent;
  let fixture: ComponentFixture<GarageSelectComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GarageSelectComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GarageSelectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
