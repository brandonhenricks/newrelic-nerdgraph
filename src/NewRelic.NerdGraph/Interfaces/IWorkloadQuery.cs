namespace NewRelic.NerdGraph.Interfaces;

public interface IWorkloadQuery {
    IQueryBuilder SelectName();
    IQueryBuilder SelectGuid();
    IWorkloadQuery WithPagination(int? first = null, string after = null);
}
