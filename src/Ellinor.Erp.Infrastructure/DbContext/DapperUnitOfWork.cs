﻿using System.Data;
using Microsoft.Data.SqlClient;
using Ellinor.Erp.Domain.Core;


namespace Ellinor.Erp.Infrastructure;

public class DapperUnitOfWork : IUnitOfWork
{
    private readonly IDbConnection _connection;
    private IDbTransaction _transaction;

 

    public DapperUnitOfWork(string connectionString)
    {
        _connection = new SqlConnection (connectionString);
        _connection.Open();
        _transaction = _connection.BeginTransaction();
    }

    public int Commit()
    {
        try
        {
            _transaction.Commit();
            return 1; // Successfully committed
        }
        catch
        {
            _transaction.Rollback();
            return 0; // Indicates a failure
        }
        finally
        {
            _transaction?.Dispose();
            _transaction = _connection.BeginTransaction();
        }
    }

    public void Dispose()
    {
        _transaction?.Commit();
        _connection?.Close();
    }

   
}