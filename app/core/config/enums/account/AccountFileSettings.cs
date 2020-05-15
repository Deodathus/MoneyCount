using System;

namespace MoneyCount.app.core.config.enums.account
{
    public struct AccountFileSettings
    {
        public static readonly string FilePath = AppDomain.CurrentDomain.BaseDirectory + "storage/accounts.mc";
    }
}