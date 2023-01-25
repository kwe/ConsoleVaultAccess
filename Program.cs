using VaultSharp;
using VaultSharp.V1.AuthMethods.Token;

Console.WriteLine("Grabbing secrets from a local Vault");

var authMethod = new TokenAuthMethodInfo("aVaultToken"); // don't do this, grab it from environment or something!
var vaultClientSettings = new VaultClientSettings("http://localhost:8200",authMethod);
var vaultClient = new VaultClient(vaultClientSettings);

var secret = await vaultClient.V1.Secrets.KeyValue.V2.ReadSecretAsync(path:"mobilesdk", mountPoint:"secret");

Console.WriteLine(secret.Data.Data["apikey"]);
Console.WriteLine("Done");


