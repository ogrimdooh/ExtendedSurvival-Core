using Sandbox.ModAPI;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using VRage.Game;
using VRage.Library.Utils;

namespace ExtendedSurvival.Core
{

    public static class SessionSettingsController
	{

		public struct SessionSettingsData
		{

			public Func<string> Get;
			public Func<string, bool> Set;

		}

		private static readonly ConcurrentDictionary<string, SessionSettingsData> SESSION_SETTINGS = new ConcurrentDictionary<string, SessionSettingsData>();

		/*
		 * Not Supported yet
		 * 
		 
		public SerializableDictionary<string, short> BlockTypeLimits;
		public List<string> SuppressedWarnings;

		 */

		static SessionSettingsController()
		{
			SESSION_SETTINGS["voxeltrashremovalenabled"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.VoxelTrashRemovalEnabled.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.VoxelTrashRemovalEnabled = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["voxeltrashremovalenabled"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.VoxelTrashRemovalEnabled.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.VoxelTrashRemovalEnabled = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["voxelplayerdistancethreshold"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.VoxelPlayerDistanceThreshold.ToString();
					},
					Set = (x) =>
					{
						float v;
						if (float.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.VoxelPlayerDistanceThreshold = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["voxelgriddistancethreshold"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.VoxelGridDistanceThreshold.ToString();
					},
					Set = (x) =>
					{
						float v;
						if (float.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.VoxelGridDistanceThreshold = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["voxelagethreshold"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.VoxelAgeThreshold.ToString();
					},
					Set = (x) =>
					{
						int v;
						if (int.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.VoxelAgeThreshold = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enableresearch"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableResearch.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableResearch = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enablegoodbothints"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableGoodBotHints.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableGoodBotHints = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["optimalspawndistance"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.OptimalSpawnDistance.ToString();
					},
					Set = (x) =>
					{
						float v;
						if (float.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.OptimalSpawnDistance = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enablebountycontracts"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableBountyContracts.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableBountyContracts = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["playercharacterremovalthreshold"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.PlayerCharacterRemovalThreshold.ToString();
					},
					Set = (x) =>
					{
						int v;
						if (int.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.PlayerCharacterRemovalThreshold = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enablesupergridding"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableSupergridding.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableSupergridding = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enableeconomy"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableEconomy.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableEconomy = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["depositscountcoefficient"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.DepositsCountCoefficient.ToString();
					},
					Set = (x) =>
					{
						float v;
						if (float.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.DepositsCountCoefficient = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["depositsizedenominator"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.DepositSizeDenominator.ToString();
					},
					Set = (x) =>
					{
						float v;
						if (float.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.DepositSizeDenominator = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["weathersystem"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.WeatherSystem.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.WeatherSystem = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enableautorespawn"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableAutorespawn.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableAutorespawn = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["playerinactivitythreshold"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.PlayerInactivityThreshold.ToString();
					},
					Set = (x) =>
					{
						float v;
						if (float.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.PlayerInactivityThreshold = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["blockcountthreshold"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.BlockCountThreshold.ToString();
					},
					Set = (x) =>
					{
						int v;
						if (int.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.BlockCountThreshold = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["playerdistancethreshold"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.PlayerDistanceThreshold.ToString();
					},
					Set = (x) =>
					{
						float v;
						if (float.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.PlayerDistanceThreshold = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enablescripterrole"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableScripterRole.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableScripterRole = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["mindropcontainerrespawntime"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.MinDropContainerRespawnTime.ToString();
					},
					Set = (x) =>
					{
						int v;
						if (int.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.MinDropContainerRespawnTime = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["maxdropcontainerrespawntime"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.MaxDropContainerRespawnTime.ToString();
					},
					Set = (x) =>
					{
						int v;
						if (int.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.MaxDropContainerRespawnTime = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enableturretsfriendlyfire"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableTurretsFriendlyFire.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableTurretsFriendlyFire = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enablesubgriddamage"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableSubgridDamage.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableSubgridDamage = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["syncdistance"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.SyncDistance.ToString();
					},
					Set = (x) =>
					{
						int v;
						if (int.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.SyncDistance = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["experimentalmode"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.ExperimentalMode.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.ExperimentalMode = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["adaptivesimulationquality"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.AdaptiveSimulationQuality.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.AdaptiveSimulationQuality = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enablevoxelhand"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableVoxelHand.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableVoxelHand = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["removeoldidentitiesh"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.RemoveOldIdentitiesH.ToString();
					},
					Set = (x) =>
					{
						int v;
						if (int.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.RemoveOldIdentitiesH = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["trashremovalenabled"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.TrashRemovalEnabled.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.TrashRemovalEnabled = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["stopgridsperiodmin"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.StopGridsPeriodMin.ToString();
					},
					Set = (x) =>
					{
						int v;
						if (int.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.StopGridsPeriodMin = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["trashflagsvalue"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.TrashFlagsValue.ToString();
					},
					Set = (x) =>
					{
						int v;
						if (int.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.TrashFlagsValue = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["afktimeountmin"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.AFKTimeountMin.ToString();
					},
					Set = (x) =>
					{
						int v;
						if (int.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.AFKTimeountMin = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["harvestratiomultiplier"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.HarvestRatioMultiplier.ToString();
					},
					Set = (x) =>
					{
						float v;
						if (float.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.HarvestRatioMultiplier = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["optimalgridcount"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.OptimalGridCount.ToString();
					},
					Set = (x) =>
					{
						int v;
						if (int.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.OptimalGridCount = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["tradefactionscount"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.TradeFactionsCount.ToString();
					},
					Set = (x) =>
					{
						int v;
						if (int.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.TradeFactionsCount = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["stationsdistanceouterradiusstart"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.StationsDistanceOuterRadiusStart.ToString();
					},
					Set = (x) =>
					{
						double v;
						if (double.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.StationsDistanceOuterRadiusStart = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enablerecoil"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableRecoil.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableRecoil = v;
							return true;
						}
						return false;
					}
				}
			;
			SESSION_SETTINGS["environmentdamagemultiplier"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnvironmentDamageMultiplier.ToString();
					},
					Set = (x) =>
					{
						float v;
						if (float.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnvironmentDamageMultiplier = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enablegamepadaimassist"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableGamepadAimAssist.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableGamepadAimAssist = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["backpackdespawntimer"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.BackpackDespawnTimer.ToString();
					},
					Set = (x) =>
					{
						float v;
						if (float.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.BackpackDespawnTimer = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enablefactionplayernames"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableFactionPlayerNames.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableFactionPlayerNames = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enableteamscorecounters"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableTeamScoreCounters.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableTeamScoreCounters = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["characterspeedmultiplier"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.CharacterSpeedMultiplier.ToString();
					},
					Set = (x) =>
					{
						float v;
						if (float.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.CharacterSpeedMultiplier = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enablespacesuitrespawn"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableSpaceSuitRespawn.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableSpaceSuitRespawn = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enablefactionvoicechat"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableFactionVoiceChat.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableFactionVoiceChat = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enableorca"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableOrca.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableOrca = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["maxproductionqueuelength"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.MaxProductionQueueLength.ToString();
					},
					Set = (x) =>
					{
						int v;
						if (int.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.MaxProductionQueueLength = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["prefetchshaperaylengthlimit"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.PrefetchShapeRayLengthLimit.ToString();
					},
					Set = (x) =>
					{
						long v;
						if (long.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.PrefetchShapeRayLengthLimit = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enemytargetindicatordistance"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnemyTargetIndicatorDistance.ToString();
					},
					Set = (x) =>
					{
						float v;
						if (float.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnemyTargetIndicatorDistance = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enabletrashsettingsplatformoverride"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableTrashSettingsPlatformOverride.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableTrashSettingsPlatformOverride = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["matchrestartwhenemptytime"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.MatchRestartWhenEmptyTime.ToString();
					},
					Set = (x) =>
					{
						int v;
						if (int.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.MatchRestartWhenEmptyTime = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enableteambalancing"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableTeamBalancing.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableTeamBalancing = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enablefriendlyfire"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableFriendlyFire.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableFriendlyFire = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["postmatchduration"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.PostMatchDuration.ToString();
					},
					Set = (x) =>
					{
						float v;
						if (float.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.PostMatchDuration = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["stationsdistanceouterradiusend"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.StationsDistanceOuterRadiusEnd.ToString();
					},
					Set = (x) =>
					{
						double v;
						if (double.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.StationsDistanceOuterRadiusEnd = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["economytickinseconds"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EconomyTickInSeconds.ToString();
					},
					Set = (x) =>
					{
						int v;
						if (int.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EconomyTickInSeconds = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["simplifiedsimulation"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.SimplifiedSimulation.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.SimplifiedSimulation = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enablepcutrading"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnablePcuTrading.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnablePcuTrading = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["familysharing"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.FamilySharing.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.FamilySharing = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enableselectivephysicsupdates"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableSelectivePhysicsUpdates.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableSelectivePhysicsUpdates = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["predefinedasteroids"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.PredefinedAsteroids.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.PredefinedAsteroids = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["useconsolepcu"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.UseConsolePCU.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.UseConsolePCU = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["maxplanets"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.MaxPlanets.ToString();
					},
					Set = (x) =>
					{
						int v;
						if (int.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.MaxPlanets = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["offensivewordsfiltering"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.OffensiveWordsFiltering.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.OffensiveWordsFiltering = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["adjustablemaxvehiclespeed"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.AdjustableMaxVehicleSpeed.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.AdjustableMaxVehicleSpeed = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enablematchcomponent"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableMatchComponent.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableMatchComponent = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["prematchduration"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.PreMatchDuration.ToString();
					},
					Set = (x) =>
					{
						float v;
						if (float.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.PreMatchDuration = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["matchduration"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.MatchDuration.ToString();
					},
					Set = (x) =>
					{
						float v;
						if (float.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.MatchDuration = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["stationsdistanceinnerradius"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.StationsDistanceInnerRadius.ToString();
					},
					Set = (x) =>
					{
						double v;
						if (double.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.StationsDistanceInnerRadius = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["maxactivefracturepieces"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.MaxActiveFracturePieces.ToString();
					},
					Set = (x) =>
					{
						int v;
						if (int.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.MaxActiveFracturePieces = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enablestructuralsimulation"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableStructuralSimulation.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableStructuralSimulation = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["floradensitymultiplier"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.FloraDensityMultiplier.ToString();
					},
					Set = (x) =>
					{
						float v;
						if (float.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.FloraDensityMultiplier = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["environmenthostility"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnvironmentHostility.ToString();
					},
					Set = (x) =>
					{
						MyEnvironmentHostilityEnum v;
						if (MyEnvironmentHostilityEnum.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnvironmentHostility = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["autohealing"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.AutoHealing.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.AutoHealing = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enablecopypaste"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableCopyPaste.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableCopyPaste = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["weaponsenabled"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.WeaponsEnabled.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.WeaponsEnabled = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["showplayernamesonhud"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.ShowPlayerNamesOnHud.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.ShowPlayerNamesOnHud = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["thrusterdamage"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.ThrusterDamage.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.ThrusterDamage = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enableremoteblockremoval"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableRemoteBlockRemoval.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableRemoteBlockRemoval = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["cargoshipsenabled"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.CargoShipsEnabled.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.CargoShipsEnabled = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["worldsizekm"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.WorldSizeKm.ToString();
					},
					Set = (x) =>
					{
						int v;
						if (int.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.WorldSizeKm = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["respawnshipdelete"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.RespawnShipDelete.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.RespawnShipDelete = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["resetownership"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.ResetOwnership.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.ResetOwnership = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["welderspeedmultiplier"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.WelderSpeedMultiplier.ToString();
					},
					Set = (x) =>
					{
						float v;
						if (float.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.WelderSpeedMultiplier = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["grinderspeedmultiplier"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.GrinderSpeedMultiplier.ToString();
					},
					Set = (x) =>
					{
						float v;
						if (float.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.GrinderSpeedMultiplier = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["realisticsound"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.RealisticSound.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.RealisticSound = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enablespectator"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableSpectator.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableSpectator = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["hackspeedmultiplier"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.HackSpeedMultiplier.ToString();
					},
					Set = (x) =>
					{
						float v;
						if (float.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.HackSpeedMultiplier = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["blocklimitsenabled"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.BlockLimitsEnabled.ToString();
					},
					Set = (x) =>
					{
						MyBlockLimitsEnabledEnum v;
						if (MyBlockLimitsEnabledEnum.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.BlockLimitsEnabled = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["piratepcu"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.PiratePCU.ToString();
					},
					Set = (x) =>
					{
						int v;
						if (int.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.PiratePCU = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["gamemode"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.GameMode.ToString();
					},
					Set = (x) =>
					{
						MyGameModeEnum v;
						if (MyGameModeEnum.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.GameMode = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["inventorysizemultiplier"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.InventorySizeMultiplier.ToString();
					},
					Set = (x) =>
					{
						float v;
						if (float.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.InventorySizeMultiplier = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["blocksinventorysizemultiplier"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.BlocksInventorySizeMultiplier.ToString();
					},
					Set = (x) =>
					{
						float v;
						if (float.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.BlocksInventorySizeMultiplier = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["assemblerspeedmultiplier"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.AssemblerSpeedMultiplier.ToString();
					},
					Set = (x) =>
					{
						float v;
						if (float.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.AssemblerSpeedMultiplier = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["assemblerefficiencymultiplier"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.AssemblerEfficiencyMultiplier.ToString();
					},
					Set = (x) =>
					{
						float v;
						if (float.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.AssemblerEfficiencyMultiplier = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["refineryspeedmultiplier"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.RefinerySpeedMultiplier.ToString();
					},
					Set = (x) =>
					{
						float v;
						if (float.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.RefinerySpeedMultiplier = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["maxfactionscount"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.MaxFactionsCount.ToString();
					},
					Set = (x) =>
					{
						int v;
						if (int.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.MaxFactionsCount = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["onlinemode"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.OnlineMode.ToString();
					},
					Set = (x) =>
					{
						MyOnlineModeEnum v;
						if (MyOnlineModeEnum.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.OnlineMode = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["maxfloatingobjects"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.MaxFloatingObjects.ToString();
					},
					Set = (x) =>
					{
						short v;
						if (short.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.MaxFloatingObjects = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["totalbotlimit"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.TotalBotLimit.ToString();
					},
					Set = (x) =>
					{
						int v;
						if (int.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.TotalBotLimit = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["maxbackupsaves"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.MaxBackupSaves.ToString();
					},
					Set = (x) =>
					{
						short v;
						if (short.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.MaxBackupSaves = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["maxgridsize"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.MaxGridSize.ToString();
					},
					Set = (x) =>
					{
						int v;
						if (int.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.MaxGridSize = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["maxblocksperplayer"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.MaxBlocksPerPlayer.ToString();
					},
					Set = (x) =>
					{
						int v;
						if (int.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.MaxBlocksPerPlayer = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["totalpcu"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.TotalPCU.ToString();
					},
					Set = (x) =>
					{
						int v;
						if (int.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.TotalPCU = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["maxplayers"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.MaxPlayers.ToString();
					},
					Set = (x) =>
					{
						short v;
						if (short.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.MaxPlayers = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["autosaveinminutes"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.AutoSaveInMinutes.ToString();
					},
					Set = (x) =>
					{
						uint v;
						if (uint.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.AutoSaveInMinutes = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["permanentdeath"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.PermanentDeath.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.PermanentDeath = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["infiniteammo"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.InfiniteAmmo.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.InfiniteAmmo = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["scenario"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.Scenario.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.Scenario = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["updaterespawndictionary"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.UpdateRespawnDictionary.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.UpdateRespawnDictionary = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["canjoinrunning"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.CanJoinRunning.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.CanJoinRunning = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["physicsiterations"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.PhysicsIterations.ToString();
					},
					Set = (x) =>
					{
						int v;
						if (int.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.PhysicsIterations = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["sunrotationintervalminutes"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.SunRotationIntervalMinutes.ToString();
					},
					Set = (x) =>
					{
						float v;
						if (float.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.SunRotationIntervalMinutes = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enablejetpack"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableJetpack.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableJetpack = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["spawnwithtools"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.SpawnWithTools.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.SpawnWithTools = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["blueprintsharetimeout"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.BlueprintShareTimeout.ToString();
					},
					Set = (x) =>
					{
						int v;
						if (int.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.BlueprintShareTimeout = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["blueprintshare"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.BlueprintShare.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.BlueprintShare = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["startinrespawnscreen"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.StartInRespawnScreen.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.StartInRespawnScreen = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enablevoxeldestruction"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableVoxelDestruction.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableVoxelDestruction = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["maxdrones"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.MaxDrones.ToString();
					},
					Set = (x) =>
					{
						int v;
						if (int.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.MaxDrones = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enabledrones"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableDrones.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableDrones = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enablewolfs"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableWolfs.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableWolfs = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enablespiders"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableSpiders.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableSpiders = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enablesaving"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableSaving.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableSaving = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enablerespawnships"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableRespawnShips.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableRespawnShips = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["scenarioeditmode"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.ScenarioEditMode.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.ScenarioEditMode = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["stationvoxelsupport"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.StationVoxelSupport.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.StationVoxelSupport = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enablecontainerdrops"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableContainerDrops.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableContainerDrops = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["spawnshiptimemultiplier"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.SpawnShipTimeMultiplier.ToString();
					},
					Set = (x) =>
					{
						float v;
						if (float.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.SpawnShipTimeMultiplier = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["proceduraldensity"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.ProceduralDensity.ToString();
					},
					Set = (x) =>
					{
						float v;
						if (float.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.ProceduralDensity = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["proceduralseed"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.ProceduralSeed.ToString();
					},
					Set = (x) =>
					{
						int v;
						if (int.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.ProceduralSeed = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["destructibleblocks"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.DestructibleBlocks.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.DestructibleBlocks = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enablesunrotation"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableSunRotation.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableSunRotation = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["viewdistance"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.ViewDistance.ToString();
					},
					Set = (x) =>
					{
						int v;
						if (int.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.ViewDistance = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enableingamescripts"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableIngameScripts.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableIngameScripts = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["voxelgeneratorversion"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.VoxelGeneratorVersion.ToString();
					},
					Set = (x) =>
					{
						int v;
						if (int.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.VoxelGeneratorVersion = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enableoxygen"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableOxygen.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableOxygen = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enableoxygenpressurization"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableOxygenPressurization.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableOxygenPressurization = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enable3rdpersonview"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.Enable3rdPersonView.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.Enable3rdPersonView = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enableencounters"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableEncounters.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableEncounters = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enableconverttostation"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableConvertToStation.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableConvertToStation = v;
							return true;
						}
						return false;
					}
				};
			SESSION_SETTINGS["enabletoolshake"] =
				new SessionSettingsData()
				{
					Get = () =>
					{
						return MyAPIGateway.Session.SessionSettings.EnableToolShake.ToString();
					},
					Set = (x) =>
					{
						bool v;
						if (bool.TryParse(x, out v))
						{
							MyAPIGateway.Session.SessionSettings.EnableToolShake = v;
							return true;
						}
						return false;
					}
				};
		}

		public static bool TryGetValue(string key, out string value)
        {
			value = null;
            try
            {
				if (SESSION_SETTINGS.ContainsKey(key))
				{
					value = SESSION_SETTINGS[key].Get?.Invoke();
					return true;
				}
			}
			catch (Exception ex)
			{
				ExtendedSurvivalCoreLogging.Instance.LogError(typeof(SessionSettingsController), ex);
			}
			return false;
        }

		public static bool TrySetValue(string key, string value)
		{
			try
			{
				if (SESSION_SETTINGS.ContainsKey(key))
				{
					return SESSION_SETTINGS[key].Set?.Invoke(value) ?? false;
				}
			}
			catch (Exception ex)
			{
				ExtendedSurvivalCoreLogging.Instance.LogError(typeof(SessionSettingsController), ex);
			}
			return false;
		}

	}

}
