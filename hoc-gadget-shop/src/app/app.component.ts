import { Component } from '@angular/core';
import { RouterOutlet, RouterModule } from '@angular/router';
import { InventoryComponent } from './AppComponents/inventory/inventory.component';

@Component({
    selector: 'app-root',
    standalone: true,
    imports: [RouterOutlet, RouterModule, InventoryComponent],
    templateUrl: './app.component.html',
    styleUrl: './app.component.css'
})
export class AppComponent {
    title = 'hoc-gadget-shop';
}