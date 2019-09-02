using GS.CodingChallenge.Application.Repositories;
using GS.CodingChallenge.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GS.CodingChallenge.Application.Services
{
    public class UserService
    {
        private readonly UserRepository _repository;

        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<User>> GetAll()
        {
            var entities = await _repository.GetAll();

            return entities;
        }

        public async Task<User> Get(int id)
        {
            var entity = await _repository.GetById(id);

            return entity;
        }

        public async Task<User> Add(User entity)
        {
            await _repository.Add(entity);

            return entity;
        }

        public async Task Update(User entity)
        {
            await _repository.Update(entity);
        }

        public async Task Delete(int id)
        {
            await _repository.Remove(id);
        }
    }
}
