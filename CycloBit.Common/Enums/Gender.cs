using System.ComponentModel;

namespace CycloBit.Common.Enums {
    public enum Gender : byte {
        [Description("Prefer Not To Say")]
        Unknown = 0,
        Male = 1,
        Female = 2
    }
}