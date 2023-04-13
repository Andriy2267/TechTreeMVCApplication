using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TechTreeMVCApplication.Areas.Admin.Models;

namespace TechTreeMVCApplication.Comparers
{
    public class CompareUsers : IEqualityComparer<UserModel>
    {
        public bool Equals([AllowNull] UserModel x, [AllowNull] UserModel y)
        {
            if (y == null) return false;
            if (x.Id == y.Id) return true;
            return false;
        }

        public int GetHashCode([DisallowNull] UserModel obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
