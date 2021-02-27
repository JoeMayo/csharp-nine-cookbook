using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text.Json;

namespace Section_05_07
{
    public class DynamicLog : DynamicObject
    {
        Dictionary<string, string> members =
            new Dictionary<string, string>();

        public DynamicLog(string headerString, string logString)
        {
            string[] headers = headerString.Split('|');
            string[] logData = logString.Split('|');

            for (int i = 0; i < headers.Length; i++)
                members[headers[i]] = logData[i];
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = members[binder.Name];
            return true;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            return base.TryInvokeMember(binder, args, out result);
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            members[binder.Name] = (string)value;
            return true;
        }
    }
}
