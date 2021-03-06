﻿using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Sistema.Arquitetura.Library.Core.Interface;
using Sistema.Arquitetura.Library.Core.Util.Security;
using Aula.Exemplo.VO;
using Aula.Exemplo.DAO;
using Aula.Exemplo.BO.Factory;


namespace Aula.Exemplo.BO
{

    /// <summary>
    /// Classe de Negocios da Tabela estadoCivil
    /// </summary>
    public class estadoCivilBO : IBaseBO<estadoCivil, int>
    {

        #region Variaveis Locais
        /// <summary>
        /// Define o objeto de acesso a dados.
        /// </summary>
        protected estadoCivilDAO estadoCivilDAO;
        /// <summary>
        /// Objeto de segurança
        /// </summary>
        protected ObjectSecurity objectSecurity;

        #endregion

        #region Construtores

        /// <summary>
        /// Inicializa uma instância da classe. Cria uma nova conexao com o banco de dados
        /// </summary>
        public estadoCivilBO(ObjectSecurity pObjectSecurity) : base()
        {
            estadoCivilDAO = new estadoCivilDAO(ConnectionFactory.GetDbConnectionDefault(), pObjectSecurity);
            objectSecurity = pObjectSecurity;
        }

        /// <summary>
        /// Inicializa uma instância da classe. Recebendo como parametro a conexao com banco de dados
        /// </summary>
        public estadoCivilBO(System.Data.IDbConnection pIDbConnection, ObjectSecurity pObjectSecurity) : base()
        {
            estadoCivilDAO = new estadoCivilDAO(pIDbConnection, pObjectSecurity);
            objectSecurity = pObjectSecurity;
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the <see cref="estadoCivilBO"/> is reclaimed by garbage collection.
        /// </summary>
        ~estadoCivilBO()
        {
            estadoCivilDAO.Dispose();
        }

        #endregion

        #region WOLI - Métodos Básicos

        /// <summary>
        /// Realiza o insert do objeto por stored Procedure
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser inserido</param>
        /// <returns>Objeto Inserido</returns>
        public estadoCivil Insert(estadoCivil pObject)
        {
            estadoCivilDAO.BeginTransaction();
            try
            {
                estadoCivil estadoCivilAux = estadoCivilDAO.InsertByStoredProcedure(pObject);
                pObject.idEstadoCivil = estadoCivilAux.idEstadoCivil;

                estadoCivilDAO.CommitTransaction();
            }
            catch (Exception ex)
            {
                estadoCivilDAO.RollbackTransaction();
                throw ex;
            }
            return pObject;
        }

        /// <summary>
        /// Realiza o update do objeto por stored Procedure
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser atualizado</param>
        /// <returns>Objeto Atualizado</returns>
        public estadoCivil Update(estadoCivil pObject)
        {
            estadoCivilDAO.BeginTransaction();
            try
            {
                estadoCivilDAO.UpdateByStoredProcedure(pObject);

                estadoCivilDAO.CommitTransaction();
            }
            catch (Exception ex)
            {
                estadoCivilDAO.RollbackTransaction();
                throw ex;
            }
            return pObject;
        }

        /// <summary>
        /// Realiza a deleção do objeto por stored Procedure
        /// </summary>
        /// <param name="pidestadoCivil">PK da tabela</param>
        /// <returns>Quantidade de Registros deletados</returns>
        public int Delete(int pidestadoCivil)
        {
            int iRetorno = 0;
            estadoCivilDAO.BeginTransaction();
            try
            {
                iRetorno = estadoCivilDAO.DeleteByStoredProcedure(pidestadoCivil, false, objectSecurity.UserSystem);
                estadoCivilDAO.CommitTransaction();
            }
            catch (Exception ex)
            {
                estadoCivilDAO.RollbackTransaction();
                throw ex;
            }
            return iRetorno;
        }

        /// <summary>
        /// Retorna registro pela PK
        /// </summary>
        /// <param name="pidestadoCivil">PK da tabela</param>
        /// <returns>Registro da PK</returns>
        public estadoCivil SelectByPK(int pidestadoCivil)
        {
            return estadoCivilDAO.SelectByPK(pidestadoCivil);
        }

        /// <summary>
        /// Realiza a busca Lookup
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser atribuidos no filtro</param>
        /// <returns>Lista de Objetos que atendam ao filtro</returns>
        public IList<estadoCivil> ListForLookup(estadoCivil pObject)
        {
            return estadoCivilDAO.ListForLookup(pObject);
        }

        /// <summary>
        /// Realiza a busca pelos parametros informados no objeto por stored Procedure
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser atribuidos no filtro</param>
        /// <param name="pNumRegPag">Número de registros por página</param>
        /// <param name="pNumPagina">Página corrente</param>
        /// <param name="pDesOrdem">Critério de ordenação</param>
        /// <param name="pNumTotReg">Quantidade de registros que a consulta retorna</param>
        /// <returns>Lista de Objetos que atendam ao filtro</returns>
        public IList<estadoCivil> ListForGrid(estadoCivil pObject, int pNumRegPag, int pNumPagina, string pDesOrdem, out int pNumTotReg)
        {
            return estadoCivilDAO.ListForGrid(pObject, pNumRegPag, pNumPagina, pDesOrdem, out pNumTotReg);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {

            if (!disposedValue)
            {

                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }
                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                objectSecurity = null;
                estadoCivilDAO = null;

                disposedValue = true;
            }
        }

        /// <summary>
        /// This code added to correctly implement the disposable pattern.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        #endregion

        #endregion

        #region Metodos Personalizados

        #endregion
    }
}

