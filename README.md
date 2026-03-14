# 🛒 Mi Tiendita - Sistema de Control

Este es un programa sencillo hecho en **C#** para ayudar a manejar un 
pequeño negocio desde la computadora. Permite llevar el control de qué 
productos tienes, cuánto cuestan y hacer ventas rápidas.

## 🌟 ¿Qué puedes hacer con este programa?
* **Guardar Productos**: Puedes registrar cosas nuevas (como "Leche" o "Pan") con su precio y cuántos tienes.
* **Controlar el Inventario**: Si te llega más mercancía, puedes sumar al stock existente fácilmente.
* **Hacer Ventas**: Puedes elegir varios productos, el programa resta lo que vendiste de tu lista y al final te da el total a cobrar (tu factura).
* **Alertas de "Se acaba el producto"**: El programa te avisa con letras rojas si te quedan 5 unidades o menos de algo para que compres más.
* **No pierdes tus datos**: Todo se guarda en un archivo de texto llamado `inventario.txt`. Aunque apagues la computadora, tus productos seguirán ahí la próxima vez que abras el programa.

## 📂 ¿Cómo está organizado el código?
* **Inicio.cs**: Es el botón de "encendido" del programa.
* **menu.cs**: Contiene todas las preguntas y opciones que ves en pantalla.
* **funciones.cs**: Es el "cerebro" que hace las cuentas y guarda la información en el archivo.
* **data.cs**: Es el lugar donde se guardan las listas de productos mientras el programa está abierto.