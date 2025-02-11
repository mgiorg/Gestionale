# 🏭 Gestionale

Un'applicazione web ASP.NET Core MVC per la gestione di magazzini, prodotti e trasporti.

## 🛠 Tecnologie Utilizzate

- **Framework**: ASP.NET Core 8.0
- **Database**: SQLite
- **ORM**: Entity Framework Core 9.0.1
- **Frontend**: Bootstrap, jQuery
- **Pattern**: MVC, Repository Pattern, Service Layer

## 📦 Funzionalità Principali

### Gestione Magazzini (Storage)
- Visualizzazione lista magazzini
- Aggiunta nuovo magazzino
- Modifica dati magazzino
- Eliminazione magazzino
- Tracking stato attività

### Gestione Prodotti (Products)
- Catalogo prodotti
- Inserimento nuovo prodotto
- Modifica dettagli prodotto
- Rimozione prodotto
- Tracking di prezzi e descrizioni

### Gestione Trasporti (Transport)
- Registro trasporti
- Creazione nuova spedizione
- Modifica dettagli spedizione
- Cancellazione spedizione
- Associazione con prodotti e magazzini

## 🏗 Struttura del Progetto

```
Gestionale/
├── Controllers/         # Controller MVC per la gestione delle richieste
├── Models/             # ViewModel e modelli di presentazione
│   ├── Product/        # ViewModel specifici per i prodotti
│   ├── Storage/        # ViewModel specifici per i magazzini
│   └── Transport/      # ViewModel specifici per i trasporti
├── Views/              # Viste Razor
├── Services/           # Servizi di business logic
├── Repository/         # Layer di accesso ai dati
├── Database/           # Configurazione e contesto del database
├── DomainModel/        # Modelli di dominio
└── Helpers/            # Classi di utilità
```

## 🚀 Setup Locale

1. **Prerequisiti**
   - .NET 8.0 SDK
   - Visual Studio Code o Visual Studio 2022
   - SQLite

2. **Installazione**
   ```bash
   git clone <repository-url>
   cd Gestionale
   dotnet restore
   ```

3. **Configurazione Database**
   - Il database SQLite viene creato automaticamente
   - Stringa di connessione in `GestionaleDatabase.cs`:
   ```csharp
   "Data Source=database.db"
   ```

4. **Avvio Applicazione**
   ```bash
   dotnet run
   ```
   Naviga su `https://localhost:5001`

## 💾 Struttura Database

### Entità Principali
- **Storage**: Magazzini con tracking dello stato
- **Product**: Catalogo prodotti con dettagli
- **Transport**: Gestione spedizioni e collegamenti

### Relazioni
- Transport → Product (Many-to-One)
- Transport → Storage (Many-to-One)

## 🔧 Architettura

### Pattern Utilizzati
- **Repository Pattern**: Separazione logica accesso dati
- **Service Layer**: Business logic centralizzata
- **MVC**: Separazione delle responsabilità
- **Command Pattern**: Gestione risposte operazioni (CommandResponse)

### Caratteristiche Implementative
- Dependency Injection
- Entity Framework Core con SQLite
- CRUD operations asincrone
- Validazione dati client/server

## 🎨 Frontend

- **Layout Responsive**: Bootstrap 5
- **Interazioni AJAX**: jQuery
- **Modal Dialogs**: Conferme operazioni
- **Form Validation**: Client-side e server-side
- **Feedback Utente**: Messaggi di stato operazioni

## 📝 Note di Sviluppo

### Best Practices Implementate
- Separazione delle responsabilità (SRP)
- Dependency Injection
- Repository Pattern
- Validazione input
- Gestione errori centralizzata

### Sicurezza
- HTTPS forzato
- Validazione input
- Protezione CSRF
- Sanitizzazione dati

## 🔄 Workflow Tipico

1. **Gestione Magazzini**
   - Creazione/modifica magazzini
   - Tracking stato attività

2. **Gestione Prodotti**
   - Inserimento prodotti
   - Aggiornamento catalogo

3. **Gestione Trasporti**
   - Creazione spedizioni
   - Collegamento con prodotti e magazzini

## 🎯 Roadmap Futura

- [ ] Implementazione autenticazione utenti
- [ ] Dashboard analytics
- [ ] API RESTful
- [ ] Report generazione PDF
- [ ] Integrazione notifiche email

---
© 2025 Gestionale - Sviluppato per uso personale 