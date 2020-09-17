using System.Collections.Generic;
using System.Linq;

namespace p0937ReorderDataInLogFiles
{
    public class Solution
    {
        //Accepted answer (ft 43.02%)
        public string[] ReorderLogFiles(string[] logs)
        {
            List<string> letterLogs = logs.Where(log => log.Split(' ')[1][0] > '9' || log.Split(' ')[1][0] < '0').ToList();
            var digitLogs = logs.Where(log => log.Split(' ')[1][0] <= '9' && log.Split(' ')[1][0] >= '0');

            letterLogs.Sort((a, b) => {
                var aContent = string.Join(' ', a.Split(' ').Skip(1));
                var bContent = string.Join(' ', b.Split(' ').Skip(1));
                if (string.Compare(aContent, bContent) != 0)
                    return string.Compare(aContent, bContent);
                else
                {
                    var aIdentifier = a.Split(' ')[0];
                    var bIdentifier = b.Split(' ')[0];
                    return string.Compare(aIdentifier, bIdentifier);
                }

            });
            return letterLogs.Concat(digitLogs).ToArray();
        }
    }
}
