using System;

namespace KaptastFormula1Api.Repository.Entities.Interfaces
{
    /// <summary>
    /// An entity interface which ensures that the object has an Id
    /// </summary>
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
