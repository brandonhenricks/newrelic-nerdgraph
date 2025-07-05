namespace NewRelic.NerdGraph.Interfaces;

/// <summary>
/// Provides methods to build a fragment body for a query by selecting fields and nesting fragments.
/// </summary>
public interface IFragmentBodyBuilder
{
    /// <summary>
    /// Selects a field to be included in the fragment body.
    /// </summary>
    /// <param name="field">The name of the field to select.</param>
    /// <returns>The current <see cref="IFragmentBodyBuilder"/> instance for chaining.</returns>
    IFragmentBodyBuilder Select(string field);

    /// <summary>
    /// Nests a fragment within the current fragment body.
    /// </summary>
    /// <param name="name">The name of the nested fragment.</param>
    /// <param name="nested">A function that builds the nested fragment using an <see cref="IFragmentBodyBuilder"/>.</param>
    /// <returns>The current <see cref="IFragmentBodyBuilder"/> instance for chaining.</returns>
    IFragmentBodyBuilder Nest(string name, Func<IFragmentBodyBuilder, IFragmentBodyBuilder> nested);
}
