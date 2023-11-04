using System.Text;

namespace LogMeIn.Areas.Admin.Controllers;

public class ExcelConverter
{
    public static string ConvertToCsv(List<List<string>> data)
    {
        var csv = new StringBuilder();

        // Convert the data to CSV format
        foreach (var row in data)
        {
            for (var i = 0; i < row.Count; i++)
            {
                // Enclose values in double quotes to handle values with special characters
                csv.Append("\"" + row[i].Replace("\"", "\"\"") + "\"");

                // Add a comma separator, except for the last value in the row
                if (i < row.Count - 1) csv.Append(",");
            }

            // Add a newline to separate rows
            csv.AppendLine();
        }

        return csv.ToString();
    }
}