using GS.CodingChallenge.Application.Repositories;
using GS.CodingChallenge.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GS.CodingChallenge.Application.Services
{
    public class ProjectService
    {
        private readonly UserRepository _userRepository;
        private readonly ProjectRepository _repository;

        public ProjectService(ProjectRepository repository, UserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public async Task<ICollection<Project>> GetAll()
        {
            var entities = await _repository.GetAll();

            return entities;
        }


        public async Task<ICollection<Project>> GetByUser(int userId)
        {
            var user = _userRepository.FindBy(u => u.Id == userId, new string[] {
                nameof(User.UserProject),
                $"{nameof(User.UserProject)}.{nameof(Project)}"
            }).First();
            var entities = new List<Project>();
            if (user != null)
            {
                foreach (var userProject in user.UserProject)
                {                    
                    entities.Add(userProject.Project);
                }
            }

            return entities;
        }

        public async Task<Project> Get(int id)
        {
            var entity = await _repository.GetById(id);

            return entity;
        }

        public async Task<Project> Add(Project entity)
        {
            await _repository.Add(entity);

            return entity;
        }

        public async Task Update(Project entity)
        {
            await _repository.Update(entity);
        }

        public async Task Delete(int id)
        {
            await _repository.Remove(id);
        }
    }
}
