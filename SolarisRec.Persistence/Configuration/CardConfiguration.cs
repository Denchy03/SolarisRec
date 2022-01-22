using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolarisRec.Core.CardType;
using SolarisRec.Persistence.PersistenceModel;
using System;
using Enum = SolarisRec.Core.Card.Enums;

namespace SolarisRec.Persistence.Configuration
{
    internal class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.ToTable("Cards");

            builder.Property(c => c.Name)
                .IsRequired(true);

            builder.Property(c => c.Name)
                .HasMaxLength(48);

            builder.Property(c => c.Ability)
                .IsRequired(false);

            builder.Property(c => c.Type)
                .IsRequired(true);

            builder.Property(c => c.AttackValue)
                .IsRequired(false);

            builder.Property(c => c.HealthValue)
                .IsRequired(false);

            builder.Property(c => c.ExpansionSerialNumber)
                .IsRequired(true);

            builder.Property(c => c.ExpansionSerialNumber).HasColumnType("VARCHAR").HasMaxLength(4);

            Seed(builder);
        }

        private static void Seed(EntityTypeBuilder<Card> builder)
        {
            builder.HasData
            (

            #region Belt

                new Card
                {
                    Id = (int)Enum.CardId.Turncoat,
                    Name = "Turncoat",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 2,
                    HealthValue = 2,
                    Ability = "Forced Reaction: When thisAgent enters play, put 2 traitor counters on it."
                        + Environment.NewLine
                        + "Forced Reaction: When this Agent would leave play, instead remove 1 traitor counter from this Agent,"
                        + Environment.NewLine
                        + "heal all of its damage and your opponent takes control of it."
                    ,
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "001"
                },
                new Card
                {
                    Id = (int)Enum.CardId.InsuredColleague,
                    Name = "Insured Colleague",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 1,
                    HealthValue = 1,
                    Ability = "Reaction: After this Agent leaves play, draw 1 card.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "002"
                },
                new Card
                {
                    Id = (int)Enum.CardId.BeggarInformator,
                    Name = "Beggar Informator",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 0,
                    HealthValue = 1,
                    Ability = "Reaction: After this Agent leaves play, look at the top 2 cards of your deck,"
                        + Environment.NewLine
                        + "put one of them into your hand and the other to the bottom of your deck.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "003"
                },
                new Card
                {
                    Id = (int)Enum.CardId.KoronisBelter,
                    Name = "Koronis Belter",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 2,
                    HealthValue = 2,
                    Ability = "Reaction, [B][B][A2]: After this Agent deals attack damage to an Agent, destroy that Agent.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "004"
                },
                new Card
                {
                    Id = (int)Enum.CardId.Concubine,
                    Name = "Concubine",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 2,
                    HealthValue = 2,
                    Ability = "Sacrifice: Target Agent loses a Talent of your choice on this Mission until the end of the phase.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "005"
                },
                new Card
                {
                    Id = (int)Enum.CardId.MadameKyung,
                    Name = "Madame Kyung",
                    Unique = true,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 2,
                    HealthValue = 4,
                    Ability = "Use, Sacrifice an Agent on this Mission: Target opponent sacrifices an Agent on this Mission,"
                        + Environment.NewLine
                        + "then you draw 1 Card",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "006"
                },
                new Card
                {
                    Id = (int)Enum.CardId.Phisher,
                    Name = "Phisher",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 2,
                    HealthValue = 3,
                    Ability = "[B][A2]: This Agent gains [Data] or [Mining] until the end of the phase.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "007"
                },
                new Card
                {
                    Id = (int)Enum.CardId.VestaExtortionist,
                    Name = "Vesta Extortionist",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 3,
                    HealthValue = 1,
                    Ability = "Reaction: Cancel the first attack targeting this Agent in the Conflict phase.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "008"
                },
                new Card
                {
                    Id = (int)Enum.CardId.YoungScum,
                    Name = "Young Scum",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 1,
                    HealthValue = 1,
                    Ability = "Reaction: After this Agent leaves play, put a 2/2 Scum Agent token"
                        + Environment.NewLine
                        + "with [Espionage] into play on the same Area.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "009"
                },
                new Card
                {
                    Id = (int)Enum.CardId.VestaThug,
                    Name = "Vesta Thug",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 4,
                    HealthValue = 3,
                    Ability = "[B][B][A3], Use: Put a 2/2 Scum Agent token with [Espionage] into play"
                        + Environment.NewLine
                        + "on the same Area.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "010"
                },
                new Card
                {
                    Id = (int)Enum.CardId.RebelSaboteur,
                    Name = "Rebel Saboteur",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 3,
                    HealthValue = 4,
                    Ability = "Sacrifice: Destroy target Construction",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "011"
                },
                new Card
                {
                    Id = (int)Enum.CardId.GangLeader,
                    Name = "Gang Leader",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 2,
                    HealthValue = 4,
                    Ability = "Conflict action, Use: Target enemy Agent"
                       + Environment.NewLine
                       + "on this Mission moves to another Ready"
                       + Environment.NewLine
                       + "Mission, if there are no Ready Missions,"
                       + Environment.NewLine
                       + "then move that Agent to the Shuttle area.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "012"
                },
                new Card
                {
                    Id = (int)Enum.CardId.MrYue,
                    Name = "Mr. Yué",
                    Unique = true,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 3,
                    HealthValue = 4,
                    Ability = "Reaction: After a friendly"
                       + Environment.NewLine
                       + "non-token Agent leaves play,"
                       + Environment.NewLine
                       + "put 1 Influence on this Agent.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "013"
                },
                new Card
                {
                    Id = (int)Enum.CardId.GrowingInfection,
                    Name = "Growing Infection",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "When you play this card, attach it to an Agent and"
                       + Environment.NewLine
                       + "put 1 infection counter on this card."
                       + Environment.NewLine
                       + "Reaction: At the beginning of the Starting phase put"
                       + Environment.NewLine
                       + "1 infection counter on this card. If there are equal or"
                       + Environment.NewLine
                       + "more infection counters on this card as the"
                       + Environment.NewLine
                       + "converted Resource cost of the attached Agent,"
                       + Environment.NewLine
                       + "destroy that Agent.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "014"
                },
                new Card
                {
                    Id = (int)Enum.CardId.Execution,
                    Name = "Execution",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Syndicate Maneuver"
                       + Environment.NewLine
                       + "Destroy target Agent.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "015"
                },
                new Card
                {
                    Id = (int)Enum.CardId.HuntDown,
                    Name = "Hunt Down",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Reaction: After an Agent you control"
                       + Environment.NewLine
                       + "deals attack damage to a non-Unique"
                       + Environment.NewLine
                       + "Agent, destroy that Agent.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "016"
                },
                new Card
                {
                    Id = (int)Enum.CardId.OrganDonor,
                    Name = "Organ Donor",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Sacrifice an Agent: Prevent all damage"
                       + Environment.NewLine
                       + "from one source to an Agent on the"
                       + Environment.NewLine
                       + "same Mission.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "017"
                },
                new Card
                {
                    Id = (int)Enum.CardId.YouareTired,
                    Name = "You are Tired!",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Move target used enemy Agent to a Ready"
                       + Environment.NewLine
                       + "Mission, if there are no Ready Missions, then"
                       + Environment.NewLine
                       + "move that Agent to the Shuttle area.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "018"
                },
                new Card
                {
                    Id = (int)Enum.CardId.EyeforanEye,
                    Name = "Eye for an Eye",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Syndicate Maneuver"
                       + Environment.NewLine
                       + "All players destroy 1 Agent"
                       + Environment.NewLine
                       + "in all their Shuttles.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "019"
                },
                new Card
                {
                    Id = (int)Enum.CardId.Arson,
                    Name = "Arson",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Syndicate Maneuver"
                       + Environment.NewLine
                       + "Sacrifice an Agent: Destroy target"
                       + Environment.NewLine
                       + "Agent or Construction.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "020"
                },
                new Card
                {
                    Id = (int)Enum.CardId.BestoftheBelt,
                    Name = "Best of the Belt",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Syndicate Maneuver"
                       + Environment.NewLine
                       + "Put three 2/2 Scum Agent tokens"
                       + Environment.NewLine
                       + "with [Espionage] into a Shuttle.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "021"
                },
                new Card
                {
                    Id = (int)Enum.CardId.Donorcenter,
                    Name = "Donor center",
                    Unique = true,
                    Type = (int)CardTypeEnum.Construction,
                    Ability = "Use, Sacrifice a non-token Agent:"
                       + Environment.NewLine
                       + "Draw 1 card.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "022"
                },
                new Card
                {
                    Id = (int)Enum.CardId.AsteroidIntelStation,
                    Name = "Asteroid Intel Station",
                    Unique = false,
                    Type = (int)CardTypeEnum.Construction,
                    Ability = "Use: Use target Agent"
                       + Environment.NewLine
                       + "unless its controller pays [A2].",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "023"
                },

            #endregion

            #region Earth

                 new Card
                 {
                     Id = (int)Enum.CardId.AcolyteinTraining,
                     Name = "Acolyte in Training",
                     Unique = false,
                     Type = (int)CardTypeEnum.Agent,
                     AttackValue = 0,
                     HealthValue = 1,
                     Ability = "Syndicate action, Use, Discard a"
                        + Environment.NewLine
                        + "card: Put a +1/+1 counter on this"
                        + Environment.NewLine
                        + "Agent",
                     ExpansionId = (int)Enum.Expansion.SoItBegins,
                     ExpansionSerialNumber = "024"
                 },
                 new Card
                 {
                     Id = (int)Enum.CardId.MonkofSol,
                     Name = "Monk of Sol",
                     Unique = false,
                     Type = (int)CardTypeEnum.Agent,
                     AttackValue = 1,
                     HealthValue = 1,
                     Ability = "Reaction: After this Agent leaves"
                        + Environment.NewLine
                        + "play, put a +1/+1 counter on target"
                        + Environment.NewLine
                        + "Agent on the same area.",
                     ExpansionId = (int)Enum.Expansion.SoItBegins,
                     ExpansionSerialNumber = "025"
                 },
                 new Card
                 {
                     Id = (int)Enum.CardId.SanctionedPriest,
                     Name = "Sanctioned Priest",
                     Unique = false,
                     Type = (int)CardTypeEnum.Agent,
                     AttackValue = 1,
                     HealthValue = 2,
                     Ability = "Reaction: After this Agent enters"
                        + Environment.NewLine
                        + "play draw 1 card.",
                     ExpansionId = (int)Enum.Expansion.SoItBegins,
                     ExpansionSerialNumber = "026"
                 },
                 new Card
                 {
                     Id = (int)Enum.CardId.EarthseedActivist,
                     Name = "Earthseed Activist",
                     Unique = false,
                     Type = (int)CardTypeEnum.Agent,
                     AttackValue = 2,
                     HealthValue = 2,
                     Ability = "[E][E][A1]: Increase a Talent"
                       + Environment.NewLine
                       + "requirement on this Mission by 1"
                       + Environment.NewLine
                       + "until the end of the phase.",
                     ExpansionId = (int)Enum.Expansion.SoItBegins,
                     ExpansionSerialNumber = "027"
                 },
                 new Card
                 {
                     Id = (int)Enum.CardId.PeacefulRepresentative,
                     Name = "Peaceful Representative",
                     Unique = false,
                     Type = (int)CardTypeEnum.Agent,
                     AttackValue = 1,
                     HealthValue = 1,
                     Ability = "Reaction: After this Agent enters play"
                       + Environment.NewLine
                       + "put the top card of your deck under it"
                       + Environment.NewLine
                       + "face down. At the beginning of the"
                       + Environment.NewLine
                       + "Starting phase, draw that card.",
                     ExpansionId = (int)Enum.Expansion.SoItBegins,
                     ExpansionSerialNumber = "028"
                 },
                 new Card
                 {
                     Id = (int)Enum.CardId.ReveredMediator,
                     Name = "Revered Mediator",
                     Unique = false,
                     Type = (int)CardTypeEnum.Agent,
                     AttackValue = 0,
                     HealthValue = 2,
                     Ability = "Conflict action, Use: Move this Agent"
                       + Environment.NewLine
                       + "and a non-Unique enemy Agent on this"
                       + Environment.NewLine
                       + "Mission with converted Resource cost 3"
                       + Environment.NewLine
                       + "or lower to the Shuttle area.",
                     ExpansionId = (int)Enum.Expansion.SoItBegins,
                     ExpansionSerialNumber = "029"
                 },
                 new Card
                 {
                     Id = (int)Enum.CardId.NegotiatorEld,
                     Name = "Negotiator Eld",
                     Unique = true,
                     Type = (int)CardTypeEnum.Agent,
                     AttackValue = 3,
                     HealthValue = 3,
                     Ability = "Reaction: After this Agent"
                       + Environment.NewLine
                       + "completes a Mission, draw 1 card.",
                     ExpansionId = (int)Enum.Expansion.SoItBegins,
                     ExpansionSerialNumber = "030"
                 },
                 new Card
                 {
                     Id = (int)Enum.CardId.ExiledPaladin,
                     Name = "Exiled Paladin",
                     Unique = false,
                     Type = (int)CardTypeEnum.Agent,
                     AttackValue = 2,
                     HealthValue = 3,
                     Ability = "While this Agent is ready, it takes 1"
                       + Environment.NewLine
                       + "less damage from any source.",
                     ExpansionId = (int)Enum.Expansion.SoItBegins,
                     ExpansionSerialNumber = "031"
                 },
                 new Card
                 {
                     Id = (int)Enum.CardId.InvestigatorPaladin,
                     Name = "Investigator Paladin",
                     Unique = false,
                     Type = (int)CardTypeEnum.Agent,
                     AttackValue = 3,
                     HealthValue = 2,
                     Ability = "Reaction: After this Agent enters play"
                       + Environment.NewLine
                       + "put the top card of your deck under it"
                       + Environment.NewLine
                       + "face down. At the beginning of the"
                       + Environment.NewLine
                       + "Starting phase, draw that card.",
                     ExpansionId = (int)Enum.Expansion.SoItBegins,
                     ExpansionSerialNumber = "032"
                 },
                 new Card
                 {
                     Id = (int)Enum.CardId.GuardianPaladin,
                     Name = "Guardian Paladin",
                     Unique = false,
                     Type = (int)CardTypeEnum.Agent,
                     AttackValue = 1,
                     HealthValue = 6,
                     Ability = "Reaction: After another Agent is"
                       + Environment.NewLine
                       + "assigned attack damage on this Mission"
                       + Environment.NewLine
                       + "you may reassign it to this Agent.",
                     ExpansionId = (int)Enum.Expansion.SoItBegins,
                     ExpansionSerialNumber = "033"
                 },
                 new Card
                 {
                     Id = (int)Enum.CardId.PoliticalAdvisor,
                     Name = "Political Advisor",
                     Unique = false,
                     Type = (int)CardTypeEnum.Agent,
                     AttackValue = 4,
                     HealthValue = 3,
                     Ability = "Reaction: After this Agent"
                       + Environment.NewLine
                       + "completes a Mission gain 1"
                       + Environment.NewLine
                       + "Influence.",
                     ExpansionId = (int)Enum.Expansion.SoItBegins,
                     ExpansionSerialNumber = "034"
                 },
                 new Card
                 {
                     Id = (int)Enum.CardId.CosmicLinkManager,
                     Name = "CosmicLink Manager",
                     Unique = false,
                     Type = (int)CardTypeEnum.Agent,
                     AttackValue = 3,
                     HealthValue = 4,
                     Ability = "[E][E][A2]: Target Agent on a ready"
                       + Environment.NewLine
                       + "Mission gains a Talent of your"
                       + Environment.NewLine
                       + "choice until the end of the phase.",
                     ExpansionId = (int)Enum.Expansion.SoItBegins,
                     ExpansionSerialNumber = "035"
                 },
                 new Card
                 {
                     Id = (int)Enum.CardId.AmbassadorSunders,
                     Name = "Ambassador Sunders",
                     Unique = true,
                     Type = (int)CardTypeEnum.Agent,
                     AttackValue = 0,
                     HealthValue = 5,
                     Ability = "This Agent cannot be targeted by Conflict"
                       + Environment.NewLine
                       + "actions if there are any other friendly Agents on"
                       + Environment.NewLine
                       + "this Mission."
                       + Environment.NewLine
                       + "Conflict Action, Use: Return target non-Unique"
                       + Environment.NewLine
                       + "enemy Agent on this Mission to its owners hand.",
                     ExpansionId = (int)Enum.Expansion.SoItBegins,
                     ExpansionSerialNumber = "036"
                 },
                 new Card
                 {
                     Id = (int)Enum.CardId.HeroicRescue,
                     Name = "Heroic Rescue",
                     Unique = false,
                     Type = (int)CardTypeEnum.Maneuver,
                     Ability = "Reaction: After an attack is declared"
                       + Environment.NewLine
                       + "against an Agent you control, choose a"
                       + Environment.NewLine
                       + "new defender.",
                     ExpansionId = (int)Enum.Expansion.SoItBegins,
                     ExpansionSerialNumber = "037"
                 },
                 new Card
                 {
                     Id = (int)Enum.CardId.SawitComing,
                     Name = "Saw it Coming",
                     Unique = false,
                     Type = (int)CardTypeEnum.Maneuver,
                     Ability = "Reaction: Prevent all damage on an"
                       + Environment.NewLine
                       + "Agent from a source that deals 3 or"
                       + Environment.NewLine
                       + "more damage.",
                     ExpansionId = (int)Enum.Expansion.SoItBegins,
                     ExpansionSerialNumber = "038"
                 },
                 new Card
                 {
                     Id = (int)Enum.CardId.ExpendableBodyguard,
                     Name = "Expendable Bodyguard",
                     Unique = false,
                     Type = (int)CardTypeEnum.Maneuver,
                     Ability = "Reaction: Prevent 2 damage",
                     ExpansionId = (int)Enum.Expansion.SoItBegins,
                     ExpansionSerialNumber = "039"
                 },
                 new Card
                 {
                     Id = (int)Enum.CardId.IntroducingtoTheFaith,
                     Name = "Introducing to The Faith",
                     Unique = false,
                     Type = (int)CardTypeEnum.Maneuver,
                     Ability = "Return target non-Unique Agent with"
                       + Environment.NewLine
                       + "converted Resource cost 3 or lower to its"
                       + Environment.NewLine
                       + "owners hand.",
                     ExpansionId = (int)Enum.Expansion.SoItBegins,
                     ExpansionSerialNumber = "040"
                 },
                 new Card
                 {
                     Id = (int)Enum.CardId.CantTouchMe,
                     Name = "Can't Touch Me",
                     Unique = false,
                     Type = (int)CardTypeEnum.Maneuver,
                     Ability = "Conflict action, Use target Agent:"
                       + Environment.NewLine
                       + "Move target friendly Agent and a"
                       + Environment.NewLine
                       + "non-Unique enemy Agent on the same"
                       + Environment.NewLine
                       + "Mission with converted Resource cost 3 or"
                       + Environment.NewLine
                       + "lower to the Shuttle area.",
                     ExpansionId = (int)Enum.Expansion.SoItBegins,
                     ExpansionSerialNumber = "041"
                 },
                 new Card
                 {
                     Id = (int)Enum.CardId.HardTimes,
                     Name = "Hard Times",
                     Unique = false,
                     Type = (int)CardTypeEnum.Maneuver,
                     Ability = "Attach this card to a Mission. Increase all"
                       + Environment.NewLine
                       + "Talent requirements on this Mission by 1."
                       + Environment.NewLine
                       + "Forced Reaction: After completing this"
                       + Environment.NewLine
                       + "Mission, destroy this card.",
                     ExpansionId = (int)Enum.Expansion.SoItBegins,
                     ExpansionSerialNumber = "042"
                 },
                 new Card
                 {
                     Id = (int)Enum.CardId.TwistofFate,
                     Name = "Twist of Fate",
                     Unique = false,
                     Type = (int)CardTypeEnum.Maneuver,
                     Ability = "Change a Talent requirement on a"
                       + Environment.NewLine
                       + "Mission until the end of round.",
                     ExpansionId = (int)Enum.Expansion.SoItBegins,
                     ExpansionSerialNumber = "043"
                 },
                 new Card
                 {
                     Id = (int)Enum.CardId.ScorchedEarthTactic,
                     Name = "Scorched Earth Tactic",
                     Unique = false,
                     Type = (int)CardTypeEnum.Maneuver,
                     Ability = "Destroy all Agents"
                       + Environment.NewLine
                       + "on target Mission.",
                     ExpansionId = (int)Enum.Expansion.SoItBegins,
                     ExpansionSerialNumber = "044"
                 },
                 new Card
                 {
                     Id = (int)Enum.CardId.PoliticalDelegation,
                     Name = "Political Delegation",
                     Unique = false,
                     Type = (int)CardTypeEnum.Maneuver,
                     Ability = "Choose up to 3 Agents,"
                       + Environment.NewLine
                       + "they gain [Diplomacy] until the"
                       + Environment.NewLine
                       + "end of the phase.",
                     ExpansionId = (int)Enum.Expansion.SoItBegins,
                     ExpansionSerialNumber = "045"
                 },
                 new Card
                 {
                     Id = (int)Enum.CardId.PoliticalAcademy,
                     Name = "Political Academy",
                     Unique = false,
                     Type = (int)CardTypeEnum.Construction,
                     Ability = "Preparing."
                       + Environment.NewLine
                       + "[This card enters play Used.]"
                       + Environment.NewLine
                       + "Syndicate action, Use:"
                       + Environment.NewLine
                       + "Put an 1/1 Envoy Agent token"
                       + Environment.NewLine
                       + "with [Diplomacy] into play.",
                     ExpansionId = (int)Enum.Expansion.SoItBegins,
                     ExpansionSerialNumber = "046"
                 },

            #endregion

            #region Mars
                
                new Card
                {
                    Id = (int)Enum.CardId.MartianDiplomat,
                    Name = "Martian Diplomat",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 0,
                    HealthValue = 2,
                    Ability = "Use: Choose a Talent on another Agent"
                        + Environment.NewLine
                        + "on this Mission, give that Agent on more"
                        + Environment.NewLine
                        + "of that Talent until the end of the phase.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "047"
                },
                new Card
                {
                    Id = (int)Enum.CardId.CrimsonGrenadier,
                    Name = "Crimson Grenadier",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 1,
                    HealthValue = 1,
                    Ability = "Reaction: After this Agent leaves"
                        + Environment.NewLine
                        + "play, each player deals 1 damage"
                        + Environment.NewLine
                        + "to target enemy Agent on this"
                        + Environment.NewLine
                        + "Mission.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "048"
                },
                new Card
                {
                    Id = (int)Enum.CardId.CrimsonLegionInfantry,
                    Name = "Crimson Legion Infantry",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 1,
                    HealthValue = 1,
                    Ability = "Reaction: After this Agent leaves play,"
                        + Environment.NewLine
                        + "search your deck for a card named"
                        + Environment.NewLine
                        + "Crimson Legion Infantry, reveal it and"
                        + Environment.NewLine
                        + "add it to your hand. Shuffle.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "049"
                },
                new Card
                {
                    Id = (int)Enum.CardId.SpecialOps,
                    Name = "Special Ops",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 2,
                    HealthValue = 1,
                    Ability = "Reaction, [Ma]: After this Agent is"
                        + Environment.NewLine
                        + "deployed to a Mission, search your deck"
                        + Environment.NewLine
                        + "or hand for a card named Special Ops,"
                        + Environment.NewLine
                        + "put it into play on this Mission Used."
                        + Environment.NewLine
                        + "Shuffle."
                        + Environment.NewLine
                        + "[Limit once per phase.]",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "050"
                },
                new Card
                {
                    Id = (int)Enum.CardId.CrimsonShockTroops,
                    Name = "Crimson Shock Troops",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 2,
                    HealthValue = 2,
                    Ability = "[Ma][A1]: This Agent gains"
                        + Environment.NewLine
                        + "+1/+0 until the end of the phase.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "051"
                },
                new Card
                {
                    Id = (int)Enum.CardId.CrimsonLegionScout,
                    Name = "Crimson Legion Scout",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 2,
                    HealthValue = 1,
                    Ability = "Reaction: After this Agent leaves play,"
                        + Environment.NewLine
                        + "target Agent gains a Talent of your"
                        + Environment.NewLine
                        + "choice until the end of the phase.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "052"
                },
                new Card
                {
                    Id = (int)Enum.CardId.SergeantJoseph,
                    Name = "Sergeant Joseph",
                    Unique = true,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 3,
                    HealthValue = 3,
                    Ability = "Reaction: After this Agent deals"
                        + Environment.NewLine
                        + "attack damage to an enemy Agent,"
                        + Environment.NewLine
                        + "deal 1 damage to target Agent on"
                        + Environment.NewLine
                        + "this Mission.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "053"
                },
                new Card
                {
                    Id = (int)Enum.CardId.ChefuMilitia,
                    Name = "Chefu Militia",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 2,
                    HealthValue = 2,
                    Ability = "[Ma][Ma][A1]: Deal 1 damage"
                        + Environment.NewLine
                        + "to target Agent on this Mission.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "054"
                },
                new Card
                {
                    Id = (int)Enum.CardId.TarakanGuard,
                    Name = "Tarakan Guard",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 3,
                    HealthValue = 2,
                    Ability = "[Ma][Ma]: This Agent gains [Military]"
                        + Environment.NewLine
                        + "until the end of this phase.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "055"
                },
                new Card
                {
                    Id = (int)Enum.CardId.ChameleonCorps,
                    Name = "Chameleon Corps",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 2,
                    HealthValue = 3,
                    Ability = "[A2]: This Agent gains a Talent of"
                        + Environment.NewLine
                        + "your choice until the end"
                        + Environment.NewLine
                        + "of the phase.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "056"
                },
                new Card
                {
                    Id = (int)Enum.CardId.ExplosiveExpert,
                    Name = "Explosive Expert",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 2,
                    HealthValue = 2,
                    Ability = "Reaction: After this Agent is deployed"
                        + Environment.NewLine
                        + "to a Mission, deal 1 damage to each"
                        + Environment.NewLine
                        + "enemy Agent on this Mission.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "057"
                },
                new Card
                {
                    Id = (int)Enum.CardId.SupplyLineOfficer,
                    Name = "Supply Line Officer",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 4,
                    HealthValue = 3,
                    Ability = "Reaction: After this Agent is deployed"
                        + Environment.NewLine
                        + "to a Mission, look at the top 3 cards of"
                        + Environment.NewLine
                        + "your deck, you may reveal an Agent"
                        + Environment.NewLine
                        + "card and add it to your hand. Shuffle.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "058"
                },
                new Card
                {
                    Id = (int)Enum.CardId.IrharenVeteran,
                    Name = "Irharen Veteran",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 4,
                    HealthValue = 3,
                    Ability = "[Ma][Ma][A2]: Deal 2 damage"
                        + Environment.NewLine
                        + "to target agent on this Mission.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "059"
                },
                new Card
                {
                    Id = (int)Enum.CardId.GeneralRwanda,
                    Name = "General Rwanda",
                    Unique = true,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 3,
                    HealthValue = 6,
                    Ability = "Reaction: After this Agent is deployed to"
                        + Environment.NewLine
                        + "a Mission, put a 1/1 Infantry Agent token"
                        + Environment.NewLine
                        + "with [Military] into play on this Mission.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "060"
                },
                new Card
                {
                    Id = (int)Enum.CardId.Headshot,
                    Name = "Headshot",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Hasty"
                        + Environment.NewLine
                        + "[If you play this card during the"
                        + Environment.NewLine
                        + "Conflict phase, pay [A1] more.]"
                        + Environment.NewLine
                        + "Deal 2 damage to target Agent.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "061"
                },
                new Card
                {
                    Id = (int)Enum.CardId.PreparedAmbush,
                    Name = "Prepared Ambush",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Conflict Maneuver"
                        + Environment.NewLine
                        + "Use an Agent: Deal its attack value to"
                        + Environment.NewLine
                        + "target Agent on the same mission.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "062"
                },
                new Card
                {
                    Id = (int)Enum.CardId.UnexpectedCourage,
                    Name = "Unexpected Courage",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Conflict Maneuver"
                        + Environment.NewLine
                        + "Target friendly Agent deals its attack value to"
                        + Environment.NewLine
                        + "target Agent on the same mission.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "063"
                },
                new Card
                {
                    Id = (int)Enum.CardId.DevotedLearning,
                    Name = "Devoted Learning",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Reaction: After completing a Mission,"
                        + Environment.NewLine
                        + "draw 3 cards."
                        + Environment.NewLine
                        + "[Limit once per mission.]",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "064"
                },
                new Card
                {
                    Id = (int)Enum.CardId.MartianEducation,
                    Name = "Martian Education",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Target Agent gains a Talent of your"
                        + Environment.NewLine
                        + "choice until the end of the phase.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "065"
                },
                new Card
                {
                    Id = (int)Enum.CardId.Aftermath,
                    Name = "Aftermath",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Reaction: After completing a Mission,"
                        + Environment.NewLine
                        + "deal 3 damage to target Agent in play.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "066"
                },
                new Card
                {
                    Id = (int)Enum.CardId.ChemicalWarfare,
                    Name = "Chemical Warfare",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Deal 1 damage to each Agent on a Mission.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "067"
                },
                new Card
                {
                    Id = (int)Enum.CardId.WarPropaganda,
                    Name = "War Propaganda",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Reaction: After you claim a Mission,"
                        + Environment.NewLine
                        + "instead of your opponent, you put the new"
                        + Environment.NewLine
                        + "Mission from your Mission Deck into play.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "068"
                },
                new Card
                {
                    Id = (int)Enum.CardId.OlympusUniversity,
                    Name = "Olympus University",
                    Unique = true,
                    Type = (int)CardTypeEnum.Construction,
                    Ability = "Use: Target Agent gains a"
                        + Environment.NewLine
                        + "Talent of your choice"
                        + Environment.NewLine
                        + "until the end of the phase.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "069"
                },

            #endregion

            #region Mercury

                new Card
                {
                    Id = (int)Enum.CardId.MercurianRecruiter,
                    Name = "Mercurian Recruiter",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 0,
                    HealthValue = 1,
                    Ability = "Preparing."
                        + Environment.NewLine
                        + "[This Agent enters play Used.]"
                        + Environment.NewLine
                        + "Use: Gain [Me].",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "070"
                },                
                new Card
                {
                    Id = (int)Enum.CardId.ApollodorusMerc,
                    Name = "Apollodorus Merc",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 2,
                    HealthValue = 2,
                    Ability = "[A2]: Take control of this Agent."
                        + Environment.NewLine
                        + "[Any player may pay for this ability.]",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "071"
                },
                new Card
                {
                    Id = (int)Enum.CardId.NewDallasSapper,
                    Name = "New Dallas Sapper",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 2,
                    HealthValue = 2,
                    Ability = "Use, [Me][Me][A2]: Destroy target"
                        + Environment.NewLine
                        + "Construction.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "072"
                },
                new Card
                {
                    Id = (int)Enum.CardId.SecondGenColonist,
                    Name = "Second Gen. Colonist",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 1,
                    HealthValue = 2,
                    Ability = "Reaction: After this Agent enters"
                        + Environment.NewLine
                        + "play, ready one of your Resource"
                        + Environment.NewLine
                        + "cards.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "073"
                },
                new Card
                {
                    Id = (int)Enum.CardId.NoahtheArchitect,
                    Name = "Noah, the Architect",
                    Unique = true,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 2,
                    HealthValue = 4,
                    Ability = "Spend 1 influence: Gain"
                        + Environment.NewLine
                        + "[Me][Me][Me] you can only spend this"
                        + Environment.NewLine
                        + "Resource to play Construction cards.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "074"
                },
                new Card
                {
                    Id = (int)Enum.CardId.MiningBeliever,
                    Name = "Mining Believer",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 3,
                    HealthValue = 2,
                    Ability = "[Me][Me]: This Agent gains [Mining]"
                        + Environment.NewLine
                        + "until the end of the phase.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "075"
                },
                new Card
                {
                    Id = (int)Enum.CardId.NewDallasOpportunist,
                    Name = "New Dallas Opportunist",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 2,
                    HealthValue = 3,
                    Ability = "Reaction, [A2]: After this Agent"
                        + Environment.NewLine
                        + "completes a Mission, gain 1"
                        + Environment.NewLine
                        + "Influence.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "076"
                },
                new Card
                {
                    Id = (int)Enum.CardId.CalorisBasinTrader,
                    Name = "Caloris Basin Trader",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 2,
                    HealthValue = 3,
                    Ability = "Reaction: After you have 0 ready"
                        + Environment.NewLine
                        + "Resource cards the first time"
                        + Environment.NewLine
                        + "during your turn, gain 1 Influence.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "077"
                },
                new Card
                {
                    Id = (int)Enum.CardId.AMU,
                    Name = "A.M.U.",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 4,
                    HealthValue = 3,
                    Ability = "[Me][Me][A2]: Gain +1/+1 until the"
                        + Environment.NewLine
                        + "end of the phase.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "078"
                },
                new Card
                {
                    Id = (int)Enum.CardId.OutcastSmuggler,
                    Name = "Outcast Smuggler",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 2,
                    HealthValue = 2,
                    Ability = "Reaction: After this Agent enters"
                        + Environment.NewLine
                        + "play, put a Resource card of your"
                        + Environment.NewLine
                        + "choice into play Used.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "079"
                },
                new Card
                {
                    Id = (int)Enum.CardId.MiningWalker,
                    Name = "Mining Walker",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 0,
                    HealthValue = 5,
                    Ability = "Use: Gain 1 Influence.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "080"
                },
                new Card
                {
                    Id = (int)Enum.CardId.BobbyMcKendrickTheBoss,
                    Name = "Bobby McKendrick, The Boss",
                    Unique = true,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 4,
                    HealthValue = 5,
                    Ability = "Reaction: At the start of the"
                        + Environment.NewLine
                        + "Conflict phase, gain [A1] for each"
                        + Environment.NewLine
                        + "Construction you control.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "081"
                },
                new Card
                {
                    Id = (int)Enum.CardId.CombatSteroids,
                    Name = "Combat Steroids",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Target Agent gains +2/+2"
                        + Environment.NewLine
                        + "until the end of the Conflict round.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "082"
                },                
                new Card
                {
                    Id = (int)Enum.CardId.GiveUporGetUp,
                    Name = "Give Up or Get Up!",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Ready target Agent on a Mission.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "083"
                },
                new Card
                {
                    Id = (int)Enum.CardId.MercifulLoan,
                    Name = "Merciful Loan",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Reaction: After your opponent plays a card, you"
                        + Environment.NewLine
                        + "may pay the card's converted Resource cost"
                        + Environment.NewLine
                        + "instead, gain Influence equal to the cost payed."
                        + Environment.NewLine
                        + "[up to 3 Influence.]",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "084"
                },
                new Card
                {
                    Id = (int)Enum.CardId.NabuInsurancePolicy,
                    Name = "Nabu Insurance Policy",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "You can only play this card if you have 3 or more"
                        + Environment.NewLine
                        + "ready Resource cards."
                        + Environment.NewLine
                        + "Reaction: Cancel target Maneuver card, that is"
                        + Environment.NewLine
                        + "targeting one of your Agents or Constructions.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "085"
                },
                new Card
                {
                    Id = (int)Enum.CardId.InvestmentintheFuture,
                    Name = "Investment in the Future",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Syndicate maneuver"
                        + Environment.NewLine
                        + "Put a Resource card of your"
                        + Environment.NewLine
                        + "choice into play Used.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "086"
                },
                new Card
                {
                    Id = (int)Enum.CardId.RecycleEverythingthatShines,
                    Name = "Recycle Everything that Shines",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Syndicate maneuver"
                        + Environment.NewLine
                        + "Put a Mercury Resource"
                        + Environment.NewLine
                        + "card into play Used.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "087"
                },
                new Card
                {
                    Id = (int)Enum.CardId.PlannedDemolition,
                    Name = "Planned Demolition",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Syndicate maneuver"
                        + Environment.NewLine
                        + "Destroy target Construction",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "088"
                },
                new Card
                {
                    Id = (int)Enum.CardId.BadQualityFuelCells,
                    Name = "Bad Quality Fuel Cells",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Syndicate maneuver"
                        + Environment.NewLine
                        + "Target Shuttle cannot be deployed this"
                        + Environment.NewLine
                        + "round.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "089"
                },
                new Card
                {
                    Id = (int)Enum.CardId.CalorStorage,
                    Name = "Calor Storage",
                    Unique = false,
                    Type = (int)CardTypeEnum.Construction,
                    Ability = "This card can't have more than"
                        + Environment.NewLine
                        + "3 material counters on it."
                        + Environment.NewLine
                        + "Use a Resource card: Put a material counter on"
                        + Environment.NewLine
                        + "this card."
                        + Environment.NewLine
                        + "Use: Remove all material counters from this card to"
                        + Environment.NewLine
                        + "gain that many [A].",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "090"
                },
                new Card
                {
                    Id = (int)Enum.CardId.ApollodorusDock,
                    Name = "Apollodorus Dock",
                    Unique = true,
                    Type = (int)CardTypeEnum.Construction,
                    Ability = "Use, [Me][A1]:"
                        + Environment.NewLine
                        + "Draw 1 card.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "091"
                },
                new Card
                {
                    Id = (int)Enum.CardId.WalkingFactory,
                    Name = "Walking Factory",
                    Unique = false,
                    Type = (int)CardTypeEnum.Construction,
                    Ability = "[A2]: Gain 1 Influence."
                        + Environment.NewLine
                        + "[Limit once per phase.]",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "092"
                },
                new Card
                {
                    Id = (int)Enum.CardId.GearingStation,
                    Name = "Gearing Station",
                    Unique = false,
                    Type = (int)CardTypeEnum.Construction,
                    Ability = "Reaction, Use: At the start of the"
                        + Environment.NewLine
                        + "Conflict phase target Agent gains"
                        + Environment.NewLine
                        + "+1/+0 until the end of the phase.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "093"
                },

            #endregion

            #region Titan

                new Card
                {
                    Id = (int)Enum.CardId.DataMiner,
                    Name = "Data Miner",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 0,
                    HealthValue = 2,
                    Ability = "Use: Discard the"
                        + Environment.NewLine
                        + "top 2 cards of your deck.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "094"
                },
                new Card
                {
                    Id = (int)Enum.CardId.OrdinaryServitor,
                    Name = "Ordinary Servitor",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 2,
                    HealthValue = 2,
                    Ability = "Archive."
                        + Environment.NewLine
                        + "[You can play this card as a Resource from your"
                        + Environment.NewLine
                        + "discard pile.]",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "095"
                },
                new Card
                {
                    Id = (int)Enum.CardId.SinlapParasyte,
                    Name = "Sinlap Parasyte",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 0,
                    HealthValue = 2,
                    Ability = "Conflict action, Use: Take control of"
                        + Environment.NewLine
                        + "target non-Unique Agent on this Mission"
                        + Environment.NewLine
                        + "with converted Resource cost 3 or lower"
                        + Environment.NewLine
                        + "until the end of the phase or until this"
                        + Environment.NewLine
                        + "card leaves this Mission. This Agent"
                        + Environment.NewLine
                        + "cannot ready until the end of the Round.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "096"
                },
                new Card
                {
                    Id = (int)Enum.CardId.OracleDroid,
                    Name = "Oracle Droid",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 2,
                    HealthValue = 2,
                    Ability = "Reaction: After this Agent enters play"
                        + Environment.NewLine
                        + "return target card from your discard"
                        + Environment.NewLine
                        + "pile to the top of your deck. Shuffle.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "097"
                },
                new Card
                {
                    Id = (int)Enum.CardId.EbonyFranth,
                    Name = "Ebony Franth",
                    Unique = true,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 2,
                    HealthValue = 4,
                    Ability = "Reaction: After this Agent deals"
                        + Environment.NewLine
                        + "damage to an enemy Agent, that Agent"
                        + Environment.NewLine
                        + "loses all of its Talents until the end of"
                        + Environment.NewLine
                        + "the phase.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "098"
                },
                new Card
                {
                    Id = (int)Enum.CardId.BattleDroid,
                    Name = "Battle Droid",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 2,
                    HealthValue = 3,
                    Ability = "Archive."
                        + Environment.NewLine
                        + "[You can play this card as a Resource from your"
                        + Environment.NewLine
                        + "discard pile.]",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "099"
                },
                new Card
                {
                    Id = (int)Enum.CardId.LigeiaDeveloper,
                    Name = "Ligeia Developer",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 2,
                    HealthValue = 2,
                    Ability = "Reaction: At the start of the Conflict"
                        + Environment.NewLine
                        + "phase, give target Agent on this Mission"
                        + Environment.NewLine
                        + "+1/+1 until the end of the phase.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "100"
                },
                new Card
                {
                    Id = (int)Enum.CardId.XanaduLeadLibrarian,
                    Name = "Xanadu Lead Librarian",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 3,
                    HealthValue = 3,
                    Ability = "Reaction: After this Agent enters play"
                        + Environment.NewLine
                        + "reveal the top 5 cards of your deck. You"
                        + Environment.NewLine
                        + "may choose a Maneuver card among"
                        + Environment.NewLine
                        + "them and put it into your hand."
                        + Environment.NewLine
                        + "Discard the rest.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "101"
                },
                new Card
                {
                    Id = (int)Enum.CardId.LazarusProtocol,
                    Name = "Lazarus Protocol",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 0,
                    HealthValue = 0,
                    Ability = "Archive."
                        + Environment.NewLine
                        + "Reaction: After this agent enters play"
                        + Environment.NewLine
                        + "choose a non-Unique Agent with converted"
                        + Environment.NewLine
                        + "Resource cost 3 or lower in your discard pile."
                        + Environment.NewLine
                        + "Put that Agent into play with a +1/+1 counter"
                        + Environment.NewLine
                        + "on it, it gains a [Data]. attach Lazarus Protocol"
                        + Environment.NewLine
                        + "to that Agent.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "102"
                },
                new Card
                {
                    Id = (int)Enum.CardId.CyborgBodyguard,
                    Name = "Cyborg Bodyguard",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 3,
                    HealthValue = 4,
                    Ability = "Archive."
                        + Environment.NewLine
                        + "[You can play this card as a Resource from your"
                        + Environment.NewLine
                        + "discard pile.]",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "103"
                },
                new Card
                {
                    Id = (int)Enum.CardId.BhavyaAdministrator,
                    Name = "Bhavya, Administrator",
                    Unique = true,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 3,
                    HealthValue = 5,
                    Ability = "Reaction: After this agent deals"
                        + Environment.NewLine
                        + "attack damage discard a random"
                        + Environment.NewLine
                        + "card from your opponent's hand.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "104"
                },
                new Card
                {
                    Id = (int)Enum.CardId.IllusionalDistraction,
                    Name = "Illusional Distraction",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Reaction: After an Agent is dealt attack"
                        + Environment.NewLine
                        + "damage, that Agent loses all of its"
                        + Environment.NewLine
                        + "Talents until the end of the phase.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "105"
                },
                new Card
                {
                    Id = (int)Enum.CardId.FatigueoftheFlesh,
                    Name = "Fatigue of the Flesh",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Archive."
                        + Environment.NewLine
                        + "[You can play this card as a Resource from your discard pile.]"
                        + Environment.NewLine
                        + "Use target Agent with converted"
                        + Environment.NewLine
                        + "Resource cost 3 or lower.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "106"
                },
                new Card
                {
                    Id = (int)Enum.CardId.InterplanetaryAssist,
                    Name = "Interplanetary Assist",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Use target Agent:"
                        + Environment.NewLine
                        + "Ready another target Agent.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "107"
                },
                new Card
                {
                    Id = (int)Enum.CardId.SuddenTurnaround,
                    Name = "Sudden Turnaround",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Conflict action: Ready target non-Unique"
                        + Environment.NewLine
                        + "enemy Agent with converted Resource"
                        + Environment.NewLine
                        + "cost 3 or lower, take control of it and"
                        + Environment.NewLine
                        + "immediately make an Attack with that Agent."
                        + Environment.NewLine
                        + "Return it to its owner's control.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "108"
                },
                new Card
                {
                    Id = (int)Enum.CardId.SilenceYourMind,
                    Name = "Silence Your Mind",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Archive."
                        + Environment.NewLine
                        + "[You can play this card as a Resource from your discard pile.]"
                        + Environment.NewLine
                        + "Target Agent treats its text box as if it were"
                        + Environment.NewLine
                        + "blan until the end of the phase.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "109"
                },
                new Card
                {
                    Id = (int)Enum.CardId.DataBreach,
                    Name = "Data Breach",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Target opponent reveals their hand."
                        + Environment.NewLine
                        + "You choose a card from it."
                        + Environment.NewLine
                        + "That player discards that card.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "110"
                },
                new Card
                {
                    Id = (int)Enum.CardId.MindOverride,
                    Name = "Mind Override",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Archive."
                        + Environment.NewLine
                        + "Choose a non-Unique Agent in play,"
                        + Environment.NewLine
                        + "take control of that Agent"
                        + Environment.NewLine
                        + "until the end of the phase.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "111"
                },
                new Card
                {
                    Id = (int)Enum.CardId.WipetheMind,
                    Name = "Wipe the Mind",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Target Agent loses a Talent of your"
                        + Environment.NewLine
                        + "choice until the end of the round.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "112"
                },
                new Card
                {
                    Id = (int)Enum.CardId.SearchingtheArchives,
                    Name = "Searching the Archives",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Archive."
                        + Environment.NewLine
                        + "Search your discard pile for an Agent"
                        + Environment.NewLine
                        + "card, put it into your hand.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "113"
                },
                new Card
                {
                    Id = (int)Enum.CardId.AncientDrives,
                    Name = "Ancient Drives",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Discard the top 5 cards"
                        + Environment.NewLine
                        + "of your deck.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "114"
                },
                new Card
                {
                    Id = (int)Enum.CardId.DataMine,
                    Name = "Data Mine",
                    Unique = false,
                    Type = (int)CardTypeEnum.Construction,
                    Ability = "Reaction: After this card enters play put 4"
                        + Environment.NewLine
                        + "memory counters on it."
                        + Environment.NewLine
                        + "Use, Remove a memory counter:"
                        + Environment.NewLine
                        + "Look at the top card of your deck."
                        + Environment.NewLine
                        + "You may put that card into your Discard pile.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "115"
                },
                new Card
                {
                    Id = (int)Enum.CardId.XanaduMemoryVault,
                    Name = "Xanadu Memory Vault",
                    Unique = true,
                    Type = (int)CardTypeEnum.Construction,
                    Ability = "Use: Put 1 corruption counter on this card."
                        + Environment.NewLine
                        + "Use: Take control of an Agent with converted"
                        + Environment.NewLine
                        + "Resource cost equal to the corruption counters"
                        + Environment.NewLine
                        + "on this card. Destroy this card.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "116"
                },
                new Card
                {
                    Id = (int)Enum.CardId.CyberBankOfTitan,
                    Name = "Cyber Bank of Titan",
                    Unique = true,
                    Type = (int)CardTypeEnum.Construction,
                    Ability = "Forced Reaction: After this card enters play put the top 5 cards of your deck under it face down"
                        + Environment.NewLine
                        + "[You may look at these cards any time.]"
                        + Environment.NewLine
                        + "Use: Play a card from under this card. When there are no cards left under this card, destroy it.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "117"
                },

            #endregion

            #region Venus

                new Card
                {
                    Id = (int)Enum.CardId.DisguisedCrew,
                    Name = "Disguised Crew",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 1,
                    HealthValue = 1,
                    Ability = "Covert."
                        + Environment.NewLine
                        + "[This Agent can be played in"
                        + Environment.NewLine
                        + "the Conflict phase.]",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "118"
                },
                new Card
                {
                    Id = (int)Enum.CardId.DustAddict,
                    Name = "Dust Addict",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 2,
                    HealthValue = 2,
                    Ability = "Forced Reaction: Destroy this"
                        + Environment.NewLine
                        + "Agent at the end of the round.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "119"
                },
                new Card
                {
                    Id = (int)Enum.CardId.DisciplineofNight,
                    Name = "Discipline of Night",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 2,
                    HealthValue = 1,
                    Ability = "Covert."
                        + Environment.NewLine
                        + "[This Agent can be played in"
                        + Environment.NewLine
                        + "the Conflict phase.]",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "120"
                },
                new Card
                {
                    Id = (int)Enum.CardId.EvidenceAnalyst,
                    Name = "Evidence Analyst",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 2,
                    HealthValue = 2,
                    Ability = "[V]: This Agent gains a Talent of your"
                        + Environment.NewLine
                        + "choice from an enemy Agent on the"
                        + Environment.NewLine
                        + "same Mission until the end of the phase.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "121"
                },
                new Card
                {
                    Id = (int)Enum.CardId.QuasimDaher,
                    Name = "Quasim Daher",
                    Unique = true,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 3,
                    HealthValue = 3,
                    Ability = "Reaction: After a friendly Agent"
                        + Environment.NewLine
                        + "moves to this Mission,"
                        + Environment.NewLine
                        + "draw 1 card. [limit once per phase]",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "122"
                },
                new Card
                {
                    Id = (int)Enum.CardId.IshtarAssociate,
                    Name = "Ishtar Associate",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 2,
                    HealthValue = 3,
                    Ability = "[V][V][A1]: In the Conflict phase,"
                        + Environment.NewLine
                        + "moves target friendly Agent"
                        + Environment.NewLine
                        + "to the Shuttle area.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "123"
                },
                new Card
                {
                    Id = (int)Enum.CardId.TravelingMerchant,
                    Name = "Traveling Merchant",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 2,
                    HealthValue = 2,
                    Ability = "Use: When this Agent is on a"
                        + Environment.NewLine
                        + "Mission, move this Agent to a"
                        + Environment.NewLine
                        + "Ready Mission.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "124"
                },
                new Card
                {
                    Id = (int)Enum.CardId.HiddenCell,
                    Name = "Hidden Cell",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 3,
                    HealthValue = 2,
                    Ability = "Covert."
                        + Environment.NewLine
                        + "[This Agent can be played in the"
                        + Environment.NewLine
                        + "Conflict phase.]",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "125"
                },
                new Card
                {
                    Id = (int)Enum.CardId.MaatMonsSupervisor,
                    Name = "Maat Mons Supervisor",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 3,
                    HealthValue = 4,
                    Ability = "Reaction: After a friendly Agent"
                        + Environment.NewLine
                        + "enters play on this Mission,"
                        + Environment.NewLine
                        + "ready this Agent.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "126"
                },
                new Card
                {
                    Id = (int)Enum.CardId.FailedExperiment,
                    Name = "Failed Experiment",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 6,
                    HealthValue = 1,
                    Ability = "[V][V][A2]: Prevent all damage"
                        + Environment.NewLine
                        + "from a source on this Agent.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "127"
                },
                new Card
                {
                    Id = (int)Enum.CardId.Mole,
                    Name = "Mole",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 3,
                    HealthValue = 2,
                    Ability = "Covert."
                        + Environment.NewLine
                        + "Reaction: When this Agent enters play"
                        + Environment.NewLine
                        + "in the Conflict phase,"
                        + Environment.NewLine
                        + "Cancel target card.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "128"
                },
                new Card
                {
                    Id = (int)Enum.CardId.FamedNavigator,
                    Name = "Famed Navigator",
                    Unique = false,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 3,
                    HealthValue = 3,
                    Ability = "Reaction, Use: If this is the only Agent"
                        + Environment.NewLine
                        + "in this shuttle, after the Shuttle Dials"
                        + Environment.NewLine
                        + "are revealed change the number of"
                        + Environment.NewLine
                        + "this Agent's Shuttle Dial.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "129"
                },
                new Card
                {
                    Id = (int)Enum.CardId.VioletThorn,
                    Name = "Violet Thorn",
                    Unique = true,
                    Type = (int)CardTypeEnum.Agent,
                    AttackValue = 3,
                    HealthValue = 4,
                    Ability = "Reaction: After this Agent completes a"
                        + Environment.NewLine
                        + "Mission move this Agent to the next"
                        + Environment.NewLine
                        + "Mission. [Limit once per phase.]",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "130"
                },
                new Card
                {
                    Id = (int)Enum.CardId.UnexpectedExpenses,
                    Name = "Unexpected Expenses",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,                    
                    Ability = "Reaction: Cancel target card,"
                        + Environment.NewLine
                        + "unless the controlling player pays [A2].",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "131"
                },
                new Card
                {
                    Id = (int)Enum.CardId.FailedProject,
                    Name = "Failed Project",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Syndicate maneuver"
                        + Environment.NewLine
                        + "Reaction: Cancel target card.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "132"
                },
                new Card
                {
                    Id = (int)Enum.CardId.ActofAggression,
                    Name = "Act of Aggression",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Reaction: After a friendly Agent with"
                        + Environment.NewLine
                        + "Covert enters play, it deals its attack"
                        + Environment.NewLine
                        + "value to target Agent on the same mission.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "133"
                },
                new Card
                {
                    Id = (int)Enum.CardId.ForgedTravelLog,
                    Name = "Forged Travel Log",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Reaction: After the Shuttle dials are"
                        + Environment.NewLine
                        + "revealed, change the number on a"
                        + Environment.NewLine
                        + "Shuttle dial you control.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "134"
                },
                new Card
                {
                    Id = (int)Enum.CardId.IntelGathering,
                    Name = "Intel Gathering",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Search the top 5 cards of your deck"
                        + Environment.NewLine
                        + "for a card and put it into your hand."
                        + Environment.NewLine
                        + "Put the rest to the bottom of your deck.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "135"
                },
                new Card
                {
                    Id = (int)Enum.CardId.ToxicBlood,
                    Name = "Toxic Blood",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Reaction: After a friendly Agent is dealt"
                        + Environment.NewLine
                        + "damage from an enemy Agent,"
                        + Environment.NewLine
                        + "deal the same amount of damage to that"
                        + Environment.NewLine
                        + "Agent, up to this Agent's health.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "136"
                },
                new Card
                {
                    Id = (int)Enum.CardId.HologramTrick,
                    Name = "Hologram Trick",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Reaction: Prevent all damage"
                        + Environment.NewLine
                        + "from one source on an Agent.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "137"
                },
                new Card
                {
                    Id = (int)Enum.CardId.ImOutofHere,
                    Name = "I'm Out of Here!",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Conflict maneuver"
                        + Environment.NewLine
                        + "Move target friendly Agent to"
                        + Environment.NewLine
                        + "the Shuttle area.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "138"
                },
                new Card
                {
                    Id = (int)Enum.CardId.Misinformation,
                    Name = "Misinformation",
                    Unique = false,
                    Type = (int)CardTypeEnum.Maneuver,
                    Ability = "Rearrange all friendly Agents"
                        + Environment.NewLine
                        + "in your Shuttles.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "139"
                },
                new Card
                {
                    Id = (int)Enum.CardId.InfiltrationAcademy,
                    Name = "Infiltration Academy",
                    Unique = false,
                    Type = (int)CardTypeEnum.Construction,
                    Ability = "Use: You may play an Agent in this"
                        + Environment.NewLine
                        + "phase as a Maneuver.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "140"
                },
                new Card
                {
                    Id = (int)Enum.CardId.TheShadowDistrict,
                    Name = "The Shadow District",
                    Unique = true,
                    Type = (int)CardTypeEnum.Construction,
                    Ability = "Reaction, Use: After a friendly Agent"
                        + Environment.NewLine
                        + "enters play in the Conflict phase,"
                        + Environment.NewLine
                        + "draw 1 card.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "141"
                },

            #endregion

            #region Mission

                new Card
                {
                    Id = (int)Enum.CardId.ReconIntel,
                    Name = "Recon Intel",
                    Unique = false,
                    Type = (int)CardTypeEnum.Mission,
                    Ability = "Draw 2 cards then discard 1.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "142"
                },
                new Card
                {
                    Id = (int)Enum.CardId.Deconstruction,
                    Name = "Deconstruction",
                    Unique = false,
                    Type = (int)CardTypeEnum.Mission,
                    Ability = "Destroy target Construction.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "143"
                },
                new Card
                {
                    Id = (int)Enum.CardId.MissionSwap,
                    Name = "Mission Swap",
                    Unique = false,
                    Type = (int)CardTypeEnum.Mission,
                    Ability = "Choose target Mission in the Mission Row, switch that Mission with one from"
                        + Environment.NewLine
                        + "your Mission Deck- [The other one goes back to its owner's Mission Deck.]",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "144"
                },
                new Card
                {
                    Id = (int)Enum.CardId.IndustrialSabotage,
                    Name = "Industrial Sabotage",
                    Unique = false,
                    Type = (int)CardTypeEnum.Mission,
                    Ability = "Destroy target Resource card.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "145"
                },
                new Card
                {
                    Id = (int)Enum.CardId.PeaceAgreement,
                    Name = "Peace Agreement",
                    Unique = false,
                    Type = (int)CardTypeEnum.Mission,
                    Ability = "Each player gains 3 Influence.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "146"
                },
                new Card
                {
                    Id = (int)Enum.CardId.CollapsingStocks,
                    Name = "Collapsing Stocks",
                    Unique = false,
                    Type = (int)CardTypeEnum.Mission,
                    Ability = "Each player loses 4 Influence.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "147"
                },
                new Card
                {
                    Id = (int)Enum.CardId.ServerOverload,
                    Name = "Server Overload",
                    Unique = false,
                    Type = (int)CardTypeEnum.Mission,
                    Ability = "Draw 1 card, target opponent discards 1 card.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "148"
                },
                new Card
                {
                    Id = (int)Enum.CardId.Framing,
                    Name = "Framing",
                    Unique = false,
                    Type = (int)CardTypeEnum.Mission,
                    Ability = "Destroy target Agent with converted Resource cost 3 or lower.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "149"
                },
                new Card
                {
                    Id = (int)Enum.CardId.Wiretapping,
                    Name = "Wiretapping",
                    Unique = false,
                    Type = (int)CardTypeEnum.Mission,
                    Ability = "Target player reveals their hand. You choose a card from it."
                        + Environment.NewLine
                        + "That player discards that card.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "150"
                },
                new Card
                {
                    Id = (int)Enum.CardId.CarefulPlanning,
                    Name = "Careful Planning",
                    Unique = false,
                    Type = (int)CardTypeEnum.Mission,
                    Ability = "Put a Resource card of your choice into play.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "151"
                },                
                new Card
                {
                    Id = (int)Enum.CardId.ResourceOperation,
                    Name = "Resource Operation",
                    Unique = false,
                    Type = (int)CardTypeEnum.Mission,
                    Ability = "Put an Agent into your Shuttle area from your discard pile with"
                        + Environment.NewLine
                        + "converted Resource cost 3 or less.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "152"
                },
                new Card
                {
                    Id = (int)Enum.CardId.MyWay,
                    Name = "My Way!",
                    Unique = false,
                    Type = (int)CardTypeEnum.Mission,
                    Ability = "After you claim this Mission, instead of your opponent, you put"
                        + Environment.NewLine
                        + "the new Mission from your Mission Deck into play.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "153"
                },
                new Card
                {
                    Id = (int)Enum.CardId.CallinginFavors,
                    Name = "Calling in Favors",
                    Unique = false,
                    Type = (int)CardTypeEnum.Mission,
                    Ability = "You may spend up to 3 Influence to draw that many cards.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "154"
                },
                new Card
                {
                    Id = (int)Enum.CardId.LevelthePlayingField,
                    Name = "Level the Playing Field",
                    Unique = false,
                    Type = (int)CardTypeEnum.Mission,
                    Ability = "Destroy all Agents in play.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "155"
                },
                new Card
                {
                    Id = (int)Enum.CardId.Mustering,
                    Name = "Mustering",
                    Unique = false,
                    Type = (int)CardTypeEnum.Mission,
                    Ability = "Put an Agent into your Shuttle area from your hand.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "156"
                },
                new Card
                {
                    Id = (int)Enum.CardId.Seduction,
                    Name = "Seduction",
                    Unique = false,
                    Type = (int)CardTypeEnum.Mission,
                    Ability = "Take control of target non-Unique Agent.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "157"
                },
                new Card
                {
                    Id = (int)Enum.CardId.WithdrawFunds,
                    Name = "Withdraw Funds",
                    Unique = false,
                    Type = (int)CardTypeEnum.Mission,
                    Ability = "Choose up to 2 Maneuver cards from your discard pile"
                        + Environment.NewLine
                        + "and put them into your hand.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "158"
                },
                new Card
                {
                    Id = (int)Enum.CardId.Redistribution,
                    Name = "Redistribution",
                    Unique = false,
                    Type = (int)CardTypeEnum.Mission,
                    Ability = "Discard your hand then draw 5 cards.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "159"
                },
                new Card
                {
                    Id = (int)Enum.CardId.SearchforLostKnowledge,
                    Name = "Search for Lost Knowledge",
                    Unique = false,
                    Type = (int)CardTypeEnum.Mission,
                    Ability = "Draw 1 card. Gain 2 Influence.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "160"
                },
                new Card
                {
                    Id = (int)Enum.CardId.PlanetaryPolitics,
                    Name = "Planetary Politics",
                    Unique = false,
                    Type = (int)CardTypeEnum.Mission,
                    Ability = "Target player discards 1 card from their hand."
                        + Environment.NewLine
                        + "Gain 2 Influence.",
                    ExpansionId = (int)Enum.Expansion.SoItBegins,
                    ExpansionSerialNumber = "161"
                }

                #endregion

            );
        }
    }
}