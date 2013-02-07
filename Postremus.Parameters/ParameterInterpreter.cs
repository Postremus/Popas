using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Popas
{
    [assembly: CLSCompliant(true)]
    public sealed class ParameterInterpreter
    {
        public ParameterInterpreter()
        {
        }

        public static Parameterdata InterpretCommandLine(string[] args)
        {
            Parameterdata ret = new Parameterdata();
            if (args.Length <= 0)
            {
                return ret;
            }
            int idx;
            for (int i = 0; i < args.Length; i++)
            {
                string arg = args[i];
                if (!String.IsNullOrEmpty(arg.Trim()))
                {
                    if (arg.StartsWith("--"))
                    {
                        arg = arg.Remove(0, 1);
                    }
                    if (arg[0] == '/' || arg[0] == '-' || arg[0] == '?')
                    {
                        idx = arg.Contains(':') ? arg.IndexOf(':') : arg.Contains('=') ? arg.IndexOf('=') : -1;

                        if (idx >= 0)
                        {
                            string key = arg.Substring(1, idx - 1);
                            ret.Add(key, arg.Substring(idx + 1));
                        }
                        else
                        {
                            string key = arg.Substring(1);
                            ret.Add(key, true);
                        }
                    }
                }
            }
            return ret;
        }
    }
}

