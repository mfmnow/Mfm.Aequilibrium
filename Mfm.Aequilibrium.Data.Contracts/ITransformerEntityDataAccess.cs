using Mfm.Aequilibrium.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mfm.Aequilibrium.Data.Contracts
{
    public interface ITransformerEntityDataAccess
    {
        Task<int> CreateTransformerEntity(string name, byte type, byte strength, byte intelligence, byte speed, byte endurance
            , byte rank, byte courage, byte firepower, byte skill, byte overallRating, string createdBy = "");
        Task UpdateTransformerEntity(int id, string name, byte type, byte strength, byte intelligence, byte speed, byte endurance
            , byte rank, byte courage, byte firepower, byte skill, byte overallRating, string updatedBy = "");
        Task<TransformerEntity> GetTransformerEntityById(int id);
        Task DeleteTransformerEntityById(int id);
        Task<List<TransformerEntity>> GetTransformerEntities();
        Task<List<TransformerEntity>> GetTransformerEntitiesByIds(List<int> ids);
    }
}
