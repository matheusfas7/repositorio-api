import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment.development';
import { Repositorio } from '../Models/Repositorio';

@Injectable({
  providedIn: 'root'
})
export class FavoritoService {
  private apiUrl = environment.ApiUrl;

  constructor(private http: HttpClient) {}

  adicionarFavorito(id: number) {
    return this.http.post(`${this.apiUrl}/favoritos`, { id });
  }

  removerFavorito(id: number) {
    return this.http.delete(`${this.apiUrl}/favoritos/${id}`);
  }

  listarFavoritos() {
    return this.http.get<number[]>(`${this.apiUrl}/favoritos`,);
  }
}