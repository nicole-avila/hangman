# Hangman Game - Hängagubbe

## Beskrivning

Hangman är ett enkelt konsolbaserat ord-gissningsspel skrivet i C#. Användaren försöker gissa ett ord genom att föreslå bokstäver. Spelet finns en begränsad mängd gissningar innan det är över. All kod är skriven med engelska ord.

## Funktioner

- Gissa ordet med upp till 7 försök.
- Användaren kan lägga till nya ord (3-11 tecken, inga siffror).
- Informativa meddelanden om spelets status och felhantering.
- Stylat användargränssnitt med hjälp av [Spectre.Console](https://spectre.sh/) och [Figgle](https://github.com/pdevito/Figgle).

## Installation

För att installera och köra projektet:

1. Klona repot:
   git clone https://github.com/nicole-avila/hangman.git
   cd hangman

2. dotnet add package Spectre.Console
   dotnet add package Figgle
   dotnet add package Newtonsoft.Json
   dotnet add package FluentValidation

3. dotnet build

4. dontet run
