using System.Runtime.InteropServices;
using FFXIVClientStructs.Attributes;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info
{
    [StructLayout(LayoutKind.Explicit, Size = 0x14A0)]
    public unsafe partial struct InfoProxyCrossRealm
    {
        [FieldOffset(0x00)] public void** Vtbl;
        [FieldOffset(0x08)] public UIModule* UiModule;
        // memset((void *)(a1 + 0x30),  0, 0x358ui64);
        // memset((void *)(a1 + 0x3A0), 0, 0xF30ui64);

        [FieldOffset(0x38D)] public byte LocalPlayerGroupIndex;
        [FieldOffset(0x38E)] public byte GroupCount;
        
        [FieldOffset(0x390)] public byte IsCrossRealm; //i guess?
        [FieldOffset(0x391)] public byte IsInAllianceRaid;
        [FieldOffset(0x392)] public byte IsPartyLeader;
        [FieldOffset(0x393)] public byte IsInCrossRealmParty;

        [FieldOffset(0x3A0)] public fixed byte CrossRealmGroupArray[6 * 0x288];


        [MemberFunction("E8 ?? ?? ?? ?? 80 B8 ?? ?? ?? ?? ?? 74 5C", IsStatic = true)]
        public static partial InfoProxyCrossRealm* Instance();

        [MemberFunction("E8 ?? ?? ?? ?? F6 D8 1A C0", IsStatic = true)]
        public static partial bool IsCrossRealmParty();

        [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 8F", IsStatic = true)]
        public static partial bool IsAllianceRaid();

        [MemberFunction("E8 ?? ?? ?? ?? 0F B6 D8 8B CB", IsStatic = true)]
        public static partial byte GetGroupIndex(byte group);

        [MemberFunction("E8 ?? ?? ?? ?? 3C 01 77 4B", IsStatic = true)]
        public static partial byte GetPartyMemberCount();

        [MemberFunction("E8 ?? ?? ?? ?? 0F B6 C0 EB 0C", IsStatic = true)]
        public static partial byte GetGroupMemberCount(int groupIndex);

        [MemberFunction("E8 ?? ?? ?? ?? 44 38 60 4B", IsStatic = true)]
        public static partial CrossRealmMember* GetGroupMember(uint memberIndex, int groupIndex = -1);
        
        [MemberFunction("E8 ?? ?? ?? ?? 48 8B F8 8B 46 10", IsStatic = true)]
        public static partial CrossRealmMember* GetMemberByContentId(ulong contentId);

        [MemberFunction("40 53 4C 8B 05", IsStatic = true)]
        public static partial CrossRealmMember* GetMemberByObjectId(uint objectId);

        [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 2E 0F B6 5E 11", IsStatic = true)]
        public static partial bool IsContentIdInParty(ulong contentId);
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x288)]
    public unsafe struct CrossRealmGroup {
        [FieldOffset(0x00)] public byte GroupMemberCount;
        [FieldOffset(0x08)] public fixed byte GroupMembers[8 * 0x50];
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x50)]
    public unsafe struct CrossRealmMember {
        [FieldOffset(0x00)] public ulong ContentId;
        [FieldOffset(0x10)] public uint ObjectId;
        [FieldOffset(0x18)] public byte Level;
        [FieldOffset(0x1A)] public short HomeWorld;
        [FieldOffset(0x1C)] public short CurrentWorld;
        [FieldOffset(0x1E)] public byte ClassJobId;
        [FieldOffset(0x22)] public fixed byte Name[30];
        [FieldOffset(0x48)] public byte MemberIndex;
        [FieldOffset(0x49)] public byte GroupIndex;
        [FieldOffset(0x4B)] public byte IsPartyLeader;
    }
}
