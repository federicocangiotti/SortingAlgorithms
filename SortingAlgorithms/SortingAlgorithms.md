# Spiegazione degli algoritmi di ordinamento

## Selection sort

Questo algoritmo si basa nel suddividere l'array in due parti: una sequenza ordinata di valori (sezione destra) e una disordinata (sezione sinistra).

L'algoritmo termina quando l'array risulterà ordinato ovvero, quando la sequenza disordinata avrà un solo elemento dove quest'ultimo è l'elemento maggiore dell'array.

1. Trovare l’elemento minore all'interno della sequenza disordinata.
2. Scambiare l'elemento minore trovato con l'ultimo elemento della sequenza ordinata (solo se è stato effettivamente trovato un elemento minore).
3. Aggiornare la lunghezza delle due sequenze (incrementare di uno la sequenza ordinata e decrementare di uno la sequenza disordinata).
4. Ripetere i passaggi 1,2 finché non rimane un solo elemento nella sequenza disordinata.
   <br>
   <br>

---

## Bubble sort

Questo algoritmo utilizza un sistema di scambio basato nello scegliere una coppia di elementi. Se il primo elemento è più grande del secondo allora vengono scambiati, in modo tale da portare gli elementi più grandi in coda all'array mentre quelli più piccoli all'inizio.

In entrambi i casi (scambio effettuato o non effettuato), si prosegue con la stesso principio con gli elementi successivi fino alla fine dell'array. Successivamente si ripete l'intera l'operazione fino a quando si verifica almeno uno scambio.

Infatti, l'algoritmo termina quando si scorre l'intero array senza effettuare scambi.

1. Scambiare la coppia di elementi se il primo è maggiore del secondo.
2. Proseguire con lo stesso principio traslando la coppia di un elemento verso destra, proseguendo in questo modo fino ad arrivare in coda all'array.
3. Ripetere i passaggi 1,2 finché si verificano scambi.
