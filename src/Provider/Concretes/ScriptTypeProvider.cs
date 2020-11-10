using System;
using System.Collections.Generic;

namespace Skclusive.Core.Component
{
    public class ScriptTypeProvider : IScriptTypeProvider
    {
        public IEnumerable<Type> Scripts { get; }

        public ScriptTypeProvider(params Type [] scripts)
        {
            Scripts = scripts;
        }
    }
}
