namespace Alias.Application.Permissions
{
    public static class Permission
    {
        public static class Games
        {
            public const string Create = "Perm.Games.Create";
            public const string View = "Perm.Games.View";
            public const string Edit = "Perm.Games.Edit";
            public const string Delete = "Perm.Games.Delete";
        }

        public static class Users
        {
            public const string View = "Perm.Users.View";
            public const string Create = "Perm.Users.Create";
            public const string Edit = "Perm.Users.Edit";
            public const string Delete = "Perm.Users.Delete";
        }

        public static class Roles
        {
            public const string View = "Perm.Roles.View";
            public const string Create = "Perm.Roles.Create";
            public const string Edit = "Perm.Roles.Edit";
            public const string Delete = "Perm.Roles.Delete";
        }
    }
}
