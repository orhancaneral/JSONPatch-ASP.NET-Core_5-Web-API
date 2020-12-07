using JsonPatchWebApi.Models;
using System;
using System.Collections.Generic;

namespace JsonPatchWebApi.Services
{
    public interface IDataService
    {
        Guid Add(Person person);
        Person GetBy(Guid id);
        List<Person> GetPeople();
    }
}