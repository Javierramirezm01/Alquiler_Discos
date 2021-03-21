﻿using Microsoft.AspNetCore.Http;
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
    public class SancionController : ControllerBase
    {
        private readonly Context _miBd;

        public SancionController(Context miBd)
        {
            _miBd = miBd;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var Lista = _miBd.sancions.Include("Alquiler").ToList();
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
        public IActionResult Add(SancionViewModel oSancion)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                Sancion sancion = new Sancion();
                sancion.TipoSancion = oSancion.TipoSancion;
                sancion.NroDiasSancion = oSancion.NroDiasSancion;
                _miBd.sancions.Add(sancion);
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
        public IActionResult Update(SancionViewModel oSancion)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                Sancion sancion = new Sancion();
                sancion.TipoSancion = oSancion.TipoSancion;
                sancion.NroDiasSancion = oSancion.NroDiasSancion;
                _miBd.sancions.Add(sancion);
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
                var sancion = _miBd.sancions.Find(Id);
                _miBd.sancions.Remove(sancion);
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
