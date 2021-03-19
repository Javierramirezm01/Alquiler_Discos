using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alquiler_Discos.Models;
using Alquiler_Discos.Response;
using Alquiler_Discos.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alquiler_Discos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CdController : ControllerBase
    {
        private readonly Context _miBd;

        public CdController(Context miBd)
        {
            _miBd = miBd;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var Lista = _miBd.cds.ToList();
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
        public IActionResult Add(CdViewModel oCd)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                Cd cd = new Cd();
                cd.codigoTitulo = oCd.codigoTitulo;
                cd.condicion = oCd.condicion;
                cd.estado = oCd.estado;
                cd.ubicacion = oCd.ubicacion;
                _miBd.cds.Add(cd);
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
        public IActionResult Update(CdViewModel oCd)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var cd = _miBd.cds.Find(oCd.Id);
                cd.codigoTitulo = oCd.codigoTitulo;
                cd.condicion = oCd.condicion;
                cd.estado = oCd.estado;
                cd.ubicacion = oCd.ubicacion;
                _miBd.cds.Update(cd);
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
                var cd = _miBd.cds.Find(Id);
                _miBd.cds.Remove(cd);
                _miBd.SaveChanges();
                oRespuesta.Exito = 1;


            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;

            }

            return Ok(oRespuesta);
        }
    }
}