using System;
using System.Collections.Generic;
using System.Text;

namespace NewRelic.NerdGraph.Builders
{
    /// <summary>
    /// Abstract base class for all GraphQL query and mutation builders.
    /// Provides common logic for field selection, argument handling, and query construction.
    /// </summary>
    public abstract class BaseBuilder<TBuilder> where TBuilder : BaseBuilder<TBuilder>
    {
        protected readonly List<string> _fields = new List<string>();
        protected readonly Dictionary<string, object> _arguments = new Dictionary<string, object>();
        protected string _operationName;

        /// <summary>
        /// Sets the operation name (query or mutation root).
        /// </summary>
        public TBuilder WithOperation(string operationName)
        {
            _operationName = operationName;
            return (TBuilder)this;
        }

        /// <summary>
        /// Adds a field to the selection set.
        /// </summary>
        public TBuilder SelectField(string field)
        {
            if (!string.IsNullOrWhiteSpace(field))
                _fields.Add(field);
            return (TBuilder)this;
        }

        /// <summary>
        /// Adds an argument to the operation.
        /// </summary>
        public TBuilder WithArgument(string name, object value)
        {
            if (!string.IsNullOrWhiteSpace(name))
                _arguments[name] = value;
            return (TBuilder)this;
        }

        /// <summary>
        /// Builds the GraphQL query or mutation string.
        /// </summary>
        public virtual string Build()
        {
            var sb = new StringBuilder();
            sb.Append(_operationName);
            if (_arguments.Count > 0)
            {
                sb.Append("(");
                bool first = true;
                foreach (var arg in _arguments)
                {
                    if (!first) sb.Append(", ");
                    sb.AppendFormat("{0}: {1}", arg.Key, FormatValue(arg.Value));
                    first = false;
                }
                sb.Append(")");
            }
            if (_fields.Count > 0)
            {
                sb.Append(" {");
                sb.Append(string.Join(" ", _fields));
                sb.Append("}");
            }
            return sb.ToString();
        }

        protected string FormatValue(object value)
        {
            if (value is string s)
                return $"\"{s}\"";
            if (value is bool b)
                return b ? "true" : "false";
            if (value is null)
                return "null";
            return value.ToString();
        }
    }
}
