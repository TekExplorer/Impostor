﻿using System.Threading.Tasks;
using Impostor.Api.Innersloth.Customization;
using Impostor.Api.Net.Inner.Objects;

namespace Impostor.Server.Net.Inner.Objects
{
    internal partial class InnerPlayerControl : IInnerPlayerControl
    {
        IInnerPlayerInfo IInnerPlayerControl.PlayerInfo => PlayerInfo;

        public async ValueTask SetNameAsync(string name)
        {
            PlayerInfo.PlayerName = name;

            using var writer = _game.StartRpc(NetId, RpcCalls.SetName);
            writer.Write(name);
            await _game.FinishRpcAsync(writer);
        }

        public async ValueTask SetColorAsync(byte colorId)
        {
            PlayerInfo.ColorId = colorId;

            using var writer = _game.StartRpc(NetId, RpcCalls.SetColor);
            writer.Write(colorId);
            await _game.FinishRpcAsync(writer);
        }

        public ValueTask SetColorAsync(ColorType colorType)
        {
            return SetColorAsync((byte)colorType);
        }

        public async ValueTask SetHatAsync(uint hatId)
        {
            PlayerInfo.HatId = hatId;

            using var writer = _game.StartRpc(NetId, RpcCalls.SetHat);
            writer.WritePacked(hatId);
            await _game.FinishRpcAsync(writer);
        }

        public ValueTask SetHatAsync(HatType hatType)
        {
            return SetHatAsync((uint)hatType);
        }

        public async ValueTask SetPetAsync(uint petId)
        {
            PlayerInfo.PetId = petId;

            using var writer = _game.StartRpc(NetId, RpcCalls.SetPet);
            writer.WritePacked(petId);
            await _game.FinishRpcAsync(writer);
        }

        public ValueTask SetPetAsync(PetType petType)
        {
            return SetPetAsync((uint)petType);
        }

        public async ValueTask SetSkinAsync(uint skinId)
        {
            PlayerInfo.SkinId = skinId;

            using var writer = _game.StartRpc(NetId, RpcCalls.SetSkin);
            writer.WritePacked(skinId);
            await _game.FinishRpcAsync(writer);
        }

        public ValueTask SetSkinAsync(SkinType skinType)
        {
            return SetSkinAsync((uint)skinType);
        }

        public async ValueTask SendChatAsync(string text)
        {
            using var writer = _game.StartRpc(NetId, RpcCalls.SendChat);
            writer.Write(text);
            await _game.FinishRpcAsync(writer);
        }
    }
}
