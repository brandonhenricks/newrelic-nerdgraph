using System;
using System.Collections.Generic;
using System.Text;

namespace NewRelic.NerdGraph.Interfaces;

/// <summary>
/// Provides methods to define and build GraphQL fragments for use in NerdGraph queries.
/// </summary>
public interface IFragmentBuilder
{
    /// <summary>
    /// Defines a new fragment with the specified name and type, using a selector to build its body.
    /// </summary>
    /// <param name="name">The name of the fragment.</param>
    /// <param name="type">The GraphQL type the fragment applies to.</param>
    /// <param name="selector">
    /// A function that receives an <see cref="IFragmentBodyBuilder"/> to define the fragment's fields and nested fragments.
    /// </param>
    /// <returns>
    /// The current <see cref="IFragmentBuilder"/> instance for chaining.
    /// </returns>
    IFragmentBuilder Define(string name, string type, Func<IFragmentBodyBuilder, IFragmentBodyBuilder> selector);

    /// <summary>
    /// Completes the fragment building process and returns the parent <see cref="IQueryBuilder"/>.
    /// </summary>
    /// <returns>
    /// The parent <see cref="IQueryBuilder"/> instance for further query construction.
    /// </returns>
    IQueryBuilder Done();
}
