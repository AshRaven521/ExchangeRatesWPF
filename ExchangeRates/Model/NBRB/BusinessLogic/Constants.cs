namespace ExchangeRates.Model.NBRB.BusinessLogic
{
    public static class Constants
    {
        public static string NBRB_ALL_CURRENCIES_REFERENCE { get; } = "https://api.nbrb.by/exrates/currencies";
        // Параметр periodicity = 0 означает, что получаем курс на сегодня
        public static string NBRB_TODAY_RATES_REFERENCE { get; } = "https://api.nbrb.by/exrates/rates?periodicity=0";

    }
}
