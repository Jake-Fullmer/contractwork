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
    internal Bid GetBid(Bid bid)
    {
      string sql = "SELECT * FROM bids WHERE jobId = @JobId AND contractorId = @ContractorId";
      return _db.QueryFirstOrDefault<Bid>(sql, bid);
    }

    public IEnumerable<Bid> GetBidsByJobId(int jobId)
    {
      string sql = @"
                SELECT * FROM bids b
                INNER JOIN contractors c ON c.id = b.contractorId
                WHERE (jobId = @jobId) 
            ";
      return _db.Query<Bid>(sql, new { jobId });
    }
    public void AddContractor(int jobId, int contractorId, int price)
    {
      string sql = @"
            INSERT INTO bids
            (jobId, contractorId, price)
            VALUES
            (@jobId, @contractorId, @price)";
      _db.Execute(sql, new { jobId, contractorId, price });
    }

    public void RemoveContractorFromJob(int id)
    {
      string sql = "DELETE FROM bids WHERE id = @id";
      _db.Execute(sql, new { id });
    }



  }
}