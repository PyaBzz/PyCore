namespace Baz.Core
{
    public enum Injection { Singleton, Transient };

    public static class AuthConstants
    {
        public const string SchemeName = "Cookies";

        public const string Level0PolicyName = "Level0AndBelow";
        public const string Level1PolicyName = "Level1AndBelow";
        public const string Level2PolicyName = "Level2AndBelow";
        public const string Level3PolicyName = "Level3AndBelow";

        public const string AdminRoleName = "Admin";
        public const string JuniorRoleName = "Junior";
        public const string SeniorRoleName = "Senior";

        public static string[] All => new string[] { AdminRoleName, JuniorRoleName, SeniorRoleName };
    }
}
