using System;
using System.Collections.Generic;
using System.Text;
using NewRelic.NerdGraph.Interfaces;

namespace NewRelic.NerdGraph.Builders
{
    public class FragmentBuilder : IFragmentBuilder, IFragmentBodyBuilder
    {
        private readonly QueryBuilder _core;
        private readonly IQueryBuilder _root;

        public FragmentBuilder(IQueryBuilder root, QueryBuilder core)
        {
            _core = core;
            _root = root;
        }

        public IFragmentBuilder Define(string name, string type, Func<IFragmentBodyBuilder, IFragmentBodyBuilder> selector)
        {
            _core.SelectField($"fragment {name} on {type} {{");
            selector(this);
            _core.SelectField("}");
            return this;
        }

        public IFragmentBodyBuilder Select(string field)
        {
            _core.SelectField(field);
            return this;
        }

        public IFragmentBodyBuilder Nest(string name, Func<IFragmentBodyBuilder, IFragmentBodyBuilder> nested)
        {
            _core.SelectField($"{name} {{");
            nested(this);
            _core.SelectField("}");
            return this;
        }

        public IQueryBuilder Done() => _root;
    }
}
