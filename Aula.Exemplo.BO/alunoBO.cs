using System;
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
    /// Classe de Negocios da Tabela aluno
    /// </summary>
    public class alunoBO : IBaseBO<aluno, int>
    {

        #region Variaveis Locais
        /// <summary>
        /// Define o objeto de acesso a dados.
        /// </summary>
        protected alunoDAO alunoDAO;
        /// <summary>
        /// Objeto de segurança
        /// </summary>
        protected ObjectSecurity objectSecurity;

        #endregion

        #region Construtores

        /// <summary>
        /// Inicializa uma instância da classe. Cria uma nova conexao com o banco de dados
        /// </summary>
        public alunoBO(ObjectSecurity pObjectSecurity) : base()
        {
            alunoDAO = new alunoDAO(ConnectionFactory.GetDbConnectionDefault(), pObjectSecurity);
            objectSecurity = pObjectSecurity;
        }

        /// <summary>
        /// Inicializa uma instância da classe. Recebendo como parametro a conexao com banco de dados
        /// </summary>
        public alunoBO(System.Data.IDbConnection pIDbConnection, ObjectSecurity pObjectSecurity) : base()
        {
            alunoDAO = new alunoDAO(pIDbConnection, pObjectSecurity);
            objectSecurity = pObjectSecurity;
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the <see cref="alunoBO"/> is reclaimed by garbage collection.
        /// </summary>
        ~alunoBO()
        {
            alunoDAO.Dispose();
        }

        #endregion

        #region WOLI - Métodos Básicos

        /// <summary>
        /// Realiza o insert do objeto por stored Procedure
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser inserido</param>
        /// <returns>Objeto Inserido</returns>
        public aluno Insert(aluno pObject)
        {
            alunoDAO.BeginTransaction();
            try
            {
                aluno alunoAux = alunoDAO.InsertByStoredProcedure(pObject);
                pObject.idAluno = alunoAux.idAluno;

                alunoDAO.CommitTransaction();
            }
            catch (Exception ex)
            {
                alunoDAO.RollbackTransaction();
                throw ex;
            }
            return pObject;
        }

        /// <summary>
        /// Realiza o update do objeto por stored Procedure
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser atualizado</param>
        /// <returns>Objeto Atualizado</returns>
        public aluno Update(aluno pObject)
        {
            alunoDAO.BeginTransaction();
            try
            {
                alunoDAO.UpdateByStoredProcedure(pObject);

                alunoDAO.CommitTransaction();
            }
            catch (Exception ex)
            {
                alunoDAO.RollbackTransaction();
                throw ex;
            }
            return pObject;
        }

        /// <summary>
        /// Realiza a deleção do objeto por stored Procedure
        /// </summary>
        /// <param name="pidaluno">PK da tabela</param>
        /// <returns>Quantidade de Registros deletados</returns>
        public int Delete(int pidaluno)
        {
            int iRetorno = 0;
            alunoDAO.BeginTransaction();
            try
            {
                iRetorno = alunoDAO.DeleteByStoredProcedure(pidaluno, false, objectSecurity.UserSystem);
                alunoDAO.CommitTransaction();
            }
            catch (Exception ex)
            {
                alunoDAO.RollbackTransaction();
                throw ex;
            }
            return iRetorno;
        }

        /// <summary>
        /// Retorna registro pela PK
        /// </summary>
        /// <param name="pidaluno">PK da tabela</param>
        /// <returns>Registro da PK</returns>
        public aluno SelectByPK(int pidaluno)
        {
            return alunoDAO.SelectByPK(pidaluno);
        }

        /// <summary>
        /// Realiza a busca Lookup
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser atribuidos no filtro</param>
        /// <returns>Lista de Objetos que atendam ao filtro</returns>
        public IList<aluno> ListForLookup(aluno pObject)
        {
            return alunoDAO.ListForLookup(pObject);
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
        public IList<aluno> ListForGrid(aluno pObject, int pNumRegPag, int pNumPagina, string pDesOrdem, out int pNumTotReg)
        {
            return alunoDAO.ListForGrid(pObject, pNumRegPag, pNumPagina, pDesOrdem, out pNumTotReg);
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
                alunoDAO = null;

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
