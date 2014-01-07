using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Args
{
    class ArgsParser
    {
        private Dictionary<string, Type> _schema;
        private Dictionary<string, object> _argValues;

        public ArgsParser(Dictionary<string, Type> schema)
        {
            this._schema = schema;
            _argValues = new Dictionary<string, object>();
        }

        internal T GetValue<T>(string param)
        {
            object value = null;
            _argValues.TryGetValue(param, out value);

            if (value == null)
            {
                value = DefaultValue(param);
            }

            return (T)Convert.ChangeType(value, typeof(T));
        }

        private object DefaultValue(string param)
        {
            Type type;
            _schema.TryGetValue(param, out type);

            if (type == typeof(bool)) return false;
            if (type == typeof(int)) return default(int);

            return string.Empty;
        }

        internal void Process(string[] args)
        {
            var expectedType = typeof(string);
            var lastArgument = string.Empty;
            foreach (var arg in args)
            {
                if (string.IsNullOrWhiteSpace(arg))
                    continue;
                var type = default(Type);

                var isArgument = arg.Length > 1 && arg[0] == '-' && char.IsLetter(arg[1]);

                if (isArgument)
                {
                    _argValues.Add(arg, true);
                    _schema.TryGetValue(arg, out type);

                    expectedType = type ?? typeof(string);
                    lastArgument = arg;
                    continue;
                }
                _argValues[lastArgument] = Convert.ChangeType(arg, expectedType);
            }
        }
    }
}
