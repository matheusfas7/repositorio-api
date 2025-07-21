import { Routes } from '@angular/router';
import { RepositoriosComponent } from './pages/repositorios/repositorio.component';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('./pages/repositorios/repositorio.component').then(m => m.RepositoriosComponent),
  }
];