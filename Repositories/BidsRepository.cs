using System.Collections.Generic;
using System.Data;
using Dapper;
using contractors.Models;

namespace contractors.Repositories
{
  public class BidsRepository
  {
    private readonly IDbConnection _db;
    public BidsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal Bid GetBid(Bid vks)
    {
      string sql = "SELECT * FROM bids WHERE jobId = @JobId AND contractorId = @ContractorId";
      return _db.QueryFirstOrDefault<Bid>(sql, vks);
    }

    public IEnumerable<Contractor> GetContractorsByJobId(int jobId)
    {
      string sql = @"
                SELECT * FROM bids b
                INNER JOIN contractors c ON c.id = b.contractorId
                WHERE (jobId = @jobId) 
            ";
      return _db.Query<Contractor>(sql, new { jobId });
    }
    public void AddContractor(int jobId, int contractorId)
    {
      string sql = @"
            INSERT INTO bids
            (jobId, contractorId)
            VALUES
            (@jobId, @contractorId)";
      _db.Execute(sql, new { jobId, contractorId });
    }

    public void RemoveContractorFromJob(int id)
    {
      string sql = "DELETE FROM bids WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}