﻿using Bombones.Comun;
using Bombones.Comun.IRepositorios;
using Bombones.Comun.IServicios;
using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using System.Data;

namespace Bombones.Servicios.Servicios
{
    public class ServiciosClientes : IServiciosClientes
    {
        private readonly IRepositorioClientes _repositorio;
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public ServiciosClientes(IDbConnectionFactory dbConnectionFactory, IRepositorioClientes repositorio)
        {
            _repositorio = repositorio;
            _dbConnectionFactory = dbConnectionFactory;
        }

        public Cliente? GetClientePorId(int clienteId)
        {
            IDbTransaction tran = null!;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                conn.Open();
                using (tran = conn.BeginTransaction())
                {
                    try
                    {
                        return _repositorio.GetClientePorId(conn, tran, clienteId);
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }

            }

        }

        public List<Cliente> GetLista()
        {
            IDbTransaction tran = null!;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                conn.Open();
                using (tran = conn.BeginTransaction())
                {
                    try
                    {
                        return _repositorio.GetLista(conn, tran);
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }

            }
        }
    }
}
