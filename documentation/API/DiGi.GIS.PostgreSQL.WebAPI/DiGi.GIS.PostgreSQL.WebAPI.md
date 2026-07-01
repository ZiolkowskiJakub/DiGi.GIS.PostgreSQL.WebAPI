#### [DiGi\.GIS\.PostgreSQL\.WebAPI](index.md 'index')

## DiGi\.GIS\.PostgreSQL\.WebAPI Namespace
### Classes

<a name='DiGi.GIS.PostgreSQL.WebAPI.Create'></a>

## Create Class

```csharp
public static class Create
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Create
### Methods

<a name='DiGi.GIS.PostgreSQL.WebAPI.Create.GISPostgreSQLWebAPIConfigurationFileWatcher()'></a>

## Create\.GISPostgreSQLWebAPIConfigurationFileWatcher\(\) Method

Creates a new instance of the GISPostgreSQLWebAPIConfigurationFileWatcher class\.

```csharp
public static DiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIConfigurationFileWatcher GISPostgreSQLWebAPIConfigurationFileWatcher();
```

#### Returns
[GISPostgreSQLWebAPIConfigurationFileWatcher](DiGi.GIS.PostgreSQL.WebAPI.Classes.md#DiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIConfigurationFileWatcher 'DiGi\.GIS\.PostgreSQL\.WebAPI\.Classes\.GISPostgreSQLWebAPIConfigurationFileWatcher')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Create.GISPostgreSQLWebAPIManager()'></a>

## Create\.GISPostgreSQLWebAPIManager\(\) Method

Creates a new instance of the GISPostgreSQLWebAPIManager class\.

```csharp
public static DiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager? GISPostgreSQLWebAPIManager();
```

#### Returns
[GISPostgreSQLWebAPIManager](DiGi.GIS.PostgreSQL.WebAPI.Classes.md#DiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager 'DiGi\.GIS\.PostgreSQL\.WebAPI\.Classes\.GISPostgreSQLWebAPIManager')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Create.HttpClient_Geoportal(DiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager)'></a>

## Create\.HttpClient\_Geoportal\(GISPostgreSQLWebAPIManager\) Method

Creates and configures an [System\.Net\.Http\.HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient 'System\.Net\.Http\.HttpClient') instance for the Geoportal service, including a custom User\-Agent header based on the executing assembly's name and version\.

```csharp
public static System.Net.Http.HttpClient? HttpClient_Geoportal(DiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager gISPostgreSQLWebAPIManager);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.WebAPI.Create.HttpClient_Geoportal(DiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager).gISPostgreSQLWebAPIManager'></a>

