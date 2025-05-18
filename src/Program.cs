var taxList = InitialTaxData.GetDefaultTaxRecords();
var handler = new TaxHandler(taxList);

/* Assumption: Console app will run until user quits manually.
   Data is kept in memory during runtime only. */

while (true)
{
    Console.Write(
        @"Welcome to the Tax Manager!
Choose your action:
1 - Add a new Tax Record
2 - Retrieve a Tax Record
q - Quit
(1 / 2 / q): ");

    var action = Console.ReadLine()?.Trim().ToLower();

    if (action == "q")
    {
        Console.WriteLine("Bye!");
        break;
    }
    else if (action == "1")
    {
        handler.AddTaxRecord();
    }
    else if (action == "2")
    {
        handler.RetrieveTaxRecord();
    }
    else
    {
        Console.WriteLine("Invalid option, please enter '1', '2', or 'q'.\n");
    }
}
