﻿namespace Wedding.Core.Common;

public interface IEntityModelMapper<T, U>
    where T : class, IEntity
    where U : class
{
    public IEnumerable<T> MapEntitiesFromRange(IEnumerable<U> models)
    {
        var entities = new List<T>();

        foreach (var model in models)
        {
            var entity = MapEntityFrom(model);
            entities.Add(entity);
        }

        return entities;
    }

    public T MapEntityFrom(U model);

    public U MapModelFrom(T entity);

    public IEnumerable<U> MapModelsFromRange(IEnumerable<T> entities)
    {
        var models = new List<U>();

        foreach (var entity in entities)
        {
            var model = MapModelFrom(entity);
            models.Add(model);
        }

        return models;
    }
}