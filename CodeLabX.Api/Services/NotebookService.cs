﻿using CodeLabX.ActiveXData;
using CodeLabX.Api.Models;
using CodeLabX.DependencyInjection;
using CodeLabX.EntityFramework.Repository;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CodeLabX.Api.Services
{
    public class NotebookService
    {
        private readonly IRepository repository;
        private readonly ISqlDatabase sqlDatabase;

        public NotebookService(IRepository repository, ISqlDatabase sqlDatabase)
        {
            this.repository = repository;
            this.sqlDatabase = sqlDatabase;
        }

        public async Task AddAsync(string name)
        {
            await repository.AddAsync(new Notebook { Name = name });
            await repository.SaveChangesAsync();
        }

        public async Task<DataTable> GetNotes()
        {
            return await sqlDatabase.GetData("select * from Notebook");
        }

        public async Task<DataTable> GetData(string query)
        {
            var dataTable = new DataTable();
            try
            {
                using (var con = new SqlConnection(Configuration.ConnectionString))
                {
                    var command = new SqlCommand(query, con);
                    con.Open();

                    var reader = command.ExecuteReader();
                    //dataTable.Load(reader);
                    while (reader.Read())
                    {
                        var record = (IDataRecord)reader;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return await Task.FromResult(dataTable);
        }

        public void ExecuteStordProc(string stordProc, Action<object> callback = null, List<SqlParameter> sqlParameters = null)
        {
            using var con = new SqlConnection(Configuration.ConnectionString);
            con.Open();

            using var command = new SqlCommand(stordProc, con);
            command.CommandType = CommandType.StoredProcedure;

            if (sqlParameters is not null)
                command.Parameters.AddRange(sqlParameters.ToArray());

            command.ExecuteNonQuery();
            con.Close();

            if (callback is not null)
                callback(command.Parameters);
        }
    }
}
