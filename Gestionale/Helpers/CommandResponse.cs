namespace Gestionale.Helpers
{
    public class CommandResponse
    {
        // Proprietà che gestiscono il feedback
        public bool Success { get; init; }
        public string Message { get; init; }
        public string ReturnUrl { get; init; }
        public bool Warning { get; init; }

        // Costruttore privato per forzare l'uso dei metodi factory
        private CommandResponse() { }

        // Factory method statico per una risposta positiva (OK)
        // Perché: consente di creare un'istanza di CommandResponse in modo chiaro e immutabile.
        public static CommandResponse Ok(string? message = null, string? returnUrl = null)
        {
            return new CommandResponse
            {
                Success = true,
                Warning = false,
                Message = message,
                ReturnUrl = returnUrl
            };
        }

        // Factory method statico per una risposta di errore
        // Perché: semplifica la creazione di un feedback di errore, evidenziando che c'è un warning.
        public static CommandResponse Error(string? message = null, string? returnUrl = null)
        {
            return new CommandResponse
            {
                Success = false,
                Warning = true,
                Message = message,
                ReturnUrl = returnUrl
            };
        }

        // Opzionale: Factory method statico per una risposta che ha successo ma presenta un warning
        // Perché: in alcune situazioni potresti voler restituire un successo pur evidenziando un avvertimento.
        public static CommandResponse WarningResponse(string? message = null, string? returnUrl = null)
        {
            return new CommandResponse
            {
                Success = true,
                Warning = true,
                Message = message,
                ReturnUrl = returnUrl
            };
        }

        // Implicit conversion a bool per permettere un controllo diretto sulla proprietà Success.
        // Perché: consente di utilizzare l'istanza di CommandResponse direttamente in un contesto condizionale.
        public static implicit operator bool(CommandResponse response) => response.Success;

        // Override di ToString per facilitare il debugging e la visualizzazione dei messaggi di feedback.
        // Perché: restituisce una stringa riassuntiva delle proprietà principali della risposta.
        public override string ToString()
        {
            return $"Success: {Success}, Warning: {Warning}, Message: {Message}, ReturnUrl: {ReturnUrl}";
        }
    }
}