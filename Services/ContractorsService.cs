using System;
using System.Collections.Generic;
using contractors.Models;
using contractors.Repositories;

namespace contractors.Services
{
  public class ContractorsService
  {
    private readonly ContractorsRepository _repo;
    public ContractorsService(ContractorsRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<Contractor> Get()
    {
      return _repo.Get();
    }

    public Contractor Get(int id)
    {
      Contractor exists = _repo.Get(id);
      if (exists == null) { throw new Exception("Invalid Id Homie"); }
      return exists;
    }

    public Contractor Create(Contractor newContractor)
    {
      int id = _repo.Create(newContractor);
      newContractor.Id = id;
      return newContractor;
    }
    public string Delete(int id, string userId)
    {
      _repo.Delete(id, userId);
      return "Successfully Deleted";
    }
  }
}