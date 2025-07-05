namespace NewRelic.NerdGraph.Interfaces;

public interface IAccountQuery
{
    INrqlQuery Nrql(string nrql);
}
