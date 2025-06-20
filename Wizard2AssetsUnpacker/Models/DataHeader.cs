using MessagePack;

namespace Wizard2AssetsUnpacker.Models
{
    [MessagePackObject(false)]
    public class Maintenance
    {
        [Key("is_announce")]
        public bool is_announce;
        [Key("show_period")]
        public bool show_period;
        [Key("is_emergency")]
        public bool is_emergency;
        [Key("end_time")]
        public long end_time;
        [Key("open_announce_in_browser")]
        public bool open_announce_in_browser;
        [Key("is_change_dialog")]
        public bool is_change_dialog;
        [Key("is_downloadable")]
        public bool is_downloadable;
    }

    [MessagePackObject(false)]
    public class MaintenanceNotification
    {

        [Key("start_time")]
        public long start_time;
        [Key("end_time")]
        public long end_time;

    }

    public enum RestrictionStatus
    {
        None = 0,
        Ban = 1,
        Transition = 2,
        ShortBan = 3,
        MiddleBan = 4,
        LongBan = 5,
        TournamentRestriction3Month = 101,
        TournamentRestrictionHalf = 102,
        TournamentRestrictionYear = 103,
        TournamentRestrictionInf = 104,
        WorldBan = 201,
        WorldShortBan = 202,
        WorldMiddleBan = 203,
        WorldLongBan = 204,
        CommunicationBan = 301,
        CommunicationShortBan = 302,
        CommunicationMiddleBan = 303,
        CommunicationLongBan = 304
    }

    [MessagePackObject(false)]
    public class Restriction
    {

        [Key("status")]
        public RestrictionStatus status;
        [Key("end_time")]
        public int? end_time;
    }

    [MessagePackObject(false)]
    public class AchievementNotification
    {

        [Key("id")]
        public int id;
    }

    public enum MissionNotificationType
    {
        Normal = 1,
        Puzzle = 2,
        BattlePass = 3,
        Beginner = 4,
        Launch = 5,
        Grandprix = 6,
        LimitBattlePass = 7,
    }

    public enum RewardType
    {
        RedEther = 1,
        PaidCoin = 2,
        VdCoin = 3,
        Item = 4,
        Card = 5,
        Sleeve = 6,
        Emblem = 7,
        Degree = 8,
        Rupy = 9,
        LeaderSkin = 10,
        TemporaryCard = 11,
        TemporaryGem = 12,
        TrialDeckTemporaryCard = 13,
        FreeGachaCount = 14,
        AvatarParts = 15,
        AvatarEmote = 16,
        Illustration = 17,
        Shadopay = 18,
        CardStyle = 19,
        MetaverseBgm = 28,
        MetaverseObject = 29,
        MetaverseStamp = 30,
        BattlePassPoint = 31,
        AvatarAutoAnimation = 32,
        MetaverseIllustration = 34,
        HouseSet = 36,
        GuildDecorativeItem = 40,
        GuildTag = 41,
        AvatarPartsColor = 42,
        GuildEmblemFrame = 43
    }

    [MessagePackObject(false)]
    public class Reward
    {

        [Key("reward_type")]
        public RewardType reward_type;
        [Key("reward_detail_id")]
        public int reward_detail_id;
        [Key("reward_number")]
        public int reward_number;
    }

    [MessagePackObject(false)]
    public class MissionNotification
    {

        [Key("id")]
        public int id;
        [Key("type")]
        public MissionNotificationType type;
        [Key("reward_list")]
        public Reward[] reward_list;
        [Key("require_count")]
        public int require_count;
        [Key("before_count")]
        public int before_count;
        [Key("after_count")]
        public int after_count;

    }

    [MessagePackObject(false)]
    public class CardCollectionLevel
    {

        [Key("level")]
        public int level;
        [Key("min_exp")]
        public int min_exp;
        [Key("max_exp")]
        public int max_exp;

    }

    [MessagePackObject(false)]
    public class CardCollectionLevelGauge
    {

        [Key("before_exp")]
        public int before_exp;
        [Key("after_exp")]
        public int after_exp;
        [Key("before_level")]
        public CardCollectionLevel before_level;
        [Key("after_level")]
        public CardCollectionLevel after_level;
    }

    [MessagePackObject(false)]
    public class CardCollectionNotification
    {

        [Key("card_collection_level_gauge")]
        public CardCollectionLevelGauge card_collection_level_gauge;
        [Key("complete_card_set_id")]
        public int complete_card_set_id;
    }

    [MessagePackObject(false)]
    public class DataHeader
    {
        [Key("result_code")]
        public int result_code;
        [Key("sid")]
        public string sid;
        [Key("servertime")]
        public int servertime;
        [Key("maintenance")]
        public Maintenance maintenance;
        [Key("maintenance_task_ids")]
        public int[] maintenance_task_ids;
        [Key("restriction")]
        public Restriction restriction;
        [Key("achievement_notification")]
        public AchievementNotification[] achievement_notification;
        [Key("mission_notification")]
        public MissionNotification[] mission_notification;
        [Key("maintenance_notification")]
        public MaintenanceNotification maintenance_notification;
        [Key("store_url")]
        public string store_url;
        [Key("card_collection_notification")]
        public CardCollectionNotification card_collection_notification;
    }
}
