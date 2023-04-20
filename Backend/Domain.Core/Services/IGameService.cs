using Domain.DTOs;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Services
{
    public interface IGameService
    {
        public Task<ActionResult<GameDTO>> Start(Theme theme, IEnumerable<User> users);
    }
}
