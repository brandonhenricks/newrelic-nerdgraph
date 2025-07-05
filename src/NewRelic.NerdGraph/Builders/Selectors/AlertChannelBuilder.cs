using NewRelic.NerdGraph.Interfaces.Selector;

namespace NewRelic.NerdGraph.Builders.Selectors;

public class AlertChannelBuilder : IAlertChannelSelection
{
    private readonly QueryBuilder _channelCore;
    public AlertChannelBuilder(QueryBuilder core) { _channelCore = core; }
    public IAlertChannelSelection SelectId() { _channelCore.Add("id"); return this; }
    public IAlertChannelSelection SelectName() { _channelCore.Add("name"); return this; }
    public IAlertChannelSelection SelectType() { _channelCore.Add("type"); return this; }
}
