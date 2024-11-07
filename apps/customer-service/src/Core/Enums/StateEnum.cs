using System.Runtime.Serialization;

namespace CustomerService.Core.Enums;

public enum StateEnum
{
    [EnumMember(Value = "Ca")]
    Ca,

    [EnumMember(Value = "Fl")]
    Fl,

    [EnumMember(Value = "Tx")]
    Tx
}
