#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class AppleTangle
    {
        private static byte[] data = System.Convert.FromBase64String("XUBPQEpIXUwJS1AJSEdQCVlIW11WaIGx0PjjT7UNQjj5ipLNMgPqNglGTwldQUwJXUFMRwlIWVlFQEpIWUVMCWpMW11AT0BKSF1ARkcJaFwcGxgdGRofcz4kGhwZGxkQGxgdGfAfVuiufPCOsJAba9Lx/Fi3V4h7JC8gA69hr94kKCgsLCkqqygoKXWB9VcLHOMM/PAm/0L9iw0KON6IhRk4Lyp8LSM6I2hZWUVMCWBHSgcYXUFGW0BdUBg/GT0vKnwtKjokaFk2uPI3bnnCLMR3UK0Ewh+LfmV8xR+wZQRRnsSlsvXaXrLbX/teGWboR00JSkZHTUBdQEZHWglGTwlcWkwFCUpMW11AT0BKSF1MCVlGRUBKUC7FVBCqonoJ+hHtmJazZiNC1gLVWUVMCXtGRl0JamgZNz4kGR8ZHRupPQL5QG69XyDX3UKkB2mP3m5kVgYZqOovIQIvKCwsLisrGaifM6iaLCkqqygmKRmrKCMrqygoKc24gCAJamgZqygLGSQvIAOvYa/eJCgoKKsoKS8gA69hr95KTSwoGajbGQMvl91assf7TSbiUGYd8YsX0FHWQuFQCUhaWlxETFoJSEpKTFldSEdKTCF3GasoOC8qfDQJLasoIRmrKC0ZIQIvKCwsLisoPzdBXV1ZWhMGBl4HaY/ebmRWIXcZNi8qfDQKLTEZP0VMCWBHSgcYDxkNLyp8LSI6NGhZplqoSe8yciAGu5vRbWHZSRG3PNwDr2Gv3iQoKCwsKRlLGCIZIC8qfC8qfDQnLT8tPQL5QG69XyDX3UKkLS86K3x6GDoZOC8qfC0jOiNoWVlOpiGdCd7ihQUJRlmfFigZpZ5q5mDxX7YaPUyIXr3gBCsqKCkoiqsonBOE3SYnKbsimAg/B138FSTySz/pShpe3hMuBX/C8yYIJ/OTWjBmnF5eB0hZWUVMB0pGRAZIWVlFTEpIJrQU2gJgATPh1+eckCfwdzX/4hRNHAo8YjxwNJq93t+1t+Z5k+hxeVtISl1ASkwJWl1IXUxETEddWgcZgopYu256fOiGBmia0dLKWeTPimWiMKD30GJF3C6CCxkrwTEX0Xkg+g3LwvieWfYmbMgO49hEUcTOnD4+4DBb3HQn/FZ2stsMKpN8pmR0JNgvGSYvKnw0Oigo1i0sGSooKNYZNDasqqwysBRuHtuAsmmnBf2YuTvxQE9ASkhdQEZHCWhcXUFGW0BdUBhsVzZlQnm/aKDtXUsiOaporhqjqD8ZPS8qfC0qOiRoWVlFTAl7RkZdGastkhmrKoqJKisoKysoKxkkLyAaH3MZSxgiGSAvKnwtLzorfHoYOntMRUBIR0pMCUZHCV1BQFoJSkxbS0VMCVpdSEdNSFtNCV1MW0RaCUgJSEdNCUpMW11AT0BKSF1ARkcJWXCOLCBVPml/ODdd+p6iChJuivxGvLdTJY1uonL9Px4a4u0mZOc9QPieMpS6aw07A+4mNJ9ktXdK4WKpPg8ZDS8qfC0iOjRoWVlFTAlqTFtdmBlxxXMtG6VBmqY090xa1k53TJUUD04JoxpD3iSr5vfCigbQekNyTVMZqyhfGScvKnw0Jigo1i0tKisoeYOj/PPN1fkgLh6ZXFwI");
        private static int[] order = new int[] { 39,17,41,4,7,58,47,54,9,58,15,48,43,44,51,47,32,37,51,44,34,50,40,33,35,31,54,55,37,30,41,50,55,33,57,36,40,57,46,40,55,53,44,53,49,48,50,53,55,58,50,58,55,55,58,59,59,58,59,59,60 };
        private static int key = 41;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
