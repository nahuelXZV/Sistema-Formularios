namespace Domain.Constants;

public static class Constantes
{
    public static class HttpClientNames
    {
        public const string ApiRest = "ApiRest";
    }
    public static class CorsPolicies
    {
        public const string ClienteWeb = "ClienteWeb";
        public const string AllowOrigin = "AllowOrigin";
    }

    public static class TiposConceptos
    {
        public const int TipoPregunta = 1;
    }

}

public enum TipoPregunta : short
{
    Texto = 1,
    TextoLargo = 2,
    OpcionMultiple = 3,
    OpcionUnica = 4,
    Fecha = 5,
    Hora = 6,
    Numerico = 7,
    Booleano = 8
}