import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GaragesTableComponent } from './garages-table.component';

describe('GaragesTableComponent', () => {
  let component: GaragesTableComponent;
  let fixture: ComponentFixture<GaragesTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GaragesTableComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GaragesTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