`gISPostgreSQLWebAPIManager` [GISPostgreSQLWebAPIManager](DiGi.GIS.PostgreSQL.WebAPI.Classes.md#DiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager 'DiGi\.GIS\.PostgreSQL\.WebAPI\.Classes\.GISPostgreSQLWebAPIManager')

The manager used to create the HTTP client instance\.

#### Returns
[System\.Net\.Http\.HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient 'System\.Net\.Http\.HttpClient')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Create.HttpContent(thisbyte[],System.Threading.CancellationToken)'></a>

## Create\.HttpContent\(this byte\[\], CancellationToken\) Method

Asynchronously creates GZip\-compressed HttpContent from the provided byte array\.

```csharp
public static System.Threading.Tasks.Task<System.Net.Http.HttpContent?> HttpContent(this byte[] bytes, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.WebAPI.Create.HttpContent(thisbyte[],System.Threading.CancellationToken).bytes'></a>

`bytes` [System\.Byte](https://learn.microsoft.com/en-us/dotnet/api/system.byte 'System\.Byte')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The raw byte array to be compressed\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Create.HttpContent(thisbyte[],System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to monitor for cancellation requests\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Net\.Http\.HttpContent](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpcontent 'System\.Net\.Http\.HttpContent')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Create.HttpContent(thisstring,System.Threading.CancellationToken)'></a>

## Create\.HttpContent\(this string, CancellationToken\) Method

Converts a JSON string into an asynchronous [System\.Net\.Http\.HttpContent](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpcontent 'System\.Net\.Http\.HttpContent') object\.

```csharp
public static System.Threading.Tasks.Task<System.Net.Http.HttpContent?> HttpContent(this string json, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.WebAPI.Create.HttpContent(thisstring,System.Threading.CancellationToken).json'></a>

`json` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The JSON string to be converted\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Create.HttpContent(thisstring,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellationToken\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Net\.Http\.HttpContent](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpcontent 'System\.Net\.Http\.HttpContent')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Create.HttpContent_TSerializableObject_(thisSystem.Collections.Generic.IEnumerable_TSerializableObject_,System.Threading.CancellationToken)'></a>

## Create\.HttpContent\<TSerializableObject\>\(this IEnumerable\<TSerializableObject\>, CancellationToken\) Method

Converts a collection of serializable objects into an [System\.Net\.Http\.HttpContent](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpcontent 'System\.Net\.Http\.HttpContent') object by first serializing them to a JSON string\.

```csharp
public static System.Threading.Tasks.Task<System.Net.Http.HttpContent?> HttpContent<TSerializableObject>(this System.Collections.Generic.IEnumerable<TSerializableObject> serializableObjects, System.Threading.CancellationToken cancellationToken)
    where TSerializableObject : DiGi.Core.Interfaces.ISerializableObject;
```
#### Type parameters

<a name='DiGi.GIS.PostgreSQL.WebAPI.Create.HttpContent_TSerializableObject_(thisSystem.Collections.Generic.IEnumerable_TSerializableObject_,System.Threading.CancellationToken).TSerializableObject'></a>

`TSerializableObject`

The type of the objects in the collection, which must implement [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')\.
#### Parameters

<a name='DiGi.GIS.PostgreSQL.WebAPI.Create.HttpContent_TSerializableObject_(thisSystem.Collections.Generic.IEnumerable_TSerializableObject_,System.Threading.CancellationToken).serializableObjects'></a>

`serializableObjects` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[TSerializableObject](DiGi.GIS.PostgreSQL.WebAPI.md#DiGi.GIS.PostgreSQL.WebAPI.Create.HttpContent_TSerializableObject_(thisSystem.Collections.Generic.IEnumerable_TSerializableObject_,System.Threading.CancellationToken).TSerializableObject 'DiGi\.GIS\.PostgreSQL\.WebAPI\.Create\.HttpContent\<TSerializableObject\>\(this System\.Collections\.Generic\.IEnumerable\<TSerializableObject\>, System\.Threading\.CancellationToken\)\.TSerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of objects to be serialized and converted to HTTP content\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Create.HttpContent_TSerializableObject_(thisSystem.Collections.Generic.IEnumerable_TSerializableObject_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to cancel the asynchronous operation\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Net\.Http\.HttpContent](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpcontent 'System\.Net\.Http\.HttpContent')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Create.ServiceProvider()'></a>

## Create\.ServiceProvider\(\) Method

Creates and configures a service provider with the registered services\.

```csharp
public static System.IServiceProvider ServiceProvider();
```

#### Returns
[System\.IServiceProvider](https://learn.microsoft.com/en-us/dotnet/api/system.iserviceprovider 'System\.IServiceProvider')  
An [System\.IServiceProvider](https://learn.microsoft.com/en-us/dotnet/api/system.iserviceprovider 'System\.IServiceProvider') containing the registered services\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify'></a>

## Modify Class

```csharp
public static class Modify
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Modify
### Methods

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.InitializeAsync(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection)'></a>

## Modify\.InitializeAsync\(this IServiceCollection\) Method

Initializes the GIS PostgreSQL Web API services, including the configuration file watcher and converter manager\.

```csharp
public static System.Threading.Tasks.Task InitializeAsync(this Microsoft.Extensions.DependencyInjection.IServiceCollection serviceCollection);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.InitializeAsync(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection).serviceCollection'></a>

`serviceCollection` [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')

The [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection') to add services to\.

#### Returns
[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')  
A [System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task') representing the asynchronous operation\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,DiGi.GIS.Classes.AdministrativeAreal2D,DiGi.WebAPI.Classes.PostOptions)'></a>

## Modify\.UpdateItemsAsync\(this GISPostgreSQLWebAPIManager, AdministrativeAreal2D, PostOptions\) Method

Updates a single administrative area item asynchronously\.

```csharp
public static System.Threading.Tasks.Task<bool> UpdateItemsAsync(this DiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager? gISPostgreSQLWebAPIManager, DiGi.GIS.Classes.AdministrativeAreal2D? administrativeAreal2D, DiGi.WebAPI.Classes.PostOptions? postOptions=null);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,DiGi.GIS.Classes.AdministrativeAreal2D,DiGi.WebAPI.Classes.PostOptions).gISPostgreSQLWebAPIManager'></a>

`gISPostgreSQLWebAPIManager` [GISPostgreSQLWebAPIManager](DiGi.GIS.PostgreSQL.WebAPI.Classes.md#DiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager 'DiGi\.GIS\.PostgreSQL\.WebAPI\.Classes\.GISPostgreSQLWebAPIManager')

The GIS PostgreSQL Web API manager instance\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,DiGi.GIS.Classes.AdministrativeAreal2D,DiGi.WebAPI.Classes.PostOptions).administrativeAreal2D'></a>

`administrativeAreal2D` [DiGi\.GIS\.Classes\.AdministrativeAreal2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.administrativeareal2d 'DiGi\.GIS\.Classes\.AdministrativeAreal2D')

The administrative area item to be updated\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,DiGi.GIS.Classes.AdministrativeAreal2D,DiGi.WebAPI.Classes.PostOptions).postOptions'></a>

`postOptions` [DiGi\.WebAPI\.Classes\.PostOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.postoptions 'DiGi\.WebAPI\.Classes\.PostOptions')

Optional configuration options for the HTTP POST request\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,DiGi.GIS.Classes.Building2D,string,DiGi.WebAPI.Classes.PostOptions)'></a>

## Modify\.UpdateItemsAsync\(this GISPostgreSQLWebAPIManager, Building2D, string, PostOptions\) Method

Asynchronously updates building items in the PostgreSQL GIS database via the web API\.

```csharp
public static System.Threading.Tasks.Task<bool> UpdateItemsAsync(this DiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager? gISPostgreSQLWebAPIManager, DiGi.GIS.Classes.Building2D? building2D, string? code=null, DiGi.WebAPI.Classes.PostOptions? postOptions=null);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,DiGi.GIS.Classes.Building2D,string,DiGi.WebAPI.Classes.PostOptions).gISPostgreSQLWebAPIManager'></a>

`gISPostgreSQLWebAPIManager` [GISPostgreSQLWebAPIManager](DiGi.GIS.PostgreSQL.WebAPI.Classes.md#DiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager 'DiGi\.GIS\.PostgreSQL\.WebAPI\.Classes\.GISPostgreSQLWebAPIManager')

The manager instance used to handle communication with the PostgreSQL Web API\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,DiGi.GIS.Classes.Building2D,string,DiGi.WebAPI.Classes.PostOptions).building2D'></a>

`building2D` [DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')

The [DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D') object containing the data to be updated\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,DiGi.GIS.Classes.Building2D,string,DiGi.WebAPI.Classes.PostOptions).code'></a>

`code` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

An optional identification code associated with the update request\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,DiGi.GIS.Classes.Building2D,string,DiGi.WebAPI.Classes.PostOptions).postOptions'></a>

`postOptions` [DiGi\.WebAPI\.Classes\.PostOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.postoptions 'DiGi\.WebAPI\.Classes\.PostOptions')

Optional configuration settings for the HTTP POST request\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,string,bool,bool,bool,DiGi.GIS.PostgreSQL.WebAPI.Classes.SerializableObjectsPostOptions,System.IProgress_long_,System.Nullable_System.Threading.CancellationToken_)'></a>

## Modify\.UpdateItemsAsync\(this GISPostgreSQLWebAPIManager, string, bool, bool, bool, SerializableObjectsPostOptions, IProgress\<long\>, Nullable\<CancellationToken\>\) Method

Asynchronously updates items from the specified file system path\.

```csharp
public static System.Threading.Tasks.Task<bool> UpdateItemsAsync(this DiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager? gISPostgreSQLWebAPIManager, string? path, bool oT_ADJA_A=true, bool oT_ADMS_A=true, bool oT_BUBD_A=true, DiGi.GIS.PostgreSQL.WebAPI.Classes.SerializableObjectsPostOptions? serializableObjectsPostOptions=null, System.IProgress<long>? progress=null, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,string,bool,bool,bool,DiGi.GIS.PostgreSQL.WebAPI.Classes.SerializableObjectsPostOptions,System.IProgress_long_,System.Nullable_System.Threading.CancellationToken_).gISPostgreSQLWebAPIManager'></a>

`gISPostgreSQLWebAPIManager` [GISPostgreSQLWebAPIManager](DiGi.GIS.PostgreSQL.WebAPI.Classes.md#DiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager 'DiGi\.GIS\.PostgreSQL\.WebAPI\.Classes\.GISPostgreSQLWebAPIManager')

The GIS PostgreSQL Web API manager instance\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,string,bool,bool,bool,DiGi.GIS.PostgreSQL.WebAPI.Classes.SerializableObjectsPostOptions,System.IProgress_long_,System.Nullable_System.Threading.CancellationToken_).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The file system path to the source data files\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,string,bool,bool,bool,DiGi.GIS.PostgreSQL.WebAPI.Classes.SerializableObjectsPostOptions,System.IProgress_long_,System.Nullable_System.Threading.CancellationToken_).oT_ADJA_A'></a>

`oT_ADJA_A` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Indicates whether items with the OT\_ADJA\_A suffix should be updated\. Defaults to `true`\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,string,bool,bool,bool,DiGi.GIS.PostgreSQL.WebAPI.Classes.SerializableObjectsPostOptions,System.IProgress_long_,System.Nullable_System.Threading.CancellationToken_).oT_ADMS_A'></a>

`oT_ADMS_A` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Indicates whether items with the OT\_ADMS\_A suffix should be updated\. Defaults to `true`\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,string,bool,bool,bool,DiGi.GIS.PostgreSQL.WebAPI.Classes.SerializableObjectsPostOptions,System.IProgress_long_,System.Nullable_System.Threading.CancellationToken_).oT_BUBD_A'></a>

`oT_BUBD_A` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Indicates whether items with the OT\_BUBD\_A suffix should be updated\. Defaults to `true`\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,string,bool,bool,bool,DiGi.GIS.PostgreSQL.WebAPI.Classes.SerializableObjectsPostOptions,System.IProgress_long_,System.Nullable_System.Threading.CancellationToken_).serializableObjectsPostOptions'></a>

`serializableObjectsPostOptions` [SerializableObjectsPostOptions](DiGi.GIS.PostgreSQL.WebAPI.Classes.md#DiGi.GIS.PostgreSQL.WebAPI.Classes.SerializableObjectsPostOptions 'DiGi\.GIS\.PostgreSQL\.WebAPI\.Classes\.SerializableObjectsPostOptions')

The options used for serializing objects during the POST request\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,string,bool,bool,bool,DiGi.GIS.PostgreSQL.WebAPI.Classes.SerializableObjectsPostOptions,System.IProgress_long_,System.Nullable_System.Threading.CancellationToken_).progress'></a>

`progress` [System\.IProgress&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iprogress-1 'System\.IProgress\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iprogress-1 'System\.IProgress\`1')

The progress reporter for reporting progress updates\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,string,bool,bool,bool,DiGi.GIS.PostgreSQL.WebAPI.Classes.SerializableObjectsPostOptions,System.IProgress_long_,System.Nullable_System.Threading.CancellationToken_).cancellationToken'></a>

`cancellationToken` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The cancellation token to observe\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.EPW.Classes.EPWFile_,DiGi.WebAPI.Classes.PostOptions)'></a>

## Modify\.UpdateItemsAsync\(this GISPostgreSQLWebAPIManager, IEnumerable\<EPWFile\>, PostOptions\) Method

Asynchronously updates a collection of EPW files\.

```csharp
public static System.Threading.Tasks.Task<bool> UpdateItemsAsync(this DiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager? gISPostgreSQLWebAPIManager, System.Collections.Generic.IEnumerable<DiGi.EPW.Classes.EPWFile>? ePWFiles, DiGi.WebAPI.Classes.PostOptions? postOptions=null);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.EPW.Classes.EPWFile_,DiGi.WebAPI.Classes.PostOptions).gISPostgreSQLWebAPIManager'></a>

`gISPostgreSQLWebAPIManager` [GISPostgreSQLWebAPIManager](DiGi.GIS.PostgreSQL.WebAPI.Classes.md#DiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager 'DiGi\.GIS\.PostgreSQL\.WebAPI\.Classes\.GISPostgreSQLWebAPIManager')

The GIS PostgreSQL Web API manager instance\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.EPW.Classes.EPWFile_,DiGi.WebAPI.Classes.PostOptions).ePWFiles'></a>

`ePWFiles` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.EPW\.Classes\.EPWFile](https://learn.microsoft.com/en-us/dotnet/api/digi.epw.classes.epwfile 'DiGi\.EPW\.Classes\.EPWFile')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

A collection of EPW files to update\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.EPW.Classes.EPWFile_,DiGi.WebAPI.Classes.PostOptions).postOptions'></a>

`postOptions` [DiGi\.WebAPI\.Classes\.PostOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.postoptions 'DiGi\.WebAPI\.Classes\.PostOptions')

Optional configuration options for the POST request\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_,DiGi.WebAPI.Classes.PostOptions)'></a>

## Modify\.UpdateItemsAsync\(this GISPostgreSQLWebAPIManager, IEnumerable\<AdministrativeAreal2D\>, PostOptions\) Method

Asynchronously updates a collection of administrative area items\.

```csharp
public static System.Threading.Tasks.Task<bool> UpdateItemsAsync(this DiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager? gISPostgreSQLWebAPIManager, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.AdministrativeAreal2D>? administrativeAreal2Ds, DiGi.WebAPI.Classes.PostOptions? postOptions=null);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_,DiGi.WebAPI.Classes.PostOptions).gISPostgreSQLWebAPIManager'></a>

`gISPostgreSQLWebAPIManager` [GISPostgreSQLWebAPIManager](DiGi.GIS.PostgreSQL.WebAPI.Classes.md#DiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager 'DiGi\.GIS\.PostgreSQL\.WebAPI\.Classes\.GISPostgreSQLWebAPIManager')

The GIS PostgreSQL Web API manager instance\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_,DiGi.WebAPI.Classes.PostOptions).administrativeAreal2Ds'></a>

`administrativeAreal2Ds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.AdministrativeAreal2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.administrativeareal2d 'DiGi\.GIS\.Classes\.AdministrativeAreal2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

A collection of administrative area items to update\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_,DiGi.WebAPI.Classes.PostOptions).postOptions'></a>

`postOptions` [DiGi\.WebAPI\.Classes\.PostOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.postoptions 'DiGi\.WebAPI\.Classes\.PostOptions')

Optional configuration options for the POST request\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,string,DiGi.WebAPI.Classes.PostOptions)'></a>

## Modify\.UpdateItemsAsync\(this GISPostgreSQLWebAPIManager, IEnumerable\<Building2D\>, string, PostOptions\) Method

Updates multiple 2D building items asynchronously\.

```csharp
public static System.Threading.Tasks.Task<bool> UpdateItemsAsync(this DiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager? gISPostgreSQLWebAPIManager, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.Building2D>? building2Ds, string? code=null, DiGi.WebAPI.Classes.PostOptions? postOptions=null);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,string,DiGi.WebAPI.Classes.PostOptions).gISPostgreSQLWebAPIManager'></a>

`gISPostgreSQLWebAPIManager` [GISPostgreSQLWebAPIManager](DiGi.GIS.PostgreSQL.WebAPI.Classes.md#DiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager 'DiGi\.GIS\.PostgreSQL\.WebAPI\.Classes\.GISPostgreSQLWebAPIManager')

The GIS PostgreSQL Web API manager instance\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,string,DiGi.WebAPI.Classes.PostOptions).building2Ds'></a>

`building2Ds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

A collection of [DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D') items to be updated\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,string,DiGi.WebAPI.Classes.PostOptions).code'></a>

`code` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

An optional code used for the update operation\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,string,DiGi.WebAPI.Classes.PostOptions).postOptions'></a>

`postOptions` [DiGi\.WebAPI\.Classes\.PostOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.postoptions 'DiGi\.WebAPI\.Classes\.PostOptions')

Optional configuration options for the POST request\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.OccupancyData_,DiGi.WebAPI.Classes.PostOptions)'></a>

## Modify\.UpdateItemsAsync\(this GISPostgreSQLWebAPIManager, IEnumerable\<OccupancyData\>, PostOptions\) Method

Asynchronously updates multiple occupancy data items via the PostgreSQL Web API\.

```csharp
public static System.Threading.Tasks.Task<bool> UpdateItemsAsync(this DiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager? gISPostgreSQLWebAPIManager, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.OccupancyData>? occupancyDatas, DiGi.WebAPI.Classes.PostOptions? postOptions=null);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.OccupancyData_,DiGi.WebAPI.Classes.PostOptions).gISPostgreSQLWebAPIManager'></a>

`gISPostgreSQLWebAPIManager` [GISPostgreSQLWebAPIManager](DiGi.GIS.PostgreSQL.WebAPI.Classes.md#DiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager 'DiGi\.GIS\.PostgreSQL\.WebAPI\.Classes\.GISPostgreSQLWebAPIManager')

The manager instance used to facilitate the API communication\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.OccupancyData_,DiGi.WebAPI.Classes.PostOptions).occupancyDatas'></a>

`occupancyDatas` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.OccupancyData](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.occupancydata 'DiGi\.GIS\.Classes\.OccupancyData')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of [DiGi\.GIS\.Classes\.OccupancyData](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.occupancydata 'DiGi\.GIS\.Classes\.OccupancyData') items to be updated\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.OccupancyData_,DiGi.WebAPI.Classes.PostOptions).postOptions'></a>

`postOptions` [DiGi\.WebAPI\.Classes\.PostOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.postoptions 'DiGi\.WebAPI\.Classes\.PostOptions')

Optional configuration options for the POST request\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.OccupancyData_,string,DiGi.WebAPI.Classes.PostOptions)'></a>

## Modify\.UpdateItemsAsync\(this GISPostgreSQLWebAPIManager, IEnumerable\<OccupancyData\>, string, PostOptions\) Method

Asynchronously updates multiple occupancy data items via the Web API\.

```csharp
public static System.Threading.Tasks.Task<bool> UpdateItemsAsync(this DiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager? gISPostgreSQLWebAPIManager, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.OccupancyData>? occupancyDatas, string? code=null, DiGi.WebAPI.Classes.PostOptions? postOptions=null);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.OccupancyData_,string,DiGi.WebAPI.Classes.PostOptions).gISPostgreSQLWebAPIManager'></a>

`gISPostgreSQLWebAPIManager` [GISPostgreSQLWebAPIManager](DiGi.GIS.PostgreSQL.WebAPI.Classes.md#DiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager 'DiGi\.GIS\.PostgreSQL\.WebAPI\.Classes\.GISPostgreSQLWebAPIManager')

The [GISPostgreSQLWebAPIManager](DiGi.GIS.PostgreSQL.WebAPI.Classes.md#DiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager 'DiGi\.GIS\.PostgreSQL\.WebAPI\.Classes\.GISPostgreSQLWebAPIManager') instance used to create the HTTP client for the request\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.OccupancyData_,string,DiGi.WebAPI.Classes.PostOptions).occupancyDatas'></a>

`occupancyDatas` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.OccupancyData](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.occupancydata 'DiGi\.GIS\.Classes\.OccupancyData')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

A collection of [DiGi\.GIS\.Classes\.OccupancyData](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.occupancydata 'DiGi\.GIS\.Classes\.OccupancyData') items to be updated\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.OccupancyData_,string,DiGi.WebAPI.Classes.PostOptions).code'></a>

`code` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

An optional code associated with the update operation\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.OccupancyData_,string,DiGi.WebAPI.Classes.PostOptions).postOptions'></a>

`postOptions` [DiGi\.WebAPI\.Classes\.PostOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.postoptions 'DiGi\.WebAPI\.Classes\.PostOptions')

Optional configuration settings for the HTTP POST request\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.OrtoDatas_,int,DiGi.WebAPI.Classes.PostOptions)'></a>

