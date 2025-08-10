import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { DialogBoxComponent } from '../dialog-box/dialog-box.component';

@Component({
    selector: 'app-inventory',
    standalone: true,
    imports: [FormsModule, CommonModule],
    templateUrl: './inventory.component.html',
    styleUrl: './inventory.component.css'
})
export class InventoryComponent {
    httpClient = inject(HttpClient);
    private modelService = inject(NgbModal);

    inventoryData = {
        productId: "",
        productName: "",
        availableQnt: 0,
        reorderPoint: 0,
    }

    inventoryDetials: any;

    ngOnInit() {
        this.getInventoryDetails();
    }

    getInventoryDetails() {
        let apiUrl = "https://localhost:7136/api/Inventory";

        this.httpClient.get(apiUrl).subscribe(data => {
            this.inventoryDetials = data;
            console.log(this.inventoryDetials)
        });
    }

    onSubmit(): void {
        let apiUrl = "https://localhost:7136/api/Inventory";

        let httpOptions = {
            headers: new HttpHeaders({
                Authorization: 'my-auth-token',
                "Content-Type": "application/json"
            })
        }

        this.httpClient.post(apiUrl, this.inventoryData, httpOptions).subscribe({
            next: v => console.log(v),
            error: e => console.log(e),
            complete: () => {
                alert("Form Submitted successfully: " + JSON.stringify(this.inventoryData));
                this.getInventoryDetails();
            },
        });
    }

    openConfirmDialog() {
        this.modelService.open(DialogBoxComponent);
    }
}
