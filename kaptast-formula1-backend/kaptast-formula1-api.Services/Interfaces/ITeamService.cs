using KaptastFormula1Api.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KaptastFormula1Api.Services.Interfaces
{
    /// <summary>
    /// A service used for managing team data.
    /// </summary>
    public interface ITeamService
    {
        /// <summary>
        /// Adds the team to the repository.
        /// </summary>
        /// <param name="team">Team object which is converted into an entity and added to the database.</param>
        /// <returns>An awaitable task which adds the team to the repository.</returns>
        Task Add(TeamViewModel team);

        /// <summary>
        /// Deletes the team from the repository.
        /// </summary>
        /// <param name="id">Id of the which will be deleted.</param>
        /// <returns>An awaitable task which deletes the team.</returns>
        Task Delete(Guid id);

        /// <summary>
        /// Gets the team identified by the Id.
        /// </summary>
        /// <param name="Id">Id of the queried team.</param>
        /// <returns>Team object with the correc Id or null if the team is not the database.</returns>
        Task<TeamViewModel> Get(Guid Id);

        /// <summary>
        /// Gets all the teams in the database.
        /// </summary>
        /// <returns>A list with all the teams.</returns>
        Task<IEnumerable<TeamViewModel>> Get();

        /// <summary>
        /// Updates the team in the database.
        /// </summary>
        /// <param name="team">Team object which will be updated.</param>
        /// <returns>An awaitable task which updates the team.</returns>
        Task Update(TeamViewModel team);
    }
}