## Modify\.UpdateItemsAsync\(this GISPostgreSQLWebAPIManager, IEnumerable\<OrtoDatas\>, int, PostOptions\) Method

Updates multiple ortho data items for a specific county\.

```csharp
public static System.Threading.Tasks.Task<bool> UpdateItemsAsync(this DiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager? gISPostgreSQLWebAPIManager, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.OrtoDatas>? ortoDatas, int countyId, DiGi.WebAPI.Classes.PostOptions? postOptions=null);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.OrtoDatas_,int,DiGi.WebAPI.Classes.PostOptions).gISPostgreSQLWebAPIManager'></a>

`gISPostgreSQLWebAPIManager` [GISPostgreSQLWebAPIManager](DiGi.GIS.PostgreSQL.WebAPI.Classes.md#DiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager 'DiGi\.GIS\.PostgreSQL\.WebAPI\.Classes\.GISPostgreSQLWebAPIManager')

The [GISPostgreSQLWebAPIManager](DiGi.GIS.PostgreSQL.WebAPI.Classes.md#DiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager 'DiGi\.GIS\.PostgreSQL\.WebAPI\.Classes\.GISPostgreSQLWebAPIManager') instance used to perform the update operation\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.OrtoDatas_,int,DiGi.WebAPI.Classes.PostOptions).ortoDatas'></a>

`ortoDatas` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.OrtoDatas](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.ortodatas 'DiGi\.GIS\.Classes\.OrtoDatas')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of [DiGi\.GIS\.Classes\.OrtoDatas](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.ortodatas 'DiGi\.GIS\.Classes\.OrtoDatas') items to be updated\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.OrtoDatas_,int,DiGi.WebAPI.Classes.PostOptions).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The unique identifier of the county for which the items are being updated\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.OrtoDatas_,int,DiGi.WebAPI.Classes.PostOptions).postOptions'></a>

`postOptions` [DiGi\.WebAPI\.Classes\.PostOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.postoptions 'DiGi\.WebAPI\.Classes\.PostOptions')

Optional configuration options for the HTTP POST request\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.OrtoDatas_,string,DiGi.WebAPI.Classes.PostOptions)'></a>

## Modify\.UpdateItemsAsync\(this GISPostgreSQLWebAPIManager, IEnumerable\<OrtoDatas\>, string, PostOptions\) Method

Asynchronously updates multiple ortho data items via the PostgreSQL Web API\.

```csharp
public static System.Threading.Tasks.Task<bool> UpdateItemsAsync(this DiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager? gISPostgreSQLWebAPIManager, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.OrtoDatas>? ortoDatas, string? code=null, DiGi.WebAPI.Classes.PostOptions? postOptions=null);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.OrtoDatas_,string,DiGi.WebAPI.Classes.PostOptions).gISPostgreSQLWebAPIManager'></a>

