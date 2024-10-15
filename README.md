# Supermercado-Consola

## Gestión de un supermercado.

Se desea automatizar el proceso de venta de los artículos de un supermercado.

De los artículos se conoce código interno, código de barras, descripción, descripción abreviada
(utilizada en el ticket), y su precio. 

Además el supermercado cuenta con 5 cajas
registradoras y cada una de ellas registra durante la jornada toda la información de las
ventas efectuadas d1esde las cajas.


Cada venta contiene un conjunto de artículos, escaneados en la caja, y por artículo
se registra la información: número venta, número de caja, código de barra del artículo y
cantidad de unidades vendidas.


Al final del día se utiliza la información registrada en las 5 cajas para actualizar las
existencias globales del supermercado en función de los artículos vendidos.

El inventario
de existencias guarda por cada artículo a la venta la siguiente información: código de
barras artículo y stock.


# Se pide realizar al final del día:

* Venta total por caja (dinero)
* Venta total de artículos (código y cantidad por caja)
* Stock de artículos.