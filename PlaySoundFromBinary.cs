using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReleaseNameVerifier
{
    internal class PlaySoundFromBinary
    {
        public static void Play(string hexString)
        {
            PlayAudio(HexToByteArray(hexString));
        }

        private static void PlayAudio(byte[] audioBytes)
        {
            using (MemoryStream memoryStream = new MemoryStream(audioBytes))
            {
                using (System.Media.SoundPlayer player = new System.Media.SoundPlayer(memoryStream))
                {
                    player.Play();
                }
            }
        }

        private static byte[] HexToByteArray(string hex)
        {
            int length = hex.Length;
            byte[] bytes = new byte[length / 2];

            for (int i = 0; i < length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }

            return bytes;
        }
    }

}