`gISPostgreSQLWebAPIManager` [GISPostgreSQLWebAPIManager](DiGi.GIS.PostgreSQL.WebAPI.Classes.md#DiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager 'DiGi\.GIS\.PostgreSQL\.WebAPI\.Classes\.GISPostgreSQLWebAPIManager')

The [GISPostgreSQLWebAPIManager](DiGi.GIS.PostgreSQL.WebAPI.Classes.md#DiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager 'DiGi\.GIS\.PostgreSQL\.WebAPI\.Classes\.GISPostgreSQLWebAPIManager') instance used to perform the update operation\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.OrtoDatas_,string,DiGi.WebAPI.Classes.PostOptions).ortoDatas'></a>

`ortoDatas` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.OrtoDatas](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.ortodatas 'DiGi\.GIS\.Classes\.OrtoDatas')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

A collection of [DiGi\.GIS\.Classes\.OrtoDatas](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.ortodatas 'DiGi\.GIS\.Classes\.OrtoDatas') items to be updated\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.OrtoDatas_,string,DiGi.WebAPI.Classes.PostOptions).code'></a>

`code` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

An optional code used to identify or filter the items for updating\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.OrtoDatas_,string,DiGi.WebAPI.Classes.PostOptions).postOptions'></a>

`postOptions` [DiGi\.WebAPI\.Classes\.PostOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.postoptions 'DiGi\.WebAPI\.Classes\.PostOptions')

