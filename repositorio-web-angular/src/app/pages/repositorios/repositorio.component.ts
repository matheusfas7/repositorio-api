import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RepositorioService } from '../../services/repositorio.service';
import { FavoritoService } from '../../services/favorito.service';

@Component({
  selector: 'app-repositorios',
  standalone: true,
  imports: [CommonModule, FormsModule], 
  templateUrl: './repositorio.component.html',
  styleUrls: ['./repositorio.component.css']
})
export class RepositoriosComponent{
  nome: string = '';
  repositorios: any[] = [];
  favoritos: Set<number> = new Set();

  constructor(
    private repositorioService: RepositorioService,
    private favoritoService: FavoritoService
  ) {}

  carregarFavoritos(): void {
    this.favoritoService.listarFavoritos().subscribe({
      next: (data: number[]) => {
        this.favoritos = new Set(data);
      },
      error: err => console.error('Erro ao carregar favoritos:', err)
    });
  }

  buscarRepositorios(): void {
    this.repositorioService.listartRepositorios(this.nome).subscribe({
      next: (dados) => {
        this.repositorios = dados;
        this.carregarFavoritos();
      },
      error: (err) => {
        console.error('Erro ao buscar repositórios:', err);
      }
    });
  }

  buscarRepositoriosPorRelevancia(): void {
    this.repositorioService.listartRepositoriosPorRelevancia(this.nome).subscribe({
      next: (dados) => {
        this.repositorios = dados;
        this.carregarFavoritos();
      },
      error: (err) => {
        console.error('Erro ao buscar repositórios:', err);
      }
    });
  }

  toggleFavorito(id: number): void {
    if (this.favoritos.has(id)) {
      this.favoritoService.removerFavorito(id).subscribe({
        next: () => this.carregarFavoritos(),
        error: err => console.error('Erro ao remover favorito:', err)
      });
    } else {
      this.favoritoService.adicionarFavorito(id).subscribe({
        next: () => this.carregarFavoritos(),
        error: err => console.error('Erro ao adicionar favorito:', err)
      });
    }
  }

  isFavorito(id: number): boolean {
    return this.favoritos.has(id);
  }
}