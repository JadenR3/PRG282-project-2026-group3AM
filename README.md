# Baobab Ridge Wildlife Rehabilitation Centre

## Team Members
- Member 1 – Snawo Nonkomo – 605092 – Core Setup & Add Feature
- Member 2 – Kealeboga Ramongae – 604861 – View Feature
- Member 3 – Keanon Tities – 603801 – Update, Delete and Search
- Member 4 – Nkosinathi Jaden Repinga – 604916 – Summary Report & Integration

## How to Build and Run
1. Clone this repository.
2. Open `BaobabRidge.sln` in Visual Studio 2022.
3. Build the solution (Ctrl + Shift + B).
4. Run (F5). The app opens with data loaded from `animals.txt`.

## Features
- Add a new animal
- View all animals
- Update an existing animal
- Delete an animal
- Generate summary report (summary.txt)

## File Formats
- **animals.txt**: 7 pipe-separated fields (ID|Name|Species|Age|Score|Status|Housing Unit). ID format is WR-####; the hashes being integer values
- **summary.txt**: Generated each time summary is run (overwritten each time). It contain the total number of animals, average age and recovery score rounded to 2 decimal points, as well as counters for each status. The generation date is formatted as 'yyyy-MM-dd HH:mm'

## Known Limitations
- Data stored in plain text only.
