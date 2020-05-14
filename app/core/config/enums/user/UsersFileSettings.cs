using System;

namespace MoneyCount.app.core.config.enums.user
{
    public struct UsersFileSettings
    {
        public static readonly string FilePath = AppDomain.CurrentDomain.BaseDirectory + "storage/users.xml";
    }
}