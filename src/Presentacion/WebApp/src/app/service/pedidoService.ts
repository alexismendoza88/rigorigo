
// pedido.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Producto {
id?: number;
nombre: string;
precio: number;
cantidad: number;
}

export interface Pedido {
cedula: string;
direccion: string;
productos: Producto[];
}

@Injectable({
providedIn: 'root'
})
export class PedidoService {
private apiUrl = 'https://localhost:5001/api/v1/pedidos'; // Ajustar URL según la configuración

constructor(private http: HttpClient) { }

crearPedido(pedido: Pedido): Observable<any> {
    return this.http.post<any>(this.apiUrl, pedido);
}
}