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
    public class DetalleAlquilerController : ControllerBase
    {
        private readonly Context _miBd;

        public DetalleAlquilerController(Context miBd)
        {
            _miBd = miBd;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var Lista = _miBd.detalleAlquilers.Include("Cd").Include("Alquiler").ToList();
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
        public IActionResult Add(DetalleAlquilerViewModel oDetalleAlquiler)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                DetalleAlquiler detalleAlquiler = new DetalleAlquiler();
                detalleAlquiler.item = oDetalleAlquiler.item;
                detalleAlquiler.diasPrestamo = oDetalleAlquiler.diasPrestamo;
                detalleAlquiler.fechaDevolucion = oDetalleAlquiler.fechaDevolucion;
                detalleAlquiler.CdId = oDetalleAlquiler.CdId;
                detalleAlquiler.AlquilerId = oDetalleAlquiler.AlquilerId;
                
                _miBd.detalleAlquilers.Add(detalleAlquiler);
                _miBd.SaveChanges();
                oRespuesta.Exito = 1;


            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;

            }

            return Ok(oRespuesta);
        }

        [HttpPut]
        public IActionResult Update(DetalleAlquilerViewModel oDetalleAlquiler)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var detalleAlquiler = _miBd.detalleAlquilers.Find(oDetalleAlquiler.Id);
                detalleAlquiler.item = oDetalleAlquiler.item;
                detalleAlquiler.diasPrestamo = oDetalleAlquiler.diasPrestamo;
                detalleAlquiler.fechaDevolucion = oDetalleAlquiler.fechaDevolucion;
                detalleAlquiler.CdId = oDetalleAlquiler.CdId;
                detalleAlquiler.AlquilerId = oDetalleAlquiler.AlquilerId;
                _miBd.detalleAlquilers.Update(detalleAlquiler);
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
                var detalleAlquiler = _miBd.detalleAlquilers.Find(Id);
                _miBd.detalleAlquilers.Remove(detalleAlquiler);
                _miBd.SaveChanges();
                oRespuesta.Exito = 1;


            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;

            }

            return Ok(oRespuesta);
        }

        [HttpGet("Cd")]
        public IActionResult GetCd()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var Lista = _miBd.cds.Where(Cd => Cd.estado == true).ToList();
                oRespuesta.Exito = 1;
                oRespuesta.Datos = Lista;

            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;

            }

            return Ok(oRespuesta);
        }

        [HttpGet("Alquiler")]
        public IActionResult GetAlquiler()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var Lista = _miBd.alquilers.ToList();
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
