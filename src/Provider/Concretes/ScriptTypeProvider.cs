using System;
using System.Collections.Generic;

namespace Skclusive.Core.Component
{
    public class ScriptTypeProvider : IScriptTypeProvider
    {
        public int? Priority { get; }

        public IEnumerable<Type> Scripts { get; }

        public ScriptTypeProvider(int? priority = null, params Type [] scripts)
        {
            Priority = priority;

            Scripts = scripts;
        }

        public ScriptTypeProvider(params Type [] scripts) : this(priority: default, scripts)
        {
        }
    }
}
