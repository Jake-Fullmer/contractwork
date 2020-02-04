using System;
using System.Collections.Generic;
using contractors.Models;
using contractors.Repositories;

namespace contractors.Services
{
  public class BidsService
  {
    private readonly BidsRepository _repo;
    private readonly JobsRepository _jrepo;
    private readonly ContractorsRepository _crepo;

    public BidsService(BidsRepository repo, ContractorsRepository crepo, JobsRepository jrepo)
    {
      _repo = repo;
      _crepo = crepo;
      _jrepo = jrepo;
    }



    public string AddContractor(int contractorId, int jobId)
    {
      Job job = _jrepo.Get(jobId);
      if (job == null) { throw new Exception("Invalid Job Id Homie"); }
      Contractor contractorToAdd = _crepo.Get(contractorId);
      if (contractorToAdd == null) { throw new Exception("Invalid Contractor Id Homie"); }
      _repo.AddContractor(jobId, contractorId);
      return "Successfully added Contractor to Job";
    }


    public IEnumerable<Contractor> GetContractors(int jobId)
    {
      Job job = _jrepo.Get(jobId);
      if (job == null) { throw new Exception("Invalid Id Homie"); }
      return _repo.GetContractorsByJobId(jobId);

    }

    public string RemoveContractor(Bid bid)
    {
      Bid job = _repo.GetBid(bid);
      if (job == null) { throw new Exception("Invalid Info Homie"); }
      _repo.RemoveContractorFromJob(job.Id);
      return "Successfully Booted";
    }
  }
}