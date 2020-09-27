import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { YogaRoomComponent } from './yoga-room.component';

describe('YogaRoomComponent', () => {
  let component: YogaRoomComponent;
  let fixture: ComponentFixture<YogaRoomComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ YogaRoomComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(YogaRoomComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
