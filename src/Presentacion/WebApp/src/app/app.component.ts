import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Pedido, PedidoService, Producto } from './service/pedidoService';
import {CommonModule} from '@angular/common';
import { FormsModule } from '@angular/forms'; // Importa FormsModule  


@Component({
  selector: 'app-root',
  imports: [RouterOutlet,CommonModule,FormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'WebApp';
  pedido: Pedido = {
    cedula: '',
    direccion: '',
    productos: []
};

constructor(private pedidoService: PedidoService) {}

agregarProducto() {
  // Se agrega un producto vacío para llenar sus datos
  this.pedido.productos.push({ nombre: '', precio: 0, cantidad: 1 });
}

calcularTotal(): number {
  return this.pedido.productos.reduce((total, prod: Producto) => total + (prod.precio * prod.cantidad), 0);
}

enviarPedido() {
  // Opcional: Se puede asignar el total si se requiere
  // this.pedido.valorTotal = this.calcularTotal();
  this.pedidoService.crearPedido(this.pedido).subscribe(
  response => {
      console.log('Pedido creado:', response);
      // Limpiar el formulario o mostrar mensaje de éxito
  },
  error => {
      console.error('Error al crear pedido:', error);
  }
  );
}
}
