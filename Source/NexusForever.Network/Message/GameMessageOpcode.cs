namespace NexusForever.Network.Message
{
    public enum GameMessageOpcode
    {
        State                           = 0x0000,
        State2                          = 0x0001,
        ServerHello                     = 0x0003,
        ServerMaxCharacterLevelAchieved = 0x0036,
        ServerPlayerEnteredWorld        = 0x0061,
        ServerClientEntityUpdateInterval = 0x0070,
        ServerAuthEncrypted             = 0x0076,
        ServerLogoutUpdate              = 0x0092,
        ClientActivateUnitCast          = 0x0097, // not sure about the name - almost the same as 0x00B3, but also initiates 0x07FD
        ClientCastSpell                 = 0x009A,
        ServerChangeWorld               = 0x00AD,
        ServerAchievementInit           = 0x00AE,
        ServerAchievementUpdate         = 0x00AF,
        ClientRequestActionSetChanges   = 0x00B1,
        Server00B2                      = 0x00B2, // this triggers the client to send 0xB1
        ClientActivateUnit              = 0x00B3,
        ServerBuybackItemUpdated        = 0x00BA,
        ClientBuybackItemFromVendor     = 0x00BB,
        ServerBuybackItems              = 0x00BC,
        ServerBuybackItemRemoved        = 0x00BD,
        ClientVendorPurchase            = 0x00BE,
        ClientLogoutRequest             = 0x00BF,
        ClientLogoutConfirm             = 0x00C0,
        ClientHousingResidencePrivacyLevel = 0x00C9,
        ServerCostume                   = 0x00D8,
        ServerCostumeList               = 0x00D9,
        ServerCharacterCreate           = 0x00DC,
        ServerChannelUpdateLoot         = 0x00DD,
        ServerDatacubeUpdateList        = 0x00E0,
        ServerDatacubeUpdate            = 0x00E1,
        ServerDatacubeVolumeUpdate      = 0x00E2,
        ClientResurrectRequest          = 0x00E4,
        ServerCharacterDeleteResult     = 0x00E6,
        ServerInstanceSettings          = 0x00F1, // handler sends 0x00D5 and ClientPlayerMovementSpeedUpdate
        ClientEnteredWorld              = 0x00F2,
        ServerCharacterFlagsUpdated     = 0x00FE,
        ServerResurrectionState         = 0x0100,
        Server0104                      = 0x0104, // Galactic Archive
        ServerGenericError              = 0x0106,
        ClientGuildHolomarkUpdate       = 0x010C,
        ServerHousingBasics             = 0x010E,
        ServerCharacter                 = 0x010F, // single character
        ServerItemAdd                   = 0x0111,
        ServerCharacterList             = 0x0117,
        ClientMailDelete                = 0x011E,
        ClientMailOpen                  = 0x0122,
        ClientMailPayCod                = 0x0123,
        ClientMailReturn                = 0x0124,
        ClientMailTakeAllFromSelection  = 0x0125,
        ClientMailTakeAttachment        = 0x0126,
        ClientMailTakeCash              = 0x0127,
        ServerUnlockMount               = 0x0129,
        ClientItemMoveToSupplySatchel   = 0x012A,
        ServerPetCustomizationList      = 0x012E,
        ServerPetCustomisation          = 0x012F,
        ClientRapidTransport            = 0x0141,
        ClientCharacterAppearanceChange = 0x0144,
        ServerCharacterAppearanceResult = 0x0145,
        ServerItemDelete                = 0x0148,
        ClientItemDelete                = 0x0149,
        ClientEntityInteractChair       = 0x014E,
        ClientRequestAmpReset           = 0x0151,
        ClientResurrectAccept           = 0x015A,
        ServerResurrectRequest          = 0x015B,
        ClientItemUseLootBag            = 0x015E,
        ServerCharacterSelectFail       = 0x0162,
        ClientSellItemToVendor          = 0x0166,
        ClientMailSend                  = 0x0168,
        ServerAbilityPoints             = 0x0169,
        ClientNonSpellActionSetChanges  = 0x016A,
        ServerShowActionBar             = 0x016C,
        ClientInnateChange              = 0x016F,
        ClientChangeActiveActionSet     = 0x0174,
        ServerChangeActiveActionSet     = 0x0175,
        ClientToggleWeapons             = 0x0177,
        ServerTutorial                  = 0x0179,
        ServerSpellUpdate               = 0x017B,
        ClientItemSplit                 = 0x017D,
        ServerItemStackCountUpdate      = 0x017F,
        ClientItemMove                  = 0x0182,
        ClientItemMoveFromSupplySatchel = 0x0184,
        ClientEntitySelect              = 0x0185,
        ServerFlightPathUpdate          = 0x0188,
        ServerTitleSet                  = 0x0189,
        ServerTitleUpdate               = 0x018A,
        ServerTitles                    = 0x018B,
        ServerSupplySatchelUpdate       = 0x0199,
        ServerPlayerChanged             = 0x019B,
        ServerActionSet                 = 0x019D,
        ServerPlayerInnateSet           = 0x019F,
        ServerAbilities                 = 0x01A0,
        ServerAmpList                   = 0x01A3,
        ServerReputationUpdate          = 0x01A5,
        ServerPathUpdateXP              = 0x01AA,
        ServerResurrectionUpdate        = 0x01AB,
        ServerExperienceGained          = 0x01AC,
        ServerUnlockVanityPet           = 0x01AE,
        ClientVehicleDisembark          = 0x01AF,
        ServerResurrectionShow          = 0x01B3,
        ServerZoneMap                   = 0x01B4,
        ServerChatAction                = 0x01B5,
        ServerChatFlag                  = 0x01B7,
        ClientChatJoin                  = 0x01BA,
        ServerChatJoinResult            = 0x01BB,
        ServerChatJoin                  = 0x01BC,
        ClientChatLeave                 = 0x01BE,
        ClientChatKick                  = 0x01BD,
        ServerChatLeave                 = 0x01BF,
        ServerChatList                  = 0x01C0,
        ServerChatAccept                = 0x01C2,
        ClientChat                      = 0x01C3,
        ServerChat                      = 0x01C8,
        ClientChatMute                  = 0x01CE,
        ClientChatModerator             = 0x01CD,
        ClientChatOwner                 = 0x01CF,
        ClientChatPassword              = 0x01D0,
        ClientChatList                  = 0x01D2,
        ServerChatResult                = 0x01D3,
        ClientChatWhisper               = 0x01D4,
        ServerChatWhisperFail           = 0x01D9,
        ServerChatZoneChange            = 0x01DA,
        ServerCinematicComplete         = 0x0210,
        ServerCinematic0211             = 0x0211,
        ServerCinematic0212             = 0x0212,
        ServerCinematicActorAttach      = 0x0213,
        ServerCinematicCameraSpline     = 0x0215,
        ServerCinematic0216             = 0x0216,
        ServerCinematicTransitionDurationSet = 0x0222,
        ServerCinematicVisualEffectEnd  = 0x0225,
        ServerCinematicScene            = 0x0227,
        ServerCinematicTransition       = 0x0218,
        ServerCinematicVisualEffect     = 0x021C,
        ServerCinematicActorVisibility  = 0x0220,
        ServerCinematicActor            = 0x0228,
        ServerCinematicText             = 0x022A,
        ServerCinematic022B             = 0x022B,
        ServerCinematicShowAnimate      = 0x022E,
        ServerCinematicActorAngle       = 0x0230,
        ServerCinematicNotify           = 0x0232,
        Server0237                      = 0x0237, // UI related, opens or closes different UI windows (bank, barber, ect...)
        ClientWatchdogStatistics        = 0x023C,
        ClientPing                      = 0x0241,
        ClientEncrypted                 = 0x0244,
        ServerCombatLog                 = 0x0247,
        ServerHousingCommunityRename    = 0x024D,
        ClientCostumeSave               = 0x0255,
        ClientCostumeSet                = 0x0256,
        ServerCostumeSave               = 0x0257,
        ServerCostumeItemUnlockMultiple = 0x0258,
        ServerCostumeItemUnlock         = 0x0259,
        ServerCostumeItemList           = 0x025A,
        ClientCharacterCreate           = 0x025B,
        ClientPacked                    = 0x025C, // the same as ClientEncrypted except the contents isn't encrypted?
        ServerPlayerCreate              = 0x025E,
        ServerEntityCreate              = 0x0262,
        ServerNewCustomerSurveyRequest = 0x033E,
        ClientCustomerSurveySubmit      = 0x033F,
        ClientCharacterDelete           = 0x0352,
        ServerEntityDestroy             = 0x0355,
        Server0357                      = 0x0357,
        ClientQuestAbandon              = 0x035A,
        ClientQuestAccept               = 0x035B,
        ServerQuestStateChange          = 0x035C,
        ClientQuestComplete             = 0x035D,
        ClientQuestSetIgnore            = 0x035E,
        ServerQuestInit                 = 0x035F,
        ServerQuestObjectiveUpdate      = 0x0361,
        ClientQuestSetTracked           = 0x0364,
        ClientQuestRetry                = 0x0365,
        ServerForceKick                 = 0x036A,
        ClientEmote                     = 0x037E,
        ClientCostumeItemForget         = 0x038B,
        ClientPackedWorld               = 0x038C,
        Server03AA                      = 0x03AA, // friendship account related
        Server03BE                      = 0x03BE, // friendship related
        ServerRealmInfo                 = 0x03DB,
        ServerRealmEncrypted            = 0x03DC,
        ClientCheat                     = 0x03E0,
        ServerRealmBroadcast            = 0x03E1,
        ClientItemGenericUnlock         = 0x0400,
        ClientQuestShareResult          = 0x045E,
        ClientQuestShare                = 0x045F,
        ClientGuildRegister             = 0x0481,
        ServerGuildFlagUpdate           = 0x048B,
        ServerGuildInfoMessageUpdate    = 0x048F,
        ClientGuildInviteResponse       = 0x0490,
        ServerGuildInvite               = 0x0491,
        ServerGuildJoin                 = 0x0493,
        ServerGuildRemove               = 0x0495,
        ServerGuildInit                 = 0x0497, // guild info
        ServerGuildRoster               = 0x04A0,
        ServerGuildMemberRemove         = 0x04A2,
        ServerGuildMemberChange         = 0x04A3,
        ServerGuildMotdUpdate           = 0x04A5,
        ServerGuildNameplateAdd         = 0x04AC,
        ServerEntityGuildAffiliation    = 0x04AE,
        ServerGuildRename               = 0x04AF,
        ClientGuildOperation            = 0x04B1,
        ServerGuildRankChange           = 0x04C5,
        ServerGuildResult               = 0x04C9,
        ClientCastSpellContinuous       = 0x04DB,
        ServerHousingPlacedResidencesList = 0x04DD,
        ServerHousingResidenceDecor     = 0x04DE,
        ServerHousingProperties         = 0x04DF,
        ServerHousingPlots              = 0x04E1,
        ClientItemUseDecor              = 0x04E7,
        ClientHousingCommunityRemoval   = 0x04EA,
        ClientHousingCrateAllDecor      = 0x04EC,
        ClientHousingCommunityDonate    = 0x04F5,
        ServerHousingNeighbors          = 0x0507,
        ServerHousingVendorList         = 0x0508,
        ClientHousingRemodel            = 0x050A,
        ClientHousingDecorUpdate        = 0x050B,
        ClientHousingFlagsUpdate        = 0x050E,
        ClientHousingPlugUpdate         = 0x0510,
        ClientHousingVendorList         = 0x0525,
        ServerHousingRandomCommunityList = 0x0526,
        ServerHousingRandomResidenceList = 0x0527,
        ClientHousingRenameProperty     = 0x0529,
        ClientHousingPlacedResidencesList = 0x052A,
        ClientHousingCommunityPlacement = 0x052B,
        ClientHousingRandomCommunityList = 0x052C,
        ClientHousingRandomResidenceList = 0x052D,
        ClientHousingReturn             = 0x052E,
        ClientHousingVisit              = 0x0531,
        ServerHousingOwnership          = 0x0533,
        ServerHousingResult             = 0x0536,
        ClientHousingCommunityPrivacyLevel = 0x0538,
        ClientHousingEditMode           = 0x053C,
        ServerSpellList                 = 0x0551,
        ClientInspectPlayerRequest      = 0x0552,
        ServerInspectPlayerResponse     = 0x0553,
        ServerItemSwap                  = 0x0568,
        ServerItemMove                  = 0x0569,
        ServerItemError                 = 0x056A,
        BiInputKeySet                   = 0x056F,
        ClientRequestInputKeySet        = 0x0570,
        ClientSetInputKeySet            = 0x0571,
        ClientHelloRealm                = 0x058F,
        ServerAuthAccepted              = 0x0591,
        ClientHelloAuth                 = 0x0592,
        ServerLogout                    = 0x0594,
        ClientPlayerInfoRequest         = 0x0597,
        ServerPlayerInfoBasicResponse   = 0x0598,
        ServerPlayerInfoFullResponse    = 0x0599,
        ServerMailResult                = 0x05A2,
        ServerMailAvailable             = 0x05A3,
        ServerMailUnavailable           = 0x05A7,
        ServerMailTakeAttachment        = 0x05A8,
        Server0635                      = 0x0635,
        ServerMovementControl           = 0x0636, // handler sends 0x0635 and 0x063A
        ClientEntityCommand             = 0x0637, // bidirectional? packet has both read and write handlers 
        ServerEntityCommand             = 0x0638, // bidirectional? packet has both read and write handlers
        ServerMovementControlRemove     = 0x0639,
        ClientZoneChange                = 0x063A,
        ClientPlayerMovementSpeedUpdate = 0x063B,
        ServerAuthDenied                = 0x063D,
        ServerOwnedCommodityOrders      = 0x064C,
        ServerOwnedItemAuctions         = 0x064D,
        ServerPendingWorldRemovalCancel = 0x0688,
        ServerPendingWorldRemoval       = 0x0689,
        ClientRequestPlayed             = 0x0693,
        ServerPlayerPlayed              = 0x0694,
        ClientPathActivate              = 0x06B2,
        ServerPathActivateResult        = 0x06B3,
        ServerPathRefresh               = 0x06B4,
        ServerPathEpisodeProgress       = 0x06B5,
        Server06B6                      = 0x06B6,
        Server06B7                      = 0x06B7,
        Server06B8                      = 0x06B8,
        Server06B9                      = 0x06B9,
        ServerPathMissionActivate       = 0x06BA, 
        ServerPathMissionUpdate         = 0x06BB,
        ServerPathLog                   = 0x06BC,
        ClientPathUnlock                = 0x06BD,
        ServerPathUnlockResult          = 0x06BE,
        ServerPathCurrentEpisode        = 0x06BF,
        Server068B                      = 0x068B, // pet customization something
        ClientPetRename                 = 0x068C,
        ServerUnlockPetFlair            = 0x068D,
        ServerChangePetStance           = 0x068F,
        ServerPublicEventStart          = 0x0700,
        ServerQueueFinish               = 0x0715,
        ServerQueueStatus               = 0x0717,
        ClientRandomRollRequest         = 0x071B,
        ServerRandomRollResponse        = 0x071C,
        ClientCinematicState            = 0x0720,
        ServerStoryCommunicatorShow     = 0x073A,
        ServerEntityInteractiveUpdate   = 0x0755,
        ServerCommunicatorMessage       = 0x0757,
        ServerStoryPanelHide            = 0x0759,
        ServerStoryPanelShow            = 0x075A,
        ServerRealmFirstAchievement     = 0x075F,
        ServerRealmList                 = 0x0761, // bidirectional? packet has both read and write handlers
        ServerRealmMessages             = 0x0763,
        ClientHousingCommunityRename    = 0x0788,
        ClientTitleSet                  = 0x078E,
        ServerNewRealm                  = 0x07A1,
        ClientRealmList                 = 0x07A4,
        ClientReplayLevelRequest        = 0x07A5,
        ClientCharacterSelect           = 0x07DD,
        ClientCharacterList             = 0x07E0,
        ClientEntityInteract            = 0x07EA,
        ClientPetCustomisation          = 0x07ED,
        ClientSelectRealm               = 0x07DF,
        ServerSpellGo                   = 0x07F4,
        Server07F5                      = 0x07F5, // spell related
        Server07F6                      = 0x07F6, // spell related
        Server07F7                      = 0x07F7, // spell related
        Server07F8                      = 0x07F8, // spell related
        Server07F9                      = 0x07F9, // spell related
        Server07FA                      = 0x07FA, // spell related
        Server07FB                      = 0x07FB, // spell miss info?
        ServerSpellCastResult           = 0x07FC,
        Server07FD                      = 0x07FD, // spell related
        ServerSpellFinish               = 0x07FE,
        ServerSpellStart                = 0x07FF,
        ClientSpellStopCast             = 0x0801,
        ClientCancelEffect              = 0x0802,
        ServerCooldown                  = 0x0804,
        Server0811                      = 0x0811, // spell related: broadcast parts of 0x07FF?
        ServerSpellBuffRemove           = 0x0813,
        Server0814                      = 0x0814, // spell related
        Server0816                      = 0x0816, // spell related: broadcast parts of 0x07FF?
        Server0817                      = 0x0817, // spell related
        Server0818                      = 0x0818,
        Server081A                      = 0x081A, // spline related
        Server081B                      = 0x081B, // spline related
        Server081C                      = 0x081C, // spline related
        ClientStorefrontPurchaseAccount = 0x0828,
        ClientStorefrontPurchaseCharacter = 0x082A,
        ClientStorefrontRequestCatalog  = 0x082D,
        ClientSummonVanityPet           = 0x082F,
        ServerTimeOfDay                 = 0x0845,
        Server0854                      = 0x0854, // crafting schematic
        Server0856                      = 0x0856, // tradeskills
        ServerVehiclePassengerAdd       = 0x086F,
        ServerEntityAggroSwitch         = 0x0876,
        ServerEntityCCStateSet          = 0x087F,
        ServerEntityDeathState          = 0x088C,
        ServerUnitEnteredCombat         = 0x089A,
        Server089B                      = 0x089B, // mount related
        Server08B3                      = 0x08B3,
        ServerSetUnitPathType           = 0x08B8,
        ServerVehiclePassengerRemove    = 0x08C7,
        ServerUnitSetChair              = 0x08CF,
        ServerEntityVisualUpdate        = 0x0905,
        ServerEntityTargetUnit          = 0x0908,
        ServerEntityThreatListUpdate    = 0x0909,
        ServerEntityThreatUpdate        = 0x090A,
        ServerVendorItemsUpdated        = 0x090B,
        ClientCostumeItemUnlock         = 0x090F,
        ServerSpellAbilityCharges       = 0x0914,
        ServerEntitlement               = 0x0918,
        ServerCombatReward              = 0x0919,
        ServerCooldownList              = 0x091B,
        ServerRewardPropertySet         = 0x092C,
        ServerPlayerHealthUpdate        = 0x092F,
        ServerEntityBoneUpdate          = 0x0931,
        ServerItemVisualUpdate          = 0x0933,
        ServerEntityFaction             = 0x0934,
        ServerEntityStatUpdateFloat     = 0x0935,
        ServerEntityHealthUpdate        = 0x0937,
        ServerEntityStatUpdateInteger   = 0x0938,
        ServerEntityPropertiesUpdate    = 0x093A,
        ServerEmote                     = 0x093C,
        ClientItemUse                   = 0x0943,
        ClientWhoRequest                = 0x0959,
        ServerWhoResponse               = 0x095A,
        ServerAccountCurrencySet        = 0x0966,
        ServerAccountCurrencyGrant      = 0x0967,
        ServerAccountEntitlements       = 0x0968,
        ServerAccountItems              = 0x096D,
        ServerAccountEntitlement        = 0x0973,
        ServerAccountItemCooldownSet    = 0x0974,
        ServerAccountItemAdd            = 0x0975,
        ServerAccountItemsPending       = 0x0979,
        ServerAccountTier               = 0x097F,
        ServerGenericUnlockList         = 0x0981,
        ServerGenericUnlock             = 0x0982,
        ServerGenericUnlockResult       = 0x0985,
        ServerStoreFinalise             = 0x0987,
        ServerStoreCategories           = 0x0988,
        ServerStoreOffers               = 0x098B,
    }
}