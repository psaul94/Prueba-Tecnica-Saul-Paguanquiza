using Persistencia.Entity;
using Persistencia.Model;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Services
{
    public class GamerService : IGamerService
    {
        private readonly GamerDbContext _db;
        public GamerService(GamerDbContext db)
        {
            _db = db;
        }

        public async Task<bool> GetExistGamer(string name)
        {
            return await _db.Gamers.AnyAsync(m => m.Name == name);
        }
        public async Task<Gamer?> AddGamer(Gamer gamer)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {                   
                    gamer.FechaCreacion = DateTime.Now;
                    _db.Gamers.Add(gamer);
                    var result = await _db.SaveChangesAsync();
                    transaction.Commit();
                    return result >= 0 ? gamer : null;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }

            }
        }
        public async Task<Gamer?> UpdateGamer(Gamer gamer)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    gamer.FechaCreacion = DateTime.Now;
                    _db.Gamers.Update(gamer);
                    var result = await _db.SaveChangesAsync();
                    transaction.Commit();
                    return result >= 0 ? gamer : null;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }

            }
        }

    }
}