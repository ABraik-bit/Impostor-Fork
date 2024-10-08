using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Impostor.Api.Innersloth;
using Impostor.Api.Innersloth.Customization;
using Impostor.Api.Net.Messages;

namespace Impostor.Api.Net.Inner.Objects
{
    public interface IInnerPlayerInfo
    {
        /// <summary>
        ///     Gets the name of the player as decided by the host.
        /// </summary>
        string PlayerName { get; }

        /// <summary>
        ///     Gets the role type of the player.
        /// </summary>
        RoleTypes? RoleType { get; }

        /// <summary>
        ///     Gets a value indicating whether the player is an impostor.
        /// </summary>
        bool IsImpostor { get; }

        /// <summary>
        ///     Gets a value indicating whether the player is a dead in the current game.
        /// </summary>
        bool IsDead { get; }

        string FriendCode { get; }

        string PUID { get; }

        bool Disconnected { get; set; }

        uint NetId { get; }

        Dictionary<PlayerOutfitType, PlayerOutfit> Outfits { get; }

        PlayerOutfitType CurrentOutfitType { get; set; }

        PlayerOutfit CurrentOutfit { get; }

        /// <summary>
        ///     Gets the reason why the player is dead in the current game.
        /// </summary>
        DeathReason LastDeathReason { get; }

        IEnumerable<ITaskInfo> Tasks { get; }

        DateTimeOffset LastMurder { get; }

        uint PlayerLevel { get; }

        ValueTask<bool> SerializeAsync(IMessageWriter writer, bool initialState);

        
    }
}
