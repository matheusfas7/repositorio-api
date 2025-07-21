import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RepositorioService } from '../../services/repositorio.service';
import { FavoritoService } from '../../services/favorito.service';
import { NgxPaginationModule } from 'ngx-pagination';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-repositorios',
  standalone: true,
  imports: [CommonModule, FormsModule, NgxPaginationModule], 
  templateUrl: './repositorio.component.html',
  styleUrls: ['./repositorio.component.css']
})
export class RepositoriosComponent{
  nome: string = '';
  repositorios: any[] = [];
  favoritos: Set<number> = new Set();

  /** Página atual da paginação */
  paginaAtual = 1;

  constructor(
    private repositorioService: RepositorioService,
    private favoritoService: FavoritoService
  ) {}

  /* Carrega os IDs dos repositórios marcados como favoritos do backend.*/
  carregarFavoritos(): void {
    this.favoritoService.listarFavoritos().subscribe({
      next: (data: number[]) => {
        this.favoritos = new Set(data);
      },
      error: (err) => {
        Swal.fire({
            icon: 'error',
            title: 'Ocorreu um erro ao carregar os favoritos...',
            text: err.error,
            showConfirmButton: true
        });
      }
    });
  }

  buscarRepositorios(): void {
    this.repositorioService.listartRepositorios(this.nome).subscribe({
      next: (dados) => {
        this.repositorios = dados;
        this.carregarFavoritos();
      },
      error: (err) => {
        Swal.fire({
            icon: 'error',
            title: 'Ocorreu um erro ao buscar os repositórios...',
            text: err.error,
            showConfirmButton: true
        });
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
        Swal.fire({
            icon: 'error',
            title: 'Ocorreu um erro ao buscar os repositórios...',
            text: err.error,
            showConfirmButton: true
        });
      }
    });
  }

  /*Adiciona ou remove um repositório dos favoritos com base no seu estado atual.*/
  toggleFavorito(id: number): void {
    if (this.favoritos.has(id)) {
      this.favoritoService.removerFavorito(id).subscribe({
        next: () => this.carregarFavoritos(),
        error: (err) => {
          Swal.fire({
              icon: 'error',
              title: 'Ocorreu um erro ao remover favorito...',
              text: err.error,
              showConfirmButton: true
          });
      }
      });
    } else {
      this.favoritoService.adicionarFavorito(id).subscribe({
        next: () => this.carregarFavoritos(),
        error: (err) => {
          Swal.fire({
              icon: 'error',
              title: 'Ocorreu um erro ao adicionar favorito...',
              text: err.error,
              showConfirmButton: true
          });
      }
      });
    }
  }

  isFavorito(id: number): boolean {
    return this.favoritos.has(id);
  }
}