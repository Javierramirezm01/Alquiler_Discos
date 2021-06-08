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
    public class AlquilerController : ControllerBase
    {
        private readonly Context _miBd;

        public AlquilerController(Context miBd)
        {
            _miBd = miBd;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var Lista = (from i in _miBd.alquilers
                             select new AlquilerViewModel
                             {
                                 Id = i.Id,
                                 nroAlquiler = i.nroAlquiler,
                                 fechaAlquiler = i.fechaAlquiler,
                                 valorAlquiler = i.valorAlquiler,
                                 Cliente = _miBd.clientes.Where(c => c.Id == i.ClienteId).FirstOrDefault(),
                                 DetallesAlquiler = _miBd.detalleAlquilers.Include("Producto").Where(d => d.AlquilerId == i.Id).ToList()
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
        public IActionResult Add(AlquilerViewModel oAlquiler)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                Alquiler alquiler = new Alquiler();
                alquiler.nroAlquiler = oAlquiler.nroAlquiler;
                alquiler.fechaAlquiler = oAlquiler.fechaAlquiler;
                alquiler.valorAlquiler = oAlquiler.valorAlquiler;
                alquiler.ClienteId = oAlquiler.ClienteId;
                
                _miBd.alquilers.Add(alquiler);
                _miBd.SaveChanges();

                foreach (var item in oAlquiler.ProductoIds)
                {
                    DetalleAlquiler detalle = new DetalleAlquiler();
                    detalle.AlquilerId = alquiler.Id;
                    detalle.ProductoId = item;
                    _miBd.detalleAlquilers.Add(detalle);
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
        public IActionResult Update(AlquilerViewModel oAlquiler)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var alquiler = _miBd.alquilers.Find(oAlquiler.Id);
                alquiler.nroAlquiler = oAlquiler.nroAlquiler;
                alquiler.fechaAlquiler = oAlquiler.fechaAlquiler;
                alquiler.valorAlquiler = oAlquiler.valorAlquiler;
                alquiler.ClienteId = oAlquiler.ClienteId;

                _miBd.alquilers.Update(alquiler);
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
                var alquiler = _miBd.alquilers.Find(Id);
                _miBd.alquilers.Remove(alquiler);
                _miBd.SaveChanges();
                oRespuesta.Exito = 1;


            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;

            }

            return Ok(oRespuesta);
        }
        [HttpGet("Clientes")]
        public IActionResult GetClientes()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var Lista = _miBd.clientes.Where(C => C.Estado == true).ToList();
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
