// See https://aka.ms/new-console-template for more information
using Microsoft.Data.SqlClient;

const string ConnectionString = "**CONNECTION STRING**";
const string Command = "select getdate()";

var t1 = Task.Run(Query);

var t2 = Task.Run(Query);

try
{
    await Task.WhenAll(t1, t2);
    Console.WriteLine("Great Success!");
}
catch (Exception e)
{
    Console.WriteLine(e.ToString());
}

static DateTime Query()
{
    using var c = new SqlConnection(ConnectionString);
    c.Open();
    using var cmd = new SqlCommand(Command, c);
    return (DateTime)cmd.ExecuteScalar();
}

static async Task<DateTime> QueryAsync()
{
    using var c = new SqlConnection(ConnectionString);
    await c.OpenAsync();
    using var cmd = new SqlCommand(Command, c);
    return (DateTime)await cmd.ExecuteScalarAsync();
}