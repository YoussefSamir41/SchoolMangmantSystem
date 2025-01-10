namespace Data.AppMetaData
{
    public static class Router
    {
        public const string root = "Api";
        public const string version = "V1";
        public const string Rule = root + "/" + version + "/";

        public static class StudentRouting
        {
            public const string Prefix = Rule + "Student/";
            public const string List = Prefix + "List";
            public const string GetById = Prefix + "{id}";
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete";
            public const string Paginated = Prefix + "Paginate";
        }

        public static class DepartmentRouting
        {
            public const string Prefix = Rule + "Department/";
            public const string List = Prefix + "List";
            public const string GetById = Prefix + "{id}";
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete";
            public const string Paginated = Prefix + "Paginate";
            public const string GetDepartmentStudentsCount = Prefix + "GetDepartmentStudentsCount";
            public const string GetDepartmentStudentsCountById = Prefix + "GetDepartmentStudentsCountById";
        }

        public static class UserRouting
        {
            public const string Prefix = Rule + "UserRouting/";
            public const string Create = Prefix + "Create";
            public const string Paginated = Prefix + "Paginate";
            public const string GetById = Prefix + "{id}";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete";
            public const string ChangePassword = Prefix + "ChangePassword";


        }

        public static class Authentication
        {
            private const string Prefix = Rule + "Authentication/";
            public const string SignIn = Prefix + "SignIn";
            public const string RefreshToken = Prefix + "RefreshToken";
            public const string ValidateToken = Prefix + "ValidateToken";
            public const string ConfirmEmail = Prefix + "ConfirmEmail";
            public const string ResetPassword = Prefix + "ResetPassword";
            public const string SendResetPassword = Prefix + "SendResetPassword";
        }

        public static class AuthorizationRouting
        {
            private const string Prefix = Rule + "Authorization/";
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete";
            public const string RoleList = Prefix + "RoleList";
            public const string GetRoleById = Prefix + "GetRoleById";
            public const string ManageUserRoles = Prefix + "ManageUserRoles";

        }

        public static class EmailsRoute
        {
            private const string Prefix = Rule + "EmailSending/";
            public const string SendEmail = Rule + "SendEmail/";


        }

    }
}
