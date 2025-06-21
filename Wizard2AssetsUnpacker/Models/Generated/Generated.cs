using MasterMemory;
using MessagePack;

namespace Wizard2AssetsUnpacker.Models.Generated
{

    [MessagePackObject(false)]

    [MemoryTable("AchievementMaster")]

    public class AchievementMaster
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int Id { get; set; }
        [Key(1)]
        public int RewardType { get; set; }
        [Key(2)]
        public int RewardDetailId { get; set; }
        [Key(3)]
        public int RewardNumber { get; set; }
        [Key(4)]
        public string PlatformAchieve { get; set; }
    }

    [MemoryTable("AdviceFaceMaster")]

    [MessagePackObject(false)]

    public class AdviceFaceMaster
    {
        [Key(0)]
        [PrimaryKey(0)]
        public string TextId { get; set; }
        [Key(1)]
        public int[] FaceIndexes { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("AjitoGrade")]

    public class AjitoGrade
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int Grade { get; set; }
        [Key(1)]
        public int CutsceneId { get; set; }
    }

    [MemoryTable("AjitoTheme")]

    [MessagePackObject(false)]

    public class AjitoTheme
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int ThemeId { get; set; }
        [Key(1)]
        public int SortId { get; set; }
        [Key(2)]
        public string[] ProbeCubemapIds { get; set; }
        [Key(3)]
        public int TableObjectId { get; set; }
        [Key(4)]
        public int ChairObjectId { get; set; }
    }

    [MemoryTable("ArrangeLayoutDetail")]

    [MessagePackObject(false)]

    public class ArrangeLayoutDetail
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int DetailId { get; set; }
        [Key(1)]
        [SecondaryKey(5, 0)]
        [NonUnique]
        public int ArrangeLayoutId { get; set; }
        [Key(2)]
        public int ObjectId { get; set; }
        [Key(3)]
        public int ChildObjectId { get; set; }
        [Key(4)]
        public Single PositionX { get; set; }
        [Key(5)]
        public Single PositionY { get; set; }
        [Key(6)]
        public Single PositionZ { get; set; }
        [Key(7)]
        public Single RotationX { get; set; }
        [Key(8)]
        public Single RotationY { get; set; }
        [Key(9)]
        public Single RotationZ { get; set; }
        [Key(10)]
        public Single ScaleX { get; set; }
        [Key(11)]
        public Single ScaleY { get; set; }
        [Key(12)]
        public Single ScaleZ { get; set; }
    }
    public enum AttractionCategory : uint { Soccer = 0, Hockey = 1, Volley = 2, ExtraTableTop = 3, }

    [MessagePackObject(false)]

    [MemoryTable("AttractionAreaMaster")]

    public class AttractionAreaMaster
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int AttractionId { get; set; }
        [SecondaryKey(0, 0)]
        [Key(1)]
        public int FloorObjectId { get; set; }
        [Key(2)]
        public int ArrangeLayoutId { get; set; }
        [Key(3)]
        public AttractionCategory AttractionCategory { get; set; }
        [Key(4)]
        public string AttractionName { get; set; }
    }
    public enum AvatarAutoAnimationType : uint { Idle = 1, Run = 2, Jump = 3, Tackle = 4, }


    public class MasterTextId
    {

    }
    public enum AvatarEditTabType : uint { Head = 0, Eye = 1, Eyebrow = 2, Mouth = 4, Glasses = 5, Tops = 6, Bottoms = 7, Socks = 8, Shoes = 9, Smartphone = 10, Mustache = 11, Costume = 12, BodyShape = 100, BodyColor = 101, AvatarVoice = 150, CustomEmote = 200, StandIdle = 300, Run = 400, Jump = 500, Tackle = 600, AvatarStamp = 700, }
    public enum AvatarEditTabCategory : uint { BodyShape = 0, Face = 1, Costume = 2, Motion = 3, AvatarStamp = 4, }

    [MessagePackObject(false)]

    [MemoryTable("AvatarEditTabMaster")]

    public class AvatarEditTabMaster
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int Id { get; set; }
        [Key(1)]
        public AvatarEditTabType TabType { get; set; }
        [Key(2)]
        public AvatarEditTabCategory TabCategory { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("AvatarAutoAnimMaster")]

    public class AvatarAutoAnimMaster
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int AnimationId { get; set; }
        [Key(1)]
        public AvatarAutoAnimationType AnimationType { get; set; }
        [Key(2)]
        public string AnimationFileName { get; set; }
        [Key(3)]
        public string _LocalizedName { get; set; }
        [IgnoreMember]
        public MasterTextId LocalizedName { get; set; }
        [Key(4)]
        public int EditTabId { get; set; }
        [Key(5)]
        public Single OptionAnimationSpeedRate { get; set; }
        [IgnoreMember]
        public AvatarEditTabMaster EditTabIdRef { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("AvatarBodyMaster")]

    public class AvatarBodyMaster
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int AvatarBodyId { get; set; }
        [Key(1)]
        public string _LocalizedName { get; set; }
        [IgnoreMember]
        public MasterTextId LocalizedName { get; set; }
        [Key(2)]
        public int[] Size { get; set; }
        [Key(3)]
        public int[] ColorIds { get; set; }
        [Key(4)]
        public int EditTabId { get; set; }
    }
    public enum AvatarPartsType : uint { Head = 0, Eye = 1, Eyebrow = 2, Body = 3, Mouth = 4, Glasses = 5, Tops = 6, Bottoms = 7, Socks = 8, Shoes = 9, Smartphone = 10, Face = 11, Mustache = 12, Costume = 13, }

    [MemoryTable("AvatarCategoryMaster")]

    [MessagePackObject(false)]

    public class AvatarCategoryMaster
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int CategoryId { get; set; }
        [Key(1)]
        [NonUnique]
        [SecondaryKey(5, 0)]
        public AvatarPartsType PartsType { get; set; }
        [Key(2)]
        public string Name { get; set; }
        [Key(3)]
        public int[] CombinationNgCategoryIds { get; set; }
        [Key(4)]
        public int EditTabId { get; set; }
        [IgnoreMember]
        public AvatarEditTabMaster EditTabIdRef { get; set; }
    }

    [MemoryTable("AvatarColorCodeMaster")]

    [MessagePackObject(false)]

    public class AvatarColorCodeMaster
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int ColorCodeId { get; set; }
        [Key(1)]
        public string ColorCode { get; set; }
        [Key(2)]
        public string Name { get; set; }
    }

    [MemoryTable("AvatarColorMaster")]

    [MessagePackObject(false)]

    public class AvatarColorMaster
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int ColorId { get; set; }
        [Key(1)]
        public int MaskRColorCodeId { get; set; }
        [Key(2)]
        public int MaskGColorCodeId { get; set; }
        [Key(3)]
        public int MaskGColorOpacity { get; set; }
        [Key(4)]
        public int MaskBColorCodeId { get; set; }
        [Key(5)]
        public int MaskBColorOpacity { get; set; }
        [Key(6)]
        public int MaskAColorCodeId { get; set; }
        [Key(7)]
        public int MaskAColorOpacity { get; set; }
        [Key(8)]
        public int ImageColorCodeId { get; set; }
        [Key(9)]
        public int OverrideAvatarTextureId { get; set; }
        [Key(10)]
        public string Name { get; set; }
        [IgnoreMember]
        public AvatarColorCodeMaster MaskRColorCodeIdRef { get; set; }
        [IgnoreMember]
        public AvatarColorCodeMaster MaskGColorCodeIdRef { get; set; }
        [IgnoreMember]
        public AvatarColorCodeMaster MaskBColorCodeIdRef { get; set; }
        [IgnoreMember]
        public AvatarColorCodeMaster MaskAColorCodeIdRef { get; set; }
        [IgnoreMember]
        public AvatarColorCodeMaster ImageColorCodeIdRef { get; set; }
    }

    [MemoryTable("AvatarEmoteMaster")]

    [MessagePackObject(false)]

    public class AvatarEmoteMaster
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int EmoteId { get; set; }
        [Key(1)]
        public int Type { get; set; }
        [Key(2)]
        public string EmoteFileName { get; set; }
        [Key(3)]
        public string _LocalizedName { get; set; }
        [IgnoreMember]
        public MasterTextId LocalizedName { get; set; }
        [Key(4)]
        public int EditTabId { get; set; }
        [Key(5)]
        public string CySpringOverwriteKey { get; set; }
        [Key(6)]
        public int Rarity { get; set; }
        [IgnoreMember]
        public AvatarEditTabMaster EditTabIdRef { get; set; }
    }

    [MemoryTable("AvatarPartsBottoms")]

    [MessagePackObject(false)]

    public class AvatarPartsBottoms
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int AvatarId { get; set; }
        [Key(1)]
        public string AvatarFileName { get; set; }
        [Key(2)]
        public int DefaultIconColorId { get; set; }
        [Key(3)]
        public int[] ColorIds { get; set; }
        [Key(4)]
        public int[] SoundCategoryIds { get; set; }
        [Key(5)]
        public int AvatarTextureId { get; set; }
        [Key(6)]
        public int SortPriority { get; set; }
    }

    [MemoryTable("AvatarPartsColorRewardMaster")]

    [MessagePackObject(false)]

    public class AvatarPartsColorRewardMaster
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int Id { get; set; }
        [Key(1)]
        public int AvatarId { get; set; }
        [Key(2)]
        public int ColorId { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("AvatarPartsMaster")]

    public class AvatarPartsMaster
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int AvatarId { get; set; }
        [Key(1)]
        public int CategoryId { get; set; }
        [Key(2)]
        public string _LocalizedName { get; set; }
        [IgnoreMember]
        public MasterTextId LocalizedName { get; set; }
        [Key(3)]
        public int Rarity { get; set; }
        [Key(4)]
        public bool IsNormallyUnavailable { get; set; }
        [IgnoreMember]
        public AvatarCategoryMaster CategoryIdRef { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("AvatarSizeMaster")]

    public class AvatarSizeMaster
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int SizeId { get; set; }
        [Key(1)]
        public Single Value { get; set; }
        [Key(2)]
        public string Name { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("AvatarPartsCostume")]

    public class AvatarPartsCostume
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int AvatarId { get; set; }
        [Key(1)]
        public string AvatarFileName { get; set; }
        [Key(2)]
        public int DefaultIconAvatarTextureId { get; set; }
        [Key(3)]
        public int[] AvatarTextureIds { get; set; }
        [Key(4)]
        public int[] SoundCategoryIds { get; set; }
        [Key(5)]
        public int DedicatedEmoteId { get; set; }
        [Key(6)]
        public int AvatarBodyId { get; set; }
        [Key(7)]
        public int Size { get; set; }
        [Key(8)]
        public int SortPriority { get; set; }
        [IgnoreMember]
        public AvatarPartsMaster AvatarIdRef { get; set; }
        [IgnoreMember]
        public AvatarEmoteMaster DedicatedEmoteIdRef { get; set; }
        [IgnoreMember]
        public AvatarSizeMaster SizeRef { get; set; }
        [IgnoreMember]
        public int[] ColorIds { get; set; }
    }
    public enum AvatarBlinkType : uint { Normal = 0, None = 1, }

    [MessagePackObject(false)]

    [MemoryTable("AvatarPartsEye")]

    public class AvatarPartsEye
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int AvatarId { get; set; }
        [Key(1)]
        public string AvatarFileName { get; set; }
        [Key(2)]
        public int[] ColorIds { get; set; }
        [Key(3)]
        public int[] MakeupColorIds { get; set; }
        [Key(4)]
        public AvatarBlinkType BlinkType { get; set; }
        [Key(5)]
        public int AvatarTextureId { get; set; }
        [Key(6)]
        public int SortPriority { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("AvatarPartsEyebrow")]

    public class AvatarPartsEyebrow
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int AvatarId { get; set; }
        [Key(1)]
        public string AvatarFileName { get; set; }
        [Key(2)]
        public int[] ColorIds { get; set; }
        [Key(3)]
        public int[] PatternIds { get; set; }
        [Key(4)]
        public int SortPriority { get; set; }
    }

    [MemoryTable("AvatarPartsGlasses")]

    [MessagePackObject(false)]

    public class AvatarPartsGlasses
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int AvatarId { get; set; }
        [Key(1)]
        public string AvatarFileName { get; set; }
        [Key(2)]
        public int DefaultIconColorId { get; set; }
        [Key(3)]
        public int[] ColorIds { get; set; }
        [Key(4)]
        public int[] SoundCategoryIds { get; set; }
        [Key(5)]
        public int AvatarTextureId { get; set; }
        [Key(6)]
        public int SortPriority { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("AvatarPartsHead")]

    public class AvatarPartsHead
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int AvatarId { get; set; }
        [Key(1)]
        public string AvatarFileName { get; set; }
        [Key(2)]
        public int[] ColorIds { get; set; }
        [Key(3)]
        public int[] PatternIds { get; set; }
        [Key(4)]
        public int SortPriority { get; set; }
    }

    [MemoryTable("AvatarPartsMouth")]

    [MessagePackObject(false)]

    public class AvatarPartsMouth
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int AvatarId { get; set; }
        [Key(1)]
        public string AvatarFileName { get; set; }
        [Key(2)]
        public int[] ColorIds { get; set; }
        [Key(3)]
        public int AvatarTextureId { get; set; }
        [Key(4)]
        public int SortPriority { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("AvatarPartsMustache")]

    public class AvatarPartsMustache
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int AvatarId { get; set; }
        [Key(1)]
        public string AvatarFileName { get; set; }
        [Key(2)]
        public int[] ColorIds { get; set; }
        [Key(3)]
        public int SortPriority { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("AvatarPartsShoes")]

    public class AvatarPartsShoes
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int AvatarId { get; set; }
        [Key(1)]
        public string AvatarFileName { get; set; }
        [Key(2)]
        public int DefaultIconColorId { get; set; }
        [Key(3)]
        public int[] ColorIds { get; set; }
        [Key(4)]
        public int[] SoundCategoryIds { get; set; }
        [Key(5)]
        public int AvatarTextureId { get; set; }
        [Key(6)]
        public int SortPriority { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("AvatarPartsSmartphone")]

    public class AvatarPartsSmartphone
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int AvatarId { get; set; }
        [Key(1)]
        public string AvatarFileName { get; set; }
        [Key(2)]
        public int DefaultIconColorId { get; set; }
        [Key(3)]
        public int[] ColorIds { get; set; }
        [Key(4)]
        public int[] SoundCategoryIds { get; set; }
        [Key(5)]
        public int AvatarTextureId { get; set; }
        [Key(6)]
        public int SortPriority { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("AvatarPartsSocks")]

    public class AvatarPartsSocks
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int AvatarId { get; set; }
        [Key(1)]
        public string AvatarFileName { get; set; }
        [Key(2)]
        public int DefaultIconColorId { get; set; }
        [Key(3)]
        public int[] ColorIds { get; set; }
        [Key(4)]
        public int[] SoundCategoryIds { get; set; }
        [Key(5)]
        public int AvatarTextureId { get; set; }
        [Key(6)]
        public int SortPriority { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("AvatarPartsTops")]

    public class AvatarPartsTops
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int AvatarId { get; set; }
        [Key(1)]
        public string AvatarFileName { get; set; }
        [Key(2)]
        public int DefaultIconColorId { get; set; }
        [Key(3)]
        public int[] ColorIds { get; set; }
        [Key(4)]
        public int[] SoundCategoryIds { get; set; }
        [Key(5)]
        public int AvatarTextureId { get; set; }
        [Key(6)]
        public int SortPriority { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("AvatarSoundCategory")]

    public class AvatarSoundCategory
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int SoundCategoryId { get; set; }
        [Key(1)]
        public int Priority { get; set; }
        [Key(2)]
        public string Material { get; set; }
    }

    [MemoryTable("AvatarVoiceTypeMaster")]

    [MessagePackObject(false)]

    public class AvatarVoiceTypeMaster
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int AvatarVoiceTypeId { get; set; }
        [Key(1)]
        public string _LocalizedName { get; set; }
        [IgnoreMember]
        public MasterTextId LocalizedName { get; set; }
        [Key(2)]
        public string _LocalizedDescription { get; set; }
        [IgnoreMember]
        public MasterTextId LocalizedDescription { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("BaseCardMaster")]

    public class BaseCardMaster
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int BaseCardId { get; set; }
        [Key(1)]
        public int Type { get; set; }
        [Key(2)]
        public int Class { get; set; }
        [Key(3)]
        public int[] Tribes { get; set; }
        [Key(4)]
        public int Cost { get; set; }
        [Key(5)]
        public int Atk { get; set; }
        [Key(6)]
        public int Life { get; set; }
        [Key(7)]
        public int ChantCount { get; set; }
        [Key(8)]
        public int Rarity { get; set; }
        [Key(9)]
        public int[] RelatedBaseCardIds { get; set; }
        [Key(10)]
        public int[] SpecificEffectCardIds { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("BasePuzzleMaster")]

    public class BasePuzzleMaster
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int Id { get; set; }
        [Key(1)]
        public string QuestName { get; set; }
        [Key(2)]
        public int StageId { get; set; }
        [Key(3)]
        public int PuzzleBattleMasterId { get; set; }
    }

    [MemoryTable("BattleAchievementType")]

    [MessagePackObject(false)]

    public class BattleAchievementType
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int Id { get; set; }
        [Key(1)]
        public string Name { get; set; }
        [Key(2)]
        public string TextId { get; set; }
        [Key(3)]
        public int OrderNum { get; set; }
    }

    [MemoryTable("BattleCountSetting")]

    [MessagePackObject(false)]

    public class BattleCountSetting
    {
        [PrimaryKey(0)]
        [Key(0)]
        public string Name { get; set; }
        [Key(1)]
        public int Count { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("BattleFieldMaster")]

    public class BattleFieldMaster
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int Id { get; set; }
        [Key(1)]
        public string StartDate { get; set; }
        [Key(2)]
        public string EndDate { get; set; }
        [Key(3)]
        public int SceneId { get; set; }
        [Key(4)]
        public string BgmId { get; set; }
    }

    [MemoryTable("BattleLogInfoMaster")]

    [MessagePackObject(false)]

    public class BattleLogInfoMaster
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int Id { get; set; }
        [Key(1)]
        public string _Text { get; set; }
        [IgnoreMember]
        public MasterTextId Text { get; set; }
        [Key(2)]
        public int Priority { get; set; }
        [Key(3)]
        public int DisplayZero { get; set; }
        [Key(4)]
        public int[] Classes { get; set; }
    }

    [MemoryTable("BattleTimeSetting")]

    [MessagePackObject(false)]

    public class BattleTimeSetting
    {
        [PrimaryKey(0)]
        [Key(0)]
        public string Name { get; set; }
        [Key(1)]
        public int Milliseconds { get; set; }
    }
    public enum BattleTutorialSkipType : uint { None = 0, Skip = 1, SkipShowClear = 2, }

    [MessagePackObject(false)]

    [MemoryTable("BattleTutorial")]

    public class BattleTutorial
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int Id { get; set; }
        [Key(1)]
        public int CommandGroup { get; set; }
        [Key(2)]
        public int StageId { get; set; }
        [Key(3)]
        public string SoundBankName { get; set; }
        [Key(4)]
        public string ReplayPath { get; set; }
        [Key(5)]
        public bool IsFirstSideAlly { get; set; }
        [Key(6)]
        public int StartTurn { get; set; }
        [Key(7)]
        public bool IsStartTurnAlly { get; set; }
        [Key(8)]
        public int StartStep { get; set; }
        [Key(9)]
        public bool IsFreeBattle { get; set; }
        [Key(10)]
        public bool IsUserInfo { get; set; }
        [Key(11)]
        public string AllyNameTextId { get; set; }
        [Key(12)]
        public string OppoNameTextId { get; set; }
        [Key(13)]
        public int AllyClass { get; set; }
        [Key(14)]
        public int OppoClass { get; set; }
        [Key(15)]
        public int AllyLeaderSkinId { get; set; }
        [Key(16)]
        public int OppoLeaderSkinId { get; set; }
        [Key(17)]
        public int AllyEmblem { get; set; }
        [Key(18)]
        public int OppoEmblem { get; set; }
        [Key(19)]
        public string AllyLeaderVoice { get; set; }
        [Key(20)]
        public string OppoLeaderVoice { get; set; }
        [Key(21)]
        public BattleTutorialSkipType SkipType { get; set; }
        [Key(22)]
        public bool IsUseBattleLog { get; set; }
        [Key(23)]
        public bool IsUseBattleMenu { get; set; }
        [Key(24)]
        public bool IsUseStartCutin { get; set; }
    }
    public enum BattleTutorialCommandType : uint { Null = 0, CardPlay = 1, WaitTime = 2, WaitTurnStartDrawEnd = 3, DialogTips = 4, TurnEnd = 5, Attack = 6, Activation = 7, Evolve = 8, FocusHand = 9, MaskHand = 10, MaskTurnEnd = 11, MaskPP = 12, MaskLeader = 13, MaskFieldStatus = 14, WaitMulliganStart = 15, MulliganChange = 16, MulliganEnd = 17, MaskAllyFieldAndOppoField = 18, MaskMulliganEnd = 19, ExtraPP = 20, MaskField = 21, CursorHand = 22, CursorField = 23, FocusHandLock = 24, MaskEvolve = 25, CursorMulligan = 26, MaskSpellBoostButton = 27, SelectCard = 28, CloseCardDetail = 29, OpenCloseCardDetailLock = 30, OpenCardDetail = 31, OpenFusion = 32, SelectFusionCard = 33, DecideFusion = 34, SelectMode = 35, SelectChoice = 36, MulliganBG = 37, PushSpellBoostButton = 38, MaskHandCost = 39, MaskExtraPP = 40, MaskHandAndPP = 41, MaskCemeteryUI = 42, NoUse011 = 43, NoUse012 = 44, NoUse013 = 45, NoUse014 = 46, NoUse015 = 47, CursorEvolveOrb = 48, WaitDirectBattleStart = 49, WaitTurnStartEnd = 50, PassAndWait = 51, Result = 52, Emote = 53, CharaMessage = 54, MaskLeaderLife = 55, MaskMulligan = 56, BG = 57, NoUse20 = 58, NoUse21 = 59, NoUse22 = 60, PlayFinishMulligan = 61, MaskMode = 62, MaskCardDetail = 63, MaskActivationButton = 64, MaskFusionButton = 65, MaskFusionDecideButton = 66, MaskCrest = 67, WaitVfxAndTime = 68, MaskMulliganCard = 69, MaskCardCounter = 70, Introduction = 71, }

    [MessagePackObject(false)]

    [MemoryTable("BattleTutorialCommand")]

    public class BattleTutorialCommand
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int Id { get; set; }
        [SecondaryKey(5, 0)]
        [NonUnique]
        [Key(1)]
        public int CommandGroup { get; set; }
        [Key(2)]
        public BattleTutorialCommandType CommandType { get; set; }
        [Key(3)]
        public string Param1 { get; set; }
        [Key(4)]
        public string Param2 { get; set; }
        [Key(5)]
        public string Param3 { get; set; }
        [Key(6)]
        public string Param4 { get; set; }
        [Key(7)]
        public string Param5 { get; set; }
        [Key(8)]
        public string Param6 { get; set; }
        [Key(9)]
        public string Param7 { get; set; }
    }

    [MemoryTable("BattleTutorialMenuList")]

    [MessagePackObject(false)]

    public class BattleTutorialMenuList
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int TutorialId { get; set; }
        [Key(1)]
        public int OrderNumber { get; set; }
        [Key(2)]
        public int ParentId { get; set; }
        [Key(3)]
        public bool IsBasicTutorial { get; set; }
        [Key(4)]
        public int NextTutorialId { get; set; }
        [Key(5)]
        public int Difficulty { get; set; }
        [Key(6)]
        public string BannerPath { get; set; }
    }

    [MemoryTable("BingoMissionLineMaster")]

    [MessagePackObject(false)]

    public class BingoMissionLineMaster
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int Line { get; set; }
        [Key(1)]
        public string RewardNameTextId { get; set; }
        [Key(2)]
        public string ImagePath { get; set; }
    }

    [MemoryTable("BingoMissionMaster")]

    [MessagePackObject(false)]

    public class BingoMissionMaster
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int Id { get; set; }
        [Key(1)]
        [SecondaryKey(0, 0)]
        public int Position { get; set; }
        [SecondaryKey(1, 0)]
        [Key(2)]
        public int AchieveCondition { get; set; }
        [Key(3)]
        public int AchieveConditionDetailId { get; set; }
        [Key(4)]
        public int RequireCount { get; set; }
        [Key(5)]
        public int MessageId { get; set; }
        [Key(6)]
        public string MissionNameTextId { get; set; }
    }

    [MemoryTable("BoxGrade")]

    [MessagePackObject(false)]

    public class BoxGrade
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int Id { get; set; }
        [Key(1)]
        [SecondaryKey(0, 0)]
        public int Round { get; set; }
        [SecondaryKey(0, 0)]
        [Key(2)]
        public int Tier { get; set; }
        [Key(3)]
        [SecondaryKey(0, 0)]
        public int WinCount { get; set; }
        [Key(4)]
        public int GradeId { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("CardFilterKeywordMaster")]

    public class CardFilterKeywordMaster
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int Id { get; set; }
        [Key(1)]
        public string _Keyword { get; set; }
        [IgnoreMember]
        public MasterTextId Keyword { get; set; }
        [Key(2)]
        public string _Category { get; set; }
        [IgnoreMember]
        public MasterTextId Category { get; set; }
    }
    public enum BattleSummonContinueEffectStopTiming : uint { None = 0, All = 4294967295, RemoveField = 1, TurnEnd = 2, }

    [MessagePackObject(false)]

    [MemoryTable("CardResourceMaster")]

    public class CardResourceMaster
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int CardResourceId { get; set; }
        [Key(1)]
        public int TextureName { get; set; }
        [Key(2)]
        public int HeaderTextureName { get; set; }
        [Key(3)]
        public string SummonEffectPath { get; set; }
        [Key(4)]
        public string SummonMoveType { get; set; }
        [Key(5)]
        public Single SummonTime { get; set; }
        [Key(6)]
        public string SummonFx { get; set; }
        [Key(7)]
        public string SummonContinueEffectPath { get; set; }
        [Key(8)]
        public BattleSummonContinueEffectStopTiming SummonContinueEffectStopTiming { get; set; }
        [Key(9)]
        public string SummonContinueFx { get; set; }
        [Key(10)]
        public string SummonPraiseEffectPath { get; set; }
        [Key(11)]
        public string SummonPraiseMoveType { get; set; }
        [Key(12)]
        public Single SummonPraiseTime { get; set; }
        [Key(13)]
        public string SummonPraiseFx { get; set; }
        [Key(14)]
        public string AtkEffectPath { get; set; }
        [Key(15)]
        public string AtkMoveType { get; set; }
        [Key(16)]
        public Single AtkTime { get; set; }
        [Key(17)]
        public string AtkFx { get; set; }
        [Key(18)]
        public string SubAtkParam { get; set; }
        [Key(19)]
        public string EvoAtkEffectPath { get; set; }
        [Key(20)]
        public string EvoAtkMoveType { get; set; }
        [Key(21)]
        public Single EvoAtkTime { get; set; }
        [Key(22)]
        public string EvoAtkFx { get; set; }
        [Key(23)]
        public string EvoSubAtkParam { get; set; }
        [Key(24)]
        public int HeavyParam { get; set; }
        [Key(25)]
        public Single TillingNormalX { get; set; }
        [Key(26)]
        public Single TillingNormalY { get; set; }
        [Key(27)]
        public Single OffsetNormalX { get; set; }
        [Key(28)]
        public Single OffsetNormalY { get; set; }
        [Key(29)]
        public Single TillingEvolX { get; set; }
        [Key(30)]
        public Single TillingEvolY { get; set; }
        [Key(31)]
        public Single OffsetEvolX { get; set; }
        [Key(32)]
        public Single OffsetEvolY { get; set; }
        [Key(33)]
        public Single TillingSuperEvolX { get; set; }
        [Key(34)]
        public Single TillingSuperEvolY { get; set; }
        [Key(35)]
        public Single OffsetSuperEvolX { get; set; }
        [Key(36)]
        public Single OffsetSuperEvolY { get; set; }
        [Key(37)]
        public string VoiceBankName { get; set; }
        [Key(38)]
        public string PlayVoice { get; set; }
        [Key(39)]
        public string AttackVoice { get; set; }
        [Key(40)]
        public string EvoAttackVoice { get; set; }
        [Key(41)]
        public string EvolveVoice { get; set; }
        [Key(42)]
        public string DestroyVoice { get; set; }
        [Key(43)]
        public string EvoDestroyVoice { get; set; }
        [Key(44)]
        public string SkillVoice { get; set; }
        [Key(45)]
        public string EvoSkillVoice { get; set; }
        [Key(46)]
        public string ActVoice { get; set; }
        [Key(47)]
        public Single SuperEvolveBlowTime { get; set; }
        [Key(48)]
        public string DestroyEffectPath { get; set; }
        [Key(49)]
        public string DestroyEffectFx { get; set; }
    }

    [MemoryTable("CardMaster")]

    [MessagePackObject(false)]

    public class CardMaster
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int CardId { get; set; }
        [Key(1)]
        [NonUnique]
        [SecondaryKey(6, 0)]
        public int BaseCardId { get; set; }
        [Key(2)]
        public int CardResourceId { get; set; }
        [Key(3)]
        public int CardSetId { get; set; }
        [Key(4)]
        public int CardTextId { get; set; }
        [Key(5)]
        public int FoilType { get; set; }
        [Key(6)]
        public int PreConvertId { get; set; }
        [Key(7)]
        public int LeaderAreaOwnerId { get; set; }
        [SecondaryKey(0, 0)]
        [Key(8)]
        public string HashId { get; set; }
        [IgnoreMember]
        public CardResourceMaster CardResourceIdRef { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("CardStyleResource")]

    public class CardStyleResource
    {
        [SecondaryKey(0, 0)]
        [Key(0)]
        [PrimaryKey(0)]
        public int StyleId { get; set; }
        [Key(1)]
        [SecondaryKey(0, 0)]
        public int CardId { get; set; }
        [Key(2)]
        public int CardResourceId { get; set; }
        [Key(3)]
        public int CardTextId { get; set; }
        [Key(4)]
        public int FrameId { get; set; }
        [Key(5)]
        public int StyleEffectId { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("CardText")]

    public class CardText
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int CardTextId { get; set; }
        [Key(1)]
        public string _Name { get; set; }
        [IgnoreMember]
        public MasterTextId Name { get; set; }
        [Key(2)]
        public string _SkillDesc { get; set; }
        [IgnoreMember]
        public MasterTextId SkillDesc { get; set; }
        [Key(3)]
        public string _Flavour { get; set; }
        [IgnoreMember]
        public MasterTextId Flavour { get; set; }
        [Key(4)]
        public string _EvoFlavour { get; set; }
        [IgnoreMember]
        public MasterTextId EvoFlavour { get; set; }
        [Key(5)]
        public string _CardCv { get; set; }
    }
    public enum CardTextPhraseDisplay : uint { Always = 1, OnlyBattle = 2, OnlyHand = 3, OnlyField = 4, }

    [MemoryTable("CardTextPhrase")]

    [MessagePackObject(false)]

    public class CardTextPhrase
    {
        [Key(0)]
        [PrimaryKey(0)]
        public string Identifier { get; set; }
        [Key(1)]
        public CardTextPhraseDisplay Display { get; set; }
        [Key(2)]
        public string _Text { get; set; }
        [IgnoreMember]
        public MasterTextId Text { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("CardVoiceIgnoreMaster")]

    public class CardVoiceIgnoreMaster
    {
        [PrimaryKey(0)]
        [Key(0)]
        public string VoiceId { get; set; }
    }

    [MemoryTable("CollectionNoBlankStyle")]

    [MessagePackObject(false)]

    public class CollectionNoBlankStyle
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int StyleId { get; set; }
        [Key(1)]
        public string Name { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("CutsceneMaster")]

    public class CutsceneMaster
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int Id { get; set; }
        [NonUnique]
        [SecondaryKey(5, 0)]
        [Key(1)]
        public int WatchType { get; set; }
        [Key(2)]
        public string StartDate { get; set; }
        [Key(3)]
        public string EndDate { get; set; }
        [Key(4)]
        public string MovieFile { get; set; }
        [Key(5)]
        public string SoundFile { get; set; }
        [Key(6)]
        public string CutsceneName { get; set; }
    }
    public enum DecorativeItemCategory : uint { Medal = 0, Trophy = 1, }

    [MemoryTable("DecorativeItem")]

    [MessagePackObject(false)]

    public class DecorativeItem
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int DecorativeItemId { get; set; }
        [Key(1)]
        public int SortId { get; set; }
        [Key(2)]
        public DecorativeItemCategory Category { get; set; }
        [Key(3)]
        public string _NameId { get; set; }
        [IgnoreMember]
        public MasterTextId NameId { get; set; }
        [Key(4)]
        public string _DescriptionId { get; set; }
        [IgnoreMember]
        public MasterTextId DescriptionId { get; set; }
        [Key(5)]
        public string ModelId { get; set; }
        [Key(6)]
        public string IconName { get; set; }
        [Key(7)]
        public string ThumbnailId { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("DefaultloadingMaster")]

    public class DefaultloadingMaster
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int Id { get; set; }
        [Key(1)]
        public string _TitleName { get; set; }
        [IgnoreMember]
        public MasterTextId TitleName { get; set; }
        [Key(2)]
        public string _DetailName { get; set; }
        [IgnoreMember]
        public MasterTextId DetailName { get; set; }
        [Key(3)]
        public int LoadType { get; set; }
        [Key(4)]
        public int ImageId { get; set; }
        [Key(5)]
        public string StartDate { get; set; }
        [Key(6)]
        public string EndDate { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("DegreeCategotyMaster")]

    public class DegreeCategotyMaster
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int CategoryId { get; set; }
        [Key(1)]
        public string CategoryName { get; set; }
    }

    [MemoryTable("DegreeMaster")]

    [MessagePackObject(false)]

    public class DegreeMaster
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int Id { get; set; }
        [Key(1)]
        public int OrderNumber { get; set; }
        [Key(2)]
        public int IsSpecial { get; set; }
        [Key(3)]
        public string Name { get; set; }
        [Key(4)]
        public string Path { get; set; }
        [Key(5)]
        public string DegreeAchievementId { get; set; }
        [Key(6)]
        public int CategoryId { get; set; }
        [Key(7)]
        public int IsPremium { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("EmblemCategotyMaster")]

    public class EmblemCategotyMaster
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int CategoryId { get; set; }
        [Key(1)]
        public string CategoryName { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("EmblemMaster")]

    public class EmblemMaster
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int Id { get; set; }
        [Key(1)]
        public int IsSpecial { get; set; }
        [Key(2)]
        public string Name { get; set; }
        [Key(3)]
        public string Path { get; set; }
        [Key(4)]
        public int CategoryId { get; set; }
        [Key(5)]
        public int BaseId { get; set; }
        [Key(6)]
        public int PremiumId { get; set; }
        [Key(7)]
        public int IsPremium { get; set; }
        [Key(8)]
        public int SeriesId { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("EmoteColorChange")]

    public class EmoteColorChange
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int EmoteId { get; set; }
        [Key(1)]
        public string MaterialName { get; set; }
        [Key(2)]
        public string[] Color { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("ExticketResourceMaster")]

    public class ExticketResourceMaster
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int ItemId { get; set; }
        [Key(1)]
        public int CardResourceId { get; set; }
        [Key(2)]
        public int FrameId { get; set; }
        [Key(3)]
        public Single TillingNormalX { get; set; }
        [Key(4)]
        public Single TillingNormalY { get; set; }
        [Key(5)]
        public Single OffsetNormalX { get; set; }
        [Key(6)]
        public Single OffsetNormalY { get; set; }
    }
    public enum FirstTipsType : uint { Image = 0, TextOnly = 1, Cut = 2, }

    [MessagePackObject(false)]

    [MemoryTable("FirstTipsMaster")]

    public class FirstTipsMaster
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int Id { get; set; }
        [SecondaryKey(4, 0)]
        [NonUnique]
        [Key(1)]
        public int Group { get; set; }
        [Key(2)]
        public string Comment { get; set; }
        [Key(3)]
        public FirstTipsType Type { get; set; }
        [Key(4)]
        public string TextId { get; set; }
        [Key(5)]
        public string ImageName { get; set; }
    }

    [MemoryTable("FurnitureObjectMaster")]

    [MessagePackObject(false)]

    public class FurnitureObjectMaster
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int MetaverseObjectId { get; set; }
        [Key(1)]
        public int[] PlaceableSeriesIds { get; set; }
        [Key(2)]
        public int FurnitureType { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("GuildAchievementMaster")]

    public class GuildAchievementMaster
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int AchievementId { get; set; }
        [Key(1)]
        public int Category { get; set; }
        [Key(2)]
        public string _DescriptionText { get; set; }
        [IgnoreMember]
        public MasterTextId DescriptionText { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("GuildAchievementReward")]

    public class GuildAchievementReward
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int Id { get; set; }
        [SecondaryKey(0, 0)]
        [Key(1)]
        public int RewardType { get; set; }
        [Key(2)]
        [SecondaryKey(0, 0)]
        public int RewardDetailId { get; set; }
        [Key(3)]
        public int AchievementId { get; set; }
    }

    [MemoryTable("GuildFrameMaster")]

    [MessagePackObject(false)]

    public class GuildFrameMaster
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int Id { get; set; }
        [Key(1)]
        public string _Name { get; set; }
        [IgnoreMember]
        public MasterTextId Name { get; set; }
        [Key(2)]
        public string ImageBaseName { get; set; }
        [Key(3)]
        public string ThumbnailPath { get; set; }
    }

    [MemoryTable("GuildLevelMaster")]

    [MessagePackObject(false)]

    public class GuildLevelMaster
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int Level { get; set; }
        [Key(1)]
        public int NecessaryPoint { get; set; }
        [Key(2)]
        public int AccumulatePoint { get; set; }
        [Key(3)]
        public string _UnlockText { get; set; }
        [IgnoreMember]
        public MasterTextId UnlockText { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("GuildMissionName")]

    public class GuildMissionName
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int MissionId { get; set; }
        [Key(1)]
        public string _MissionName { get; set; }
        [IgnoreMember]
        public MasterTextId MissionName { get; set; }
    }
    public enum GuildTagLookType : uint { Normal = 0, Bronze = 1, Silver = 2, Gold = 3, }

    [MessagePackObject(false)]

    [MemoryTable("GuildTagMaster")]

    public class GuildTagMaster
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int TagId { get; set; }
        [Key(1)]
        public GuildTagLookType LookType { get; set; }
        [Key(2)]
        public string _NameTextId { get; set; }
        [IgnoreMember]
        public MasterTextId NameTextId { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("HighPremiumCard")]

    public class HighPremiumCard
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int CardId { get; set; }
        [Key(1)]
        public string Name { get; set; }
        [Key(2)]
        public Single ScaleX { get; set; }
        [Key(3)]
        public Single ScaleY { get; set; }
        [Key(4)]
        public Single OffsetX { get; set; }
        [Key(5)]
        public Single OffsetY { get; set; }
        [Key(6)]
        public Single EvolvedScaleX { get; set; }
        [Key(7)]
        public Single EvolvedScaleY { get; set; }
        [Key(8)]
        public Single EvolvedOffsetX { get; set; }
        [Key(9)]
        public Single EvolvedOffsetY { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("HomeIllustrationMaster")]

    public class HomeIllustrationMaster
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int Id { get; set; }
        [Key(1)]
        public int TextArrowDirection { get; set; }
        [Key(2)]
        public Single TextPosX { get; set; }
        [Key(3)]
        public Single TextPosY { get; set; }
    }
    public enum ParkVenue : uint { Lobby = 0, GuildLounge = 1, Space = 2, }

    [MessagePackObject(false)]

    [MemoryTable("HomeParkButtonAd")]

    public class HomeParkButtonAd
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int HomeParkButtonAdId { get; set; }
        [Key(1)]
        public int CampaignType { get; set; }
        [Key(2)]
        public ParkVenue DialogTarget { get; set; }
        [Key(3)]
        public int Sort { get; set; }
        [Key(4)]
        public string _AdText { get; set; }
        [IgnoreMember]
        public MasterTextId AdText { get; set; }
        [Key(5)]
        public string _FooterBalloonText { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("HouseActivityObjMaster")]

    public class HouseActivityObjMaster
    {
        [SecondaryKey(0, 0)]
        [PrimaryKey(0)]
        [Key(0)]
        public int HouseActivityObjId { get; set; }
        [Key(1)]
        [SecondaryKey(5, 0)]
        [SecondaryKey(0, 0)]
        [NonUnique]
        public int HouseSetId { get; set; }
        [Key(2)]
        public int DefaultObjectId { get; set; }
        [Key(3)]
        public Single PositionX { get; set; }
        [Key(4)]
        public Single PositionY { get; set; }
        [Key(5)]
        public Single PositionZ { get; set; }
        [Key(6)]
        public Single RotationX { get; set; }
        [Key(7)]
        public Single RotationY { get; set; }
        [Key(8)]
        public Single RotationZ { get; set; }
        [Key(9)]
        public Single ScaleX { get; set; }
        [Key(10)]
        public Single ScaleY { get; set; }
        [Key(11)]
        public Single ScaleZ { get; set; }
        [Key(12)]
        public int ChildObjectId { get; set; }
        [Key(13)]
        public int PlayDetailId { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("HouseEditableObjMaster")]

    public class HouseEditableObjMaster
    {
        [Key(0)]
        [SecondaryKey(0, 0)]
        [PrimaryKey(0)]
        public int HouseEditableObjId { get; set; }
        [SecondaryKey(0, 0)]
        [SecondaryKey(5, 0)]
        [NonUnique]
        [Key(1)]
        public int HouseSetId { get; set; }
        [Key(2)]
        public int DefaultObjectId { get; set; }
        [Key(3)]
        public Single PositionX { get; set; }
        [Key(4)]
        public Single PositionY { get; set; }
        [Key(5)]
        public Single PositionZ { get; set; }
        [Key(6)]
        public Single RotationX { get; set; }
        [Key(7)]
        public Single RotationY { get; set; }
        [Key(8)]
        public Single RotationZ { get; set; }
        [Key(9)]
        public Single ScaleX { get; set; }
        [Key(10)]
        public Single ScaleY { get; set; }
        [Key(11)]
        public Single ScaleZ { get; set; }
        [Key(12)]
        public int ChildObjectId { get; set; }
        [Key(13)]
        public int EssentialIdType { get; set; }
        [Key(14)]
        public int EssentialDetailId { get; set; }
        [Key(15)]
        public int EssentialExtraId { get; set; }
    }

    [MemoryTable("HouseSetMaster")]

    [MessagePackObject(false)]

    public class HouseSetMaster
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int HouseSetId { get; set; }
        [Key(1)]
        public int SeriesId { get; set; }
        [Key(2)]
        public string HouseSetModelId { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("Item")]

    public class Item
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int ItemId { get; set; }
        [Key(1)]
        public int ItemType { get; set; }
        [Key(2)]
        public string Name { get; set; }
        [Key(3)]
        public int LimitNum { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("ItemMaster")]

    public class ItemMaster
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int ItemId { get; set; }
        [Key(1)]
        public int ItemType { get; set; }
        [Key(2)]
        public string ThumbnailPath { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("LeaderSkinMaster")]

    public class LeaderSkinMaster
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int LeaderSkinId { get; set; }
        [Key(1)]
        public string LeaderSkinName { get; set; }
        [Key(2)]
        [NonUnique]
        [SecondaryKey(5, 0)]
        public int ClassId { get; set; }
        [Key(3)]
        public int EmoteId { get; set; }
        [Key(4)]
        public int AvailableTermId { get; set; }
        [Key(5)]
        public int IsHighRank { get; set; }
        [Key(6)]
        public int StartCutinId { get; set; }
    }

    [MemoryTable("LobbyEventSchedule")]

    [MessagePackObject(false)]

    public class LobbyEventSchedule
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int EventId { get; set; }
        [Key(1)]
        public int EventType { get; set; }
        [Key(2)]
        public int ConditionValue { get; set; }
        [Key(3)]
        public string OpenDate { get; set; }
        [Key(4)]
        public string StartDate { get; set; }
        [Key(5)]
        public string EndDate { get; set; }
        [Key(6)]
        public string CloseDate { get; set; }
    }

    [MemoryTable("LobbyTournament")]

    [MessagePackObject(false)]

    public class LobbyTournament
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int Id { get; set; }
        [Key(1)]
        public string Name { get; set; }
        [Key(2)]
        public string HomeDescription { get; set; }
        [Key(3)]
        public string TournamentName { get; set; }
        [Key(4)]
        public string FormatName { get; set; }
        [Key(5)]
        public string FormatDescription { get; set; }
        [Key(6)]
        public string EntryCondition { get; set; }
        [Key(7)]
        public int EntryNum { get; set; }
        [Key(8)]
        public int TotalRound { get; set; }
        [Key(9)]
        public int BattleRule { get; set; }
        [Key(10)]
        public string EntryPageLogoLayoutPrefab { get; set; }
        [Key(11)]
        public int EntryPageDecorationId { get; set; }
        [Key(12)]
        public string EntryPageCollaboImagePath { get; set; }
        [Key(13)]
        public string EntryPageBalloonText { get; set; }
        [Key(14)]
        public string EntryPageEntryConfirmText { get; set; }
        [Key(15)]
        public int MinRankId { get; set; }
        [Key(16)]
        public string BannerImg { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("LobbyTreasureBoxQuestMaster")]

    public class LobbyTreasureBoxQuestMaster
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int Id { get; set; }
        [SecondaryKey(5, 0)]
        [NonUnique]
        [Key(1)]
        public int ScheduleId { get; set; }
        [Key(2)]
        public string Name { get; set; }
        [Key(3)]
        public int AchieveCondition { get; set; }
        [Key(4)]
        public int AchieveConditionDetailId { get; set; }
        [Key(5)]
        public int RequireCount { get; set; }
        [Key(6)]
        public int LimitType { get; set; }
        [Key(7)]
        public int RewardPoint { get; set; }
        [Key(8)]
        public int RewardType { get; set; }
        [Key(9)]
        public int RewardDetailId { get; set; }
        [Key(10)]
        public int RewardNumber { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("LobbyTreasureBoxQuestWeeklyPointReward")]

    public class LobbyTreasureBoxQuestWeeklyPointReward
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int Id { get; set; }
        [Key(1)]
        [NonUnique]
        [SecondaryKey(5, 0)]
        public int ScheduleId { get; set; }
        [Key(2)]
        public int Point { get; set; }
        [Key(3)]
        public int RewardType { get; set; }
        [Key(4)]
        public int RewardDetailId { get; set; }
        [Key(5)]
        public int RewardNumber { get; set; }
    }

    [MemoryTable("LobbyTreasureBoxRewardGroup")]

    [MessagePackObject(false)]

    public class LobbyTreasureBoxRewardGroup
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int Id { get; set; }
        [Key(1)]
        public string Name { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("MasterTextLabel")]

    public class MasterTextLabel
    {
        [Key(0)]
        [PrimaryKey(0)]
        public string Id { get; set; }
        [Key(1)]
        public string Text { get; set; }
    }

    [MemoryTable("MetaverseBgmMaster")]

    [MessagePackObject(false)]

    public class MetaverseBgmMaster
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int BgmId { get; set; }
        [Key(1)]
        public string BgmEventName { get; set; }
        [Key(2)]
        public string BgmTitle { get; set; }
        [Key(3)]
        public int BgmDuration { get; set; }
    }
    public enum ConciergeTextUsageType : uint { TalkStart = 0, TalkEnd = 1, TalkGuest = 2, StartRebuild = 3, Cutscene_1 = 4, Cutscene_1_Leader = 5, Cutscene_2 = 6, Cutscene_3 = 7, Cutscene_4 = 8, }

    [MessagePackObject(false)]

    [MemoryTable("MetaverseConcierge")]

    public class MetaverseConcierge
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int Id { get; set; }
        [SecondaryKey(0, 0)]
        [Key(1)]
        public int NpcId { get; set; }
        [Key(2)]
        [SecondaryKey(0, 0)]
        public ConciergeTextUsageType UsageType { get; set; }
        [SecondaryKey(0, 0)]
        [Key(3)]
        public int Index { get; set; }
        [Key(4)]
        public string _MessageText { get; set; }
        [IgnoreMember]
        public MasterTextId MessageText { get; set; }
    }
    public enum MetaverseGatePointType : uint { Start = 1, Middle = 2, End = 3, LeaveCameraPos = 4, LeaveStart = 5, LeaveMiddle = 6, LeaveEnd = 7, }

    [MemoryTable("MetaverseGateMaster")]

    [MessagePackObject(false)]

    public class MetaverseGateMaster
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int Id { get; set; }
        [SecondaryKey(4, 0)]
        [NonUnique]
        [Key(1)]
        public int MetaverseObjectId { get; set; }
        [Key(2)]
        public MetaverseGatePointType PointType { get; set; }
        [Key(3)]
        public Single PositionX { get; set; }
        [Key(4)]
        public Single PositionY { get; set; }
        [Key(5)]
        public Single PositionZ { get; set; }
        [Key(6)]
        public Single CameraH { get; set; }
        [Key(7)]
        public Single CameraV { get; set; }
    }
    public enum LobbyCardEssentialIdType : uint { Card = 1, Illustration = 2, }

    [MessagePackObject(false)]

    [MemoryTable("MetaverseLobbyCard")]

    public class MetaverseLobbyCard
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int Id { get; set; }
        [Key(1)]
        [SecondaryKey(4, 0)]
        [NonUnique]
        public int GroupId { get; set; }
        [Key(2)]
        public LobbyCardEssentialIdType ContentType { get; set; }
        [Key(3)]
        public int DetailId { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("MetaverseMap")]

    public class MetaverseMap
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int MapId { get; set; }
        [Key(1)]
        public string Name { get; set; }
        [Key(2)]
        public int MaxUserCount { get; set; }
        [Key(3)]
        public string SceneName { get; set; }
        [Key(4)]
        public string DefaultBgm { get; set; }
        [Key(5)]
        public string WwiseSceneState { get; set; }
        [Key(6)]
        public Single JoinPositionX { get; set; }
        [Key(7)]
        public Single JoinPositionY { get; set; }
        [Key(8)]
        public Single JoinPositionZ { get; set; }
        [Key(9)]
        public Single CameraH { get; set; }
        [Key(10)]
        public Single CameraV { get; set; }
        [Key(11)]
        public int IntroCutTipsId { get; set; }
        [Key(12)]
        public int NpcPlacementId { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("MetaverseMapSpot")]

    public class MetaverseMapSpot
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int SpotId { get; set; }
        [NonUnique]
        [SecondaryKey(4, 0)]
        [Key(1)]
        public int MapId { get; set; }
        [Key(2)]
        public string Name { get; set; }
        [Key(3)]
        public Single PositionX { get; set; }
        [Key(4)]
        public Single PositionY { get; set; }
        [Key(5)]
        public Single PositionZ { get; set; }
        [Key(6)]
        public Single CameraH { get; set; }
        [Key(7)]
        public Single CameraV { get; set; }
        [Key(8)]
        public bool HideOnMapFlag { get; set; }
        [Key(9)]
        public Single OffsetX { get; set; }
        [Key(10)]
        public Single OffsetY { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("MetaverseMonitorContent")]

    public class MetaverseMonitorContent
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int Id { get; set; }
        [Key(1)]
        public int ContentType { get; set; }
        [Key(2)]
        public int MonitorType { get; set; }
        [Key(3)]
        public string ContentFileName { get; set; }
        [Key(4)]
        public string SoundName { get; set; }
        [Key(5)]
        public int Length { get; set; }
        [Key(6)]
        public int FadeOutType { get; set; }
        [Key(7)]
        public string AccessUrl { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("MetaverseMonitorSchedule")]

    public class MetaverseMonitorSchedule
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int Id { get; set; }
        [NonUnique]
        [Key(1)]
        [SecondaryKey(5, 0)]
        public int DetailId { get; set; }
        [Key(2)]
        public int[] MonitorContentIds { get; set; }
        [Key(3)]
        public string StartDate { get; set; }
        [Key(4)]
        public string EndDate { get; set; }
    }
    public enum MetaverseNpcType : uint { None = 0, Tutorial = 1, AreaWarp = 2, Achievement = 3, Conversation = 4, Shop = 5, GuildConcierge = 6, }

    [MessagePackObject(false)]

    [MemoryTable("MetaverseNpc")]

    public class MetaverseNpc
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int Id { get; set; }
        [Key(1)]
        public string _Name { get; set; }
        [IgnoreMember]
        public MasterTextId Name { get; set; }
        [Key(2)]
        public string _PositionName { get; set; }
        [IgnoreMember]
        public MasterTextId PositionName { get; set; }
        [Key(3)]
        public MetaverseNpcType NpcType { get; set; }
        [Key(4)]
        public string _InteractiveLabelText { get; set; }
        [IgnoreMember]
        public MasterTextId InteractiveLabelText { get; set; }
        [Key(5)]
        public string _MessageText0 { get; set; }
        [IgnoreMember]
        public MasterTextId MessageText0 { get; set; }
        [Key(6)]
        public string _MessageText1 { get; set; }
        [Key(7)]
        public string _MessageText2 { get; set; }
        [Key(8)]
        public string _MessageText3 { get; set; }
        [Key(9)]
        public int ReactionEmoteId { get; set; }
        [Key(10)]
        public string AvatarModelName { get; set; }
        [Key(11)]
        public int[] AvatarPartsIds { get; set; }
        [Key(12)]
        public int[] AvatarPartsColorIds { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("MetaverseNpcPlacement")]

    public class MetaverseNpcPlacement
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int Id { get; set; }
        [Key(1)]
        public string PrefabName { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("MetaverseObjectMaster")]

    public class MetaverseObjectMaster
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int MetaverseObjectId { get; set; }
        [Key(1)]
        public string Name { get; set; }
        [Key(2)]
        public int OperationType { get; set; }
        [Key(3)]
        public int ObjectType { get; set; }
        [Key(4)]
        public string MetaverseObjectModelId { get; set; }
        [Key(5)]
        public int ObjectCategory { get; set; }
        [Key(6)]
        public int[] ColorIds { get; set; }
        [Key(7)]
        public string ColorFormatPath { get; set; }
        [Key(8)]
        public int UseMemberLimit { get; set; }
        [Key(9)]
        public int[] ChildObjectTypes { get; set; }
        [Key(10)]
        public int DefaultChildId { get; set; }
        [Key(11)]
        public int Talk3dBgObjCollectType { get; set; }
    }

    [MemoryTable("MetaverseTempleteMessage")]

    [MessagePackObject(false)]

    public class MetaverseTempleteMessage
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int Id { get; set; }
        [Key(1)]
        public string TextId { get; set; }
        [Key(2)]
        public string FilePath { get; set; }
        [Key(3)]
        public int AvatarVoiceId { get; set; }
    }
    public enum MetaverseTutorialStepType : uint { None = 0, PlayFirstMovie = 1, CreateAvatar = 2, UseTreasureBoxKey = 3, TutorialComplete = 4, OpenTreasureBoxResult = 5, }

    [MessagePackObject(false)]

    [MemoryTable("MetaverseTutorial")]

    public class MetaverseTutorial
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int Id { get; set; }
        [Key(1)]
        public int SeasonId { get; set; }
        [Key(2)]
        public int Step { get; set; }
        [Key(3)]
        [SecondaryKey(0, 0)]
        public MetaverseTutorialStepType StepType { get; set; }
    }

    [MemoryTable("ModeSkillText")]

    [MessagePackObject(false)]

    public class ModeSkillText
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int CardId { get; set; }
        [Key(1)]
        [PrimaryKey(0)]
        public int TimingIndex { get; set; }
        [Key(2)]
        [PrimaryKey(0)]
        public int ModeIndex { get; set; }
        [Key(3)]
        public string _ModeDesc { get; set; }
        [IgnoreMember]
        public MasterTextId ModeDesc { get; set; }
    }

    [MemoryTable("MtvJumpGimmickMaster")]

    [MessagePackObject(false)]

    public class MtvJumpGimmickMaster
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int MetaverseObjectId { get; set; }
        [Key(1)]
        public int JumpUpValue { get; set; }
        [Key(2)]
        public int MoveVelocityScaleUpValue { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("MtvObjectDeployMaster")]

    public class MtvObjectDeployMaster
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int MetaverseObjectDeployId { get; set; }
        [SecondaryKey(5, 0)]
        [NonUnique]
        [Key(1)]
        public int MapId { get; set; }
        [SecondaryKey(6, 0)]
        [Key(2)]
        [NonUnique]
        public int MetaverseObjectId { get; set; }
        [Key(3)]
        public Single PositionX { get; set; }
        [Key(4)]
        public Single PositionY { get; set; }
        [Key(5)]
        public Single PositionZ { get; set; }
        [Key(6)]
        public Single RotationX { get; set; }
        [Key(7)]
        public Single RotationY { get; set; }
        [Key(8)]
        public Single RotationZ { get; set; }
        [Key(9)]
        public Single ScaleX { get; set; }
        [Key(10)]
        public Single ScaleY { get; set; }
        [Key(11)]
        public Single ScaleZ { get; set; }
        [Key(12)]
        public int ColorId { get; set; }
        [Key(13)]
        public int ChildObjectId { get; set; }
        [Key(14)]
        public int ChildColorId { get; set; }
        [Key(15)]
        public int DetailId { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("NpcAchievConditionMaster")]

    public class NpcAchievConditionMaster
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int Id { get; set; }
        [Key(1)]
        public int ConditionType { get; set; }
        [Key(2)]
        public string Description { get; set; }
        [Key(3)]
        public int TargetId { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("NpcAchievMaster")]

    public class NpcAchievMaster
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int Id { get; set; }
        [Key(1)]
        public int UnlockNpcId { get; set; }
        [Key(2)]
        public int UnlockConditionId { get; set; }
        [Key(3)]
        public string _UnlockLabelText { get; set; }
        [IgnoreMember]
        public MasterTextId UnlockLabelText { get; set; }
        [Key(4)]
        public string _UnlockMessageText { get; set; }
        [IgnoreMember]
        public MasterTextId UnlockMessageText { get; set; }
        [Key(5)]
        public int CompletionNpcId { get; set; }
        [Key(6)]
        public int CompletionConditionId { get; set; }
        [Key(7)]
        public string _CompletionLabelText { get; set; }
        [IgnoreMember]
        public MasterTextId CompletionLabelText { get; set; }
        [Key(8)]
        public string _CompletionMessageText { get; set; }
        [IgnoreMember]
        public MasterTextId CompletionMessageText { get; set; }
        [Key(9)]
        public int RewardType { get; set; }
        [Key(10)]
        public int RewardDetailId { get; set; }
        [Key(11)]
        public int RewardNumber { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("PuzzleBattleMaster")]

    public class PuzzleBattleMaster
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int Id { get; set; }
        [Key(1)]
        public string WinConditionTextId { get; set; }
        [Key(2)]
        public string[] HintTextId { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("PuzzleMaster")]

    public class PuzzleMaster
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int Id { get; set; }
        [Key(1)]
        public int SortType { get; set; }
        [Key(2)]
        public string CharaId { get; set; }
        [Key(3)]
        public string BasicTitleTextId { get; set; }
        [Key(4)]
        public string BasicPuzzleStartDate { get; set; }
        [Key(5)]
        public int MissionId { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("Rank")]

    public class Rank
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int Id { get; set; }
        [Key(1)]
        public int Type { get; set; }
        [Key(2)]
        public int NecessaryPoint { get; set; }
        [Key(3)]
        public int AccumulatePoint { get; set; }
        [Key(4)]
        public int LowerLimitPoint { get; set; }
        [Key(5)]
        public int BaseAddPoint { get; set; }
        [Key(6)]
        public int BaseDropPoint { get; set; }
    }

    [MemoryTable("SceneTransition")]

    [MessagePackObject(false)]

    public class SceneTransition
    {
        [Key(0)]
        public string RewardName { get; set; }
        [SecondaryKey(5, 0)]
        [Key(1)]
        [NonUnique]
        public int RewardType { get; set; }
        [Key(2)]
        [PrimaryKey(0)]
        public int RewardDetailIdMin { get; set; }
        [Key(3)]
        public int RewardDetailIdMax { get; set; }
        [Key(4)]
        public string Button1 { get; set; }
        [Key(5)]
        public string Button1Click { get; set; }
        [Key(6)]
        public int Button1Status { get; set; }
        [Key(7)]
        public string Button2 { get; set; }
        [Key(8)]
        public string Button2Click { get; set; }
        [Key(9)]
        public int Button2Status { get; set; }
        [Key(10)]
        public string Button3 { get; set; }
        [Key(11)]
        public string Button3Click { get; set; }
        [Key(12)]
        public int Button3Status { get; set; }
    }
    public enum BattleLogType : uint { Add = 0, AddWithoutTiming = 1, None = 2, }
    public enum SideLogType : uint { None = 0, AddCommon = 1, AddInvocation = 2, }

    [MemoryTable("SkillMaster")]

    [MessagePackObject(false)]

    public class SkillMaster
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int SkillId { get; set; }
        [Key(1)]
        public BattleLogType BattleLogType { get; set; }
        [Key(2)]
        public SideLogType SideLogType { get; set; }
        [Key(3)]
        public string SkillEffectOption { get; set; }
    }
    public enum EffectTiming : uint { Default = 0, Custom = 1, Each = 2, }
    public enum EffectPosition : uint { Default = 0, Center = 1, CenterAlly = 2, CenterOppo = 3, }

    [MessagePackObject(false)]

    [MemoryTable("SkillResourceMaster")]

    public class SkillResourceMaster
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int SkillId { get; set; }
        [PrimaryKey(0)]
        [Key(1)]
        public int CardResourceId { get; set; }
        [Key(2)]
        public string[] SkillEffectPath { get; set; }
        [Key(3)]
        public string[] SkillMoveType { get; set; }
        [Key(4)]
        public Single SkillEffectTime { get; set; }
        [Key(5)]
        public EffectTiming SkillEffectTiming { get; set; }
        [Key(6)]
        public EffectPosition[] SkillEffectTargetPosition { get; set; }
        [Key(7)]
        public string[] SkillFx { get; set; }
        [Key(8)]
        public string[] SubEffParam { get; set; }
        [Key(9)]
        public string[] SuperEffParam { get; set; }
        [Key(10)]
        public string[] PraiseSkillEffectPath { get; set; }
        [Key(11)]
        public string[] PraiseSkillMoveType { get; set; }
        [Key(12)]
        public Single PraiseSkillEffectTime { get; set; }
        [Key(13)]
        public EffectPosition[] PraiseSkillEffectTargetPosition { get; set; }
        [Key(14)]
        public string[] PraiseSkillFx { get; set; }
        [Key(15)]
        public string[] PraiseSubEffParam { get; set; }
        [Key(16)]
        public string[] PraiseSuperEffParam { get; set; }
        [Key(17)]
        public int ShakeStrength { get; set; }
        [Key(18)]
        public string[] LowSkillEffectPath { get; set; }
        [Key(19)]
        public string[] LowSkillMoveType { get; set; }
        [Key(20)]
        public Single LowSkillEffectTime { get; set; }
        [Key(21)]
        public string[] LowSkillFx { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("Sleeve")]

    public class Sleeve
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int SleeveId { get; set; }
        [Key(1)]
        public string SleeveName { get; set; }
        [Key(2)]
        public string Path { get; set; }
        [Key(3)]
        public int CategoryId { get; set; }
        [Key(4)]
        public int IsPremium { get; set; }
        [Key(5)]
        public int BaseId { get; set; }
        [Key(6)]
        public int PremiumId { get; set; }
        [Key(7)]
        public int SeriesId { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("SleeveCategotyMaster")]

    public class SleeveCategotyMaster
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int CategoryId { get; set; }
        [Key(1)]
        public string CategoryName { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("Stamp")]

    public class Stamp
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int Id { get; set; }
        [Key(1)]
        public int Category { get; set; }
        [Key(2)]
        public string FileName { get; set; }
        [NonUnique]
        [Key(3)]
        [SecondaryKey(4, 0)]
        public bool UseInBattle { get; set; }
        [Key(4)]
        public int SortOrderInBattle { get; set; }
        [Key(5)]
        public string _LocalizedName { get; set; }
        [IgnoreMember]
        public MasterTextId LocalizedName { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("StampCategory")]

    public class StampCategory
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int Id { get; set; }
        [Key(1)]
        public string FileName { get; set; }
    }

    [MemoryTable("Story")]

    [MessagePackObject(false)]

    public class Story
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int StoryId { get; set; }
        [SecondaryKey(0, 0)]
        [Key(1)]
        public int SectionId { get; set; }
        [SecondaryKey(0, 0)]
        [Key(2)]
        public int EpisodeId { get; set; }
        [Key(3)]
        [SecondaryKey(0, 0)]
        public int ChapterId { get; set; }
        [Key(4)]
        public string OrderId { get; set; }
        [Key(5)]
        public string StartDate { get; set; }
    }

    [MemoryTable("StoryBattleSetting")]

    [MessagePackObject(false)]

    public class StoryBattleSetting
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int SectionId { get; set; }
        [Key(1)]
        [PrimaryKey(0)]
        public int EpisodeId { get; set; }
        [Key(2)]
        [PrimaryKey(0)]
        public int ChapterId { get; set; }
        [Key(3)]
        public int AvailableDeckClassId { get; set; }
        [Key(4)]
        public int TutorialId { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("StoryBattleTalkEvent")]

    public class StoryBattleTalkEvent
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int StoryId { get; set; }
        [Key(1)]
        [PrimaryKey(0)]
        public int TalkId { get; set; }
        [Key(2)]
        public int CharaId { get; set; }
        [Key(3)]
        public int FaceId { get; set; }
        [Key(4)]
        public string MessageTextId { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("StoryChapterResources")]

    public class StoryChapterResources
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int Id { get; set; }
        [Key(1)]
        [SecondaryKey(0, 0)]
        public int SectionId { get; set; }
        [SecondaryKey(0, 0)]
        [Key(2)]
        public int EpisodeId { get; set; }
        [SecondaryKey(0, 0)]
        [Key(3)]
        public int ChapterId { get; set; }
        [Key(4)]
        public string ChapterSummaryBgPath { get; set; }
        [Key(5)]
        public bool MovieFlag { get; set; }
        [Key(6)]
        public string LockTitle { get; set; }
        [Key(7)]
        public string LockHint { get; set; }
    }

    [MemoryTable("StoryEpisodeResources")]

    [MessagePackObject(false)]

    public class StoryEpisodeResources
    {
        [PrimaryKey(0)]
        [Key(0)]
        public int Id { get; set; }
        [SecondaryKey(5, 0)]
        [NonUnique]
        [Key(1)]
        public int SectionId { get; set; }
        [Key(2)]
        [NonUnique]
        [SecondaryKey(0, 0)]
        [SecondaryKey(5, 0)]
        public int EpisodeId { get; set; }
        [Key(3)]
        public string EpisodeTitleId { get; set; }
        [Key(4)]
        public string EpisodeThumbnailPath { get; set; }
        [Key(5)]
        public string SummaryOverviewId { get; set; }
        [Key(6)]
        public string SummaryTitleId { get; set; }
        [Key(7)]
        public string SummaryTextId { get; set; }
        [Key(8)]
        public string SummaryBgPath { get; set; }
        [Key(9)]
        public string ChapterselectBgPrefabPath { get; set; }
        [Key(10)]
        public string SoloplayButtonBgPrefabPath { get; set; }
    }

    [MemoryTable("StoryHint")]

    [MessagePackObject(false)]

    public class StoryHint
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int SectionId { get; set; }
        [Key(1)]
        [PrimaryKey(0)]
        public int EpisodeId { get; set; }
        [Key(2)]
        [PrimaryKey(0)]
        public int ChapterId { get; set; }
        [Key(3)]
        public int HintCount { get; set; }
    }

    [MemoryTable("SupplementText")]

    [MessagePackObject(false)]

    public class SupplementText
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int BaseCardId { get; set; }
        [Key(1)]
        public string SupplementDesc { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("TwopickrankingMaster")]

    public class TwopickrankingMaster
    {
        [Key(0)]
        [PrimaryKey(0)]
        public int Id { get; set; }
        [Key(1)]
        public string SeasonName { get; set; }
        [Key(2)]
        public int Round { get; set; }
        [Key(3)]
        public string StartDate { get; set; }
        [Key(4)]
        public string _EndName { get; set; }
        [IgnoreMember]
        public MasterTextId EndName { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("assetname")]

    public class AssetBundleLoadName
    {
        [Key(0)]
        [PrimaryKey(0)]
        [StringComparisonOption(StringComparison.OrdinalIgnoreCase)]
        public string AssetName { get; set; }
        [NonUnique]
        [SecondaryKey(1, 0)]
        [Key(1)]
        [StringComparisonOption(StringComparison.OrdinalIgnoreCase)]
        public string Name { get; set; }
    }

    [MessagePackObject(false)]

    [MemoryTable("asset")]

    public class ManifestAsset
    {
        [Key(0)]
        [StringComparisonOption(StringComparison.OrdinalIgnoreCase)]
        [PrimaryKey(0)]
        public string Name { get; set; }
        [Key(1)]
        [StringComparisonOption(StringComparison.Ordinal)]
        [SecondaryKey(0, 0)]
        public string Hash { get; set; }
        [Key(2)]
        [SecondaryKey(3, 0)]
        public int AssetId { get; set; }
        [Key(3)]
        public int[] AllDependencies { get; set; }
        [Key(4)]
        public long Key { get; set; }
        [Key(5)]
        public int Size { get; set; }
        [SecondaryKey(1, 0)]
        [NonUnique]
        [StringComparisonOption(StringComparison.Ordinal)]
        [Key(6)]
        public string Category { get; set; }
        [Key(7)]
        [SecondaryKey(2, 0)]
        [NonUnique]
        public int Group { get; set; }
        [Key(8)]
        public ulong CheckSum { get; set; }
    }

    [MemoryTable("config")]

    [MessagePackObject(false)]

    public class ManifestConfig
    {
        [PrimaryKey(0)]
        [Key(0)]
        [StringComparisonOption(StringComparison.OrdinalIgnoreCase)]
        public string Key { get; set; }
        [Key(1)]
        [StringComparisonOption(StringComparison.OrdinalIgnoreCase)]
        [NonUnique]
        [SecondaryKey(1, 0)]
        public string Value { get; set; }
    }

    [MemoryTable("raw_asset")]

    [MessagePackObject(false)]

    public class ManifestRawAsset
    {
        [Key(0)]
        [PrimaryKey(0)]
        [StringComparisonOption(StringComparison.OrdinalIgnoreCase)]
        public string Name { get; set; }
        [Key(1)]
        [StringComparisonOption(StringComparison.Ordinal)]
        [SecondaryKey(0, 0)]
        public string Hash { get; set; }
        [Key(2)]
        public int Size { get; set; }
        [StringComparisonOption(StringComparison.Ordinal)]
        [NonUnique]
        [Key(3)]
        [SecondaryKey(1, 0)]
        public string Category { get; set; }
        [SecondaryKey(2, 0)]
        [Key(4)]
        [NonUnique]
        public int Group { get; set; }
        [Key(5)]
        public ulong CheckSum { get; set; }
    }

    [MemoryTable("localize")]

    [MessagePackObject(false)]

    public class LocalizeText
    {
        [Key(0)]
        [PrimaryKey(0)]
        public string Id { get; set; }
        [Key(1)]
        public string Text { get; set; }
    }
}