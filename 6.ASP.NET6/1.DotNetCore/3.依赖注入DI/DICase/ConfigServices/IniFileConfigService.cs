using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigServices
{
    public class IniFileConfigService : IConfigServices
    {
        public string FilePath { get; set; }
        public string GetValue(string name)
        {
            var IniFileInfo = File.ReadAllLines(FilePath).Select(s => s.Split('='))
                 .Select(strs => new { Title = strs[0], Value = strs[1] })
                 .SingleOrDefault(e => e.Title == name);
            if (IniFileInfo != null)
            {
                return IniFileInfo.Value;
            }
            return null;
        }
    }
}
