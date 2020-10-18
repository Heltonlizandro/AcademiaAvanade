import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-propostas',
  templateUrl: './propostas.component.html',
  styleUrls: ['./propostas.component.scss']
})
export class PropostasComponent implements OnInit {

  titulo = 'Propostas';
  
  propostas =[
    {nome:'Proposta 1'},
    {nome:'Proposta 2'},
    {nome:'Proposta 3'},
    {nome:'Proposta 4'},
    {nome:'Proposta 5'},
    {nome:'Proposta 6'},
    {nome:'Proposta 7'}
  ];

  constructor() { }

  ngOnInit() {
  }

}
