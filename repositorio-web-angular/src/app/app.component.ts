import { Component } from '@angular/core';
import { RepositoriosComponent } from "./pages/repositorios/repositorio.component";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  imports: [RepositoriosComponent]
})
export class AppComponent {}