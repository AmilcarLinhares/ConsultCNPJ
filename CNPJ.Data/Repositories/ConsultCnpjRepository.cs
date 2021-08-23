using CNPJ.Data.Context;
using CNPJ.Domain.DTO;
using CNPJ.Domain.Interfaces;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNPJ.Data.Extension;


namespace CNPJ.Data.Repositories
{
    public class ConsultCnpjRepository : IConsultCnpjRepository, IDisposable
    {
        private readonly ConsultCnpjDbContext db;

        public ConsultCnpjRepository(ConsultCnpjDbContext ConsultCnpjDbContext)
        {
            this.db = ConsultCnpjDbContext;
        }

        public async Task<bool> AddEmpresaAsync(ResponseApiWsDTO model)
        {
            var sql = new StringBuilder();
            sql.Append("INSERT INTO EMPRESA (");
            sql.Append(" MsgErro");
            sql.Append(", Situacao");
            sql.Append(", Bairro");
            sql.Append(", Logradouro");
            sql.Append(", Numero");
            sql.Append(", Cep");
            sql.Append(", Municipio");
            sql.Append(", Porte");
            sql.Append(", Abertura");
            sql.Append(", natureza_juridica");
            sql.Append(", Fantasia");
            sql.Append(", Cnpj");
            sql.Append(", ultima_atualizacao");
            sql.Append(", Status");
            sql.Append(", Complemento");
            sql.Append(", Email");
            sql.Append(", Efr");
            sql.Append(", MotivoSituacao");
            sql.Append(", SituacaoEspecial");
            sql.Append(", DataSituacaoEspecial");
            sql.Append(", capital_social");
            sql.Append(", DataSituacao");
            sql.Append(", Tipo");
            sql.Append(", Nome");
            sql.Append(", Uf");
            sql.Append(", Telefone");
            sql.Append(" ) VALUES (");
            sql.Append($" {model.MsgErro}");
            sql.Append($", {model.Situacao}");
            sql.Append($", {model.Bairro}");
            sql.Append($", {model.Logradouro}");
            sql.Append($", {model.Numero}");
            sql.Append($", {model.Cep}");
            sql.Append($", {model.Municipio}");
            sql.Append($", {model.Porte}");
            sql.Append($", {model.Abertura}");
            sql.Append($", {model.natureza_juridica}");
            sql.Append($", {model.Fantasia}");
            sql.Append($", {model.Cnpj}");
            sql.Append($", {model.ultima_atualizacao}");
            sql.Append($", {model.Status}");
            sql.Append($", {model.Complemento}");
            sql.Append($", {model.Email}");
            sql.Append($", {model.Efr}");
            sql.Append($", {model.MotivoSituacao}");
            sql.Append($", {model.SituacaoEspecial}");
            sql.Append($", {model.DataSituacaoEspecial}");
            sql.Append($", {model.capital_social}");
            sql.Append($", {model.DataSituacao}");
            sql.Append($", {model.Tipo}");
            sql.Append($", {model.Nome}");
            sql.Append($", {model.Uf}");
            sql.Append($", {model.Telefone}");
            sql.Append($" )");


            var result = await db.Database.GetDbConnection()
                .ExecuteAsync(sql.ToString(), null
                , transaction: db.Database.CurrentTransaction.GetTransaction());

            return result > 0;
        }

        public async Task<bool> AddDiretorAsync(ResponseQsaApiWsDTO model)
        {
            //var sql = new StringBuilder();
            //sql.Append("select ");
            //sql.Append("AlertAttendanceId ");
            //sql.Append("from AlertAttendanceConnection ");
            //sql.Append("Where AlertAttendanceId = @alertAttendanceId ");

            //long result = (await db.Database.GetDbConnection().QueryAsync<long>(sql.ToString()
            //    , new { alertAttendanceId }
            //    , transaction: db.Database.CurrentTransaction.GetTransaction())).FirstOrDefault();
            return true;
        }

        public async Task<bool> AddAtivPrincipalAsync(ResponseApApiWsDTO model)
        {
            //var sql = new StringBuilder();
            //sql.Append("select ");
            //sql.Append("AlertAttendanceId ");
            //sql.Append("from AlertAttendanceConnection ");
            //sql.Append("Where AlertAttendanceId = @alertAttendanceId ");

            //long result = (await db.Database.GetDbConnection().QueryAsync<long>(sql.ToString()
            //    , new { alertAttendanceId }
            //    , transaction: db.Database.CurrentTransaction.GetTransaction())).FirstOrDefault();
            return true;
        }

        public async Task<bool> AddAtivSecundariaAsync(ResponseAsApiWsDTO model)
        {
            //var sql = new StringBuilder();
            //sql.Append("select ");
            //sql.Append("AlertAttendanceId ");
            //sql.Append("from AlertAttendanceConnection ");
            //sql.Append("Where AlertAttendanceId = @alertAttendanceId ");

            //long result = (await db.Database.GetDbConnection().QueryAsync<long>(sql.ToString()
            //    , new { alertAttendanceId }
            //    , transaction: db.Database.CurrentTransaction.GetTransaction())).FirstOrDefault();
            return true;
        }

        public void Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
