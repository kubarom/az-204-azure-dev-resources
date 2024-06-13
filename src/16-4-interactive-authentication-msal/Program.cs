using System.Threading.Tasks;
using Microsoft.Identity.Client;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//https://portal.azure.com/#view/Microsoft_AAD_IAM/ActiveDirectoryMenuBlade/~/RegisteredApps
const string _clientId = ""; //Registered application Id
const string _tenantId = ""; // App's Tenant id

var app = PublicClientApplicationBuilder
    .Create(_clientId)
    .WithAuthority(AzureCloudInstance.AzurePublic, _tenantId)
    .WithRedirectUri("http://localhost")
    .Build();
        
string[] scopes = { "user.read" };

AuthenticationResult result = await app.AcquireTokenInteractive(scopes).ExecuteAsync();

Console.WriteLine($"Token:\t{result.AccessToken}");