Optional configuration options for the update request\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.YearBuiltData_,string,DiGi.WebAPI.Classes.PostOptions)'></a>

## Modify\.UpdateItemsAsync\(this GISPostgreSQLWebAPIManager, IEnumerable\<YearBuiltData\>, string, PostOptions\) Method

Asynchronously updates multiple year built data items via the PostgreSQL Web API\.

```csharp
public static System.Threading.Tasks.Task<bool> UpdateItemsAsync(this DiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager? gISPostgreSQLWebAPIManager, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.YearBuiltData>? yearBuiltDatas, string? code=null, DiGi.WebAPI.Classes.PostOptions? postOptions=null);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.YearBuiltData_,string,DiGi.WebAPI.Classes.PostOptions).gISPostgreSQLWebAPIManager'></a>

`gISPostgreSQLWebAPIManager` [GISPostgreSQLWebAPIManager](DiGi.GIS.PostgreSQL.WebAPI.Classes.md#DiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager 'DiGi\.GIS\.PostgreSQL\.WebAPI\.Classes\.GISPostgreSQLWebAPIManager')

The manager instance used to facilitate the web API communication\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.YearBuiltData_,string,DiGi.WebAPI.Classes.PostOptions).yearBuiltDatas'></a>

`yearBuiltDatas` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.YearBuiltData](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.yearbuiltdata 'DiGi\.GIS\.Classes\.YearBuiltData')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

A collection of [DiGi\.GIS\.Classes\.YearBuiltData](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.yearbuiltdata 'DiGi\.GIS\.Classes\.YearBuiltData') objects to be updated\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.YearBuiltData_,string,DiGi.WebAPI.Classes.PostOptions).code'></a>

`code` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

An optional code identifier for the update request\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisDiGi.GIS.PostgreSQL.WebAPI.Classes.GISPostgreSQLWebAPIManager,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.YearBuiltData_,string,DiGi.WebAPI.Classes.PostOptions).postOptions'></a>

`postOptions` [DiGi\.WebAPI\.Classes\.PostOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.postoptions 'DiGi\.WebAPI\.Classes\.PostOptions')

Optional configuration options for the POST request\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisSystem.Net.Http.HttpClient,string,string,DiGi.WebAPI.Classes.PostOptions)'></a>

## Modify\.UpdateItemsAsync\(this HttpClient, string, string, PostOptions\) Method

Asynchronously updates items by sending a JSON payload to the specified request URI\.

```csharp
public static System.Threading.Tasks.Task<bool> UpdateItemsAsync(this System.Net.Http.HttpClient httpClient, string? requestUri, string? json, DiGi.WebAPI.Classes.PostOptions? postOptions=null);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisSystem.Net.Http.HttpClient,string,string,DiGi.WebAPI.Classes.PostOptions).httpClient'></a>

