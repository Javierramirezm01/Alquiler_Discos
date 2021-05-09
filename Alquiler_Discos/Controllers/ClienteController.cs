using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alquiler_Discos.Models;
using Alquiler_Discos.Response;
using Alquiler_Discos.ViewModels;

namespace Alquiler_Discos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly Context _miBd;

        public ClienteController(Context miBd)
        {
            _miBd = miBd;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var Lista = _miBd.clientes.ToList();
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
        public IActionResult Add(ClienteViewModel oCliente)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                Cliente cliente = new Cliente();
                cliente.Nombre = oCliente.Nombre;
                cliente.Direccion = oCliente.Direccion;
                cliente.Telefono = oCliente.Telefono;
                cliente.Email = oCliente.Email;
                cliente.FechaNacimineto = oCliente.FechaNacimineto;
                cliente.FechaInscripcion = oCliente.FechaInscripcion;
                cliente.TemaInteres = oCliente.TemaInteres;
                cliente.Estado = true;
                cliente.NroDNI = oCliente.NroDNI;
                _miBd.clientes.Add(cliente);
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
        public IActionResult Update(ClienteViewModel oCliente)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var cliente = _miBd.clientes.Find(oCliente.Id);
                cliente.Nombre = oCliente.Nombre;
                cliente.Direccion = oCliente.Direccion;
                cliente.Telefono = oCliente.Telefono;
                cliente.Email = oCliente.Email;
                cliente.FechaNacimineto = oCliente.FechaNacimineto;
                cliente.FechaInscripcion = oCliente.FechaInscripcion;
                cliente.TemaInteres = oCliente.TemaInteres;
                cliente.NroDNI = oCliente.NroDNI;
                _miBd.clientes.Update(cliente);
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
                var cliente = _miBd.clientes.Find(Id);
                if (cliente.Estado)
                {
                    cliente.Estado = false;
                }

                else
                {
                    cliente.Estado = true;
                }

                _miBd.clientes.Update(cliente);
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
