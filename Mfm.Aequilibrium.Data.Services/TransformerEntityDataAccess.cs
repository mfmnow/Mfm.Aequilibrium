using Mfm.Aequilibrium.Data.Contracts;
using Mfm.Aequilibrium.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mfm.Aequilibrium.Data.Services
{
    public class TransformerEntityDataAccess : GenericRepository<TransformerEntity>, ITransformerEntityDataAccess
    {
        private readonly ITestDbContext _context;

        public TransformerEntityDataAccess(TestDbContext testDbContext) : base(testDbContext)
        {
            _context = testDbContext;
        }

        public async Task<int> CreateTransformerEntity(string name, byte type, byte strength, byte intelligence, byte speed, byte endurance
            , byte rank, byte courage, byte firepower, byte skill, byte overallRating, string createdBy = "")
        {
            var entity = new TransformerEntity
            {
                Name = name,
                Strength = strength,
                Intelligence = intelligence,
                Speed = speed,
                Endurance = endurance,
                Rank = rank,
                Courage = courage,
                Firepower = firepower,
                Skill = skill,
                OverallRating = overallRating,
                CreatedDate = DateTime.Now,
                CreatedBy = createdBy,
                Type = type
            };
            await Create(entity);
            return entity.Id;
        }

        public async Task<TransformerEntity> GetTransformerEntityById(int id)
        {
            return await GetById(id);
        }

        public async Task<List<TransformerEntity>> GetTransformerEntitiesByIds(List<int> ids)
        {
            return await GetByIds(ids);
        }

        public async Task<List<TransformerEntity>> GetTransformerEntities()
        {
            return await GetAll();
        }

        public async Task UpdateTransformerEntity(int id, string name, byte type, byte strength, byte intelligence, 
            byte speed, byte endurance, byte rank, byte courage, byte firepower, byte skill, byte overallRating, string updatedBy = "")
        {
            var entity = await GetTransformerEntityById(id);
            entity.Courage = firepower;
            entity.Endurance = endurance;
            entity.Firepower = firepower;
            entity.Intelligence = intelligence;
            entity.LastModifiedBy = updatedBy;
            entity.LastModifiedDate = DateTime.Now;
            entity.Name = name;
            entity.OverallRating = overallRating;
            entity.Rank = rank;
            entity.Skill = skill;
            entity.Speed = speed;
            entity.Strength = strength;
            entity.Type = type;
            await Update(entity);
        }

        public async Task DeleteTransformerEntityById(int id)
        {
            await Delete(id);
        }
    }
}
