import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RepositorioService } from '../../services/repositorio.service';

@Component({
  selector: 'app-repositorios',
  standalone: true,
  imports: [CommonModule, FormsModule, HttpClientModule], 
  templateUrl: './repos.component.html',
  styleUrls: ['./repos.component.css']
})
export class RepositoriosComponent{
  nome: string = '';
  repositorios: any[] = [];
  favoritos: Set<number> = new Set(); // Armazena os IDs dos repositórios favoritos

  constructor(private repositorioService: RepositorioService) {}

  // ngOnInit(): void {}

  buscarRepos(): void {
    // if (!this.repos) return;

    // this.repositorioService.getRepositorios(this.repos);

    this.repositorioService.getRepositorios(this.nome).subscribe({
      next: (dados) => {
        console.log(dados)
        this.repositorios = dados;
      },
      error: (err) => {
        console.error('Erro ao buscar:', err);
      }
    });
  }
}