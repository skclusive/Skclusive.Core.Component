using System;
using System.Collections.Generic;
using System.Linq;

namespace Skclusive.Core.Component
{
    public class CssUtil
    {
        public static IEnumerable<Tuple<string, object>> ToStyles(string style)
        {
            if (string.IsNullOrWhiteSpace(style))
            return Enumerable.Empty<Tuple<string, object>>();

            return style.Split(';').Select(single => single.Split(':'))
            .Select(pair => Tuple.Create<string, object>(pair[0], pair[1]));
        }

        public static string ToStyle(IEnumerable<Tuple<string, object>> styles, string style = null, string contextStyle = null)
        {
            var _style = string.Join(";", styles
                .Select(p => $"{p.Item1}:{p.Item2}"));

            return ToStyle(_style, style, contextStyle);
        }

        public static string ToStyle(string first, params string[] styles)
        {
            foreach (var style in styles)
            {
                first = ToStyle(first, style);
            }

            return first;
        }

        public static string ToStyle(string first, string second)
        {
            if (!string.IsNullOrWhiteSpace(second))
            {
                if (!string.IsNullOrWhiteSpace(first))
                {
                    first = $"{first};{second}";
                }
                else
                {
                    first = second;
                }
            }
            return first;
        }

        public static string ToClass(string selector, IEnumerable<string> classes, string clazz = null, string contextClass = null)
        {
            return ToClass(selector, null, classes, clazz, contextClass);
        }

        public static string ToClass(string selector, string extendor, IEnumerable<string> classes, string clazz = null, string contextClass = null)
        {
            var extending = !string.IsNullOrWhiteSpace(extendor);

            var _class = string.Join(" ", classes.Select(key =>
            {
                if (key.StartsWith("~", StringComparison.Ordinal))
                {
                    return key.Substring(1);
                }

                var currentKey = $"{(key.Length > 0 ? "-" : "")}{key}";

                var current = $"{selector}{currentKey}";

                if (extending)
                {
                    current = $"{current} {extendor}{currentKey}";
                }

                return current;
            }));

            return ToClass(_class, clazz, contextClass);
        }

        public static string ToClass(string first, params string[] classes)
        {
            foreach (var _class in classes)
            {
                first = ToClass(first, _class);
            }

            return first;
        }

        public static string ToClass(string first, string second)
        {
            if (!string.IsNullOrWhiteSpace(second))
            {
                if (second.StartsWith("~", StringComparison.Ordinal))
                {
                    second = second.Substring(1);
                }

                if (!string.IsNullOrWhiteSpace(first))
                {
                    first = $"{first} {second}";
                }
                else
                {
                    first = second;
                }
            }
            return first;
        }
    }
}
