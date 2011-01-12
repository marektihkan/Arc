using System;
using System.Collections;
using System.Collections.Generic;

namespace Arc.Infrastructure.Mapping
{
    public interface IMapCollectionToSyntax
    {
        IEnumerable<TDestination> To<TDestination>();
        IEnumerable To(Type type);
    }
}