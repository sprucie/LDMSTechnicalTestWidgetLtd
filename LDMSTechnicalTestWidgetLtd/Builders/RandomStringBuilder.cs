using System;
using System.Linq;

namespace LDMSTechnicalTestWidgetLtd.Builders
{
    public class RandomStringBuilder
    {
        private const string LetterPool = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly Random Random = new Random();

        public static string BuildRandomAplhabeticString(int length)
        {
            var chars = Enumerable.Range(0, length).Select(x => LetterPool[Random.Next(0, LetterPool.Length)]);

            return new string(chars.ToArray());
        }

        public static int BuildRandomNumeric(int length)
        {
            var randomNumber = Random.Next(1, length);

            return randomNumber;
        }
    }
}