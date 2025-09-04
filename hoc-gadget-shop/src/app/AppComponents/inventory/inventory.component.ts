import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { DialogBoxComponent } from '../dialog-box/dialog-box.component';
import { environment } from '../../../environment';

@Component({
    selector: 'app-inventory',
    standalone: true,
    imports: [FormsModule, CommonModule],
    templateUrl: './inventory.component.html',
    styleUrl: './inventory.component.css'
})
export class InventoryComponent {
    httpClient = inject(HttpClient);
    inventoryDetials: any;
    private modelService = inject(NgbModal);
    productIdToDelete: number = 0;

    inventoryData = {
        productId: "",
        productName: "",
        availableQnt: 0,
        reorderPoint: 0,
    }

    ngOnInit() {
        this.getInventoryDetails();
    }

    getInventoryDetails() {
        this.httpClient.get(environment.apiUrl).subscribe(data => {
            this.inventoryDetials = data;
            console.log(this.inventoryDetials)
        });
    }

    onSubmit(): void {
        let httpOptions = {
            headers: new HttpHeaders({
                Authorization: 'my-auth-token',
                "Content-Type": "application/json"
            })
        }

        this.httpClient.post(environment.apiUrl, this.inventoryData, httpOptions).subscribe({
            next: v => console.log(v),
            error: e => console.log(e),
            complete: () => {
                alert("Form Submitted successfully: " + JSON.stringify(this.inventoryData));
                this.getInventoryDetails();
            },
        });
    }

    openConfirmDialog(productId: number) {
        this.productIdToDelete = productId;
        console.log(this.productIdToDelete);
        this.modelService.open(DialogBoxComponent).result.then((data) => {
            if (data.event == "confirm") {
                this.deleteInventory();
            }
        });
    }

    deleteInventory(): void {
        let apiUrl = `${environment.apiUrl}?productId=${this.productIdToDelete}`;
        this.httpClient.delete(apiUrl).subscribe(data => {
            this.getInventoryDetails();
        })
    }
}
