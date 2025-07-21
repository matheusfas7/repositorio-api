import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment.development';
import { Repositorio } from '../Models/Repositorio';

@Injectable({
  providedIn: 'root'
})
export class RepositorioService {
  private apiUrl = environment.ApiUrl;

  constructor(private http: HttpClient) {}

  listartRepositorios(nome: string) : Observable<Repositorio[]>{
    const params = new HttpParams().set('nome', nome);
    return this.http.get<Repositorio[]>(`${this.apiUrl}/repositorios`, { params });
  }

  listartRepositoriosPorRelevancia(nome: string) : Observable<Repositorio[]>{
    const params = new HttpParams().set('nome', nome);
    return this.http.get<Repositorio[]>(`${this.apiUrl}/repositoriosPorRelevancia`, { params });
  }
}