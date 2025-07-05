using NewRelic.NerdGraph.Interfaces.Selector;

namespace NewRelic.NerdGraph.Builders.Selectors;

public class AlertPolicyBuilder : IAlertPolicySelection
{
    private readonly QueryBuilder _policyCore;
    public AlertPolicyBuilder(QueryBuilder core) { _policyCore = core; }
    public IAlertPolicySelection SelectId() { _policyCore.Add("id"); return this; }
    public IAlertPolicySelection SelectName() { _policyCore.Add("name"); return this; }
    public IAlertPolicySelection SelectIncidentPreference() { _policyCore.Add("incidentPreference"); return this; }
}
