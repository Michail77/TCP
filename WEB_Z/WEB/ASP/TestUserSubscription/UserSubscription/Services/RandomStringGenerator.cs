using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserSubscription.Services
{
    public class RandomStringGenerator : IRandomStringGenerator
    {
        private static Random random = new Random();

        public string Next(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
