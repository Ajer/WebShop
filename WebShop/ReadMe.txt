
Detta program ansluter till C's Redis-databas genom att ansluta från mitt YNWA till C's YNWA.(YNWA->YNWA)
Jag måste alltså använda mitt YNWA-nätverk hemma (inte Andy) för att kunna köra programmet.
Annars får man connection-timeout p.g.a rad 42 i Program.cs.

Kommentera ut redis-anslutningarna för att köra sessions med den gamla InmemoryCache istället.