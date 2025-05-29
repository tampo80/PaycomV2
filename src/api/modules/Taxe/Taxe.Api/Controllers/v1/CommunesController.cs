using FSH.Framework.Core.Application.Commands;
using FSH.Framework.Core.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using Taxe.Application.Communes.Commands.Create.v1;
using Taxe.Application.Communes.Commands.Update.v1;
using Taxe.Application.Communes.Queries.GetAll.v1;
using Taxe.Application.Communes.Queries.GetById.v1;

namespace Taxe.Api.Controllers.v1;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class CommunesController : ControllerBase
{
    private readonly ICommandBus _commandBus;
    private readonly IQueryBus _queryBus;

    public CommunesController(ICommandBus commandBus, IQueryBus queryBus)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
    }

    /// <summary>
    /// Créer une commune
    /// </summary>
    /// <remarks>
    /// Crée une nouvelle commune administrative
    /// </remarks>
    /// <param name="command">Les informations de la commune à créer</param>
    /// <param name="cancellationToken">Token d'annulation</param>
    /// <returns>Les informations de la commune créée</returns>
    [HttpPost]
    [ProducesResponseType(typeof(CreateCommuneResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(CreateCommuneCommand command, CancellationToken cancellationToken)
    {
        var response = await _commandBus.SendAsync(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    /// <summary>
    /// Mettre à jour une commune
    /// </summary>
    /// <remarks>
    /// Met à jour les informations d'une commune existante
    /// </remarks>
    /// <param name="id">L'identifiant de la commune à mettre à jour</param>
    /// <param name="command">Les nouvelles informations de la commune</param>
    /// <param name="cancellationToken">Token d'annulation</param>
    /// <returns>Les informations de la commune mise à jour</returns>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(UpdateCommuneResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateCommuneCommand command, CancellationToken cancellationToken)
    {
        if (id != command.Id)
        {
            return BadRequest("L'identifiant dans l'URL ne correspond pas à celui dans le corps de la requête.");
        }

        var response = await _commandBus.SendAsync(command, cancellationToken);
        return Ok(response);
    }

    /// <summary>
    /// Obtenir une commune par son identifiant
    /// </summary>
    /// <remarks>
    /// Récupère les informations détaillées d'une commune
    /// </remarks>
    /// <param name="id">L'identifiant de la commune à récupérer</param>
    /// <param name="cancellationToken">Token d'annulation</param>
    /// <returns>Les informations de la commune</returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(GetCommuneByIdResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetCommuneByIdQuery { Id = id };
        var response = await _queryBus.SendAsync(query, cancellationToken);
        return Ok(response);
    }

    /// <summary>
    /// Obtenir la liste des communes
    /// </summary>
    /// <remarks>
    /// Récupère la liste paginée des communes avec possibilité de filtrage et de tri
    /// </remarks>
    /// <param name="query">Les paramètres de filtrage, pagination et tri</param>
    /// <param name="cancellationToken">Token d'annulation</param>
    /// <returns>La liste paginée des communes</returns>
    [HttpGet]
    [ProducesResponseType(typeof(GetAllCommunesResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromQuery] GetAllCommunesQuery query, CancellationToken cancellationToken)
    {
        var response = await _queryBus.SendAsync(query, cancellationToken);
        return Ok(response);
    }
}
