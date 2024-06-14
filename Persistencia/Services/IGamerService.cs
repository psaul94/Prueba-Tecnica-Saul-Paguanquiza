using Persistencia.Entity;
using Persistencia.Model;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Services
{
    public interface IGamerService
    {
        //Task<List<Gamer>> GetAllGamers(bool? isActive);
        Task<bool> GetExistGamer(string name);
        Task<Gamer?> AddGamer(Gamer gamer);
        Task<Gamer?> UpdateGamer(Gamer gamer);
    }
}