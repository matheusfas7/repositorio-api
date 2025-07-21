import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { RepositoriosComponent } from "./pages/repositorios/repositorio.component";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  imports: [RepositoriosComponent]
  // standalone: true,
  // imports: [RouterOutlet],
  // template: `<router-outlet></router-outlet>`
})
export class AppComponent {}