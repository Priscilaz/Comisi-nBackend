namespace FastCommissionBack.Services
{
    public class CommissionStrategyFactory
    {
        /// Crea la estrategia de comisión especificada
        public static IComisionStrategy Create(StrategyType type)
        {
            return type switch
            {
                StrategyType.ExactMatch => new ExactMatchStrategy(),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Estrategia de comisión no soportada")
            };
        }
    }
}
