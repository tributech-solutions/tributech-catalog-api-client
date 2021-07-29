# Catalog-API .NET Core clients

## Usage

### Install

The clients for .NET Core are available as a NuGet package (requires net5.0 or higher):

| Package                                                                               | Release version                                                              |
| ------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------- |
| [Tributech.Dsk.CatalogApi.Client](https://www.nuget.org/packages/Tributech.Dsk.CatalogApi.Client) | ![Release version](https://img.shields.io/nuget/v/Tributech.Dsk.CatalogApi.Client) |

### Authentication / Authorization

You can use the included [APIAuthHandler](./APIAuthHandler.cs) as demonstrated in [the .NET Core Usage Example](../../examples/netcore).

```csharp
var authHandler = new APIAuthHandler(tokenUrl, scope, clientId, clientSecret);
```

You will need to provide the following parameters:
| Parameter | Value | Remark |
|-|-|-|
| tokenUrl | https://auth.your-hub.dataspace-hub.com/auth/realms/your-node/protocol/openid-connect/token | Url to retrieve the access token from the dataspace hub Identity Server |
| scope | profile / email / catalog-api / node-id | Defines the scope of what can be accessed |
| clientId | your-api-specific-client-id | Can be found in the Dataspace Admin (Profile -> Administration)
| clientSecret | your-api-specific-client-secret | Can be found in the Dataspace Admin (Profile -> Administration)
| baseUrl   | http://catalog-api.your-node.dataspace-node.com | Catalog Api Endpoint Url for the node you wish to integrate with |


This authHandler instance can then be used to create a HttpClient

```csharp
var authorizedHttpClient = new HttpClient(authHandler);
authorizedHttpClient.BaseAddress = new Uri(baseUrl);
```

### Interacting with the API

Create a CatalogApiClient using the authorizedHttpClient from the previous step.

```csharp
var apiClient = new CatalogApiClient(authorizedHttpClient);
```

Now you can access all methods of the respective Api.
