# Algoritmi di ordinamento semplici

I quattro algoritmi descritti in questo documento — **selection sort**, **bubble sort**, **insertion sort** e **shell sort** — appartengono alla famiglia degli ordinamenti a confronto elementare: operano in-place, non richiedono strutture dati ausiliarie significative e sono didatticamente rilevanti più che competitivi in produzione (con l'eccezione di insertion sort, usato come caso base in algoritmi ibridi moderni). Ogni sezione descrive il funzionamento, i passaggi operativi, la complessità e le implicazioni pratiche dell'algoritmo.

---

# Selection sort

## Funzionamento

Selection sort si basa sul suddividere l'array in due parti: una sequenza ordinata (sezione sinistra) e una disordinata (sezione destra). All'inizio la sequenza ordinata è vuota e quella disordinata coincide con l'intero array.

Ad ogni iterazione l'algoritmo seleziona il minimo della parte disordinata e lo sposta al confine tra le due sezioni, facendo crescere di un elemento la parte ordinata. L'algoritmo termina quando la sequenza disordinata si riduce a un solo elemento: per costruzione quest'ultimo è l'elemento maggiore dell'array e si trova già nella sua posizione definitiva.

### Passaggi

1. Trovare l'elemento minore all'interno della sequenza disordinata.
2. Scambiarlo con il primo elemento della sequenza disordinata, cioè con la posizione immediatamente successiva alla sequenza ordinata (lo scambio si esegue solo se il minimo non occupa già tale posizione).
3. Aggiornare la lunghezza delle due sequenze: incrementare di uno la sequenza ordinata e decrementare di uno quella disordinata.
4. Ripetere i passaggi 1–2 finché nella sequenza disordinata non rimane un solo elemento.

## Complessità

- **Temporale**: O(n²) in tutti i casi (migliore, medio, peggiore). Il numero di confronti è sempre n(n−1)/2, indipendentemente dall'ordine iniziale.
- **Spaziale**: O(1), in-place, senza strutture dati ausiliarie.

## Implicazioni

- **Non adattivo**: un array già ordinato costa quanto uno disordinato, perché la ricerca del minimo scandisce comunque tutta la parte disordinata.
- **Non stabile**: lo scambio a distanza può invertire l'ordine relativo di due elementi uguali.
- **Minimizza le scritture**: al massimo n−1 scambi. È il vantaggio distintivo rispetto a insertion sort e bubble sort, utile quando le scritture in memoria sono costose (es. EEPROM/flash).
- In pratica è più lento di insertion sort su dati casuali; il suo valore è soprattutto didattico, per lo schema semplice e il comportamento prevedibile.

---

# Bubble sort

## Funzionamento

Bubble sort confronta coppie di elementi adiacenti e le scambia se il primo è maggiore del secondo, portando gradualmente gli elementi grandi verso la coda dell'array e quelli piccoli verso l'inizio.

L'effetto cumulativo di un passaggio completo è che l'elemento maggiore della parte non ancora ordinata raggiunge la sua posizione definitiva in coda: come in selection sort, la parte ordinata cresce di un elemento a ogni passaggio, ma qui è costruita tramite molti scambi adiacenti invece che tramite la ricerca del minimo.

L'algoritmo termina quando un passaggio completo non produce scambi: se nessuna coppia è fuori ordine, ogni elemento è minore o uguale al proprio successore e l'array è ordinato.

### Passaggi

1. Confrontare una coppia di elementi adiacenti e scambiarla se il primo è maggiore del secondo.
2. Traslare la coppia di una posizione verso destra e ripetere fino in coda all'array. La scansione può accorciarsi: dopo k passaggi le ultime k posizioni sono già definitive e non serve riscansionarle.
3. Ripetere i passaggi 1–2 finché un passaggio completo non produce alcuno scambio.

## Complessità

- **Temporale**: O(n²) nel caso medio e peggiore (n(n−1)/2 confronti); O(n) nel caso migliore (array già ordinato), grazie al controllo sull'assenza di scambi.
- **Spaziale**: O(1), in-place.

## Implicazioni

- **Stabile**: due elementi uguali non vengono mai scambiati tra loro, quindi mantengono l'ordine relativo.
- **Adattivo**: su array già ordinati o quasi ordinati converge rapidamente, con uno o pochi passaggi.
- Soffre del problema delle "tartarughe": gli elementi grandi (i "conigli") raggiungono la coda in un solo passaggio, mentre gli elementi piccoli vicini alla coda avanzano di una sola posizione per passaggio. Il cocktail shaker sort, che alterna scansioni in entrambe le direzioni, nasce per mitigare questo limite.
- In pratica è il meno efficiente dei tre algoritmi semplici; il suo valore è prevalentemente didattico.

---

# Insertion sort

## Funzionamento

Insertion sort suddivide l'array in una sequenza ordinata (sinistra) e una disordinata (destra), come selection sort. La differenza sta nel criterio di crescita: mentre selection sort preleva il minimo dalla parte disordinata, insertion sort preleva il primo elemento della parte disordinata e lo inserisce nella posizione corretta all'interno della sequenza ordinata, facendo spazio tramite spostamenti.

È il metodo con cui si ordinano le carte in mano: si prende una carta alla volta e la si inserisce nella posizione giusta rispetto a quelle già in mano.

Ad ogni iterazione la sequenza ordinata cresce di un elemento e resta ordinata; l'algoritmo termina quando la sequenza disordinata è vuota. A differenza di selection sort e bubble sort, non è garantito che ogni elemento sistemato occupi la sua posizione definitiva: l'inserimento di un elemento piccolo può richiedere lo spostamento di tutti quelli già disposti.

### Passaggi

1. Prelevare il primo elemento della sequenza disordinata (la chiave).
2. Scorrere la sequenza ordinata da destra verso sinistra, spostando di una posizione a destra ogni elemento maggiore della chiave.
3. Inserire la chiave nella posizione liberata.
4. Ripetere i passaggi 1–3 finché la sequenza disordinata non è vuota.

## Complessità

- **Temporale**: O(n²) nel caso peggiore (array ordinato in senso inverso: ~n²/2 confronti e spostamenti) e nel caso medio (~n²/4); O(n) nel caso migliore (array già ordinato: un confronto per elemento, nessuno spostamento).
- **Spaziale**: O(1), in-place.

## Implicazioni

- **Stabile**: la chiave viene inserita dopo gli elementi a essa uguali, preservandone l'ordine relativo.
- **Fortemente adattivo**: il costo è proporzionale al numero di inversioni (coppie di elementi in ordine sbagliato) presenti nell'array, quindi su input quasi ordinati si avvicina a O(n).
- **Online**: può ordinare un flusso di dati man mano che arriva, senza conoscere in anticipo la dimensione dell'array.
- È il più veloce dei tre algoritmi semplici su array piccoli (poche decine di elementi); per questo è usato come caso base negli algoritmi ibridi: Timsort (Python, Java) e introsort (`std::sort` del C++) passano a insertion sort sulle sequenze o partizioni piccole.

---

# Shell sort

## Funzionamento

Shell sort, proposto da Donald Shell nel 1959, generalizza insertion sort correggendone il limite principale: insertion sort sposta gli elementi di una sola posizione alla volta, quindi un elemento piccolo situato in coda richiede fino a n−1 spostamenti per raggiungere la testa dell'array.

L'idea è eseguire più passaggi di insertion sort "a distanza": invece di confrontare elementi adiacenti, si confrontano elementi separati da un gap g, ordinando le sottosequenze a[i], a[i+g], a[i+2g], … (un insertion sort su ciascuna sottosequenza). Un passaggio con gap grande sposta gli elementi a lunga distanza a costo contenuto, lasciando l'array quasi ordinato. Il gap viene progressivamente ridotto e l'ultimo passaggio, con gap = 1, è un insertion sort ordinario eseguito però su un array quasi ordinato, cioè nel suo caso favorevole.

### Passaggi

1. Scegliere una sequenza di gap decrescente che termini con 1 (es. n/2, n/4, …, 1, oppure la sequenza di Ciura 701, 301, 132, 57, 23, 10, 4, 1).
2. Eseguire un insertion sort con passo g su ciascuna sottosequenza di elementi distanti g posizioni.
3. Ridurre il gap e ripetere il passaggio 2.
4. Terminare con il passaggio a gap = 1 (insertion sort standard), che rifinisce l'ordinamento.

## Complessità

- **Temporale**: dipende dalla sequenza di gap scelta.
  - Sequenza originale di Shell (n/2, n/4, …, 1): caso peggiore O(n²).
  - Sequenza di Knuth (1, 4, 13, 40, …, 3h+1): O(n^(3/2)).
  - Sequenze di Sedgewick: O(n^(4/3)).
  - Sequenza di Pratt: O(n log² n), il miglior limite noto per il caso peggiore.
  - Non esiste una formula chiusa per il caso medio.
- **Spaziale**: O(1), in-place.

## Implicazioni

- **Non stabile**: un passaggio con gap può spostare un elemento oltre elementi ad esso uguali.
- La scelta della sequenza di gap è determinante per le prestazioni; la sequenza di Ciura (1, 4, 10, 23, 57, 132, 301, 701), determinata empiricamente, è tra le migliori in pratica.
- Risolve il problema delle "tartarughe" di bubble sort: gli elementi piccoli attraversano l'array in pochi passaggi grazie ai gap ampi.
- Su array di medie dimensioni è di gran lunga più veloce dei tre algoritmi semplici e resta usato in contesti con risorse limitate (es. sistemi embedded) per la semplicità e il basso overhead.

---

## Confronto sintetico

| Algoritmo      | Caso migliore | Caso medio      | Caso peggiore         | Spazio | Stabile | Adattivo        |
| -------------- | ------------- | --------------- | --------------------- | ------ | ------- | --------------- |
| Selection sort | O(n²)         | O(n²)           | O(n²)                 | O(1)   | No      | No              |
| Bubble sort    | O(n)          | O(n²)           | O(n²)                 | O(1)   | Sì      | Sì              |
| Insertion sort | O(n)          | O(n²)           | O(n²)                 | O(1)   | Sì      | Sì (fortemente) |
| Shell sort     | O(n log n)*   | dipende dal gap | O(n²) → O(n log² n)** | O(1)   | No      | Parzialmente    |

\* Con sequenze di gap ottimizzate e input favorevole.
\** Il limite inferiore O(n log² n) si ottiene solo con la sequenza di Pratt; le sequenze più usate in pratica (es. Ciura) hanno un caso peggiore peggiore ma prestazioni medie migliori.
