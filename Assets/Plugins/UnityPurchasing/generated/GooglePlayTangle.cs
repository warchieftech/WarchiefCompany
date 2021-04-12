#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("BYD2orH8Br4iwG1EUeDw2HpO/gswJSYEH+Zz/1GWD/hW+Pe8AXFowvNwfnFB83B7c/NwcHHWgSckf0HwkoTLbA/plQJ0Wlmzta63EhxkkK31vtRUlXjWXLGNwob5o1fC9jQXcT0su+6xpEWTIyodAXvA58Ps+WhxjOHaeOvlpQqwo5MR8v1fQ26GchrPzUY66JkWstvuHsKkny5lYdoAbUHzcFNBfHd4W/c594Z8cHBwdHFylRqHhpb41rBD7Rxc/Df4oTco8UDHZMpba5iUd9ZhSXN/kjLK+bHMizVOnCn7aGSmkEzfbxbsXybK2IIuQPPBZ51i8elI6hSvuIBDxJ09Bp7EfFnbsYgAXpiKBnthLQ6FzdMoib7E/wX8J4X+hnNycHFw");
        private static int[] order = new int[] { 3,12,12,9,4,10,11,13,9,10,10,13,12,13,14 };
        private static int key = 113;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
