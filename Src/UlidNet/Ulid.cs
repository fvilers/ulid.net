using System;

namespace UlidNet
{
    public struct Ulid
    {
        private const string Encoding = "0123456789ABCDEFGHJKMNPQRSTVWXYZ";
        private const int EncodingLength = 32;

        public static string NewUlid()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
