# Release Notes

## [v1.1.4 (2023-25-01)](https://github.com/epayco/sdk-.net/compare/v1.1.3...v1.1.4)
- Se corrige metodo para recibir entero y decimales en splitpayment
## [v1.1.3 (2022-11-04)](https://github.com/epayco/sdk-.net/compare/v1.1.2...v1.1.3)
- Se cambia tipo de atributos de splitpayment a string para que reciba decimales sin problemas
## [v1.1.2 (2022-08-05)](https://github.com/epayco/sdk-.net/compare/v1.1.1...v1.1.2)
- Se añade parametros city y country al request y response de medios de pagos que no lo tengan.
- Se añade optLab al response de crear transaccion con daviplata.
## [v1.1.1 (2022-05-10)](https://github.com/epayco/sdk-.net/compare/v1.1.0...v1.1.1)

- Se corrgie readme para agregar parametros ICO y receivers 
- Se mapea los extras en las respuesta de crear transaccion de los medios de pago
- Se encripta parametros IP y test para transaccion con PSE splitpayment
- se corrgie error de mapeo de receivers para cash y efectivo
- Se consultan los medios de pagos pagos activos para Efectivo

## [v1.0.13 (2021-02-23)](https://github.com/epayco/sdk-.net/compare/v1.0.11...v1.0.13)

- Se corrige varios errores relacionadas a la url de algunos de los metodos.
- Se actualiza la funcionalidad de pagos split.

## [v1.0.11 (2021-01-27)](https://github.com/epayco/sdk-.net/compare/v1.0.0...v1.0.11)

- feat(Split): Se agrega implementación de pagos split.
- feat(Método de pago)Se agrega método de pago Su Red dentro de las opciones para efectivo.