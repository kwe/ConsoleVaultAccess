using System.Diagnostics;
using VaultSharp;
using VaultSharp.V1.AuthMethods.Token;

Console.WriteLine("Grabbing secrets from a local Vault");

var authMethod = new TokenAuthMethodInfo("hvs.GRZsikqGp1S22sifFG1MbShs"); // don't do this, grab it from environment or something!
var vaultClientSettings = new VaultClientSettings("http://localhost:8200",authMethod);
var vaultClient = new VaultClient(vaultClientSettings);

var s = Stopwatch.StartNew();
try
{
    var secret = await vaultClient.V1.Secrets.KeyValue.V2.ReadSecretAsync(path: "mobilesdk", mountPoint: "secret");
    
    Console.WriteLine(secret.Data.Data["apikey"]);
    Console.WriteLine("Done");
}
finally
{
    s.Stop();
    Console.WriteLine("Took {0}ms", s.ElapsedMilliseconds);

}

