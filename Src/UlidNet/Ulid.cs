using System;

namespace UlidNet
{
    public struct Ulid
    {
        private const string Encoding = "0123456789ABCDEFGHJKMNPQRSTVWXYZ";
        private const int EncodingLength = 32;

        public static string NewUlid()
        {
            return EncodeTime(Now(), 10) + EncodeRandom(16);
        }

        internal static string EncodeTime(long time, int length)
        {
            var str = "";

            for (var i = length; i > 0; i--)
            {
                var mod = (int)(time % EncodingLength);

                str = Encoding[mod] + str;
                time = (time - mod) / EncodingLength;
            }

            return str;
        }

        internal static string EncodeRandom(int length)
        {
            var str = "";

            for (var i = length; i > 0; i--)
            {
                var rand = (int)Math.Floor(EncodingLength * Prng());

                str = Encoding[rand] + str;
            }

            return str;
        }

        internal static double Prng()
        {
            var rnd = new Random();

            return rnd.NextDouble();
        }

        private static long Now()
        {
            return (DateTime.UtcNow.Ticks - 621355968000000000) / 10000;
        }
    }
}
