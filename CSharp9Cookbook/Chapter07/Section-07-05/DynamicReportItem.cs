using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text.Json;

namespace Section_07_05
{
    public class DynamicReportItem : DynamicObject
    {
        Dictionary<string, object> members =
            new Dictionary<string, object>();

        public DynamicReportItem(JsonElement element)
        {
            foreach (var elem in element.EnumerateObject())
            {
                members[elem.Name] = elem.Value.ToString();
            }
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return members.Keys;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return base.TryGetMember(binder, out result);
        }

        public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
        {
            return base.TryInvoke(binder, args, out result);
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            return base.TryInvokeMember(binder, args, out result);
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            members[binder.Name] = value;
            return true;
        }
    }
}