`httpClient` [System\.Net\.Http\.HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient 'System\.Net\.Http\.HttpClient')

The [System\.Net\.Http\.HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient 'System\.Net\.Http\.HttpClient') used to perform the network request\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisSystem.Net.Http.HttpClient,string,string,DiGi.WebAPI.Classes.PostOptions).requestUri'></a>

`requestUri` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The target URI where the update request is sent\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisSystem.Net.Http.HttpClient,string,string,DiGi.WebAPI.Classes.PostOptions).json'></a>

`json` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The JSON string containing the data to be updated\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.UpdateItemsAsync(thisSystem.Net.Http.HttpClient,string,string,DiGi.WebAPI.Classes.PostOptions).postOptions'></a>

`postOptions` [DiGi\.WebAPI\.Classes\.PostOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.postoptions 'DiGi\.WebAPI\.Classes\.PostOptions')

Optional [DiGi\.WebAPI\.Classes\.PostOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.postoptions 'DiGi\.WebAPI\.Classes\.PostOptions') used to configure the operation, such as specifying a delay\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.Update_Id(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.Building2DReference_)'></a>

## Modify\.Update\_Id\(this Table, IEnumerable\<Building2DReference\>\) Method

Updates the Id column of the table based on the provided building2DReferences\. If a matching row is found \(based on CountyId and Reference\), it updates the Id value\. If no matching row is found, it adds a new row with the CountyId, Reference, and Id values\.

```csharp
public static void Update_Id(this DiGi.Core.IO.Table.Classes.Table? table, System.Collections.Generic.IEnumerable<DiGi.GIS.PostgreSQL.Classes.Building2DReference>? building2DReferences);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.Update_Id(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.Building2DReference_).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table to update

<a name='DiGi.GIS.PostgreSQL.WebAPI.Modify.Update_Id(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.Building2DReference_).building2DReferences'></a>

`building2DReferences` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.PostgreSQL\.Classes\.Building2DReference](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.building2dreference 'DiGi\.GIS\.PostgreSQL\.Classes\.Building2DReference')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The building2DReferences to use for updating