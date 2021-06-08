using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alquiler_Discos.Models;
using Alquiler_Discos.Response;
using Alquiler_Discos.ViewModels;
using Microsoft.EntityFrameworkCore;


namespace Alquiler_Discos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly Context _miBd;

        public VentaController(Context miBd)
        {
            _miBd = miBd;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var Lista = (from i in _miBd.ventas
                             select new VentaViewModel
                             {
                                 Id = i.Id,
                                 CodigoVenta = i.CodigoVenta,
                                 FechaVenta = i.FechaVenta,
                                 ValorVenta = i.ValorVenta,
                                 Cliente = _miBd.clientes.Where(c => c.Id == i.ClienteId).FirstOrDefault(),
                                 DetallesVentas = _miBd.detalleVentas.Include("Producto").Where(d => d.VentaId == i.Id).ToList()
                             }).ToList();
                oRespuesta.Exito = 1;
                oRespuesta.Datos = Lista;

            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;

            }

            return Ok(oRespuesta);
        }

        [HttpPost]
        public IActionResult Add(VentaViewModel oVenta)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                Venta venta = new Venta();
                venta.CodigoVenta = oVenta.CodigoVenta;
                venta.ClienteId = oVenta.ClienteId;
                venta.FechaVenta = oVenta.FechaVenta;
                venta.ValorVenta = oVenta.ValorVenta;
                _miBd.ventas.Add(venta);
                _miBd.SaveChanges();

                foreach (var item in oVenta.ProductoIds)
                {
                    DetalleVenta detalle = new DetalleVenta();
                    detalle.VentaId = venta.Id;
                    detalle.ProductoId = item;
                    _miBd.detalleVentas.Add(detalle);
                    _miBd.SaveChanges();
                }
              

                oRespuesta.Exito = 1;
            }

            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;

            }

            return Ok(oRespuesta);
        }

        [HttpPut]
        public IActionResult Update(VentaViewModel oVenta)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var venta = _miBd.ventas.Find(oVenta.Id);
                venta.CodigoVenta = oVenta.CodigoVenta;
                venta.ClienteId = oVenta.ClienteId;
                venta.Cliente = oVenta.Cliente;
                venta.FechaVenta = oVenta.FechaVenta;
                venta.ValorVenta = oVenta.ValorVenta;

                _miBd.ventas.Update(venta);
                _miBd.SaveChanges();
                oRespuesta.Exito = 1;


            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;

            }

            return Ok(oRespuesta);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var venta = _miBd.ventas.Find(Id);
                _miBd.ventas.Remove(venta);
                _miBd.SaveChanges();
                oRespuesta.Exito = 1;


            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;

            }

            return Ok(oRespuesta);
        }

        [HttpGet ("Clientes")]
        public IActionResult GetClientes()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var Lista = _miBd.clientes.Where(C=>C.Estado==true).ToList();
                oRespuesta.Exito = 1;
                oRespuesta.Datos = Lista;

            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;

            }

            return Ok(oRespuesta);
        }

        [HttpGet("Productos")]
        public IActionResult GetProductos()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var Lista = _miBd.productos.ToList();
                oRespuesta.Exito = 1;
                oRespuesta.Datos = Lista;

            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;

            }

            return Ok(oRespuesta);
        }

    }
}