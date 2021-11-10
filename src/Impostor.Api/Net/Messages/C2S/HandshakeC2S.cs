using Impostor.Api.Innersloth;

namespace Impostor.Api.Net.Messages.C2S
{
    public static class HandshakeC2S
    {
        public static void Deserialize(IMessageReader reader, out int clientVersion, out string name, out Language language, out QuickChatModes chatMode, out PlatformSpecificData? platformSpecificData)
        {
            clientVersion = reader.ReadInt32();
            name = reader.ReadString();

            if (clientVersion >= Version.V1)
            {
                reader.ReadUInt32(); // lastNonceReceived, always 0 since 2021.11.9
            }

            if (clientVersion >= Version.V2)
            {
                language = (Language)reader.ReadUInt32();
                chatMode = (QuickChatModes)reader.ReadByte();
            }
            else
            {
                language = Language.English;
                chatMode = QuickChatModes.FreeChatOrQuickChat;
            }

            if (clientVersion >= Version.V3)
            {
                using var platformReader = reader.ReadMessage();
                platformSpecificData = new PlatformSpecificData(platformReader);
                reader.ReadInt32(); // crossplayFlags, not used yet
            }
            else
            {
                platformSpecificData = null;
            }
        }

        private static class Version
        {
            public static readonly int V1 = GameVersion.GetVersion(2021, 4, 25);

            public static readonly int V2 = GameVersion.GetVersion(2021, 6, 30);

            public static readonly int V3 = GameVersion.GetVersion(2021, 11, 9);
        }
    }
}
