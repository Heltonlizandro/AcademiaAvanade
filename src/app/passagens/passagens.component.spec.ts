/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { PassagensComponent } from './passagens.component';

describe('PassagensComponent', () => {
  let component: PassagensComponent;
  let fixture: ComponentFixture<PassagensComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PassagensComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PassagensComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
