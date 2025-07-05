using NewRelic.NerdGraph.Builders.Selectors;
using NewRelic.NerdGraph.Interfaces;
using NewRelic.NerdGraph.Interfaces.Selector;

namespace NewRelic.NerdGraph.Builders;

public class AlertBuilder : IAlertQuery
{
    private readonly IQueryBuilder _rootAlertBuilder;
    private readonly QueryBuilder _coreAlertBuilder;

    public AlertBuilder(IQueryBuilder rootAlertBuilder, QueryBuilder coreAlertBuilder)
    {
        _rootAlertBuilder = rootAlertBuilder;
        _coreAlertBuilder = coreAlertBuilder;
    }

    public IAlertQuery UseFragment(string name)
    {
        _coreAlertBuilder.SelectField($"...{name}");
        return this;
    }

    public IAlertQuery Policies(Func<IAlertPolicySelection, IAlertPolicySelection> selector)
    {
        _coreAlertBuilder.SelectField("policies {");
        selector(new AlertPolicyBuilder(_coreAlertBuilder));
        _coreAlertBuilder.SelectField("}");
        return this;
    }

    public IAlertQuery Channels(Func<IAlertChannelSelection, IAlertChannelSelection> selector)
    {
        _coreAlertBuilder.SelectField("channels {");
        selector(new AlertChannelBuilder(_coreAlertBuilder));
        _coreAlertBuilder.SelectField("}");
        return this;
    }
    public IAlertQuery WithPagination(int? first = null, string after = null)
    {
        if (first.HasValue)
            _coreAlertBuilder.WithArgument("first", first.Value);
        if (!string.IsNullOrEmpty(after))
            _coreAlertBuilder.WithArgument("after", after);
        return this;
    }

    public IQueryBuilder Done() { _coreAlertBuilder.SelectField("}"); return _rootAlertBuilder; }
}
