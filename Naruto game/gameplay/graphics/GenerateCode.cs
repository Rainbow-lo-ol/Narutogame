using System;

namespace Naruto_game
{
    public static class GenerateCode
    {
        public static string GenerateWord()
        {
            var random = new Random();
            var code = "";
            var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            for (var i = 0; i < 4; i++)
                code += alphabet[random.Next(26)];

            return code;
        }
    }
}
